using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dipndipInventory.EF.DataServices
{
    public class UnitService
    {
        CKEntities _context;

        public int CreateUnit(ck_units objUnit)
        {
            try
            {
                _context = new CKEntities();
                _context.ck_units.Add(objUnit);
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

        public IEnumerable<ck_units> ReadAllUnits()
        {
            try
            {
                _context = new CKEntities();
                IEnumerable<ck_units> objUnits = (from units in _context.ck_units orderby units.Id descending select units);
                return objUnits;
            }
            catch
            {
                return null;
            }
        }

        public int UpdateUnit(ck_units objUnit)
        {
            try
            {
                _context = new CKEntities();
                //ck_users objUserToUpdate = new ck_users();
                ck_units objUnitToUpdate = (from unit in _context.ck_units where unit.Id == objUnit.Id select unit).SingleOrDefault();
                objUnitToUpdate.unit_description = objUnit.unit_description;
                objUnitToUpdate.modified_date = objUnit.modified_date;
                objUnitToUpdate.modified_by = objUnit.modified_by;
                objUnitToUpdate.active = objUnit.active;
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

        public int DeleteUnit(ck_units objUnit)
        {
            try
            {
                _context = new CKEntities();
                ck_units objUnitToDelete = (from unit in _context.ck_units where unit.Id == objUnit.Id select unit).Single();
                _context.ck_units.Remove(objUnitToDelete);
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

        public bool IsExistingUnit(int unit_id)
        {
            bool _result = false;
            _context = new CKEntities();

            ck_units objUnit = (from unit in _context.ck_units where unit.Id == unit_id select unit).FirstOrDefault();

            if (objUnit != null)
            {
                _result = true;
            }

            return _result;
        }

    }
}
