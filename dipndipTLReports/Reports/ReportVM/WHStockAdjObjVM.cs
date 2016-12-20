using dipndipInventory.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dipndipTLReports.Reports.ReportVM
{
    public class WHStockAdjObjVM
    {
        public string adj_code { get; set; }
        public string wh_item_code { get; set; }
        public string wh_item_description { get; set; }
        public string wh_item_unit_description { get; set; }
        public decimal? adj_qty { get; set; }
        public DateTime? created_date { get; set; }

        //public long Id { get; set; }
        //public string adj_code { get; set; }
        //public int wh_item_id { get; set; }
        //public string wh_item_code { get; set; }
        //public string wh_item_description { get; set; }
        //public Nullable<int> wh_item_unit_id { get; set; }
        //public string wh_item_unit_description { get; set; }
        //public Nullable<decimal> conversion_factor { get; set; }
        //public Nullable<decimal> adj_qty { get; set; }
        //public Nullable<decimal> unit_cost { get; set; }
        //public Nullable<decimal> ext_cost { get; set; }
        //public Nullable<int> created_by { get; set; }
        //public Nullable<System.DateTime> created_date { get; set; }
        //public Nullable<int> modified_by { get; set; }
        //public Nullable<System.DateTime> modified_date { get; set; }
        //public Nullable<int> active { get; set; }

        //public virtual ck_users ck_users { get; set; }
        //public virtual ck_users ck_users1 { get; set; }
        //public virtual ckwh_items ckwh_items { get; set; }
        //public virtual wh_item_unit wh_item_unit { get; set; }
    }
}
