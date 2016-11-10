using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dipndipInventory.EF.DataServices
{
    public class CKAdjService
    {
        public string GetNewCKAdjCode()
        {
            CKEntities _context;
            try
            {
                string new_ck_adj_code = string.Empty;
                string last_ck_adj_code = string.Empty;
                _context = new CKEntities();
                //var result = _context.ck_items.OrderByDescending(i => i.Id).FirstOrDefault().ck_item_code;
                var result = _context.ck_items_adj.OrderByDescending(i => i.Id).FirstOrDefault();
                if (result == null)
                {
                    return "CADJ-0001";
                }

                last_ck_adj_code = ((ck_items_adj)result).adj_code;
                string[] tmpAdjCode = last_ck_adj_code.Split('-');

                new_ck_adj_code = "CADJ-" + (Convert.ToInt32(tmpAdjCode[1]) + 1).ToString("D4");

                return new_ck_adj_code;
            }
            catch { return string.Empty; }
        }
    }
}
