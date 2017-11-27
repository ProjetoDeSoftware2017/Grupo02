using ProjetoSoftware.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace ProjetoSoftware.Controllers
{
    public class LocalizacaoController : Controller
    {
        private Contexto db = new Contexto();
        // GET: Localizacao
        [OutputCache(Duration = 60)]
        public ActionResult Index()
        {
            //List<Naufragos> list = new List<Naufragos>();
            var UnitLst = new List<String>();

            var UnitQuery = from d in db.Naufragos orderby d.Estado select d.Estado;

            UnitLst.AddRange(UnitQuery.Distinct());
            ViewBag.ListarDropdown = new SelectList(UnitLst);
                
            return View(db.Naufragos.ToList());
        }

        public ActionResult PegaLocalizacao(string outUnit, string address)
        {
            var UnitLst = new List<string>();

            var UnitQry = from d in db.Naufragos orderby d.Nome select d.Nome;

            UnitLst.AddRange(UnitQry.Distinct());
            ViewBag.outUnit = new SelectList(UnitLst);

            string searchUnit = null;
            searchUnit = (from s in db.Naufragos where s.Latitude.Contains(address) select s.Estado).FirstOrDefault();

            if (!string.IsNullOrEmpty(outUnit))
            {
                var result = from s in db.Naufragos where s.Latitude.Contains(outUnit) select s;
                return View("Index", result.ToList());
            }
            if (!String.IsNullOrEmpty(searchUnit))
            {
                var result = from s in db.Naufragos where s.Latitude.Contains(address) select s;
                return View("Index", result.ToList());
            }
            else
            {
                //return View("Index", db.MapInfo.ToList());
                return View("Index", new List<Models.Naufragos>());
            }
        }

        public JsonResult PegarLocalizcaoPorId(int id)
        {
            var data = db.Naufragos.Where(x => x.IdNaufrago == id).SingleOrDefault();
            return Json(data,JsonRequestBehavior.AllowGet);
        }

        public ActionResult Data()
        {
            var dados =(from n in db.Naufragos select new {
                n.IdNaufrago,
                n.Nome,
                n.Latitude,
                n.Longitude,
                n.Estado
            });

            return Json(dados, JsonRequestBehavior.AllowGet);
        }
    }
}