﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EntrecineWebApp.Models;

namespace EntrecineWebApp.Controllers
{
    public class SesionController : Controller
    {
        private EntrecineModelContainer db = new EntrecineModelContainer();

        //
        // GET: /Sesion/

        public ActionResult Index()
        {
            var sesionconjunto = db.SesionConjunto.Include(s => s.Descuento).Include(s => s.Pelicula).Include(s => s.Sala);
            return View(sesionconjunto.ToList());
        }

        //
        // GET: /Sesion/Details/5

        public ActionResult Details(int id = 0)
        {
            Sesion sesion = db.SesionConjunto.Find(id);
            if (sesion == null)
            {
                return HttpNotFound();
            }
            return View(sesion);
        }

        //
        // GET: /Sesion/Create

        public ActionResult Create()
        {
            ViewBag.DescuentoId = new SelectList(db.DescuentoConjunto, "Id", "Nombre");
            ViewBag.PeliculaId = new SelectList(db.PeliculaConjunto, "Id", "Nombre");
            ViewBag.SalaId = new SelectList(db.SalaConjunto, "Id", "Id");
            return View();
        }

        //
        // POST: /Sesion/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Sesion sesion)
        {
            if (ModelState.IsValid)
            {
                db.SesionConjunto.Add(sesion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DescuentoId = new SelectList(db.DescuentoConjunto, "Id", "Nombre", sesion.DescuentoId);
            ViewBag.PeliculaId = new SelectList(db.PeliculaConjunto, "Id", "Nombre", sesion.PeliculaId);
            ViewBag.SalaId = new SelectList(db.SalaConjunto, "Id", "Id", sesion.SalaId);
            return View(sesion);
        }

        //
        // GET: /Sesion/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Sesion sesion = db.SesionConjunto.Find(id);
            if (sesion == null)
            {
                return HttpNotFound();
            }
            ViewBag.DescuentoId = new SelectList(db.DescuentoConjunto, "Id", "Nombre", sesion.DescuentoId);
            ViewBag.PeliculaId = new SelectList(db.PeliculaConjunto, "Id", "Nombre", sesion.PeliculaId);
            ViewBag.SalaId = new SelectList(db.SalaConjunto, "Id", "Id", sesion.SalaId);
            return View(sesion);
        }

        //
        // POST: /Sesion/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Sesion sesion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sesion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DescuentoId = new SelectList(db.DescuentoConjunto, "Id", "Nombre", sesion.DescuentoId);
            ViewBag.PeliculaId = new SelectList(db.PeliculaConjunto, "Id", "Nombre", sesion.PeliculaId);
            ViewBag.SalaId = new SelectList(db.SalaConjunto, "Id", "Id", sesion.SalaId);
            return View(sesion);
        }

        //
        // GET: /Sesion/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Sesion sesion = db.SesionConjunto.Find(id);
            if (sesion == null)
            {
                return HttpNotFound();
            }
            return View(sesion);
        }

        //
        // POST: /Sesion/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sesion sesion = db.SesionConjunto.Find(id);
            db.SesionConjunto.Remove(sesion);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}