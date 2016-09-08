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
            catch(Exception ex)
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
                //objCKItemDetailsToUpdate.ckwh_item_unit = objCKItemDetails.ckwh_item_unit;
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

        public int UpdateCKItemRecipe(ck_item_details objCKItemDetails)
        {
            try
            {
                _context = new CKEntities();
                //ck_users objUserToUpdate = new ck_users();
                ck_item_details objCKItemDetailsToUpdate = (from ckitemdetails in _context.ck_item_details where ckitemdetails.Id == objCKItemDetails.Id select ckitemdetails).SingleOrDefault();
                objCKItemDetailsToUpdate.ckwh_item_qty = objCKItemDetails.ckwh_item_qty;
                //objCKItemDetailsToUpdate.ckwh_item_unit = objCKItemDetails.ckwh_item_unit;
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

        public bool IsExistingCKItemRecipeByCKItemId(int ck_item__id)
        {
            bool _result = false;
            _context = new CKEntities();

            ck_item_details objckitemDetail = (from ckitemdetail in _context.ck_item_details where ckitemdetail.ck_item_id == ck_item__id select ckitemdetail).FirstOrDefault();

            if (objckitemDetail != null)
            {
                _result = true;
            }

            return _result;
        }

        public bool IsExistingCKItemRecipe(int ck_item__id, int wh_item_id)
        {
            bool _result = false;
            _context = new CKEntities();

            ck_item_details objckitemDetail = (from ckitemdetail in _context.ck_item_details where (ckitemdetail.ck_item_id == ck_item__id && ckitemdetail.ckwh_item_id==wh_item_id) select ckitemdetail).FirstOrDefault();

            if (objckitemDetail != null)
            {
                _result = true;
            }

            return _result;
        }

        public int GetID(int ck_item__id, int wh_item_id)
        {
            int _result = 0;
            _context = new CKEntities();

            ck_item_details objckitemDetail = (from ckitemdetail in _context.ck_item_details where (ckitemdetail.ck_item_id == ck_item__id && ckitemdetail.ckwh_item_id == wh_item_id) select ckitemdetail).FirstOrDefault();

            if (objckitemDetail != null)
            {
                _result = objckitemDetail.Id;
            }

            return _result;
        }

        public int DeleteCKItemRecipeByCKItemId(int ck_item_id)
        {
            try
            {
                _context = new CKEntities();
                //wh_item_unit objWHItemUnitToDelete = (from whitemunit in _context.wh_item_unit where whitemunit.wh_item_id == wh_item_id select whitemunit).Single();
                IEnumerable<ck_item_details> objCKItemRecipesToDelete = (from ckitemrecipe in _context.ck_item_details where ckitemrecipe.ck_item_id == ck_item_id select ckitemrecipe);

                foreach (ck_item_details objCKItemRecipeToDelete in objCKItemRecipesToDelete)
                {
                    _context.ck_item_details.Remove(objCKItemRecipeToDelete);

                }
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

        public int DeleteCKItemRecipeByWHItemId(int wh_item_id)
        {
            try
            {
                _context = new CKEntities();
                //wh_item_unit objWHItemUnitToDelete = (from whitemunit in _context.wh_item_unit where whitemunit.wh_item_id == wh_item_id select whitemunit).Single();
                IEnumerable<ck_item_details> objCKItemRecipesToDelete = (from ckitemrecipe in _context.ck_item_details where ckitemrecipe.ckwh_item_id == wh_item_id select ckitemrecipe);

                foreach (ck_item_details objCKItemRecipeToDelete in objCKItemRecipesToDelete)
                {
                    _context.ck_item_details.Remove(objCKItemRecipeToDelete);

                }
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

        public int DeleteCKItemRecipeById(int id)
        {
            try
            {
                _context = new CKEntities();
                //wh_item_unit objWHItemUnitToDelete = (from whitemunit in _context.wh_item_unit where whitemunit.wh_item_id == wh_item_id select whitemunit).Single();
                ck_item_details objCKItemRecipeToDelete = (from ckitemrecipe in _context.ck_item_details where ckitemrecipe.Id == id select ckitemrecipe).FirstOrDefault();

                
                _context.ck_item_details.Remove(objCKItemRecipeToDelete);

               
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

        public IEnumerable<ck_item_details> ReadAllCKItemRecipeByCKItemId(int ck_item_id)
        {
            try
            {
                _context = new CKEntities();
                IEnumerable<ck_item_details> objCKItemRecipes = (from ckitemrecipes in _context.ck_item_details where ckitemrecipes.ck_item_id == ck_item_id orderby ckitemrecipes.Id descending select ckitemrecipes);
                return objCKItemRecipes;
            }
            catch
            {
                return null;
            }
        }
    }
}
