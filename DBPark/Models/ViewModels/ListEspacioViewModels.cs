using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DBPark.Models.ViewModels
{
    public class ListEspacioViewModels
    {
        public int Esp_ID { get; set; }
        public string Esp_TipVehiculo { get; set; }
        public string Esp_Estado { get; set; }
        public bool Esp_Eliminado { get; set; }

        public int Ocu_ID { get; set; }
        public string Email { get; set; }
        public string Matricula_Vhiculo { get; set; }
        public string Us_ID { get; set; }
    }
}