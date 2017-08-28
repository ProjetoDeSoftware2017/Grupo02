using ProjetoSoftware.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoSoftware.Controllers
{
    public class LongitudeController : Controller
    {
        private Contexto db = new Contexto();

        // GET: Longitude
        public ActionResult Index()
        {
            var mostra = db.Longitude.OrderBy(p => p.Nome);
            return View(mostra);
        }

        // GET: Longitude/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Longitude/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Longitude/Create
        [HttpPost]
        public ActionResult Create(Longitude longitude)
        {
            try
            {
                // TODO: Add insert logic here
                db.Longitude.Add(longitude);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Longitude/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Longitude/Edit/5
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

        // GET: Longitude/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Longitude/Delete/5
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
