using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dipndipInventory.EF.DataServices
{
    public class CKIssueService
    {
        CKEntities _context;
        public string GetNewCKIssueCode()
        {
            try
            {
                string new_issue_code = string.Empty;
                string last_issue_code = string.Empty;
                _context = new CKEntities();
                //var result = _context.ck_items.OrderByDescending(i => i.Id).FirstOrDefault().ck_item_code;
                var result = _context.ck_issue_master.OrderByDescending(i => i.Id).FirstOrDefault();
                if (result == null)
                {
                    return "CKIS-0001";
                }

                last_issue_code = ((ck_issue_master)result).ck_issue_code;
                string[] tmpIssueCode = last_issue_code.Split('-');

                new_issue_code = "CKIS-" + (Convert.ToInt32(tmpIssueCode[1]) + 1).ToString("D4");

                return new_issue_code;
            }
            catch (Exception e) { return string.Empty; }
        }

        public IEnumerable<ck_issue_master> ReadAllCKBranchDelivery()
        {
            try
            {
                _context = new CKEntities();
                IEnumerable<ck_issue_master> objCKIssueMaster = (from ckdeliveries in _context.ck_issue_master orderby ckdeliveries.Id descending select ckdeliveries);
                return objCKIssueMaster;
            }
            catch
            {
                return null;
            }
        }

        public IEnumerable<ck_issue_master> ReadLast1KCKBranchDelivery()
        {
            try
            {
                _context = new CKEntities();
                IEnumerable<ck_issue_master> objCKIssueMaster = (from ckdeliveries in _context.ck_issue_master orderby ckdeliveries.Id descending select ckdeliveries).Take(1000);
                return objCKIssueMaster;
            }
            catch
            {
                return null;
            }
        }

        public IEnumerable<ck_issue_detais> GetBranchDeliveryByIssueCode(string ck_issue_code)
        {
            try
            {
                _context = new CKEntities();
                IEnumerable<ck_issue_detais> ck_issue_delivery_detaiil = (from ckdeliveries in _context.ck_issue_detais orderby ckdeliveries.Id ascending where ckdeliveries.ck_issue_code == ck_issue_code select ckdeliveries);
                return ck_issue_delivery_detaiil;
            }
            catch
            {
                return null;
            }
        }

        public ck_issue_master GetIssueMasterInfo(string ck_issue_code)
        {
            try
            {
                _context = new CKEntities();
                ck_issue_master ck_issue_master_info = (from ckissuemaster in _context.ck_issue_master where ckissuemaster.ck_issue_code == ck_issue_code select ckissuemaster).FirstOrDefault();
                return ck_issue_master_info;
            }
            catch
            {
                return null;
            }
        }

        public int SaveCKBranchIssue(List<ck_items> g_ck_items_update_list, List<ck_prod> g_ck_prod_update_list, ck_issue_master g_ck_issue_master, List<ck_issue_detais> g_ck_issue_details, List<ck_stock_trans> g_ck_stock_trans_list, int active_user)
        {
            using (var context = new CKEntities())
            {
                using (var dbcxtrx = context.Database.BeginTransaction())
                {
                    try
                    {
                        //Update qty_on_hand in ck_items
                        foreach(ck_items ckitem in g_ck_items_update_list)
                        {
                            ck_items ck_item_to_update = (from ck_item in context.ck_items where ck_item.Id == ckitem.Id select ck_item).FirstOrDefault();
                            ck_item_to_update.qty_on_hand = ckitem.qty_on_hand;
                            ck_item_to_update.modified_by = active_user;
                            ck_item_to_update.modified_date = DateTime.Now;
                            context.SaveChanges();
                        }

                        //Update bal_qty in ck_prod
                        foreach(ck_prod ckprod in g_ck_prod_update_list)
                        {
                            //ck_prod ck_prod_to_update = (from ck_prod in context.ck_prod where ck_prod.Id == ckprod.Id select ck_prod).FirstOrDefault();
                            ck_prod ck_prod_to_update = (from ck_prod in context.ck_prod where (ck_prod.prod_code == ckprod.prod_code && ck_prod.batch_no == ckprod.batch_no) select ck_prod).FirstOrDefault();
                            ck_prod_to_update.bal_qty = ckprod.bal_qty;
                            ck_prod_to_update.modified_by = active_user;
                            ck_prod_to_update.modified_date = DateTime.Now;
                            context.SaveChanges();
                        }

                        //Update ck_issue_master
                        context.ck_issue_master.Add(g_ck_issue_master);
                        foreach(ck_issue_detais ckissuedetail in g_ck_issue_details)
                        {
                            //ckissuedetail.ck_issue_master_id = g_ck_issue_master.Id;
                            ckissuedetail.ck_issue_master = g_ck_issue_master;
                            context.ck_issue_detais.Add(ckissuedetail);
                            context.SaveChanges();
                        }
                        
                        //Update ck_stock_trans
                        foreach(ck_stock_trans ckstocktrans in g_ck_stock_trans_list)
                        {
                            context.ck_stock_trans.Add(ckstocktrans);
                            context.SaveChanges();
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
    }
}
