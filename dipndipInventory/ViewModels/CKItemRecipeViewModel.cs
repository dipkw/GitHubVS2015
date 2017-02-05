using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dipndipInventory.ViewModels
{
    public class CKItemRecipeViewModel
    {
        public int wh_item_id { get; set; }
        public string wh_item_code { get; set; }
        public string wh_item_description { get; set; }
        public decimal quantity { get; set; }
        public int wh_item_unit_id { get; set; }
        public string uom { get; set; }
        public decimal yield_cost { get; set; }
        public decimal unit_cost { get; set; }
    }
}
