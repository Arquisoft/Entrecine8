using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EntrecineWebApp.Models;

namespace EntrecineWebApp.Controllers
{
    public class AdminController : Controller
    {
        private EntrecineModelContainer db = new EntrecineModelContainer();

        //
        // GET: /Admin/

        public ActionResult Index()
        {
            return View(db.PeliculaConjunto.ToList());
        }

        //
        // GET: /Admin/Detalles/5

        public ActionResult Detalles(int id = 0)
        {
            Pelicula pelicula = db.PeliculaConjunto.Find(id);
            if (pelicula == null)
            {
                return HttpNotFound();
            }
            return View(pelicula);
        }

        //
        // GET: /Admin/Crear

        public ActionResult Crear()
        {
            return View();
        }

        //
        // POST: /Admin/Crear

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Crear(Pelicula pelicula)
        {
            if (ModelState.IsValid)
            {
                db.PeliculaConjunto.Add(pelicula);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pelicula);
        }

        //
        // GET: /Admin/Editar/5

        public ActionResult Editar()
        {
            return View(db.PeliculaConjunto.ToList());
        }

        public ActionResult EditarSesiones()
        {
            return View(db.SesionConjunto.ToList());
        }

        //
        // POST: /Admin/Editar/5
/*
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(Pelicula pelicula)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pelicula).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pelicula);
        }
*/
        //
        // GET: /Admin/Borrar/5

        public ActionResult Borrar(int id = 0)
        {
            Pelicula pelicula = db.PeliculaConjunto.Find(id);
            if (pelicula == null)
            {
                return HttpNotFound();
            }
            return View(pelicula);
        }

        //
        // POST: /Admin/Borrar/5

        [HttpPost, ActionName("Borrar")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pelicula pelicula = db.PeliculaConjunto.Find(id);
            db.PeliculaConjunto.Remove(pelicula);
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