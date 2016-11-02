using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dipndipInventory.EF.DataServices
{
    public class CKProductionService
    {
        public int CreateCKProduction(ck_prod objCKProd)
        {
            using (var context = new CKEntities())
            {
                using (var dbcxtrx = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.ck_prod.Add(objCKProd);
                        context.SaveChanges();
                        dbcxtrx.Commit();
                    }
                    catch
                    {
                        dbcxtrx.Rollback();
                        return 0;
                    }
                }
            }
            return 1;
        }

        public string GetNewProductionCode()
        {
            try
            {
                string new_prod_code = string.Empty;
                string last_prod_code = string.Empty;
                CKEntities _context = new CKEntities();
                var result = _context.ck_prod.OrderByDescending(i => i.Id).FirstOrDefault();
                if (result == null)
                {
                    return "CKPR-0001";
                }

                last_prod_code = ((ck_prod)result).prod_code;
                string[] tmpItemCode = last_prod_code.Split('-');

                new_prod_code = "CKPR-" + (Convert.ToInt32(tmpItemCode[1]) + 1).ToString("D4");

                return new_prod_code;
            }
            catch (Exception e) { return string.Empty; }
        }

        public int SaveProduction()
        {
            int result = 0;



            return result;
        }
        
        //Save Item Production (List<ck_prod>)
        public int SaveCKItemProduction(List<ck_prod> production_list, List<ck_items> ck_items_list, List<ckwh_items> warehouse_items_list, int active_user)
        {
            using (var context = new CKEntities())
            {
                using (var dbcxtrx = context.Database.BeginTransaction())
                {
                    try
                    {
                        foreach(ck_prod prod_item in production_list)
                        {
                            context.ck_prod.Add(prod_item);
                            context.SaveChanges();
                        }

                        foreach(ck_items ck_item in ck_items_list)
                        {
                            ck_items ck_item_to_update = (from ckitem in context.ck_items where ckitem.Id == ck_item.Id select ckitem).SingleOrDefault();
                            ck_item_to_update.ck_item_unit_cost = ck_item.ck_item_unit_cost;
                            ck_item_to_update.qty_on_hand = ck_item.qty_on_hand;
                            ck_item_to_update.modified_by = active_user;
                            ck_item_to_update.modified_date = DateTime.Now;
                            context.SaveChanges();
                        }

                        foreach(ckwh_items ckwh_item in warehouse_items_list)
                        {
                            ckwh_items ckwh_item_to_update = (from ckwhitem in context.ckwh_items where ckwhitem.Id == ckwh_item.Id select ckwhitem).SingleOrDefault();
                            ckwh_item_to_update.wh_item_code = ckwh_item.wh_item_code;
                            ckwh_item_to_update.ck_qty = ckwh_item.ck_qty;
                            ckwh_item_to_update.modified_by = active_user;
                            ckwh_item_to_update.modified_date = DateTime.Now;
                            context.SaveChanges();
                        }
                        dbcxtrx.Commit();
                        return 1;
                    }
                    catch
                    {
                        dbcxtrx.Rollback();
                        return 0;
                    }
                }
            }
        }
        
        //Update CK_Item (ck_item_code, ck_item_unit_cost, ck_item_qty_on_hand)

        //Update ckwh_item (wh_item_code/wh_item_id, ck_qty)

    }
}
