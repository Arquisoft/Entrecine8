//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EntrecineWebApp.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Sesion
    {
        public Sesion()
        {
            this.Reserva = new HashSet<Reserva>();
        }
    
        public int Id { get; set; }
        public System.TimeSpan Fecha { get; set; }
        public int DescuentoId { get; set; }
    
        public virtual Descuento Descuento { get; set; }
        public virtual Pelicula Pelicula { get; set; }
        public virtual ICollection<Reserva> Reserva { get; set; }
    }
}