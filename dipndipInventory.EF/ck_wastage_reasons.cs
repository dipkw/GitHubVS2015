//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace dipndipInventory.EF
{
    using System;
    using System.Collections.Generic;
    
    public partial class ck_wastage_reasons
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ck_wastage_reasons()
        {
            this.ck_wastage_details = new HashSet<ck_wastage_details>();
        }
    
        public int Id { get; set; }
        public string description { get; set; }
        public Nullable<bool> active { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ck_wastage_details> ck_wastage_details { get; set; }
    }
}
