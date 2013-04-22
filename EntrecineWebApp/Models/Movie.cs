using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace EntrecineWebApp.Models {
    public class Movie {
        public int ID { get; set; }
        public String Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public String Genre { get; set; }
        public decimal Price { get; set; }
    }

    public class MovieContext : DbContext {
        public DbSet<Movie> Movies { get; set; }
        
    }
}