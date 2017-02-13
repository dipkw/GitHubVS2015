using dipndipInventory.EF.CustomModels;
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
                //IEnumerable<ckwh_items> objWHItems = (from whitems in _context.ckwh_items where whitems.wh_item_code != "CASH001" orderby whitems.wh_item_code ascending select whitems);
                IEnumerable<ckwh_items> objWHItems = (from whitems in _context.ckwh_items where whitems.wh_item_code != "CASH001" && whitems.inactive == false orderby whitems.wh_item_code ascending select whitems);
                return objWHItems;
            }
            catch
            {
                return null;
            }
        }

        public IEnumerable<ckwh_items> GetAllWHCategoryItems(string param_category)
        {
            try
            {
                _context = new CKEntities();
                IEnumerable<ckwh_items> objWHItems = (from whitems in _context.ckwh_items where whitems.wh_item_code != "CASH001" && whitems.wh_category_description == param_category orderby whitems.wh_item_code ascending select whitems);
                return objWHItems;
            }
            catch
            {
                return null;
            }
        }

        public List<string> ReadAllWHItemsCategory()
        {
            List<string> wh_categories = new List<string>();
            try
            {
                _context = new CKEntities();
                //IEnumerable<ckwh_items> cats = (from whitems in _context.ckwh_items where whitems.wh_item_code != "CASH001" select whitems);
                IOrderedQueryable cats = (from whitems in _context.ckwh_items where whitems.wh_item_code != "CASH001" select new { categories = whitems.wh_category_description }).Distinct().OrderBy(o => o.categories);
                wh_categories = cats as List<string>;
                return wh_categories;
            }
            catch(Exception ex)
            {
                return wh_categories;
            }
        }

        public IEnumerable<ckwh_items> ReadAllWHItemsWithCash()
        {
            try
            {
                _context = new CKEntities();
                IEnumerable<ckwh_items> objWHItems = (from whitems in _context.ckwh_items orderby whitems.wh_item_code ascending select whitems);
                return objWHItems;
            }
            catch
            {
                return null;
            }
        }

        public IEnumerable<ckwh_items> ReadAllWHItemsSortById()
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
        //public IEnumerable<ckwh_items> GetStockQtySP(string wh_item_code, DateTime trans_date)
        public decimal GetStockQtySP(string wh_item_code, DateTime trans_date)
        {
            decimal quantity = 0.000m;
            try
            {
                _context = new CKEntities();
                string query = "exec dbo.StockQuantity '" + wh_item_code + "', '" + trans_date + "'";
                //IEnumerable<WHStockQuantityModel> objStockQuantity = _context.Database.SqlQuery<WHStockQuantityModel>(query);
                //IEnumerable<transaction_details> objWHItems = _context.transaction_details.SqlQuery(query).ToList<transaction_details>();
                var result = _context.Database.SqlQuery<decimal>(query);
                //if (wh_item_code.Trim() == "CER001")
                //{
                //    var item = result.FirstOrDefault();
                //}
                
                if(result != null)
                {
                    quantity = Convert.ToDecimal(result.FirstOrDefault());
                }
                 
                return quantity;
            }
            catch(Exception ex)
            {
                return 0;
            }
        }

        public List<string> GetWHCategories()
        {
            List<string> wh_categories = new List<string>();
            try
            {
                _context = new CKEntities();
                string query = "exec dbo.GetWHCategories";
                //IEnumerable<WHStockQuantityModel> objStockQuantity = _context.Database.SqlQuery<WHStockQuantityModel>(query);
                //IEnumerable<transaction_details> objWHItems = _context.transaction_details.SqlQuery(query).ToList<transaction_details>();
                IEnumerable<string>ckwhitems = _context.Database.SqlQuery<string>(query);

                //foreach (string ckwhitem in ckwhitems)
                //{
                //    wh_categories.Add(ckwhitem);
                //}
                wh_categories = ckwhitems.ToList<string>();
                return wh_categories;
            }
            catch (Exception ex)
            {
                return wh_categories;
            }
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

        public decimal? GetCurrentCKQty(int wh_item_id)
        {
            decimal? curr_ck_qty = 0.0m;

            try
            {
                _context = new CKEntities();
                curr_ck_qty = (from whitems in _context.ckwh_items where whitems.Id == wh_item_id select whitems.ck_qty).FirstOrDefault();
            }
            catch { return 0; }
            if(curr_ck_qty==null)
            {
                curr_ck_qty = 0.0m;
            }
            return curr_ck_qty;
        }

        public string GetItemCode(int id)
        {
            string item_code = string.Empty;

            try
            {
                _context = new CKEntities();
                item_code = (from whitems in _context.ckwh_items where whitems.Id == id select whitems.wh_item_code).FirstOrDefault();
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
                item_id = (from whitems in _context.ckwh_items where whitems.wh_item_code == item_code select whitems.Id).FirstOrDefault();
            }
            catch { return 0; }
            return item_id;
        }

        public string GetItemDescription(int id)
        {
            string item_description = string.Empty;

            try
            {
                _context = new CKEntities();
                item_description = (from whitems in _context.ckwh_items where whitems.Id == id select whitems.wh_item_description).FirstOrDefault();
            }
            catch { return null; }
            return item_description;
        }

        public ckwh_items GetItemByCode(string item_code)
        {
            try
            {
                _context = new CKEntities();
                ckwh_items item_details = (from whitems in _context.ckwh_items where whitems.wh_item_code == item_code select whitems).FirstOrDefault();
                return item_details;
            }
            catch { return null; }
        }

        public int UpdateCKItemQty(int item_id, decimal updated_ck_qty, int modified_by)
        {
            try
            {
                _context = new CKEntities();
                ckwh_items objCKWHItemToUpdate = (from ckwhitem in _context.ckwh_items where ckwhitem.Id == item_id select ckwhitem).SingleOrDefault();
                objCKWHItemToUpdate.ck_qty = updated_ck_qty;
                objCKWHItemToUpdate.modified_by = modified_by;
                objCKWHItemToUpdate.modified_date = DateTime.Now;
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

        public int UpdateCKItemAvgUnitCost(int item_id, decimal avg_unit_cost)
        {
            try
            {
                _context = new CKEntities();
                ckwh_items objCKWHItemToUpdate = (from ckwhitem in _context.ckwh_items where ckwhitem.Id == item_id select ckwhitem).SingleOrDefault();
                objCKWHItemToUpdate.ck_avg_unit_cost = avg_unit_cost;
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

        public decimal? GetCKAvgCost(int wh_item_id)
        {
            decimal? avg_cost = 0.0m;

            try
            {
                _context = new CKEntities();
                avg_cost = (from whitems in _context.ckwh_items where whitems.Id == wh_item_id select whitems.ck_avg_unit_cost).FirstOrDefault();
            }
            catch { return null; }

            return avg_cost;
        }
    }
}
