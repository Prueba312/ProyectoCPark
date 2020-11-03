using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Park.Models.ViewModels
{
    public class ListaUsuariosViewModels
    {
        public int id { get; set; }
        public string password { set; get; }
        public string nombre { set; get; }
        public string fecha { set; get; }
        public string correo { set; get; }
        public string tipo_usuario { set; get; }
        public string telefono { set; get; }

    }
}