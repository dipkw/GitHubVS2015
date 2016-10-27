using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dipndipInventory.EF.DataServices
{
    public class CKItemUnitService
    {
        public int CreateCKItemUnit(ck_item_unit objCKItemUnit)
        {
            using (var context = new CKEntities())
            {
                using (var dbcxtrx = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.ck_item_unit.Add(objCKItemUnit);
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

        public IEnumerable<ck_item_unit> ReadAllCKItemUnits()
        {
            using (var context = new CKEntities())
            {
                try
                {
                    IEnumerable<ck_item_unit> objCKItemUnits = (from ckitemunits in context.ck_item_unit orderby ckitemunits.Id descending select ckitemunits);
                    return objCKItemUnits;
                }
                catch
                {
                    return null;
                }
            }
        }


        public IEnumerable<ck_item_unit> ReadAllCKItemUnitsByCKItemId(int ck_item_id)
        {
            try
            {
                CKEntities _context = new CKEntities();
                IEnumerable<ck_item_unit> objCKItemUnits = (from ckitemunits in _context.ck_item_unit where ckitemunits.ck_item_id == ck_item_id orderby ckitemunits.Id descending select ckitemunits);
                return objCKItemUnits;
            }
            catch
            {
                return null;
            }
        }

        public IEnumerable<ck_item_unit> ReadAllCKItemUnitsByCKItemId1(int ck_item_id)
        {
            IEnumerable<ck_item_unit> objCKItemUnits;
            using (var context = new CKEntities())
            {
                try
                {
                    objCKItemUnits = (from ckitemunits in context.ck_item_unit where ckitemunits.ck_item_id == ck_item_id orderby ckitemunits.Id descending select ckitemunits);
                    return objCKItemUnits;
                }
                catch
                {
                    return null;
                }
            }
        }

        public int UpdateCKItemUnit(ck_item_unit objCKItemUnit)
        {
            using (var context = new CKEntities())
            {
                using (var dbcxtrx = context.Database.BeginTransaction())
                {
                    try
                    {
                        ck_item_unit objCKItemUnitToUpdate = (from ckitemunit in context.ck_item_unit where ckitemunit.Id == objCKItemUnit.Id select ckitemunit).SingleOrDefault();
                        objCKItemUnitToUpdate.ck_item_id = objCKItemUnit.ck_item_id;
                        objCKItemUnitToUpdate.ck_unit_id = objCKItemUnit.ck_unit_id;
                        objCKItemUnitToUpdate.cnv_factor = objCKItemUnit.cnv_factor;
                        objCKItemUnitToUpdate.modified_date = objCKItemUnit.modified_date;
                        objCKItemUnitToUpdate.modified_by = objCKItemUnit.modified_by;
                        objCKItemUnitToUpdate.active = objCKItemUnit.active;
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

        public int DeleteCKItemUnit(ck_item_unit objCKItemUnit)
        {
            using (var context = new CKEntities())
            {
                using (var dbcxtrx = context.Database.BeginTransaction())
                {
                    try
                    {
                        ck_item_unit objCKItemUnitToDelete = (from ckitemunit in context.ck_item_unit where ckitemunit.Id == objCKItemUnit.Id select ckitemunit).Single();
                        context.ck_item_unit.Remove(objCKItemUnitToDelete);
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

        public bool IsExistingCKItemUnit(int ck_item_id, int ck_unit_id)
        {
            bool result = false;
            using (var context = new CKEntities())
            {
                try
                {
                    ck_item_unit objUnit = (from ckitemunit in context.ck_item_unit where (ckitemunit.ck_item_id == ck_item_id && ckitemunit.ck_unit_id == ck_unit_id) select ckitemunit).FirstOrDefault();

                    if (objUnit != null)
                    {
                        result = true;
                    }
                }
                catch
                {
                    result = false;
                }
            }
            return result; 
        }

        public bool IsExistingCKItemUnitByCKItemId(int ck_item__id)
        {
            bool result = false;
            try
            {
                CKEntities context = new CKEntities();
                ck_item_unit objckitemUnit = (from ckitemunit in context.ck_item_unit where ckitemunit.ck_item_id == ck_item__id select ckitemunit).FirstOrDefault();
                if (objckitemUnit != null)
                {
                    result = true;
                }
            }
            catch
            {
                result = false;
            }
            return result;
        }
        public bool IsExistingCKItemUnitByCKItemId1(int ck_item__id)
        {
            bool result = false;
            using (var context = new CKEntities())
            {
                try
                {
                    ck_item_unit objckitemUnit = (from ckitemunit in context.ck_item_unit where ckitemunit.ck_item_id == ck_item__id select ckitemunit).FirstOrDefault();

                    if (objckitemUnit != null)
                    {
                        result = true;
                    }
                }
                catch
                {
                    result = false;
                }
            }
            return result;
        }

        public int DeleteCKItemUnitByCKItemId(int ck_item_id)
        {
            using (var context = new CKEntities())
            {
                using (var dbcxtrx = context.Database.BeginTransaction())
                {
                    try
                    {
                        IEnumerable<ck_item_unit> objCKItemUnitsToDelete = (from ckitemunit in context.ck_item_unit where ckitemunit.ck_item_id == ck_item_id select ckitemunit);

                        foreach (ck_item_unit objCKItemUnitToDelete in objCKItemUnitsToDelete)
                        {
                            context.ck_item_unit.Remove(objCKItemUnitToDelete);

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
        }

        public int DeleteCKItemUnitById(int id)
        {
            using (var context = new CKEntities())
            {
                using (var dbcxtrx = context.Database.BeginTransaction())
                {
                    try
                    {
                        IEnumerable<ck_item_unit> objCKItemUnitsToDelete = (from ckitemunit in context.ck_item_unit where ckitemunit.Id == id select ckitemunit);

                        foreach (ck_item_unit objCKItemUnitToDelete in objCKItemUnitsToDelete)
                        {
                            context.ck_item_unit.Remove(objCKItemUnitToDelete);

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
        }

        public decimal? GetConversionFactor(int id)
        {
            decimal? conv_factor = 0.000m;
            try
            {
                CKEntities context = new CKEntities();
                conv_factor = (from ckitemunit in context.ck_item_unit where ckitemunit.Id == id select ckitemunit.cnv_factor).FirstOrDefault();
            }
            catch
            {
                return null;
            }
            return conv_factor;
        }
        public decimal? GetConversionFactor1(int id)
        {
            decimal? conv_factor = 0.0m;
            using (var context = new CKEntities())
            {
                try
                {
                    conv_factor = (from ckitemunit in context.ck_item_unit where ckitemunit.Id == id select ckitemunit.cnv_factor).FirstOrDefault();
                }
                catch
                {
                    return null;
                }
            }
            return conv_factor;
        }

        public decimal? GetConversionFactorByCKItemId(int ck_item_id, int ck_unit_id)
        {
            decimal? conv_factor = 0.000m;
            try
            {
                CKEntities context = new CKEntities();
                conv_factor = (from ckitemunit in context.ck_item_unit where (ckitemunit.ck_item_id == ck_item_id && ckitemunit.ck_unit_id == ck_unit_id) select ckitemunit.cnv_factor).FirstOrDefault();
            }
            catch
            {
                return null;
            }
            return conv_factor;
        }
        public decimal? GetConversionFactorByCKItemId1(int ck_item_id, int ck_unit_id)
        {
            decimal? conv_factor = 0.0m;
            using (var context = new CKEntities())
            {
                try
                {
                    conv_factor = (from ckitemunit in context.ck_item_unit where (ckitemunit.ck_item_id == ck_item_id && ckitemunit.ck_unit_id == ck_unit_id) select ckitemunit.cnv_factor).FirstOrDefault();
                }
                catch
                {
                    return null;
                }
            }
            return conv_factor;
        }

        public int? GetIdOfBaseUnit(int ck_item_id)
        {
            int? base_unit_id = 0;
            try
            {
                CKEntities context = new CKEntities();
                base_unit_id = (from ckitemunit in context.ck_item_unit where (ckitemunit.cnv_factor == 1 && ckitemunit.ck_item_id == ck_item_id) select ckitemunit.Id).FirstOrDefault();
            }
            catch
            {
                return null;
            }
            return base_unit_id;
        }
        public int? GetIdOfBaseUnit1(int ck_item_id)
        {
            int? base_unit_id = 0;
            using (var context = new CKEntities())
            {
                try
                {
                    base_unit_id = (from ckitemunit in context.ck_item_unit where (ckitemunit.cnv_factor == 1 && ckitemunit.ck_item_id == ck_item_id) select ckitemunit.Id).FirstOrDefault();
                }
                catch
                {
                    return null;
                }
            }
            return base_unit_id;
        }

        public int? GetCKUnitID(int ck_item_unit_id)
        {
            int? ck_unit_id = 0;
            try
            {
                CKEntities context = new CKEntities();
                ck_unit_id = (from ckitemunit in context.ck_item_unit where (ckitemunit.Id == ck_item_unit_id) select ckitemunit.ck_unit_id).FirstOrDefault();
            }
            catch
            {
                return null;
            }
            return ck_unit_id;
        }

        public int? GetCKUnitID1(int ck_item_unit_id)
        {
            int? ck_unit_id = 0;
            using (var context = new CKEntities())
            {
                try
                {
                    ck_unit_id = (from ckitemunit in context.ck_item_unit where (ckitemunit.Id == ck_item_unit_id) select ckitemunit.ck_unit_id).FirstOrDefault();
                }
                catch
                {
                    return null;
                }
            }
            return ck_unit_id;
        }
    }
}
