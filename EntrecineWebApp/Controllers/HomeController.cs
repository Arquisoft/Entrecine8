using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EntrecineWebApp.Models;
using EntrecineWebApp.Views.Shared;

namespace EntrecineWebApp.Controllers {

    public class HomeController : Controller {

        public ActionResult Index() {
            EntrecineModelContainer db = new EntrecineModelContainer();
            List<Pelicula> peliculas = db.PeliculaConjunto.OrderByDescending(x => x.Id).Take(4).ToList();
            peliculas.Shuffle();
            return View(peliculas);
        }

    }
}