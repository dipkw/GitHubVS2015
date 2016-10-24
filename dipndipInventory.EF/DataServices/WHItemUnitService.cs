using dipndipInventory.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dipndipInventory.EF.DataServices
{
    public class WHItemUnitService
    {
        CKEntities _context;

        public int CreateWHItemUnit(wh_item_unit objWHItemUnit)
        {
            try
            {
                _context = new CKEntities();
                _context.wh_item_unit.Add(objWHItemUnit);
                _context.SaveChanges();
                _context.Dispose();
            }
            catch(Exception Ex)
            {
                _context.Dispose();
                return 0;
            }
            return 1;
        }

        public IEnumerable<wh_item_unit> ReadAllWHItemUnits()
        {
            try
            {
                _context = new CKEntities();
                IEnumerable<wh_item_unit> objWHItemUnits = (from whitemunits in _context.wh_item_unit orderby whitemunits.Id descending select whitemunits);
                return objWHItemUnits;
            }
            catch
            {
                return null;
            }
        }

        public IEnumerable<wh_item_unit> ReadAllWHItemUnitsByWHItemId(int wh_item_id)
        {
            try
            {
                _context = new CKEntities();
                IEnumerable<wh_item_unit> objWHItemUnits = (from whitemunits in _context.wh_item_unit where whitemunits.wh_item_id == wh_item_id orderby whitemunits.Id descending select whitemunits);
                return objWHItemUnits;
            }
            catch
            {
                return null;
            }
        }

        public int UpdateWHItemUnit(wh_item_unit objWHItemUnit)
        {
            try
            {
                _context = new CKEntities();
                //ck_users objUserToUpdate = new ck_users();
                wh_item_unit objWHItemUnitToUpdate = (from whitemunit in _context.wh_item_unit where whitemunit.Id == objWHItemUnit.Id select whitemunit).SingleOrDefault();
                objWHItemUnitToUpdate.wh_item_id = objWHItemUnit.wh_item_id;
                objWHItemUnitToUpdate.ck_unit_id = objWHItemUnit.ck_unit_id;
                objWHItemUnitToUpdate.cnv_factor = objWHItemUnit.cnv_factor;
                objWHItemUnitToUpdate.modified_date = objWHItemUnit.modified_date;
                objWHItemUnitToUpdate.modified_by = objWHItemUnit.modified_by;
                objWHItemUnitToUpdate.active = objWHItemUnit.active;
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

        public int DeleteWHItemUnit(wh_item_unit objWHItemUnit)
        {
            try
            {
                _context = new CKEntities();
                wh_item_unit objWHItemUnitToDelete = (from whitemunit in _context.wh_item_unit where whitemunit.Id == objWHItemUnit.Id select whitemunit).Single();
                _context.wh_item_unit.Remove(objWHItemUnitToDelete);
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

        public bool IsExistingWHItemUnit(int wh_item_id, int ck_unit_id)
        {
            bool _result = false;
            _context = new CKEntities();

            wh_item_unit objUnit = (from whitemunit in _context.wh_item_unit where (whitemunit.wh_item_id == wh_item_id && whitemunit.ck_unit_id == ck_unit_id) select whitemunit).FirstOrDefault();

            if (objUnit != null)
            {
                _result = true;
            }

            return _result;
        }

        public bool IsExistingWHItemUnit1(int wh_item_unit_id)
        {
            bool _result = false;
            _context = new CKEntities();

            wh_item_unit objUnit = (from whitemunit in _context.wh_item_unit where whitemunit.Id == wh_item_unit_id select whitemunit).FirstOrDefault();

            if (objUnit != null)
            {
                _result = true;
            }

            return _result;
        }

        public bool IsExistingWHItemUnitByWHItemId(int wh_item__id)
        {
            bool _result = false;
            _context = new CKEntities();

            wh_item_unit objwhitemUnit = (from whitemunit in _context.wh_item_unit where whitemunit.wh_item_id == wh_item__id select whitemunit).FirstOrDefault();

            if (objwhitemUnit != null)
            {
                _result = true;
            }

            return _result;
        }

        public int DeleteWHItemUnitByWHItemId(int wh_item_id)
        {
            try
            {
                _context = new CKEntities();
                //wh_item_unit objWHItemUnitToDelete = (from whitemunit in _context.wh_item_unit where whitemunit.wh_item_id == wh_item_id select whitemunit).Single();
                IEnumerable<wh_item_unit> objWHItemUnitsToDelete = (from whitemunit in _context.wh_item_unit where whitemunit.wh_item_id == wh_item_id select whitemunit);

                foreach (wh_item_unit objWHItemUnitToDelete in objWHItemUnitsToDelete)
                {
                    _context.wh_item_unit.Remove(objWHItemUnitToDelete);
                    
                }
                _context.SaveChanges();
                _context.Dispose();
                return 1;
            }
            catch(Exception e)
            {
                _context.Dispose();
                return 0;
            }
        }

        public int DeleteWHItemUnitById(int id)
        {
            try
            {
                _context = new CKEntities();
                IEnumerable<wh_item_unit> objWHItemUnitsToDelete = (from whitemunit in _context.wh_item_unit where whitemunit.Id == id select whitemunit);

                foreach (wh_item_unit objWHItemUnitToDelete in objWHItemUnitsToDelete)
                {
                    _context.wh_item_unit.Remove(objWHItemUnitToDelete);

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

        public decimal? GetConversionFactor(int id)
        {
            decimal? conv_factor = 0.0m;

            try
            {
                _context = new CKEntities();
                conv_factor = (from whitemunit in _context.wh_item_unit where whitemunit.Id == id select whitemunit.cnv_factor).FirstOrDefault();
            }
            catch { return null; }

            return conv_factor;
        }

        public decimal? GetConversionFactorByWHItemId(int item_id, int ck_unit_id)
        {
            decimal? conv_factor = 0.0m;

            try
            {
                _context = new CKEntities();
                conv_factor = (from whitemunit in _context.wh_item_unit where (whitemunit.wh_item_id == item_id && whitemunit.ck_unit_id == ck_unit_id) select whitemunit.cnv_factor).FirstOrDefault();
            }
            catch { return null; }

            return conv_factor;
        }

        public int? GetIdOfBaseUnit(int wh_item_id)
        {
            int? base_unit_id = 0;

            try
            {
                _context = new CKEntities();
                base_unit_id = (from whitemunit in _context.wh_item_unit where (whitemunit.cnv_factor == 1 && whitemunit.wh_item_id==wh_item_id) select whitemunit.Id).FirstOrDefault();
            }
            catch { return null; }

            return base_unit_id;
        }

        public int? GetCKUnitID(int wh_item_unit_id)
        {
            int? ck_unit_id = 0;

            try
            {
                _context = new CKEntities();
                ck_unit_id = (from whitemunit in _context.wh_item_unit where (whitemunit.Id == wh_item_unit_id) select whitemunit.ck_unit_id).FirstOrDefault();
            }
            catch { return null; }

            return ck_unit_id;
        }
    }
}
