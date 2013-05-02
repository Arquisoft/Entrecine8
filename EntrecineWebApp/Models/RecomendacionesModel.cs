
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.ComponentModel.DataAnnotations;
namespace EntrecineWebApp.Models
{
    public class RecomendacionesModel : Controller
    {

        [Display(Name = "VecesVista")]
        public Func<Pelicula, int> VecesVista = pelicula =>
        {
            return new EntrecineModelContainer().ReservaConjunto.Where(r => r.Sesion.Pelicula.Id == pelicula.Id).Count();

        };
        [Display(Name = "MasVistas")]
        public IList<Pelicula> PelisMasVistas { get { return new EntrecineModelContainer().PeliculaConjunto.OrderByDescending(VecesVista).Take(3).ToList(); } }


    }
}