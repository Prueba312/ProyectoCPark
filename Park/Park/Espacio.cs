//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Park
{
    using System;
    using System.Collections.Generic;
    
    public partial class Espacio
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Espacio()
        {
            this.Ocupacion = new HashSet<Ocupacion>();
        }
    
        public string Esp_ID { get; set; }
        public string Esp_TipVehiculo { get; set; }
        public string Esp_Estado { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ocupacion> Ocupacion { get; set; }
    }
}
