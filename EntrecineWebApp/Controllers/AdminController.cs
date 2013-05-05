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
    public class AdminController : Controller
    {
        private EntrecineModelContainer db = new EntrecineModelContainer();

        //
        // GET: /Admin/

        public ActionResult Index()
        {
            return Seguridad.ComprobarAdministrador(db, User.Identity.Name, View(db.PeliculaConjunto.ToList()),RedirectToAction("Index", "Home"));
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}