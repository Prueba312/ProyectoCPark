using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCCrud.Models.ViewModels
{
    public class ParkViewModel
    {

        public int Park_ID { get; set; }
        [Required]
        [StringLength(100)]
        [Display(Name = "Direccion")]
        public string Park_direccion { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Nombre")]
        public string Park_Name { get; set; }
        [Display(Name = "Piso")]
        public int Park_Piso { get; set; }
        [Display(Name = "Usuario")]
        public int Us_ID { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Tipo de tarifa")]
        public string Park_Tarifa { get; set; }
        [Display(Name = "Valor de tarifa")]
        public int Park_Val_Tarifa { get; set; }
    }
}