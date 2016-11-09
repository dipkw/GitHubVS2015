using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dipndipInventory.ViewModels
{
    public class CKItemBatchViewModel
    {
        public int id { get; set; }
        public string ck_prod_code { get; set; }
        public int ck_item_id { get; set; }
        public string ck_item_code { get; set; }
        public string ck_item_description { get; set; }
        public string batch_no { get; set; }
        public int ck_item_unit_id { get; set; }
        public string ck_item_unit_desc { get; set; }
        public DateTime prod_date { get; set; }
        public DateTime exp_date { get; set; }
        public decimal ck_unit_cost { get; set; }
        public decimal tmp_ck_unit_cost { get; set; }
        public decimal ck_total_cost { get; set; }
        public decimal conv_factor { get; set; }
        public decimal bal_qty { get; set; }
        public decimal rem_qty { get; set; }
        public decimal qty_issued { get; set; }
        public int row_id { get; set; }
    }
}
