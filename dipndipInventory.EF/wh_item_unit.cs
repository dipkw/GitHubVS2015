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
    
    public partial class wh_item_unit
    {
        public int Id { get; set; }
        public Nullable<int> wh_item_id { get; set; }
        public Nullable<int> ck_unit_id { get; set; }
        public Nullable<decimal> cnv_factor { get; set; }
        public Nullable<int> created_by { get; set; }
        public Nullable<System.DateTime> created_date { get; set; }
        public Nullable<int> modified_by { get; set; }
        public Nullable<System.DateTime> modified_date { get; set; }
        public Nullable<bool> active { get; set; }
    
        public virtual ck_units ck_units { get; set; }
        public virtual ck_users ck_users { get; set; }
        public virtual ck_users ck_users1 { get; set; }
        public virtual wh_item_unit wh_item_unit1 { get; set; }
        public virtual wh_item_unit wh_item_unit2 { get; set; }
    }
}
