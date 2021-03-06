﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EntrecineWebApp.Models
{
    [MetadataType(typeof(PeliculaAnnotation))]
    public partial class Pelicula
    {

        [Required]
        [Display(Name = "Portada de la película")]
        public HttpPostedFileBase Caratula { get; set; }

    }

    public class PeliculaAnnotation
    {
        public int Id { get; set; }
        
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Título")]
        public string Nombre { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [Range(0.01, float.MaxValue, ErrorMessage="El precio debe ser positivo")]
        [Display(Name = "Precio base")]
        public double Precio { get; set; }
        
        [Required]
        [DataType(DataType.Duration)]
        [Range(1,int.MaxValue, ErrorMessage = "La duración no puede ser menor de 0")]
        [Display(Name = "Duración (minutos)")]
        public int Duracion { get; set; }

    }

}