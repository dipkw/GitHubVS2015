using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dipndipInventory.ViewModels
{
    public class CKWastageViewModel
    {
        public int Id { get; set; }
        public string ck_item_code { get; set; }
        public string ck_item_description { get; set; }
        public int unit_id { get; set; }
        public List<int>ck_item_unit_id { get; set; }
        public List<string> ck_item_unit_description { get; set; }
        public decimal ck_wastage_qty { get; set; }
        public int row_index { get; set; }
    }
}
