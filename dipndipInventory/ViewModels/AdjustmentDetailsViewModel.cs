using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dipndipInventory.ViewModels
{
    public class AdjustmentDetailsViewModel
    {
        public int id { get; set; }
        public int itemId { get; set; }
        public string itemCode { get; set; }
        public string itemDescription { get; set; }
        public int unitId { get; set; }
        public string unitDescription { get; set; }
        public decimal qty { get; set; }
        public decimal qty_issued { get; set; }
        public decimal qty_received { get; set; }
        public decimal qty_adjusted { get; set; }
        public int rowIndex { get; set; }
    }
}
