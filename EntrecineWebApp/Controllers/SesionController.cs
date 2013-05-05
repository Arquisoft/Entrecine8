using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EntrecineWebApp.Models;
using EntrecineWebApp.Shared;

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

            return Seguridad.ComprobarAdministrador(db, User.Identity.Name, View(sesionconjunto.ToList()), RedirectToAction("Index", "Home"));
        }


        //
        // GET: /Sesion/Crear
        public ActionResult Crear()
        {

            ViewBag.DescuentoId = new SelectList(db.DescuentoConjunto, "Id", "Nombre");
            ViewBag.PeliculaId = new SelectList(db.PeliculaConjunto, "Id", "Nombre");
            ViewBag.SalaId = new SelectList(db.SalaConjunto, "Id", "Id");

            return Seguridad.ComprobarAdministrador(db, User.Identity.Name, View(), RedirectToAction("Index", "Home"));            
        }

        //
        // POST: /Sesion/Crear
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Crear(Sesion sesion)
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
        // GET: /Sesion/Editar/5
        public ActionResult Editar(int id = 0)
        {
            Sesion sesion = db.SesionConjunto.Find(id);
            if (sesion == null)
            {
                return HttpNotFound();
            }

            ViewBag.DescuentoId = new SelectList(db.DescuentoConjunto, "Id", "Nombre", sesion.DescuentoId);
            ViewBag.PeliculaId = new SelectList(db.PeliculaConjunto, "Id", "Nombre", sesion.PeliculaId);
            ViewBag.SalaId = new SelectList(db.SalaConjunto, "Id", "Id", sesion.SalaId);
            
            return Seguridad.ComprobarAdministrador(db, User.Identity.Name, View(sesion), RedirectToAction("Index", "Home"));
        }

        //
        // POST: /Sesion/Editar/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(Sesion sesion)
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
        // GET: /Sesion/Borrar/5
        public ActionResult Borrar(int id = 0)
        {
            Sesion sesion = db.SesionConjunto.Find(id);
            
            if (sesion == null)
            {
                return HttpNotFound();
            }

            return Seguridad.ComprobarAdministrador(db, User.Identity.Name,View(sesion), RedirectToAction("Index", "Home"));
        }

        //
        // POST: /Sesion/Borrar/5
        [HttpPost, ActionName("Borrar")]
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