﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class CKEntities : DbContext
    {
        public CKEntities()
            : base("name=CKEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<ck_item_details> ck_item_details { get; set; }
        public virtual DbSet<ck_units> ck_units { get; set; }
        public virtual DbSet<ck_users> ck_users { get; set; }
        public virtual DbSet<ckwh_category> ckwh_category { get; set; }
        public virtual DbSet<ckwh_item_unit> ckwh_item_unit { get; set; }
        public virtual DbSet<ckwh_items> ckwh_items { get; set; }
        public virtual DbSet<site> sites { get; set; }
        public virtual DbSet<wh_item_unit> wh_item_unit { get; set; }
        public virtual DbSet<order_details> order_details { get; set; }
        public virtual DbSet<order> orders { get; set; }
        public virtual DbSet<receipt_details> receipt_details { get; set; }
        public virtual DbSet<receipt> receipts { get; set; }
        public virtual DbSet<transaction_details> transaction_details { get; set; }
        public virtual DbSet<ck_item_cost_history> ck_item_cost_history { get; set; }
        public virtual DbSet<wh_item_cost_history> wh_item_cost_history { get; set; }
        public virtual DbSet<control_table> control_table { get; set; }
        public virtual DbSet<reason_codes> reason_codes { get; set; }
        public virtual DbSet<ckwh_items_adj> ckwh_items_adj { get; set; }
        public virtual DbSet<ck_wastage_master> ck_wastage_master { get; set; }
        public virtual DbSet<item_site> item_site { get; set; }
        public virtual DbSet<ck_stock_trans> ck_stock_trans { get; set; }
        public virtual DbSet<ck_wastage_details> ck_wastage_details { get; set; }
        public virtual DbSet<ck_item_unit> ck_item_unit { get; set; }
        public virtual DbSet<ck_prod> ck_prod { get; set; }
        public virtual DbSet<ck_items> ck_items { get; set; }
    
        public virtual ObjectResult<ReadWarehouseItems_Result> ReadWarehouseItems()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ReadWarehouseItems_Result>("ReadWarehouseItems");
        }
    }
}
