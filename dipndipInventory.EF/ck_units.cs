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
    
    public partial class ck_units
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ck_units()
        {
            this.wh_item_unit = new HashSet<wh_item_unit>();
            this.ck_items = new HashSet<ck_items>();
            this.ckwh_item_unit = new HashSet<ckwh_item_unit>();
        }
    
        public int Id { get; set; }
        public string unit_description { get; set; }
        public Nullable<int> created_by { get; set; }
        public Nullable<System.DateTime> created_date { get; set; }
        public Nullable<int> modified_by { get; set; }
        public Nullable<System.DateTime> modified_date { get; set; }
        public Nullable<bool> active { get; set; }
    
        public virtual ck_users ck_users { get; set; }
        public virtual ck_users ck_users1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<wh_item_unit> wh_item_unit { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ck_items> ck_items { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ckwh_item_unit> ckwh_item_unit { get; set; }
    }
}
