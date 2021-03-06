﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace EntrecineWebApp.Models
{
    [MetadataType(typeof(UsuarioAnnotations))]
    public partial class Usuario
    {
    }

    public class UsuarioAnnotations
    {

        public int Id { get; set; }

        [Required]
        [DisplayName("Nombre")]
        public string Nombre { get; set; }

        [Required]
        [DisplayName("Apellidos")]
        public string Apellidos { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Correo electrónico")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Nombre de usuario")]
        public string Login { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(20,MinimumLength=6, ErrorMessage="La contraseña debe estar entre los 6 y 20 caracteres")]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }

        [DefaultValue(0)]
        public int Rol { get; set; }

    }
}