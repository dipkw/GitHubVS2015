using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dipndipInventory.EF.DataServices
{
    public class TransactionService
    {
        CKEntities _context;
        public int CreateTransaction(transaction_details objTransactionDetails)
        {
            try
            {
                _context = new CKEntities();
                _context.transaction_details.Add(objTransactionDetails);
                _context.SaveChanges();
                _context.Dispose();
            }
            catch(Exception e)
            {
                _context.Dispose();
                return 0;
            }
            return 1;
        }

        public IEnumerable<transaction_details> ReadAllTransactionDetails()
        {
            try
            {
                _context = new CKEntities();
                IEnumerable<transaction_details> objTransactionDetails = (from transaction_detail in _context.transaction_details orderby transaction_detail.Id descending select transaction_detail);
                return objTransactionDetails;
            }
            catch
            {
                return null;
            }
        }

        public int UpdateTransactionDetails(transaction_details objTransactionDetails)
        {
            try
            {
                _context = new CKEntities();
                transaction_details objTransactionToUpdate = (from transaction_detail in _context.transaction_details where transaction_detail.Id == objTransactionDetails.Id select transaction_detail).SingleOrDefault();
                objTransactionToUpdate.wh_item_id = objTransactionDetails.wh_item_id;
                objTransactionToUpdate.wh_item_code = objTransactionDetails.wh_item_code;
                objTransactionToUpdate.wh_item_description = objTransactionDetails.wh_item_description;
                objTransactionToUpdate.trans_date = objTransactionDetails.trans_date;
                objTransactionToUpdate.wh_item_unit_id = objTransactionDetails.wh_item_unit_id;
                objTransactionToUpdate.ck_unit_description = objTransactionDetails.ck_unit_description;
                objTransactionToUpdate.qty = objTransactionDetails.qty;
                objTransactionToUpdate.unit_cost = objTransactionDetails.unit_cost;
                objTransactionToUpdate.total_cost = objTransactionDetails.total_cost;
                objTransactionToUpdate.order_from_site_id = objTransactionDetails.order_from_site_id;
                objTransactionToUpdate.order_to_site_id = objTransactionDetails.order_to_site_id;
                objTransactionToUpdate.trans_type = objTransactionDetails.trans_type;
                objTransactionToUpdate.active = objTransactionDetails.active;
                objTransactionToUpdate.modified_by = objTransactionDetails.modified_by;
                objTransactionToUpdate.modified_date = objTransactionDetails.modified_date;

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

        public int DeleteTransactionDetails(transaction_details objTransactionDetails)
        {
            try
            {
                _context = new CKEntities();
                transaction_details objTransactionToDelete = (from transaction_detail in _context.transaction_details where transaction_detail.Id == objTransactionDetails.Id select transaction_detail).Single();
                _context.transaction_details.Remove(objTransactionToDelete);
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

        public IEnumerable<transaction_details> ReadReceiptTransactions()
        {
            try
            {
                _context = new CKEntities();
                IEnumerable<transaction_details> objTransactionDetails = (from transaction_detail in _context.transaction_details where transaction_detail.trans_type=="Receipt" orderby transaction_detail.Id descending select transaction_detail);
                return objTransactionDetails;
            }
            catch
            {
                return null;
            }
        }

        public transaction_details ReadNReceiptTransaction(int skip_no)
        {
            try
            {
                _context = new CKEntities();
                transaction_details objTransactionDetail = (from transaction_detail in _context.transaction_details where transaction_detail.trans_type == "Receipt" orderby transaction_detail.Id descending select transaction_detail).Skip(skip_no).Take(1).FirstOrDefault();
                return objTransactionDetail;
            }
            catch
            {
                return null;
            }
        }

        public IEnumerable<transaction_details> NewFunc(int qty)
        {
            decimal sum = 0.000m;
            //var query = col.TakeWhile(x => { var temp = sum; sum += x.Quantity; return temp < 500; });
            try
            {
                _context = new CKEntities();
                IEnumerable<transaction_details> objTransactionDetails = (from transaction_detail in _context.transaction_details where transaction_detail.trans_type == "Receipt" orderby transaction_detail.Id descending select transaction_detail);
                //IEnumerable<transaction_details> objTransactionDetails = _context.transaction_details.TakeWhile(x => { decimal temp = sum; sum += (x.qty); return temp <= qty; });
                //IEnumerable<transaction_details> objTransactionDetails = _context.transaction_details.TakeWhile(x => { decimal temp = sum; sum += (x.qty); return temp <= qty; });
                return objTransactionDetails;
            }
            catch
            {
                return null;
            }
        }
    }
}
