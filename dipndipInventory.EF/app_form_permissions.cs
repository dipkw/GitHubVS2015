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
    
    public partial class app_form_permissions
    {
        public int Id { get; set; }
        public Nullable<int> role_id { get; set; }
        public Nullable<int> form_id { get; set; }
        public Nullable<bool> create_permission { get; set; }
        public Nullable<bool> read_permission { get; set; }
        public Nullable<bool> update_permission { get; set; }
        public Nullable<bool> delete_permission { get; set; }
        public Nullable<int> created_by { get; set; }
        public Nullable<System.DateTime> created_date { get; set; }
        public Nullable<int> modified_by { get; set; }
        public Nullable<System.DateTime> modified_date { get; set; }
        public string form_desc { get; set; }
    
        public virtual app_forms app_forms { get; set; }
        public virtual user_roles user_roles { get; set; }
    }
}
