﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class EntityModelContainer : DbContext
    {
        public EntityModelContainer()
            : base("name=EntityModelContainer")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Reserva> ReservaConjunto { get; set; }
        public DbSet<Usuario> UsuarioConjunto { get; set; }
        public DbSet<Pelicula> PeliculaConjunto { get; set; }
        public DbSet<Sesion> SesionConjunto { get; set; }
        public DbSet<Descuento> DescuentoConjunto { get; set; }
        public DbSet<Favoritas> FavoritasConjunto { get; set; }
    }
}
