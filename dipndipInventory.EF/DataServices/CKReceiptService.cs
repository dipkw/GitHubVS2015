using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dipndipInventory.EF.DataServices
{
    public class CKReceiptService
    {
        CKEntities _context;

        public int CreateCKReceipt(receipt objCKReceipt)
        {
            try
            {
                _context = new CKEntities();
                _context.receipts.Add(objCKReceipt);
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

        public IEnumerable<receipt> ReadAllCKReceipts()
        {
            try
            {
                _context = new CKEntities();
                IEnumerable<receipt> objCKReceipts = (from ckreceipts in _context.receipts orderby ckreceipts.Id ascending select ckreceipts);
                return objCKReceipts;
            }
            catch
            {
                return null;
            }
        }

        public int UpdateCKReceipt(receipt objCKReceipt)
        {
            try
            {
                _context = new CKEntities();
                receipt objCKReceiptToUpdate = (from ckreceipt in _context.receipts where ckreceipt.Id == objCKReceipt.Id select ckreceipt).SingleOrDefault();
                objCKReceiptToUpdate.receipt_date = objCKReceipt.receipt_date;
                objCKReceiptToUpdate.issued_site = objCKReceipt.issued_site;
                objCKReceiptToUpdate.received_site = objCKReceipt.received_site;
                objCKReceiptToUpdate.modified_date = objCKReceipt.modified_date;
                objCKReceiptToUpdate.modified_by = objCKReceipt.modified_by;
                objCKReceiptToUpdate.active = objCKReceipt.active;
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

        public int DeleteReceipt(receipt objCKReceipt)
        {
            try
            {
                _context = new CKEntities();
                receipt objCKReceiptToDelete = (from ckreceipt in _context.receipts where ckreceipt.Id == objCKReceipt.Id select ckreceipt).Single();
                _context.receipts.Remove(objCKReceiptToDelete);
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

        public bool IsExistingCKReceipt(long ck_receipt_id)
        {
            bool _result = false;
            _context = new CKEntities();

            receipt objCKReceipt = (from ckreceipt in _context.receipts where ckreceipt.Id == ck_receipt_id select ckreceipt).FirstOrDefault();

            if (objCKReceipt != null)
            {
                _result = true;
            }

            return _result;
        }

        public bool IsExistingCKReceiptByReceiptNo(string ck_receipt_no)
        {
            bool _result = false;
            _context = new CKEntities();

            receipt objCKReceipt = (from ckreceipt in _context.receipts where string.Equals(ckreceipt.receipt_no, ck_receipt_no, StringComparison.OrdinalIgnoreCase) select ckreceipt).FirstOrDefault();

            if (objCKReceipt != null)
            {
                _result = true;
            }

            return _result;
        }

        public string GetNewCKReceiptNo()
        {
            try
            {
                string new_receipt_no = string.Empty;
                string last_receipt_no = string.Empty;
                _context = new CKEntities();
                //var result = _context.ck_items.OrderByDescending(i => i.Id).FirstOrDefault().ck_item_code;
                var result = _context.receipts.OrderByDescending(i => i.Id).FirstOrDefault();
                if (result == null)
                {
                    return "RCPT-0001";
                }

                last_receipt_no = ((receipt)result).receipt_no;
                string[] tmpItemCode = last_receipt_no.Split('-');

                new_receipt_no = "RCPT-" + (Convert.ToInt32(tmpItemCode[1]) + 1).ToString("D4");

                return new_receipt_no;
            }
            catch (Exception e) { return string.Empty; }
        }

        public receipt ReadCKReceiptByID(long? ID)
        {
            _context = new CKEntities();
            receipt objCKReceipt = (from ckreceipt in _context.receipts where ckreceipt.Id == ID select ckreceipt).FirstOrDefault();
            return objCKReceipt;
        }

        public receipt ReadCKReceiptByReceiptNo(string receipt_no)
        {
            _context = new CKEntities();
            receipt objCKReceipt = (from ckreceipt in _context.receipts where ckreceipt.receipt_no == receipt_no select ckreceipt).FirstOrDefault();
            return objCKReceipt;
        }

        public long GetLastCKReceiptId()
        {
            _context = new CKEntities();
            int ckReceiptId = 0;
            try
            {
                var maxCKReceiptId = (from ckorder in _context.orders select (ckorder.Id)).Max();

                ckReceiptId = Convert.ToInt32(maxCKReceiptId);
            }
            catch { }
            return ckReceiptId;
        }

        public IEnumerable<receipt> ReadAllActiveBranchReceipts(int site_id)
        {
            try
            {
                _context = new CKEntities();
                IEnumerable<receipt> objCKReceipts = (from ckreceipts in _context.receipts where ckreceipts.received_site == site_id orderby ckreceipts.Id ascending select ckreceipts);
                return objCKReceipts;
            }
            catch
            {
                return null;
            }
        }

        public IEnumerable<receipt> ReadAllActiveCKReceipts()
        {
            try
            {
                _context = new CKEntities();
                IEnumerable<receipt> objReceipts = (from ckreceipts in _context.receipts where ckreceipts.active == true orderby ckreceipts.Id ascending select ckreceipts);
                return objReceipts;
            }
            catch
            {
                return null;
            }
        }

        public IEnumerable<receipt> ReadAllActiveSiteReceipts(int site_id)
        {
            try
            {
                _context = new CKEntities();
                IEnumerable<receipt> objReceipts = (from ckreceipts in _context.receipts where (ckreceipts.active == true && (ckreceipts.issued_site == site_id || ckreceipts.received_site == site_id)) orderby ckreceipts.Id ascending select ckreceipts);
                return objReceipts;
            }
            catch
            {
                return null;
            }
        }

        //***************************** Receipt Details ****************************************

        public int CreateCKReceiptDetails(receipt_details objCKReceiptDetails)
        {
            try
            {
                _context = new CKEntities();
                _context.receipt_details.Add(objCKReceiptDetails);
                _context.SaveChanges();
                _context.Dispose();
            }
            catch (Exception e)
            {
                _context.Dispose();
                return 0;
            }
            return 1;
        }

        public IEnumerable<receipt_details> ReadAllCKReceiptDetails()
        {
            try
            {
                _context = new CKEntities();
                IEnumerable<receipt_details> objCKReceiptDetails = (from ckreceiptdetails in _context.receipt_details orderby ckreceiptdetails.Id ascending select ckreceiptdetails);
                return objCKReceiptDetails;
            }
            catch
            {
                return null;
            }
        }

        public int UpdateCKReceiptDetails(receipt_details objCKReceiptDetails)
        {
            try
            {
                _context = new CKEntities();
                receipt_details objCKReceiptDetailsToUpdate = (from ckreceiptdetails in _context.receipt_details where ckreceiptdetails.Id == objCKReceiptDetails.Id select ckreceiptdetails).SingleOrDefault();
                objCKReceiptDetailsToUpdate.receipt_id = objCKReceiptDetails.receipt_id;
                objCKReceiptDetailsToUpdate.receipt_no = objCKReceiptDetails.receipt_no;
                objCKReceiptDetailsToUpdate.wh_item_id = objCKReceiptDetails.wh_item_id;
                objCKReceiptDetailsToUpdate.wh_item_unit_id = objCKReceiptDetails.wh_item_unit_id;
                objCKReceiptDetailsToUpdate.qty_received = objCKReceiptDetails.qty_received;
                objCKReceiptDetailsToUpdate.active = objCKReceiptDetails.active;
                objCKReceiptDetailsToUpdate.modified_date = objCKReceiptDetails.modified_date;
                objCKReceiptDetailsToUpdate.modified_by = objCKReceiptDetails.modified_by;
                objCKReceiptDetailsToUpdate.active = objCKReceiptDetails.active;
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

        public int DeleteCKReceiptDetail(receipt_details objCKReceiptDetail)
        {
            try
            {
                _context = new CKEntities();
                receipt_details objCKReceiptDetailsToDelete = (from ckreceiptdetail in _context.receipt_details where ckreceiptdetail.Id == objCKReceiptDetail.Id select ckreceiptdetail).Single();
                _context.receipt_details.Remove(objCKReceiptDetailsToDelete);
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

        public IEnumerable<receipt_details> ReadCKReceiptDetailsByMasterId(long ckReceiptId)
        {
            try
            {
                _context = new CKEntities();
                //IEnumerable<Purchase_detail> objPurchaseDetails = (from purchasedetail in _rcontext.Purchase_details where purchasedetail.Purchase_master_id == purchaseMasterId orderby purchasedetail.Purchase_details_id descending select purchasedetail);
                IEnumerable<receipt_details> objCKReceiptDetails = (from ckreceiptdetail in _context.receipt_details where ckreceiptdetail.receipt_id == ckReceiptId orderby ckreceiptdetail.Id ascending select ckreceiptdetail);
                return objCKReceiptDetails;
            }
            catch
            {
                return null;
            }
        }

        public IEnumerable<receipt_details> ReadCKReceiptDetailsByReceiptNo(string receipt_no)
        {
            try
            {
                _context = new CKEntities();
                //IEnumerable<Purchase_detail> objPurchaseDetails = (from purchasedetail in _rcontext.Purchase_details where purchasedetail.Purchase_master_id == purchaseMasterId orderby purchasedetail.Purchase_details_id descending select purchasedetail);
                IEnumerable<receipt_details> objCKReceiptDetails = (from ckreceiptdetail in _context.receipt_details where ckreceiptdetail.receipt_no == receipt_no orderby ckreceiptdetail.Id ascending select ckreceiptdetail);
                 return objCKReceiptDetails;
            }
            catch
            {
                return null;
            }
        }

        public IEnumerable<receipt_details> ReadReceiptByOrderNo(string order_no)
        {
            try
            {
                //IEnumerable<receipt_details> ReceiptDetails = (from r in _context.receipt_details where r.receipt.order_no == order_no select new
                //{
                //    r.receipt.order.order_date,
                //    r.receipt.order.issue_date,
                //    r.receipt.order.receipt_date,
                //    r.Id,
                //    r.receipt_id,
                //    r.receipt_no,
                //    r.wh_item_id,
                //    r.wh_item_code,
                //    r.wh_item_description,
                //    r.wh_item_unit_id,
                //    r.ck_unit_description,
                //    r.qty_ordered,
                //    r.qty_received,
                //    r.qyt_returned,
                //    r.wh_item_unit_cost,
                //    r.wh_item_ext_cost,
                //    r.remarks,
                //    r.created_by,
                //    r.created_date,
                //    r.modified_by,
                //    r.modified_date,
                //    r.active
                //});
                IEnumerable<receipt_details> ReceiptDetails = (from r in _context.receipt_details
                                                               where r.receipt.order_no == order_no
                                                               select r);
                return ReceiptDetails;
            }
            catch { return null; }

        }

        public int UpdateReceivedQty(long receipt_id, decimal qty_received)
        {
            try
            {
                _context = new CKEntities();
                receipt_details objCKReceiptDetailsToUpdate = (from ckreceiptdetails in _context.receipt_details where ckreceiptdetails.receipt_id == receipt_id select ckreceiptdetails).SingleOrDefault();
                objCKReceiptDetailsToUpdate.qty_received = qty_received;
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

        //***************************** Receipt Details ****************************************


        //***************************** Receipt ************************************************

        public int CreateReceipt(receipt receipt_master, List<receipt_details> receipt_detail_list)
        {
            using (var context = new CKEntities())
            {
                using (var dbcxtrx = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.receipts.Add(receipt_master);
                        foreach (var receipt_detail in receipt_detail_list)
                        {
                            receipt_detail.receipt_id = receipt_master.Id;
                            receipt_detail.receipt_no = receipt_master.receipt_no;
                            context.receipt_details.Add(receipt_detail);
                        }
                        context.SaveChanges();
                        dbcxtrx.Commit();
                        return 1;
                    }
                    catch(Exception Ex)
                    {
                        dbcxtrx.Rollback();
                        return 0;
                    }
                }
            }
        }

        public int CreateReceipt1(receipt receipt_master, List<receipt_details> receipt_detail_list)
        {
            int result = 0;

            if (CreateCKReceipt(receipt_master) > 0)
            {
                foreach (var receipt_detail in receipt_detail_list)
                {
                    receipt_detail.receipt_id = receipt_master.Id;
                    receipt_detail.receipt_no = receipt_master.receipt_no;
                    result = CreateCKReceiptDetails(receipt_detail);
                }
            }

            // if result of create ck receipt details not >0 then
            // delete all items in receipt_details_list from receipt_details
            // then delete order with receipt_master.id

            return result;
        }
    }
}
