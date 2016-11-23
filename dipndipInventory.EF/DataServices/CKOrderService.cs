using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dipndipInventory.EF.DataServices
{
    public class CKOrderService
    {
        CKEntities _context;

        public int CreateCKOrders(order objCKOrders)
        {
            try
            {
                _context = new CKEntities();
                _context.orders.Add(objCKOrders);
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

        public IEnumerable<order> ReadAllCKOrders()
        {
            try
            {
                _context = new CKEntities();
                IEnumerable<order> objCKOrders = (from ckorders in _context.orders orderby ckorders.Id ascending select ckorders);
                return objCKOrders;
            }
            catch
            {
                return null;
            }
        }

        public int UpdateCKOrder(order objCKOrder)
        {
            try
            {
                _context = new CKEntities();
                //ck_users objUserToUpdate = new ck_users();
                order objCKOrderToUpdate = (from ckorder in _context.orders where ckorder.Id == objCKOrder.Id select ckorder).SingleOrDefault();
                objCKOrderToUpdate.order_date = objCKOrder.order_date;
                objCKOrderToUpdate.order_from_site_id = objCKOrder.order_from_site_id;
                objCKOrderToUpdate.order_to_site_id = objCKOrder.order_to_site_id;
                objCKOrderToUpdate.modified_date = objCKOrder.modified_date;
                objCKOrderToUpdate.modified_by = objCKOrder.modified_by;
                objCKOrderToUpdate.active = objCKOrder.active;
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

        public int DeleteOrder(order objCKOrder)
        {
            try
            {
                _context = new CKEntities();
                order objCKOrderToDelete = (from ckorder in _context.orders where ckorder.Id == objCKOrder.Id select ckorder).Single();
                _context.orders.Remove(objCKOrderToDelete);
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

        public bool IsExistingCKOrder(long ck_order_id)
        {
            bool _result = false;
            _context = new CKEntities();

            order objCKOrder = (from ckorder in _context.orders where ckorder.Id == ck_order_id select ckorder).FirstOrDefault();

            if (objCKOrder != null)
            {
                _result = true;
            }

            return _result;
        }

        public bool IsExistingCKOrderByOrderNo(string ck_order_no)
        {
            bool _result = false;
            try
            {
                _context = new CKEntities();

                //order objCKOrder = (from ckorder in _context.orders where ckorder.order_no == ck_order_no select ckorder).FirstOrDefault();
                //order objCKOrder = (from ckorder in _context.orders where string.Equals(ckorder.order_no, ck_order_no, StringComparison.OrdinalIgnoreCase) select ckorder).FirstOrDefault();

                order objCKOrder = (from ckorder in _context.orders where ckorder.order_no == ck_order_no select ckorder).FirstOrDefault();

                if (objCKOrder != null)
                {
                    _result = true;
                }
            }
            catch(Exception ex)
            {

            }
            return _result;
        }

        public string GetNewCKOrderNo()
        {
            try
            {
                string new_order_no = string.Empty;
                string last_order_no = string.Empty;
                _context = new CKEntities();
                //var result = _context.ck_items.OrderByDescending(i => i.Id).FirstOrDefault().ck_item_code;
                var result = _context.orders.OrderByDescending(i => i.Id).FirstOrDefault();
                if (result == null)
                {
                    return "CKOR-0001";
                }

                last_order_no = ((order)result).order_no;
                string[] tmpItemCode = last_order_no.Split('-');

                new_order_no = "CKOR-" + (Convert.ToInt32(tmpItemCode[1]) + 1).ToString("D4");

                return new_order_no;
            }
            catch { return string.Empty; }
        }

        public order ReadCKOrderByID(long? ID)
        {
            _context = new CKEntities();
            order objCKOrder = (from ckorder in _context.orders where ckorder.Id == ID select ckorder).FirstOrDefault();
            return objCKOrder;
        }

        public long GetLastCKOrderId()
        {
            _context = new CKEntities();
            int ckOrderId = 0;
            try
            {
                var maxCKOrderId = (from ckorder in _context.orders select (ckorder.Id)).Max();

                ckOrderId = Convert.ToInt32(maxCKOrderId);
            }
            catch { }
            return ckOrderId;
        }

        public IEnumerable<order> ReadAllActiveBranchOrders(int site_id)
        {
            try
            {
                _context = new CKEntities();
                IEnumerable<order> objCKOrders = (from ckorders in _context.orders where ckorders.order_from_site_id == site_id orderby ckorders.Id ascending select ckorders);
                return objCKOrders;
            }
            catch
            {
                return null;
            }
        }

        public IEnumerable<order> ReadAllActiveCKOrders()
        {
            try
            {
                _context = new CKEntities();
                IEnumerable<order> objOrders = (from ckorders in _context.orders where ckorders.active == true orderby ckorders.Id ascending select ckorders);
                return objOrders;
            }
            catch
            {
                return null;
            }
        }

        public IEnumerable<order> ReadAllActiveSiteOrders(int site_id)
        {
            try
            {
                _context = new CKEntities();
                IEnumerable<order> objOrders = (from ckorders in _context.orders where (ckorders.active == true && (ckorders.order_from_site_id == site_id || ckorders.order_to_site_id == site_id)) orderby ckorders.Id descending select ckorders);
                return objOrders;
            }
            catch
            {
                return null;
            }
        }

        public int UpdateCKOrderStatus(long order_id, string order_status, DateTime issue_date, int user_id)
        {
            try
            {
                _context = new CKEntities();
                //ck_users objUserToUpdate = new ck_users();
                order objCKOrderToUpdate = (from ckorder in _context.orders where ckorder.Id == order_id select ckorder).SingleOrDefault();
                objCKOrderToUpdate.issue_date = issue_date;
                objCKOrderToUpdate.order_status = order_status;
                objCKOrderToUpdate.modified_by = user_id;
                objCKOrderToUpdate.modified_date = DateTime.Now;
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

        public int UpdateCKOrderReceiveStatus(long order_id, string order_status, DateTime receipt_date, int user_id)
        {
            try
            {
                _context = new CKEntities();
                //ck_users objUserToUpdate = new ck_users();
                order objCKOrderToUpdate = (from ckorder in _context.orders where ckorder.Id == order_id select ckorder).SingleOrDefault();
                objCKOrderToUpdate.receipt_date = receipt_date;
                objCKOrderToUpdate.order_status = order_status;
                objCKOrderToUpdate.modified_by = user_id;
                objCKOrderToUpdate.modified_date = DateTime.Now;
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

        public int UpdateCKOrderConfirmStatus(string order_no, string order_status, DateTime confirm_date, int user_id)
        {
            try
            {
                _context = new CKEntities();
                //ck_users objUserToUpdate = new ck_users();
                order objCKOrderToUpdate = (from ckorder in _context.orders where ckorder.order_no == order_no select ckorder).SingleOrDefault();
                objCKOrderToUpdate.confirm_date = confirm_date;
                objCKOrderToUpdate.order_status = order_status;
                objCKOrderToUpdate.modified_by = user_id;
                objCKOrderToUpdate.modified_date = DateTime.Now;
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


        //***************************** Order Details ****************************************


        public int CreateCKOrderDetails(order_details objCKOrderDetails)
        {
            try
            {
                _context = new CKEntities();
                _context.order_details.Add(objCKOrderDetails);
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

        public IEnumerable<order_details> ReadAllCKOrderDetails()
        {
            try
            {
                _context = new CKEntities();
                IEnumerable<order_details> objCKOrderDetails = (from ckorderdetails in _context.order_details orderby ckorderdetails.Id ascending select ckorderdetails);
                return objCKOrderDetails;
            }
            catch
            {
                return null;
            }
        }

        public int UpdateCKOrderDetails(order_details objCKOrderDetails)
        {
            try
            {
                _context = new CKEntities();
                //ck_users objUserToUpdate = new ck_users();
                order_details objCKOrderDetailsToUpdate = (from ckorderdetails in _context.order_details where ckorderdetails.Id == objCKOrderDetails.Id select ckorderdetails).SingleOrDefault();
                objCKOrderDetailsToUpdate.order_id = objCKOrderDetails.order_id;
                objCKOrderDetailsToUpdate.order_no = objCKOrderDetails.order_no;
                objCKOrderDetailsToUpdate.ckwh_item_id = objCKOrderDetails.ckwh_item_id;
                objCKOrderDetailsToUpdate.wh_item_unit_id = objCKOrderDetails.wh_item_unit_id;
                objCKOrderDetailsToUpdate.qty = objCKOrderDetails.qty;
                objCKOrderDetailsToUpdate.active = objCKOrderDetails.active;
                objCKOrderDetailsToUpdate.modified_date = objCKOrderDetails.modified_date;
                objCKOrderDetailsToUpdate.modified_by = objCKOrderDetails.modified_by;
                objCKOrderDetailsToUpdate.active = objCKOrderDetails.active;
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

        public int DeleteCKOrderDetail(order_details objCKOrderDetail)
        {
            try
            {
                _context = new CKEntities();
                order_details objCKOrderDetailsToDelete = (from ckorderdetail in _context.order_details where ckorderdetail.Id == objCKOrderDetail.Id select ckorderdetail).Single();
                _context.order_details.Remove(objCKOrderDetailsToDelete);
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

        public IEnumerable<order_details> ReadCKOrderDetailsByMasterId(long ckOrderId)
        {
            try
            {
                _context = new CKEntities();
                //IEnumerable<Purchase_detail> objPurchaseDetails = (from purchasedetail in _rcontext.Purchase_details where purchasedetail.Purchase_master_id == purchaseMasterId orderby purchasedetail.Purchase_details_id descending select purchasedetail);
                IEnumerable<order_details> objCKOrderDetails = (from ckorderdetail in _context.order_details where ckorderdetail.order_id == ckOrderId orderby ckorderdetail.Id ascending select ckorderdetail);
                return objCKOrderDetails;
            }
            catch
            {
                return null;
            }
        }

        public int UpdateIssuedQty(long order_detail_id, decimal qty_issued)
        {
            try
            {
                _context = new CKEntities();
                //order_details objCKOrderDetailsToUpdate = (from ckorderdetails in _context.order_details where ckorderdetails.order_id == order_id select ckorderdetails).FirstOrDefault();
                order_details objCKOrderDetailsToUpdate = (from ckorderdetails in _context.order_details where ckorderdetails.Id == order_detail_id select ckorderdetails).FirstOrDefault();
                objCKOrderDetailsToUpdate.qty_issued = qty_issued;
                _context.SaveChanges();

                _context.Dispose();
                return 1;
            }
            catch (Exception ex)
            {
                _context.Dispose();
                return 0;
            }
        }

        public int UpdateReceivedQty(long order_detail_id, decimal qty_received)
        {
            try
            {
                _context = new CKEntities();
                //order_details objCKOrderDetailsToUpdate = (from ckorderdetails in _context.order_details where ckorderdetails.order_id == order_id select ckorderdetails).SingleOrDefault();
                order_details objCKOrderDetailsToUpdate = (from ckorderdetails in _context.order_details where ckorderdetails.Id == order_detail_id select ckorderdetails).FirstOrDefault();
                objCKOrderDetailsToUpdate.qty_received = qty_received;
                _context.SaveChanges();

                _context.Dispose();
                return 1;
            }
            catch (Exception Ex)
            {
                _context.Dispose();
                return 0;
            }
        }

        //***************************** Order Details ****************************************


        //***************************** Order ************************************************

        public int CreateOrder(order order_master, List<order_details> order_detail_list)
        {
            //int result = 0;

            using (var context = new CKEntities())
            {
                using (var dbcxtrx = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.orders.Add(order_master);
                        foreach (var order_detail in order_detail_list)
                        {
                            //order_detail.order_id = order_master.Id;
                            //order_detail.order_no = order_master.order_no;
                            order_detail.order = order_master;
                            context.order_details.Add(order_detail);
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

        public int CreateOrder1(order order_master, List<order_details> order_detail_list)
        {
            int result = 0;

            if (CreateCKOrders(order_master) > 0)
            {
                foreach (var order_detail in order_detail_list)
                {
                    order_detail.order_id = order_master.Id;
                    order_detail.order_no = order_master.order_no;
                    result = CreateCKOrderDetails(order_detail);
                }
            }

            // if result of create ck order details not >0 then
            // delete all items in order_details_list from order_details
            // then delete order with order_master.id

            return result;
        }

        public int UpdateOrder(order order_master, List<order_details> order_detail_list)
        {
            using (var context = new CKEntities())
            {
                using (var dbcxtrx = context.Database.BeginTransaction())
                {
                    try
                    {
                        order objCKOrderToUpdate = (from ckorder in context.orders where ckorder.Id == order_master.Id select ckorder).SingleOrDefault();
                        objCKOrderToUpdate.order_date = order_master.order_date;
                        objCKOrderToUpdate.order_from_site_id = order_master.order_from_site_id;
                        objCKOrderToUpdate.order_to_site_id = order_master.order_to_site_id;
                        objCKOrderToUpdate.modified_date = order_master.modified_date;
                        objCKOrderToUpdate.modified_by = order_master.modified_by;
                        objCKOrderToUpdate.active = order_master.active;
                        //context.SaveChanges();
                        foreach (var order_detail in order_detail_list)
                        {
                            order_details objCKOrderDetailsToUpdate = (from ckorderdetails in context.order_details where ckorderdetails.Id == order_detail.Id select ckorderdetails).SingleOrDefault();
                            objCKOrderDetailsToUpdate.order_id = order_detail.order_id;
                            objCKOrderDetailsToUpdate.order_no = order_detail.order_no;
                            objCKOrderDetailsToUpdate.ckwh_item_id = order_detail.ckwh_item_id;
                            objCKOrderDetailsToUpdate.wh_item_unit_id = order_detail.wh_item_unit_id;
                            objCKOrderDetailsToUpdate.qty = order_detail.qty;
                            objCKOrderDetailsToUpdate.active = order_detail.active;
                            objCKOrderDetailsToUpdate.modified_date = order_detail.modified_date;
                            objCKOrderDetailsToUpdate.modified_by = order_detail.modified_by;
                            objCKOrderDetailsToUpdate.active = order_detail.active;
                            //context.SaveChanges();
                        }
                        context.SaveChanges();
                        dbcxtrx.Commit();
                        return 1;
                    }
                    catch (Exception Ex)
                    {
                        dbcxtrx.Rollback();
                        return 0;
                    }
                }
            }
        }

        public int UpdateOrder1(order order_master, List<order_details> order_detail_list)
        {
            int result = 0;

            if (UpdateCKOrder(order_master) > 0)
            {
                foreach (var order_detail in order_detail_list)
                {
                    result = UpdateCKOrderDetails(order_detail);
                }
            }

            return result;
        }

        public int DeleteOrder(order order_master, List<order_details> order_detail_list)
        {
            int result = 0;

            if (DeleteOrder(order_master) > 0)
            {
                foreach (var order_detail in order_detail_list)
                {
                    result = DeleteCKOrderDetail(order_detail);
                }
            }

            return result;
        }

        public IEnumerable<order_details> ReadCKOrderDetails(int order_id)
        {
            try
            {
                _context = new CKEntities();
                IEnumerable<order_details> objCKOrderDetails = (from ckorderdetails in _context.order_details where ckorderdetails.order_id == order_id orderby ckorderdetails.Id ascending select ckorderdetails);
                return objCKOrderDetails;
            }
            catch
            {
                return null;
            }
        }

        public int UpdateOrderStatus(long order_id, decimal qty_issued, string order_status, DateTime issue_date, int user_id)
        {
            int result = 0;

            if (UpdateIssuedQty(order_id, qty_issued) > 0)
            {
                result = UpdateCKOrderStatus(order_id, order_status, issue_date, user_id);
            }

            return result;
        }

        //***************************** Order Return ****************************************



        //***************************** Order Return ****************************************

        //***** Transaction *****

        public int SaveReceipt(order g_order_master, List<order_details> g_order_detail_list, List<transaction_details> g_transaction_detail_list, List<ckwh_items> g_ckwh_item_list, receipt g_receipt_master, List<receipt_details> g_receipt_detail_list, List<wh_item_cost_history> g_wh_item_cost_history_list)
        {
            using (var context = new CKEntities())
            {
                using (var dbcxtrx = context.Database.BeginTransaction())
                {
                    //Update qty_received in order_deails table
                    try
                    {
                        foreach (order_details orderDetail in g_order_detail_list)
                        {
                            order_details objCKOrderDetailsToUpdate = (from ckorderdetails in context.order_details where ckorderdetails.Id == orderDetail.Id select ckorderdetails).FirstOrDefault();
                            objCKOrderDetailsToUpdate.qty_received = orderDetail.qty_received;
                            objCKOrderDetailsToUpdate.modified_by = orderDetail.modified_by;
                            objCKOrderDetailsToUpdate.modified_date = orderDetail.modified_date;
                            context.SaveChanges();
                        }

                        //Create transaction in transaction_details table
                        foreach(transaction_details transactionDetail in g_transaction_detail_list)
                        {
                            context.transaction_details.Add(transactionDetail);
                            context.SaveChanges();
                        }
                        //Update ck_qty and ck_avg_unit_cost in ckwh_items
                        foreach(ckwh_items ckwh_item in g_ckwh_item_list)
                        {
                            ckwh_items objCKWHItemToUpdate = (from ckwhitem in context.ckwh_items where ckwhitem.Id == ckwh_item.Id select ckwhitem).SingleOrDefault();
                            objCKWHItemToUpdate.ck_qty = ckwh_item.ck_qty;
                            objCKWHItemToUpdate.ck_avg_unit_cost = ckwh_item.ck_avg_unit_cost;
                            objCKWHItemToUpdate.modified_by = ckwh_item.modified_by;
                            objCKWHItemToUpdate.modified_date = ckwh_item.modified_date;
                            context.SaveChanges();
                        }

                        //Create order and order_details
                        context.receipts.Add(g_receipt_master);
                        foreach (receipt_details receipt_detail in g_receipt_detail_list)
                        {
                            receipt_detail.receipt = g_receipt_master;
                            context.receipt_details.Add(receipt_detail);
                        }
                        context.SaveChanges();

                        //Create Warehouse Item Cost History if any
                        foreach(wh_item_cost_history whitemcosthistory in g_wh_item_cost_history_list)
                        {
                            context.wh_item_cost_history.Add(whitemcosthistory);
                            context.SaveChanges();
                        }

                        order objCKOrderToUpdate = (from ckorder in context.orders where ckorder.Id == g_order_master.Id select ckorder).SingleOrDefault();
                        objCKOrderToUpdate.receipt_date = g_order_master.receipt_date;
                        objCKOrderToUpdate.order_status = g_order_master.order_status;
                        objCKOrderToUpdate.modified_by = g_order_master.modified_by;
                        objCKOrderToUpdate.modified_date = g_order_master.modified_date;
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
        }
        //***** Transaction *****
    }
}
