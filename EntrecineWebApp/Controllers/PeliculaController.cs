using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EntrecineWebApp.Models;
using EntrecineWebApp.Shared;

namespace EntrecineWebApp.Controllers
{
    public class PeliculaController : Controller
    {
        private EntrecineModelContainer db = new EntrecineModelContainer();

        //
        // GET: /Pelicula/Cartelera
        public ActionResult Cartelera()
        {
            return View(db.PeliculaConjunto.ToList());
        }

        //
        // GET: /Pelicula/Detalles/5
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
        // GET: /Pelicula/
        public ActionResult Index()
        {
            return Seguridad.ComprobarAdministrador(db, User.Identity.Name, View(db.PeliculaConjunto.ToList()), RedirectToAction("Index", "Home"));
        }

        //
        // GET: /Pelicula/Crear
        public ActionResult Crear()
        {
            return Seguridad.ComprobarAdministrador(db, User.Identity.Name, View(), RedirectToAction("Index", "Home"));
            
        }

        //
        // POST: /Pelicula/Crear
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Crear(Pelicula pelicula)
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
        // GET: /Pelicula/Editar/5
        public ActionResult Editar(int id = 0)
        {
            Pelicula pelicula = db.PeliculaConjunto.Find(id);
            if (pelicula == null)
            {
                return HttpNotFound();
            }
            return Seguridad.ComprobarAdministrador(db, User.Identity.Name, View(pelicula), RedirectToAction("Index", "Home"));
        }

        //
        // POST: /Pelicula/Editar/5
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

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

    }
}