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
        public double PrecioCalculado
        {
            get
            {
                return Pelicula.Precio - (Pelicula.Precio * Descuento.Porcentaje);
            }
        }
    }

    public class SesionAnnotations
    {
        public int Id { get; set; }

        [Required(ErrorMessage="Fecha imprescindible")]
        [DataType(DataType.DateTime)]
        public DateTime Fecha { get; set; }

        public int DescuentoId { get; set; }
        [Required]
        public int SalaId { get; set; }
        [Required]
        public int PeliculaId { get; set; }
    }
}