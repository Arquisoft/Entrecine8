
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

        [Display(Name = "Veces Vista")]
        public Func<Pelicula, int> VecesVista = pelicula =>
        {
            return new EntrecineModelContainer().ReservaConjunto.Where(r => r.Sesion.Pelicula.Id == pelicula.Id).Count();

        };
        [Display(Name = "Más Vistas")]
        public IList<Pelicula> PelisMasVistas { get { return new EntrecineModelContainer().PeliculaConjunto.OrderByDescending(VecesVista).Take(3).ToList(); } }

        public IEnumerable<Pelicula> Recomendaciones(String nombre, int grado)
        {
            EntrecineModelContainer db = new EntrecineModelContainer();
            Usuario cliente = db.UsuarioConjunto.First(u => u.Nombre == nombre);
            Func<Usuario, IEnumerable<Pelicula>> pelisQueVio = usuario => db.ReservaConjunto.Where(r => r.Usuario.Id == usuario.Id).Select(r => r.Sesion.Pelicula);
            Func<Usuario, int> nPelisEnComun = usuario => pelisQueVio(usuario).Intersect(pelisQueVio(cliente)).Count();
            int i = -1;
            IEnumerable<Usuario> usuariosPosiblesOrdenados = db.UsuarioConjunto.Where(u => u.Id != cliente.Id).OrderByDescending(nPelisEnComun).TakeWhile(u => { i++; return grado > i; });
            if (usuariosPosiblesOrdenados.Count() == 0)
            {
                List<Pelicula> noMencionadas = new List<Pelicula>();
                IEnumerable<int> mencionadas = pelisQueVio(cliente).Union(PelisMasVistas).Select(p => p.Id);
                foreach (Pelicula p in db.PeliculaConjunto)
                    if (!mencionadas.Contains(p.Id))
                        noMencionadas.Add(p);
                return noMencionadas.OrderBy(VecesVista);

            }
            IEnumerable<Pelicula> recomendaciones = pelisQueVio(usuariosPosiblesOrdenados.First()).Where(p => !pelisQueVio(cliente).Contains(p));

            return recomendaciones.Count() == 0 ? Recomendaciones(nombre, grado + 1) : recomendaciones;
        }

        public IEnumerable<Pelicula> Recomendaciones(String nombre)
        {
            return Recomendaciones(nombre, 0);
        }

    }
}