using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace EntrecineWebApp.Models
{
    public class ReservaModel
    {
        public enum FormasDePago
        {
            [Display(Name = "Tarjeta de Credito")]
            TarjetaDeCredito,
            [Display(Name = "En Efectivo")]
            EnEfectivo
        }

        [DataType(DataType.CreditCard)]
        [Display(Name = "Numero de tarjeta de crédito")]
        public string TarjetaCredito { get; set; }

        [Display(Name = "Seleccione una forma de pago")]
        public FormasDePago FormaDePago { get; set; }

        public bool PermiteEnEfectivo { get; set; }

        [Display(Name = "Seleccione una o más butacas")]
        public Butaca[] Ocupacion { get; set; }

        public Sesion Sesion { get; set; }

        public string GetOcupacionClass(int i){
            if (Ocupacion[i].Ocupada)
                return "ocupada";
            else
                return "libre";
        }

    }
        
    public class Butaca{
        public bool Ocupada {get; set;}
        public int Fila {get; set;}
        public int Columna {get; set;}
    }
}