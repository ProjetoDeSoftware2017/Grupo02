using ProjetoSoftware.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoSoftware.Controllers
{
    public class LocalizacaoController : Controller
    {
        private Contexto db = new Contexto();
        // GET: Localizacao
        public ActionResult Index()
        {
            //List<Naufragos> list = new List<Naufragos>();
            var UnitLst = new List<String>();

            var UnitQuery = from d in db.Naufragos orderby d.Estado select d.Estado;

            UnitLst.AddRange(UnitQuery.Distinct());
            ViewBag.ListarDropdown = new SelectList(UnitLst);
                
            return View(db.Naufragos.ToList());
        }

        public JsonResult PegaLocalizacao()
        {
            var data = db.Naufragos.ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public JsonResult PegarLocalizcaoPorId(int id)
        {
            var data = db.Naufragos.Where(x => x.IdNaufrago == id).SingleOrDefault();
            return Json(data,JsonRequestBehavior.AllowGet);
        }
    }
}