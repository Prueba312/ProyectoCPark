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
    
    public partial class Segmento
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Segmento()
        {
            this.Espacio = new HashSet<Espacio>();
            this.Estacionamiento = new HashSet<Estacionamiento>();
        }
    
        public int Seg_ID { get; set; }
        public decimal Seg_Piso { get; set; }
        public string Seg_Desc { get; set; }
        public string Seg_Estado { get; set; }
        public int Park_ID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Espacio> Espacio { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Estacionamiento> Estacionamiento { get; set; }
        public virtual Park Park { get; set; }
    }
}
