using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dipndipInventory.EF.DataServices
{
    public class CategoryService
    {
        CKEntities _context;
        public int CreateCategory1(ckwh_category objCategory)
        {
            try
            {
                _context = new CKEntities();
                _context.ckwh_category.Add(objCategory);
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

        public int CreateCategory(ckwh_category objCategory)
        {
            using (var context = new CKEntities())
            {
                using (var dbcxtrx = context.Database.BeginTransaction())
                {
                    try
                    {
                        _context.ckwh_category.Add(objCategory);
                        _context.SaveChanges();
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

        public IEnumerable<ckwh_category> ReadAllCategories()
        {
            try
            {
                _context = new CKEntities();
                IEnumerable<ckwh_category> objCategory = (from category in _context.ckwh_category orderby category.Id descending select category);
                return objCategory;
            }
            catch
            {
                return null;
            }
        }

        public int UpdateCategory1(ckwh_category objCategory)
        {
            try
            {
                _context = new CKEntities();
                //ck_users objUserToUpdate = new ck_users();
                ckwh_category objCategoryToUpdate = (from category in _context.ckwh_category where category.Id == objCategory.Id select category).SingleOrDefault();
                objCategoryToUpdate.category_name = objCategory.category_name;
                objCategoryToUpdate.modified_date = objCategory.modified_date;
                objCategoryToUpdate.modified_by = objCategory.modified_by;
                objCategoryToUpdate.active = objCategory.active;
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

        public int UpdateCategory(ckwh_category objCategory)
        {
            using (var context = new CKEntities())
            {
                using (var dbcxtrx = context.Database.BeginTransaction())
                {
                    try
                    {
                        ckwh_category objCategoryToUpdate = (from category in context.ckwh_category where category.Id == objCategory.Id select category).SingleOrDefault();
                        objCategoryToUpdate.category_name = objCategory.category_name;
                        objCategoryToUpdate.modified_date = objCategory.modified_date;
                        objCategoryToUpdate.modified_by = objCategory.modified_by;
                        objCategoryToUpdate.active = objCategory.active;
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
        public int DeleteCategory1(ckwh_category objCategory)
        {
            try
            {
                _context = new CKEntities();
                ckwh_category objCategoryToDelete = (from category in _context.ckwh_category where category.Id == objCategory.Id select category).Single();
                _context.ckwh_category.Remove(objCategoryToDelete);
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

        public int DeleteCategory(ckwh_category objCategory)
        {
            using (var context = new CKEntities())
            {
                using (var dbcxtrx = context.Database.BeginTransaction())
                {
                    try
                    {
                        ckwh_category objCategoryToDelete = (from category in context.ckwh_category where category.Id == objCategory.Id select category).Single();
                        context.ckwh_category.Remove(objCategoryToDelete);
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
        public bool IsExistingCategory(int category_id)
        {
            bool _result = false;
            _context = new CKEntities();

            ckwh_category objCategory = (from category in _context.ckwh_category where category.Id == category_id select category).FirstOrDefault();

            if (objCategory != null)
            {
                _result = true;
            }

            return _result;
        }


    }
}
