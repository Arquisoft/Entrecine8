
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

        public IEnumerable<Pelicula> Recomendaciones(String nombre)
        {
            EntrecineModelContainer db = new EntrecineModelContainer();
            Usuario cliente = db.UsuarioConjunto.First(u => u.Nombre == nombre);
            Func<Usuario, IEnumerable<Pelicula>> pelisQueVio = usuario => db.ReservaConjunto.Where(r => r.Usuario.Id == usuario.Id).Select(r => r.Sesion.Pelicula);
            Func<Usuario, int> nPelisEnComun = usuario =>   pelisQueVio(usuario).Intersect(pelisQueVio(cliente)).Count();
            IEnumerable<Pelicula> recomendaciones = pelisQueVio(db.UsuarioConjunto.Where(u=>u.Id!=cliente.Id).OrderByDescending(nPelisEnComun).First()).Where(p=>!pelisQueVio(cliente).Contains(p));
            return recomendaciones;
        }



    }
}