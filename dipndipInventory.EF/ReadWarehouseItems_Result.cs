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
    
    public partial class ReadWarehouseItems_Result
    {
        public int Id { get; set; }
        public string wh_item_code { get; set; }
        public string wh_item_description { get; set; }
        public Nullable<int> wh_category_id { get; set; }
        public string wh_category_description { get; set; }
        public Nullable<int> wh_unit_id { get; set; }
        public string wh_unit_description { get; set; }
        public Nullable<decimal> quantity { get; set; }
        public Nullable<decimal> unit_cost { get; set; }
        public Nullable<int> site_id { get; set; }
        public Nullable<int> created_by { get; set; }
        public Nullable<System.DateTime> created_date { get; set; }
        public Nullable<int> modified_by { get; set; }
        public Nullable<System.DateTime> modified_date { get; set; }
    }
}
