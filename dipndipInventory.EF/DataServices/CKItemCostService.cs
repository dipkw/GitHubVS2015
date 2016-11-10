using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dipndipInventory.EF.DataServices
{
    public class CKItemCostService
    {
        CKEntities _context;
        public decimal GetCurrentCKItemCost(int ck_item_id)
        {
            decimal ck_item_current_cost = 0.000m;

            try
            {
                _context = new CKEntities();
                ck_item_current_cost = (decimal)(from ckitems in _context.ck_item_cost_history where ckitems.ck_item_id == ck_item_id orderby ckitems.ord descending select ckitems.curr_cost).FirstOrDefault();
            }
            catch
            {
                return 0.000m;
            }
            return ck_item_current_cost;
        }

        public int GetLastOrd(int ck_item_id)
        {
            int last_ord = 0;

            try
            {
                _context = new CKEntities();
                last_ord = (int)(from ckitemscost in _context.ck_item_cost_history where ckitemscost.Id == ck_item_id orderby ckitemscost.ord descending select ckitemscost.ord).FirstOrDefault();
            }
            catch
            {
                return 0;
            }

            return last_ord;
        }
    }
}
