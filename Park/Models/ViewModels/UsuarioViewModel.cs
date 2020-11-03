using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Park.Models.ViewModels
{
    public class UsuarioViewModel
    {
        public int id { get; set; }
        [Required]
        [Display(Name = "Password")]
        public string password { set; get; }
        [Required]
        [StringLength(30)]
        [Display(Name = "Nombre completo")]
        public string nombre { set; get; }
        [Required]
        [Display(Name = "Fecha de nacimiento")]
        [DataType(DataType.Date)]
        public string fecha { set; get; }
        [Required]
        [Display(Name = "Correo")]
        [EmailAddress]
        public string correo { set; get; }
        [Required]
        [Display(Name = "Tipo de Usuario")]
        public string tipo_usuario { set; get; }
        [Required]
        [Display(Name = "Telefono")]
        public string telefono { set; get; }
    }

    public enum Type_User
    {
        Estudiante,
        Administrativo,
        Docente
    }
}