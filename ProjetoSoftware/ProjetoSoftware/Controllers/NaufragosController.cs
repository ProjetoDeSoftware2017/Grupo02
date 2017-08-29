using ProjetoSoftware.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoSoftware.Controllers
{
    public class NaufragosController : Controller
    {
        private Contexto db = new Contexto();
        // GET: Naufragos
        public ActionResult Index()
        {
            var listar = db.Naufragos.OrderBy(n => n.Estado);

            return View(listar.ToList());
        }

        // GET: Naufragos/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Naufragos/Create
        public ActionResult Create()
        {
            

            return View();
        }

        // POST: Naufragos/Create
        [HttpPost]
        public ActionResult Create(Naufragos Naufragos)
        {
            try
            {
                db.Naufragos.Add(Naufragos);
                db.SaveChanges();
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Naufragos/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Naufragos/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Naufragos/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Naufragos/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
