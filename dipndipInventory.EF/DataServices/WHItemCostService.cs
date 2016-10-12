using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dipndipInventory.EF.DataServices
{
    public class WHItemCostService
    {
        CKEntities _context;

        public int CreateWHItemCost(wh_item_cost_history objWHItemCost)
        {
            try
            {
                _context = new CKEntities();
                _context.wh_item_cost_history.Add(objWHItemCost);
                _context.SaveChanges();
                _context.Dispose();
            }
            catch
            {
                _context.Dispose();
                return 0;
            }
            return 1;
        }

        public IEnumerable<wh_item_cost_history> ReadAllWHItemCost()
        {
            try
            {
                _context = new CKEntities();
                IEnumerable<wh_item_cost_history> objWHItemCost = (from whitemcost in _context.wh_item_cost_history orderby whitemcost.Id ascending select whitemcost);
                return objWHItemCost;
            }
            catch
            {
                return null;
            }
        }

        public int UpdateWHItemCost(wh_item_cost_history objWHItemCost)
        {
            try
            {
                _context = new CKEntities();
                //ck_users objUserToUpdate = new ck_users();
                wh_item_cost_history objWHItemCostToUpdate = (from whitemcost in _context.wh_item_cost_history where whitemcost.Id == objWHItemCost.Id select whitemcost).SingleOrDefault();
                objWHItemCostToUpdate.wh_item_id = objWHItemCost.wh_item_id;
                objWHItemCostToUpdate.wh_item_code = objWHItemCost.wh_item_code;
                objWHItemCostToUpdate.wh_item_description = objWHItemCost.wh_item_description;
                objWHItemCostToUpdate.ord = objWHItemCost.ord;
                objWHItemCostToUpdate.prev_cost = objWHItemCost.prev_cost;
                objWHItemCostToUpdate.curr_cost = objWHItemCost.curr_cost;

                //objWHItemCostToUpdate.modified_date = objWHItemCost.modified_date;
                //objWHItemCostToUpdate.modified_by = objWHItemCost.modified_by;
                //objWHItemCostToUpdate.active = objWHItemCost.active;
                _context.SaveChanges();

                _context.Dispose();
                return 1;
            }
            catch (Exception e)
            {
                _context.Dispose();
                return 0;
            }
        }

        public int DeleteWHItemCost(wh_item_cost_history objWHItemCost)
        {
            try
            {
                _context = new CKEntities();
                wh_item_cost_history objWHItemCostToDelete = (from whitemcost in _context.wh_item_cost_history where whitemcost.Id == objWHItemCost.Id select whitemcost).Single();
                _context.wh_item_cost_history.Remove(objWHItemCostToDelete);
                _context.SaveChanges();
                _context.Dispose();
                return 1;
            }
            catch
            {
                _context.Dispose();
                return 0;
            }
        }

        public wh_item_cost_history GetLastCost(int wh_item_id)
        {
            _context = new CKEntities();
            wh_item_cost_history objWHItemCost = new wh_item_cost_history();
            try
            {
                objWHItemCost = (from whitemcost in _context.wh_item_cost_history where whitemcost.wh_item_id==wh_item_id orderby whitemcost.ord descending select whitemcost).FirstOrDefault();
            }
            catch { }
            return objWHItemCost;
        }
    }
}
