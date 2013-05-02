using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EntrecineWebApp.Models;

namespace EntrecineWebApp.Controllers
{
    public class RecomendacionesController : Controller
    {
        //
        // GET: /Recomendaciones/

        public ActionResult Index()
        {
            EntrecineModelContainer db = new EntrecineModelContainer();
            Func<Pelicula, int> numeroVistas = pelicula =>
            {

                return db.ReservaConjunto.Select(r => r.Sesion.Pelicula.Id == pelicula.Id).Count();
            };
            return View(db.PeliculaConjunto.OrderBy(numeroVistas).Take(3).ToList());
        }

    }
}
