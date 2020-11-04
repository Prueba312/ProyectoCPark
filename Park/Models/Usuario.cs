//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Park.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Usuario
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Usuario()
        {
            this.Park = new HashSet<Park>();
        }
    
        public int Us_ID { get; set; }
        [Required]
        [Display(Name = "Contraseña")]
        public string Us_Pass { get; set; }
        [Required]
        [Display(Name = "Nombre")]
        public string Us_Name { get; set; }
        [Required]
        [Display(Name = "Fecha de nacimiento")]
        [DataType(DataType.Date)]
        public string Us_fecha { get; set; }
        [Required]
        [Display(Name = "Correo")]
        public string Us_Correo { get; set; }
        [Required]
        [Display(Name = "Tipo de usuario")]
        public string Us_Tipo { get; set; }
        [Required]
        [Display(Name = "Telefono")]
        public string Us_Telefono { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Park> Park { get; set; }
    }

    public enum Type_User
    {
        Estudiante,
        Administrativo,
        Docente,
        Admin
    }
}
