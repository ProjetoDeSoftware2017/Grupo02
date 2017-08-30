﻿using ProjetoSoftware.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
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
            var listar = db.Naufragos.OrderBy(n => n.Nome);

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
        public ActionResult Edit(int ? id)
        {
            Naufragos naufrago = db.Naufragos.Find(id);
            if (naufrago == null)
            {
                return HttpNotFound();
            }
            return View(naufrago);
        }

        // POST: Naufragos/Edit/5
        [HttpPost]
        public ActionResult Edit(Naufragos naufrago)
        {
            if (ModelState.IsValid)
            {
                db.Entry(naufrago).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(naufrago);
        }

        // GET: Naufragos/Delete/5
        public ActionResult Delete(int id)
        {
            var naufragio = db.Naufragos.Find(id);
            return View(naufragio);
        }

        // POST: Naufragos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                Naufragos naufragos = db.Naufragos.Find(id);
                db.Naufragos.Remove(naufragos);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
