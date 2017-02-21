using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dipndipInventory.EF.DataServices
{
    public class CKItemService
    {
        CKEntities _context;

        public int CreateCKItems(ck_items objCKItems)
        {
            try
            {
                _context = new CKEntities();
                _context.ck_items.Add(objCKItems);
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

        public IEnumerable<ck_items> ReadAllCKItems()
        {
            try
            {
                _context = new CKEntities();
                IEnumerable<ck_items> objCKItems = (from ckitems in _context.ck_items where ckitems.active == true orderby ckitems.Id ascending select ckitems);
                return objCKItems;
            }
            catch
            {
                return null;
            }
        }

        public int UpdateCKItem(ck_items objCKItem)
        {
            try
            {
                _context = new CKEntities();
                //ck_users objUserToUpdate = new ck_users();
                ck_items objCKItemToUpdate = (from ckitem in _context.ck_items where ckitem.Id == objCKItem.Id select ckitem).SingleOrDefault();
                objCKItemToUpdate.ck_item_description = objCKItem.ck_item_description;
                objCKItemToUpdate.ck_design_qty = objCKItem.ck_design_qty;
                objCKItemToUpdate.ck_unit_id = objCKItem.ck_unit_id;
                objCKItemToUpdate.ck_item_unit_cost = objCKItem.ck_item_unit_cost;
                objCKItemToUpdate.modified_date = objCKItem.modified_date;
                objCKItemToUpdate.modified_by = objCKItem.modified_by;
                //objWHItemToUpdate.active = objWHItem.active;
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

        public int DeleteUnit(ck_items objCKItem)
        {
            try
            {
                _context = new CKEntities();
                ck_items objCKItemToDelete = (from ckitem in _context.ck_items where ckitem.Id == objCKItem.Id select ckitem).Single();
                _context.ck_items.Remove(objCKItemToDelete);
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


        public IEnumerable<ck_items> ReadAllActiveCKItems()
        {
            try
            {
                _context = new CKEntities();
                IEnumerable<ck_items> objCKItems = (from ckitems in _context.ck_items where ckitems.active==true orderby ckitems.Id ascending select ckitems);
                return objCKItems;
            }
            catch
            {
                return null;
            }
        }

        public int CountAllActiveCKItems()
        {
            try
            {
                _context = new CKEntities();
                IEnumerable<ck_items> objCKItems = (from ckitems in _context.ck_items where ckitems.active == true orderby ckitems.Id ascending select ckitems);
                return objCKItems.Count();
            }
            catch
            {
                return 0;
            }
        }

        public bool IsExistingCKItem(int ck_item_id)
        {
            bool _result = false;
            _context = new CKEntities();

            ck_items objCKItem = (from ckitem in _context.ck_items where ckitem.Id == ck_item_id select ckitem).FirstOrDefault();

            if (objCKItem != null)
            {
                _result = true;
            }

            return _result;
        }

        public string GetNewItemCode()
        {
            try
            {
                string new_item_code = string.Empty;
                string last_item_code = string.Empty;
                _context = new CKEntities();
                //var result = _context.ck_items.OrderByDescending(i => i.Id).FirstOrDefault().ck_item_code;
                var result = _context.ck_items.OrderByDescending(i => i.Id).FirstOrDefault();
                if (result == null)
                {
                    return "CK-0001";
                }

                last_item_code = ((ck_items)result).ck_item_code;
                string[] tmpItemCode = last_item_code.Split('-');

                new_item_code = "CK-" + (Convert.ToInt32(tmpItemCode[1]) + 1).ToString("D4");

                return new_item_code;
            }
            catch { return string.Empty; }
        }

        public string GetItemCode(int id)
        {
            string item_code = string.Empty;

            try
            {
                _context = new CKEntities();
                item_code = (from ckitems in _context.ck_items where ckitems.Id == id select ckitems.ck_item_code).FirstOrDefault();
            }
            catch { return null; }
            return item_code;
        }

        public int GetItemId(string item_code)
        {
            int item_id = 0;

            try
            {
                _context = new CKEntities();
                item_id = (from ckitems in _context.ck_items where ckitems.ck_item_code == item_code select ckitems.Id).FirstOrDefault();
            }
            catch { return 0; }
            return item_id;
        }

        public ck_items GetItemByCode(string item_code)
        {
            try
            {
                _context = new CKEntities();
                ck_items item_details = (from ckitems in _context.ck_items where ckitems.ck_item_code == item_code select ckitems).FirstOrDefault();
                return item_details;
            }
            catch { return null; }
        }

        public decimal GetCurrentCKItemQty(int ck_item_id)
        {
            decimal ck_item_current_qty = 0.000m;

            try
            {
                _context = new CKEntities();
                ck_item_current_qty = (decimal)(from ckitems in _context.ck_items where ckitems.Id == ck_item_id select ckitems.qty_on_hand).FirstOrDefault();
            }
            catch { return 0.000m; }

            return ck_item_current_qty;
        }

        public decimal GetCurrentCKItemCost(int ck_item_id)
        {
            decimal ck_item_current_cost = 0.000m;

            try
            {
                _context = new CKEntities();
                ck_item_current_cost = (decimal)(from ckitems in _context.ck_items where ckitems.Id == ck_item_id select ckitems.ck_item_unit_cost).FirstOrDefault();
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
