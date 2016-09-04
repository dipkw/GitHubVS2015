using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dipndipInventory.EF.DataServices
{
    public class CKItemDetailService
    {
        CKEntities _context;

        public int CreateCKItemDetails(ck_item_details objCKItemDetails)
        {
            try
            {
                _context = new CKEntities();
                _context.ck_item_details.Add(objCKItemDetails);
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

        public IEnumerable<ck_item_details> ReadAllCKItemDetails()
        {
            try
            {
                _context = new CKEntities();
                IEnumerable<ck_item_details> objCKItemDetails = (from ckitemdetails in _context.ck_item_details orderby ckitemdetails.Id ascending select ckitemdetails);
                return objCKItemDetails;
            }
            catch
            {
                return null;
            }
        }

        public int UpdateCKItemDetails(ck_item_details objCKItemDetails)
        {
            try
            {
                _context = new CKEntities();
                //ck_users objUserToUpdate = new ck_users();
                ck_item_details objCKItemDetailsToUpdate = (from ckitemdetails in _context.ck_item_details where ckitemdetails.Id == objCKItemDetails.Id select ckitemdetails).SingleOrDefault();
                objCKItemDetailsToUpdate.ckwh_item_qty = objCKItemDetails.ckwh_item_qty;
                objCKItemDetailsToUpdate.ckwh_item_unit = objCKItemDetails.ckwh_item_unit;
                objCKItemDetailsToUpdate.ckwh_item_unit_id = objCKItemDetails.ckwh_item_unit_id;
                objCKItemDetailsToUpdate.modified_date = objCKItemDetails.modified_date;
                objCKItemDetailsToUpdate.modified_by = objCKItemDetails.modified_by;
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
    }
}
