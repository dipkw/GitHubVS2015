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
    
    public partial class ck_users
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ck_users()
        {
            this.ck_item_details = new HashSet<ck_item_details>();
            this.ck_item_details1 = new HashSet<ck_item_details>();
            this.ck_units = new HashSet<ck_units>();
            this.ck_units1 = new HashSet<ck_units>();
            this.ckwh_category = new HashSet<ckwh_category>();
            this.ckwh_category1 = new HashSet<ckwh_category>();
            this.ckwh_item_unit = new HashSet<ckwh_item_unit>();
            this.ckwh_item_unit1 = new HashSet<ckwh_item_unit>();
            this.ckwh_items = new HashSet<ckwh_items>();
            this.ckwh_items1 = new HashSet<ckwh_items>();
            this.sites = new HashSet<site>();
            this.sites1 = new HashSet<site>();
            this.wh_item_unit = new HashSet<wh_item_unit>();
            this.wh_item_unit1 = new HashSet<wh_item_unit>();
            this.order_details = new HashSet<order_details>();
            this.order_details1 = new HashSet<order_details>();
            this.orders = new HashSet<order>();
            this.orders1 = new HashSet<order>();
            this.receipt_details = new HashSet<receipt_details>();
            this.receipt_details1 = new HashSet<receipt_details>();
            this.receipts = new HashSet<receipt>();
            this.receipts1 = new HashSet<receipt>();
            this.transaction_details = new HashSet<transaction_details>();
            this.transaction_details1 = new HashSet<transaction_details>();
            this.ck_item_cost_history = new HashSet<ck_item_cost_history>();
            this.wh_item_cost_history = new HashSet<wh_item_cost_history>();
            this.ckwh_items_adj = new HashSet<ckwh_items_adj>();
            this.ckwh_items_adj1 = new HashSet<ckwh_items_adj>();
            this.ck_wastage_master = new HashSet<ck_wastage_master>();
            this.ck_wastage_master1 = new HashSet<ck_wastage_master>();
            this.ck_wastage_details = new HashSet<ck_wastage_details>();
            this.ck_wastage_details1 = new HashSet<ck_wastage_details>();
            this.ck_item_unit = new HashSet<ck_item_unit>();
            this.ck_item_unit1 = new HashSet<ck_item_unit>();
            this.ck_prod = new HashSet<ck_prod>();
            this.ck_prod1 = new HashSet<ck_prod>();
            this.ck_items = new HashSet<ck_items>();
            this.ck_items1 = new HashSet<ck_items>();
            this.ck_issue_master = new HashSet<ck_issue_master>();
            this.ck_issue_master1 = new HashSet<ck_issue_master>();
            this.ck_issue_detais = new HashSet<ck_issue_detais>();
            this.ck_issue_detais1 = new HashSet<ck_issue_detais>();
            this.ck_items_adj = new HashSet<ck_items_adj>();
            this.ck_items_adj1 = new HashSet<ck_items_adj>();
            this.ckwh_items_log = new HashSet<ckwh_items_log>();
        }
    
        public int Id { get; set; }
        public string uname { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string role { get; set; }
        public Nullable<bool> active { get; set; }
        public Nullable<int> site_id { get; set; }
        public Nullable<int> role_id { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ck_item_details> ck_item_details { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ck_item_details> ck_item_details1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ck_units> ck_units { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ck_units> ck_units1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ckwh_category> ckwh_category { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ckwh_category> ckwh_category1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ckwh_item_unit> ckwh_item_unit { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ckwh_item_unit> ckwh_item_unit1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ckwh_items> ckwh_items { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ckwh_items> ckwh_items1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<site> sites { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<site> sites1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<wh_item_unit> wh_item_unit { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<wh_item_unit> wh_item_unit1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<order_details> order_details { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<order_details> order_details1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<order> orders { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<order> orders1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<receipt_details> receipt_details { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<receipt_details> receipt_details1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<receipt> receipts { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<receipt> receipts1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<transaction_details> transaction_details { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<transaction_details> transaction_details1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ck_item_cost_history> ck_item_cost_history { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<wh_item_cost_history> wh_item_cost_history { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ckwh_items_adj> ckwh_items_adj { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ckwh_items_adj> ckwh_items_adj1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ck_wastage_master> ck_wastage_master { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ck_wastage_master> ck_wastage_master1 { get; set; }
        public virtual site site { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ck_wastage_details> ck_wastage_details { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ck_wastage_details> ck_wastage_details1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ck_item_unit> ck_item_unit { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ck_item_unit> ck_item_unit1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ck_prod> ck_prod { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ck_prod> ck_prod1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ck_items> ck_items { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ck_items> ck_items1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ck_issue_master> ck_issue_master { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ck_issue_master> ck_issue_master1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ck_issue_detais> ck_issue_detais { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ck_issue_detais> ck_issue_detais1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ck_items_adj> ck_items_adj { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ck_items_adj> ck_items_adj1 { get; set; }
        public virtual user_roles user_roles { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ckwh_items_log> ckwh_items_log { get; set; }
    }
}
