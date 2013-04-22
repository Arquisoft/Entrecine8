using System;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace EntrecineWebApp.Models {

    public class Entrecine {
        [Key]
        public string EntrecineId { get; set; }
    }

    public class EntrecineDBContext : DbContext {
        public DbSet<Entrecine> context { get; set; }
        
    }
}