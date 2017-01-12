using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dipndipInventory.EF.DataServices
{
    public class CKWastageService
    {
        CKEntities _context;
        public int CreateWastage(ck_wastage_master wastage_master, List<ck_wastage_details> ck_wastage_detail_list)
        {
            //int result = 0;

            using (var context = new CKEntities())
            {
                using (var dbcxtrx = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.ck_wastage_master.Add(wastage_master);
                        foreach (var ck_wastage_detail in ck_wastage_detail_list)
                        {
                            ck_wastage_detail.wastage_master_id = wastage_master.Id;
                            context.ck_wastage_details.Add(ck_wastage_detail);
                        }
                        context.SaveChanges();
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
            //return result;
        }

        public IEnumerable<ck_wastage_details> ReadCKWastageDetailsByMasterId(long ckWastageMasterId)
        {
            try
            {
                _context = new CKEntities();
                IEnumerable<ck_wastage_details> objCKWastageDetails = (from ckwastagedetail in _context.ck_wastage_details where ckwastagedetail.wastage_master_id == ckWastageMasterId orderby ckwastagedetail.Id ascending select ckwastagedetail);
                return objCKWastageDetails;
            }
            catch
            {
                return null;
            }
        }

        public string GetNewCKWastageCode()
        {
            CKEntities _context;
            try
            {
                string new_ck_wst_code = string.Empty;
                string last_ck_wst_code = string.Empty;
                _context = new CKEntities();
                //var result = _context.ck_items.OrderByDescending(i => i.Id).FirstOrDefault().ck_item_code;
                var result = _context.ck_wastage_master.OrderByDescending(i => i.Id).FirstOrDefault();
                if (result == null)
                {
                    return "CWST-0001";
                }

                last_ck_wst_code = ((ck_wastage_master)result).ck_wastage_code;
                string[] tmpWstCode = last_ck_wst_code.Split('-');

                new_ck_wst_code = "CWST-" + (Convert.ToInt32(tmpWstCode[1]) + 1).ToString("D4");

                return new_ck_wst_code;
            }
            catch { return string.Empty; }

            //return "";
        }

        public int SaveCKWastage(List<ck_items> g_ck_items_update_list, List<ck_prod> g_ck_prod_update_list, ck_wastage_master g_ck_wastage_master, List<ck_wastage_details> g_ck_wastage_details, List<ck_stock_trans> g_ck_stock_trans_list, int active_user)
        {
            using (var context = new CKEntities())
            {
                using (var dbcxtrx = context.Database.BeginTransaction())
                {
                    try
                    {
                        //Update qty_on_hand in ck_items
                        foreach (ck_items ckitem in g_ck_items_update_list)
                        {
                            ck_items ck_item_to_update = (from ck_item in context.ck_items where ck_item.Id == ckitem.Id select ck_item).FirstOrDefault();
                            ck_item_to_update.qty_on_hand = ckitem.qty_on_hand;
                            ck_item_to_update.modified_by = active_user;
                            ck_item_to_update.modified_date = DateTime.Now;
                            context.SaveChanges();
                        }

                        //Update bal_qty in ck_prod
                        foreach (ck_prod ckprod in g_ck_prod_update_list)
                        {
                            //ck_prod ck_prod_to_update = (from ck_prod in context.ck_prod where ck_prod.Id == ckprod.Id select ck_prod).FirstOrDefault();
                            ck_prod ck_prod_to_update = (from ck_prod in context.ck_prod where (ck_prod.prod_code == ckprod.prod_code && ck_prod.batch_no == ckprod.batch_no) select ck_prod).FirstOrDefault();
                            ck_prod_to_update.bal_qty = ckprod.bal_qty;
                            ck_prod_to_update.modified_by = active_user;
                            ck_prod_to_update.modified_date = DateTime.Now;
                            context.SaveChanges();
                        }

                        //Update ck_wastage_master
                        context.ck_wastage_master.Add(g_ck_wastage_master);
                        //context.SaveChanges();
                        foreach (ck_wastage_details ckwastagedetail in g_ck_wastage_details)
                        {
                            ckwastagedetail.ck_wastage_master = g_ck_wastage_master;
                            //ckwastagedetail.ck_wastage_master.Id = g_ck_wastage_master.Id;
                            context.ck_wastage_details.Add(ckwastagedetail);
                            context.SaveChanges();
                        }

                        //Update ck_stock_trans
                        foreach (ck_stock_trans ckstocktrans in g_ck_stock_trans_list)
                        {
                            context.ck_stock_trans.Add(ckstocktrans);
                            context.SaveChanges();
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

        public IEnumerable<ck_wastage_reasons> GetActiveCKWastageReasons()
        {
            try
            {
                _context = new CKEntities();
                IEnumerable<ck_wastage_reasons> objReasons = (from reasons in _context.ck_wastage_reasons where reasons.active == true orderby reasons.Id descending select reasons);
                return objReasons;
            }
            catch
            {
                return null;
            }
        }

    }
}
