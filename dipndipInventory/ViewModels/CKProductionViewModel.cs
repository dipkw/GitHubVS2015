using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dipndipInventory.ViewModels
{
    public class CKProductionViewModel
    {
        public int id { get; set; }
        public int itemId { get; set; }
        public string itemCode { get; set; }
        public string itemDescription { get; set; }
        public decimal designQty { get; set; }
        public decimal prodQty { get; set; }
        public DateTime prodDate { get; set; }
        public DateTime expDate { get; set; }
        public decimal qtyonHand { get; set; }
        public int rowIndex { get; set; }
    }
}
