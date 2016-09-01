using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dipndipInventory.ViewModels
{
    public class ItemUnitViewModel
    {
        public int id { get; set; }
        public int itemId { get; set; }
        public string itemCode { get; set; }
        public int unitId { get; set; }
        public string unitText { get; set; }
        public decimal conversionFactor { get; set; }
        public string baseUnit { get; set; }
        public decimal unitCost { get; set; }
    }
}
