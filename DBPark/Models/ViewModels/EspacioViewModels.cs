using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DBPark.Models.ViewModels
{
    public class EspacioViewModels
    {
        public int Esp_ID { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Tipo de Vehiculo")]
        public string Esp_TipVehiculo { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Estado")]
        public string Esp_Estado { get; set; }
    }
}