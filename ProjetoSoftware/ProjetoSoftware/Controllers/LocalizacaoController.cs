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


            ViewBag.ListarDropdown = db.Naufragos.Distinct().ToList();
                
            return View();
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