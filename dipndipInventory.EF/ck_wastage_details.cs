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
    
    public partial class ck_wastage_details
    {
        public int Id { get; set; }
        public Nullable<long> wastage_master_id { get; set; }
        public Nullable<int> ck_item_id { get; set; }
        public Nullable<int> ck_item_unit_id { get; set; }
        public Nullable<decimal> wastage_qty { get; set; }
        public Nullable<int> created_by { get; set; }
        public Nullable<System.DateTime> created_date { get; set; }
        public Nullable<int> modified_by { get; set; }
        public Nullable<System.DateTime> modified_date { get; set; }
        public Nullable<bool> active { get; set; }
        public string ck_wastage_code { get; set; }
        public string ck_prod_code { get; set; }
        public string ck_batch_no { get; set; }
        public Nullable<System.DateTime> ck_prod_date { get; set; }
        public Nullable<System.DateTime> ck_exp_date { get; set; }
        public string ck_item_code { get; set; }
        public string ck_item_desc { get; set; }
        public Nullable<decimal> ck_item_unit_cost { get; set; }
        public Nullable<decimal> ck_item_total_cost { get; set; }
    
        public virtual ck_users ck_users { get; set; }
        public virtual ck_users ck_users1 { get; set; }
        public virtual ck_wastage_master ck_wastage_master { get; set; }
        public virtual ck_item_unit ck_item_unit { get; set; }
        public virtual ck_items ck_items { get; set; }
    }
}
