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
    
    public partial class Reserva
    {
        public int Id { get; set; }
        public int Fila { get; set; }
        public int Columna { get; set; }
        public int SesionId { get; set; }
        public int UsuarioId { get; set; }
    
        public virtual Sesion Sesion { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
