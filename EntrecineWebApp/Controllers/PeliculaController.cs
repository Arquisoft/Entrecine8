using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EntrecineWebApp.Models;

namespace EntrecineWebApp.Controllers
{
    public class PeliculaController : Controller
    {
        private EntrecineModelContainer db = new EntrecineModelContainer();

        //
        // GET: /Pelicula/

        public ActionResult Index()
        {
            return View(db.PeliculaConjunto.ToList());
        }

        //
        // GET: /Pelicula/Details/5

        public ActionResult Details(int id = 0)
        {
            Pelicula pelicula = db.PeliculaConjunto.Find(id);
            if (pelicula == null)
            {
                return HttpNotFound();
            }
            return View(pelicula);
        }

        //
        // GET: /Pelicula/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Pelicula/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Pelicula pelicula)
        {
            if (ModelState.IsValid)
            {
                db.PeliculaConjunto.Add(pelicula);
                db.SaveChanges();

                if (pelicula.Caratula != null && pelicula.Caratula.ContentLength > 0)
                {
                    var filename = "caratula_" + pelicula.Id + ".jpg";
                    var path = Path.Combine(Server.MapPath("~/Images/Caratulas"), filename);
                    pelicula.Caratula.SaveAs(path);
                }

                return RedirectToAction("Index","Home");
            }

            return View(pelicula);
        }

        //
        // GET: /Pelicula/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Pelicula pelicula = db.PeliculaConjunto.Find(id);
            if (pelicula == null)
            {
                return HttpNotFound();
            }
            return View(pelicula);
        }

        //
        // POST: /Pelicula/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Pelicula pelicula)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pelicula).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pelicula);
        }

        //
        // GET: /Pelicula/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Pelicula pelicula = db.PeliculaConjunto.Find(id);
            if (pelicula == null)
            {
                return HttpNotFound();
            }
            return View(pelicula);
        }

        //
        // POST: /Pelicula/Delete/5

        [HttpPost, ActionName("Delete")]
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