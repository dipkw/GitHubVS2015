using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dipndipInventory.ViewModels
{
    public class WHStockAdjustmentViewModel
    {
        public int wh_item_id { get; set; }
        public string wh_item_code { get; set; }
        public string wh_item_description { get; set; }
        public decimal adj_qty { get; set; }
        public int wh_unit_id { get; set; }
        public string wh_unit_description { get; set; }
        public decimal qty { get; set; }
        public int row_index { get; set; }
    }
}
