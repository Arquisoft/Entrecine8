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
    public class DescuentoController : Controller
    {
        private EntrecineModelContainer db = new EntrecineModelContainer();

        //
        // GET: /Descuento/

        public ActionResult Index()
        {
            return View(db.DescuentoConjunto.ToList());
        }

        //
        // GET: /Descuento/Create

        public ActionResult Create()
        {
            return ComprobarUsuario(View(), RedirectToAction("Index", "Home"));
        }

        //
        // POST: /Descuento/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Descuento descuento)
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

        public ActionResult Edit(int id = 0)
        {
            Descuento descuento = db.DescuentoConjunto.Find(id);
            if (descuento == null)
            {
                return HttpNotFound();
            }
            return ComprobarUsuario(View(descuento), RedirectToAction("Index", "Home"));
        }

        //
        // POST: /Descuento/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Descuento descuento)
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
        // GET: /Descuento/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Descuento descuento = db.DescuentoConjunto.Find(id);
            if (descuento == null)
            {
                return HttpNotFound();
            }
            return ComprobarUsuario(View(descuento), RedirectToAction("Index", "Home"));
        }

        //
        // POST: /Descuento/Delete/5

        [HttpPost, ActionName("Delete")]
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

        protected ActionResult ComprobarUsuario(ActionResult privilegiado, ActionResult erroneo)
        {
            Usuario user = db.UsuarioConjunto.FirstOrDefault(x => x.Login.Equals(User.Identity.Name));
            if (user != null && user.Rol >= 2)
                return privilegiado;
            else
                return erroneo;
        }
    }
}