using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EntrecineWebApp.Models
{
    [MetadataType(typeof(DescuentoAnnotations))]
    public partial class Descuento
    {

    }
    
    public class DescuentoAnnotations
    {
        
        public int Id { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name="Nombre del descuento")]
        public string Nombre { get; set; }

        [Required]
        [Display(Name="Porcentaje")]
        [DefaultValue(0)]
        [Range(0,100,ErrorMessage="El descuento debe estar comprendido entre 0 y 100")]
        public double Porcentaje { get; set; }

        public virtual ICollection<Sesion> Sesion { get; set; }
    }


}