using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dipndipInventory.EF.DataServices
{
    public class WHAdjService
    {
        CKEntities _context;

        public int CreateWHAdj(ckwh_items_adj objWHAdj)
        {
            try
            {
                _context = new CKEntities();
                _context.ckwh_items_adj.Add(objWHAdj);
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

        public IEnumerable<ckwh_items_adj> ReadAllWHAdj()
        {
            try
            {
                _context = new CKEntities();
                IEnumerable<ckwh_items_adj> objWHAdj = (from whadj in _context.ckwh_items_adj orderby whadj.Id ascending select whadj);
                return objWHAdj;
            }
            catch
            {
                return null;
            }
        }

        public int UpdateWHAdj(ckwh_items_adj objWHAdj)
        {
            try
            {
                _context = new CKEntities();
                ckwh_items_adj objWHAdjToUpdate = (from whadj in _context.ckwh_items_adj where whadj.Id == objWHAdj.Id select whadj).SingleOrDefault();
                objWHAdjToUpdate.wh_item_id = objWHAdj.wh_item_id;
                objWHAdjToUpdate.wh_item_code = objWHAdj.wh_item_code;
                objWHAdjToUpdate.wh_item_description = objWHAdj.wh_item_description;
                objWHAdjToUpdate.wh_item_unit_id = objWHAdj.wh_item_unit_id;
                objWHAdjToUpdate.wh_item_unit_description = objWHAdj.wh_item_unit_description;
                objWHAdjToUpdate.conversion_factor = objWHAdj.conversion_factor;
                objWHAdjToUpdate.adj_qty = objWHAdj.adj_qty;
                objWHAdjToUpdate.unit_cost = objWHAdj.unit_cost;
                objWHAdjToUpdate.ext_cost = objWHAdj.ext_cost;
                objWHAdjToUpdate.modified_date = objWHAdj.modified_date;
                objWHAdjToUpdate.modified_by = objWHAdj.modified_by;
                objWHAdjToUpdate.active = objWHAdj.active;
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

        public int DeleteWHAdj(ckwh_items_adj objWHAdj)
        {
            try
            {
                _context = new CKEntities();
                ckwh_items_adj objWHAdjToDelete = (from whadj in _context.ckwh_items_adj where whadj.Id == objWHAdj.Id select whadj).Single();
                _context.ckwh_items_adj.Remove(objWHAdjToDelete);
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

        public string GetNewWHAdjCode()
        {
            try
            {
                string new_wh_adj_code = string.Empty;
                string last_wh_adj_code = string.Empty;
                _context = new CKEntities();
                //var result = _context.ck_items.OrderByDescending(i => i.Id).FirstOrDefault().ck_item_code;
                var result = _context.ckwh_items_adj.OrderByDescending(i => i.Id).FirstOrDefault();
                if (result == null)
                {
                    return "WADJ-0001";
                }

                last_wh_adj_code = ((ckwh_items_adj)result).adj_code;
                string[] tmpAdjCode = last_wh_adj_code.Split('-');

                new_wh_adj_code = "WADJ-" + (Convert.ToInt32(tmpAdjCode[1]) + 1).ToString("D4");

                return new_wh_adj_code;
            }
            catch (Exception e) { return string.Empty; }
        }
    }
}
