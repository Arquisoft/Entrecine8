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
    
    public partial class Sala
    {
        public Sala()
        {
            this.Sesion = new HashSet<Sesion>();
        }
    
        public int Id { get; set; }
        public int Filas { get; set; }
        public int Columnas { get; set; }
    
        public virtual ICollection<Sesion> Sesion { get; set; }
    }
}