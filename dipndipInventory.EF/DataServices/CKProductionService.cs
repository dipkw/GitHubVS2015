﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dipndipInventory.EF.DataServices
{
    public class CKProductionService
    {
        CKEntities _context;
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

        public IEnumerable<ck_prod> ReadAllProductions()
        {
            try
            {
                _context = new CKEntities();
                IEnumerable<ck_prod> objCKProductions = (from ckproductions in _context.ck_prod orderby ckproductions.prod_date ascending select ckproductions);
                return objCKProductions;
            }
            catch
            {
                return null;
            }
        }

        public IEnumerable<ck_prod> ReadAllDistinctProductions()
        {
            try
            {
                _context = new CKEntities();

                IEnumerable<ck_prod> objCKProductions = (from ckproductions in _context.ck_prod orderby ckproductions.prod_date ascending select ckproductions);

                return objCKProductions;
            }
            catch
            {
                return null;
            }
        }

        public IEnumerable<ck_prod> ReadCKProductionDetails(string prod_code)
        {
            _context = new CKEntities();
            IEnumerable<ck_prod> production_details = (from prod_detail in _context.ck_prod where prod_detail.prod_code == prod_code select prod_detail);
            return production_details;
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
        public int SaveCKItemProduction(List<ck_prod> production_list, List<ck_items> ck_items_list, List<ckwh_items> warehouse_items_list, List<ck_item_cost_history> ck_item_cost_list, List<ck_stock_trans> ck_stock_trans_list, List<transaction_details>transaction_detail_list, List<ck_prod_log> prod_log_list, int active_user)
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
                            //ckwh_item_to_update.wh_item_code = ckwh_item.wh_item_code;
                            ckwh_item_to_update.ck_qty = ckwh_item.ck_qty;
                            ckwh_item_to_update.modified_by = active_user;
                            ckwh_item_to_update.modified_date = DateTime.Now;
                            context.SaveChanges();
                        }

                        foreach(ck_stock_trans ckstocktrans in ck_stock_trans_list)
                        {
                            context.ck_stock_trans.Add(ckstocktrans);
                            context.SaveChanges();
                        }

                        foreach(transaction_details transactiondetail in transaction_detail_list)
                        {
                            context.transaction_details.Add(transactiondetail);
                            context.SaveChanges();
                        }

                        foreach(ck_prod_log ckprodlog in prod_log_list)
                        {
                            context.ck_prod_log.Add(ckprodlog);
                            context.SaveChanges();
                        }

                        if(ck_item_cost_list.Count>0)
                        {
                            foreach(ck_item_cost_history ck_item_cost in ck_item_cost_list)
                            {
                                context.ck_item_cost_history.Add(ck_item_cost);
                                context.SaveChanges();
                            }
                        }

                        dbcxtrx.Commit();
                        return 1;
                    }
                    catch(Exception ex)
                    {
                        dbcxtrx.Rollback();
                        return 0;
                    }
                }
            }
        }
        public int SaveCKItemProduction1(List<ck_prod> production_list, List<ck_items> ck_items_list, List<ckwh_items> warehouse_items_list, List<ck_item_cost_history> ck_item_cost_list, List<ck_stock_trans> ck_stock_trans_list, List<transaction_details> transaction_detail_list, int active_user)
        {
            using (var context = new CKEntities())
            {
                using (var dbcxtrx = context.Database.BeginTransaction())
                {
                    try
                    {
                        foreach (ck_prod prod_item in production_list)
                        {
                            context.ck_prod.Add(prod_item);
                            context.SaveChanges();
                        }

                        foreach (ck_items ck_item in ck_items_list)
                        {
                            ck_items ck_item_to_update = (from ckitem in context.ck_items where ckitem.Id == ck_item.Id select ckitem).SingleOrDefault();
                            ck_item_to_update.ck_item_unit_cost = ck_item.ck_item_unit_cost;
                            ck_item_to_update.qty_on_hand = ck_item.qty_on_hand;
                            ck_item_to_update.modified_by = active_user;
                            ck_item_to_update.modified_date = DateTime.Now;
                            context.SaveChanges();
                        }

                        foreach (ckwh_items ckwh_item in warehouse_items_list)
                        {
                            ckwh_items ckwh_item_to_update = (from ckwhitem in context.ckwh_items where ckwhitem.Id == ckwh_item.Id select ckwhitem).SingleOrDefault();
                            //ckwh_item_to_update.wh_item_code = ckwh_item.wh_item_code;
                            ckwh_item_to_update.ck_qty = ckwh_item.ck_qty;
                            ckwh_item_to_update.modified_by = active_user;
                            ckwh_item_to_update.modified_date = DateTime.Now;
                            context.SaveChanges();
                        }

                        foreach (ck_stock_trans ckstocktrans in ck_stock_trans_list)
                        {
                            context.ck_stock_trans.Add(ckstocktrans);
                            context.SaveChanges();
                        }

                        foreach (transaction_details transactiondetail in transaction_detail_list)
                        {
                            context.transaction_details.Add(transactiondetail);
                            context.SaveChanges();
                        }

                        if (ck_item_cost_list.Count > 0)
                        {
                            foreach (ck_item_cost_history ck_item_cost in ck_item_cost_list)
                            {
                                context.ck_item_cost_history.Add(ck_item_cost);
                                context.SaveChanges();
                            }
                        }

                        dbcxtrx.Commit();
                        return 1;
                    }
                    catch (Exception ex)
                    {
                        dbcxtrx.Rollback();
                        return 0;
                    }
                }
            }
        }

        public IEnumerable<ck_prod> GetAvailableBatchItems(string ck_item_code)
        {
            try
            {
                _context = new CKEntities();
                IEnumerable<ck_prod> ck_batch_items = (from ckprod in _context.ck_prod where (ckprod.ck_item_code == ck_item_code && ckprod.bal_qty>0) orderby ckprod.exp_date ascending select ckprod);
                return ck_batch_items;
            }
            catch
            {
                return null;
            }
        }

        public IEnumerable<ck_prod> GetAvailableBatchItemsByProductionDate(string ck_item_code)
        {
            try
            {
                _context = new CKEntities();
                IEnumerable<ck_prod> ck_batch_items = (from ckprod in _context.ck_prod where (ckprod.ck_item_code == ck_item_code && ckprod.bal_qty > 0) orderby ckprod.prod_date ascending select ckprod);
                return ck_batch_items;
            }
            catch
            {
                return null;
            }
        }

        public decimal GetCurrentCKItemBatchQty(string prod_code, string batch_no)
        {
            decimal ck_item_batch_qty = 0.000m;

            try
            {
                _context = new CKEntities();
                ck_item_batch_qty = (decimal)(from ckprod in _context.ck_prod where (ckprod.prod_code == prod_code && ckprod.batch_no == batch_no)select ckprod.bal_qty).FirstOrDefault();
            }
            catch (Exception e)
            {
                return 0.000m;
            }
            return ck_item_batch_qty;
        }

        //Update CK_Item (ck_item_code, ck_item_unit_cost, ck_item_qty_on_hand)

        //Update ckwh_item (wh_item_code/wh_item_id, ck_qty)

    }
}
