using ProjetoSoftware.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoSoftware.Controllers
{
    public class NaufragoController : Controller
    {
        private Contexto db = new Contexto();
        // GET: Naufrago
        public ActionResult Index()
        {
            
            return View();
        }

        // GET: Naufrago/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Naufrago/Create
        public ActionResult Create()
        {
            

            return View();
        }

        // POST: Naufrago/Create
        [HttpPost]
        public ActionResult Create(Naufrago naufrago)
        {
            try
            {
                db.Naufrago.Add(naufrago);
                db.SaveChanges();
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Naufrago/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Naufrago/Edit/5
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

        // GET: Naufrago/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Naufrago/Delete/5
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
