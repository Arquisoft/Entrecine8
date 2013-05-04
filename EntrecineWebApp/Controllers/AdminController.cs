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
            return ComprobarUsuario(View(db.PeliculaConjunto.ToList()),RedirectToAction("Index", "Home"));
        }


        //
        // GET: /Admin/Editar/5

        public ActionResult Editar()
        {
            return View(db.PeliculaConjunto.ToList());
        }

        public ActionResult EditarSesiones()
        {
            return ComprobarUsuario(View(db.SesionConjunto.ToList()), RedirectToAction("Index", "Home"));
        }

        public ActionResult EditarDescuentos()
        {
            return ComprobarUsuario(View(db.DescuentoConjunto.ToList()), RedirectToAction("Index", "Home"));
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