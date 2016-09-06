using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dipndipInventory.EF.DataServices
{
    public class WHItemService
    {
        CKEntities _context;

        public int CreateWHItems(ckwh_items objWHItems)
        {
            try
            {
                _context = new CKEntities();
                _context.ckwh_items.Add(objWHItems);
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

        public IEnumerable<ckwh_items> ReadAllWHItems()
        {
            try
            {
                _context = new CKEntities();
                IEnumerable<ckwh_items> objWHItems = (from whitems in _context.ckwh_items orderby whitems.Id ascending select whitems);
                return objWHItems;
            }
            catch
            {
                return null;
            }
        }

        public IEnumerable<ckwh_items> ReadAllWarehouseItemsSP()
        {
            try
            {
                _context = new CKEntities();
                IEnumerable<ckwh_items> objWHItems = _context.ckwh_items.SqlQuery("exec dbo.ReadWarehouseItems").ToList<ckwh_items>();
                return objWHItems;
            }
            catch { return null; }
        }

        public int UpdateWHItem(ckwh_items objWHItem)
        {
            try
            {
                _context = new CKEntities();
                //ck_users objUserToUpdate = new ck_users();
                ckwh_items objWHItemToUpdate = (from whitem in _context.ckwh_items where whitem.Id == objWHItem.Id select whitem).SingleOrDefault();
                objWHItemToUpdate.wh_item_description = objWHItem.wh_item_description;
                objWHItemToUpdate.modified_date = objWHItem.modified_date;
                objWHItemToUpdate.modified_by = objWHItem.modified_by;
                //objWHItemToUpdate.active = objWHItem.active;
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

        public decimal? GetCurrentCost(int wh_item_id)
        {
            decimal? curr_cost = 0.0m;

            try
            {
                _context = new CKEntities();
                curr_cost = (from whitems in _context.ckwh_items where whitems.Id == wh_item_id select whitems.unit_cost).FirstOrDefault();
            }
            catch { return null; }

            return curr_cost;
        }

        public string GetItemCode(int id)
        {
            string item_code = string.Empty;

            try
            {
                item_code = (from whitems in _context.ckwh_items where whitems.Id == id select whitems.wh_item_code).FirstOrDefault();
            }
            catch { return null; }
            return item_code;
        }

        public string GetItemDescription(int id)
        {
            string item_description = string.Empty;

            try
            {
                item_description = (from whitems in _context.ckwh_items where whitems.Id == id select whitems.wh_item_description).FirstOrDefault();
            }
            catch { return null; }
            return item_description;
        }
    }
}
