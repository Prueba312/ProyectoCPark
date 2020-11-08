using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCCrud.Models.ViewModels
{
    public class ListParkViweModel
    {
        public int Park_ID { get; set; }
        public string Park_direccion { get; set; }
        public string Park_Name { get; set; }
        public int Park_Piso { get; set; }
        public int Us_ID { get; set; }
        public string Park_Tarifa { get; set; }
        public int Park_Val_Tarifa { get; set; }


    }
}