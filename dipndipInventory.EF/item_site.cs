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
    
    public partial class item_site
    {
        public int Id { get; set; }
        public Nullable<int> wh_item_id { get; set; }
        public Nullable<int> site_id { get; set; }
        public Nullable<bool> is_outlet { get; set; }
    
        public virtual ckwh_items ckwh_items { get; set; }
        public virtual site site { get; set; }
    }
}
