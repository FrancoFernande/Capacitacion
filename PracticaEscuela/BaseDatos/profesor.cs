//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PracticaEscuela.BaseDatos
{
    using System;
    using System.Collections.Generic;
    
    public partial class profesor
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public profesor()
        {
            this.alu_pro = new HashSet<alu_pro>();
            this.mat_pro = new HashSet<mat_pro>();
        }
    
        public int clave_p { get; set; }
        public string nom_p { get; set; }
        public string dir_p { get; set; }
        public Nullable<long> tel_p { get; set; }
        public Nullable<System.DateTime> hor_p { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<alu_pro> alu_pro { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<mat_pro> mat_pro { get; set; }
    }
}
