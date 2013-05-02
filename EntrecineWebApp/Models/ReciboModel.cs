using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace EntrecineWebApp.Models
{
    public class ReciboModel
    {
        public enum FormasDePago
        {
            [Display(Name = "Tarjeta de Credito")]
            TarjetaDeCredito,
            [Display(Name = "En Efectivo")]
            EnEfectivo
        }

        [Display(Name = "Reservas")]
        public List<Reserva> reservas { get; set; }

        public FormasDePago FormaDePago { get; set; }


    }
        
}