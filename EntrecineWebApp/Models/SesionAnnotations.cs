using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace EntrecineWebApp.Models
{
    [MetadataType(typeof(SesionAnnotations))]
    public partial class Sesion
    {
        [Display(Name="Precio final")]
        public double PrecioCalculado
        {
            get
            {
                if (Pelicula != null && Descuento != null)
                    return Pelicula.Precio - (Pelicula.Precio * Descuento.Porcentaje/100);
                else
                    return 0;
            }
        }

        [Display(Name = "Hora fin")]
        public DateTime HoraFin
        {
            get
            {
                if (Pelicula != null && Fecha != null)
                    return Fecha.AddMinutes(Pelicula.Duracion);
                else 
                    return DateTime.Now;
            }
        }
    }

    public class SesionAnnotations
    {

        public int Id { get; set; }

        [Required(ErrorMessage="Fecha imprescindible")]
        [DataType(DataType.DateTime)]
        [DisplayName("Fecha y hora")]
        public DateTime Fecha { get; set; }

        [Display(Name="Descuento")]
        public int DescuentoId { get; set; }

        [Required]
        [Display(Name="Sala")]
        public int SalaId { get; set; }

        [Required]
        [Display(Name="Película")]
        public int PeliculaId { get; set; }
    }
}