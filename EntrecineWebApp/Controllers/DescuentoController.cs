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
    public class DescuentoController : Controller
    {
        private EntrecineModelContainer db = new EntrecineModelContainer();

        //
        // GET: /Descuento/
        public ActionResult Index()
        {
            return Seguridad.ComprobarAdministrador(db, User.Identity.Name, View(db.DescuentoConjunto.ToList()), RedirectToAction("Index", "Home"));
        }

        //
        // GET: /Descuento/Crear
        public ActionResult Crear()
        {
            return Seguridad.ComprobarAdministrador(db, User.Identity.Name, View(), RedirectToAction("Index", "Home"));
        }

        //
        // POST: /Descuento/Crear
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Crear(Descuento descuento)
        {
            if (ModelState.IsValid)
            {
                db.DescuentoConjunto.Add(descuento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(descuento);
        }

        //
        // GET: /Descuento/Edit/5
        public ActionResult Editar(int id = 0)
        {
            Descuento descuento = db.DescuentoConjunto.Find(id);
            if (descuento == null)
            {
                return HttpNotFound();
            }
            return Seguridad.ComprobarAdministrador(db, User.Identity.Name, View(descuento), RedirectToAction("Index", "Home"));
        }

        //
        // POST: /Descuento/Editar/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(Descuento descuento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(descuento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(descuento);
        }

        //
        // GET: /Descuento/Borrar/5
        public ActionResult Borrar(int id = 0)
        {
            Descuento descuento = db.DescuentoConjunto.Find(id);
            if (descuento == null)
            {
                return HttpNotFound();
            }
            return Seguridad.ComprobarAdministrador(db, User.Identity.Name, View(descuento), RedirectToAction("Index", "Home"));
        }

        //
        // POST: /Descuento/Borrar/5
        [HttpPost, ActionName("Borrar")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Descuento descuento = db.DescuentoConjunto.Find(id);
            db.DescuentoConjunto.Remove(descuento);
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