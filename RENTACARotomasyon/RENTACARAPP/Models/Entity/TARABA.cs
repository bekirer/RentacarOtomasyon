//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RENTACARAPP.Models.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class TARABA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TARABA()
        {
            this.TAKSIYON = new HashSet<TAKSIYON>();
        }
    
        public int ID { get; set; }
        public string MODEL { get; set; }
        public byte KASATIPI { get; set; }
        public int MARKA { get; set; }
        public string URETIMYILI { get; set; }
        public string KM { get; set; }
        public Nullable<bool> DURUM { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TAKSIYON> TAKSIYON { get; set; }
        public virtual TKASATIPI TKASATIPI { get; set; }
        public virtual TMARKA TMARKA { get; set; }
    }
}
