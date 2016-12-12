using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dipndipInventory.EF.CustomModels
{
    public class WHStockQuantityModel
    {
        public  long Id { get; set; }
        public string wh_item_code { get; set; }
        public string wh_item_description { get; set; }
        public string unit_description { get; set; }
        public decimal qty { get; set; }
        public decimal unit_cost { get; set; }
    }
}
