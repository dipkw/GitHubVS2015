using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dipndipInventory.EF.DataServices
{
    public class ReasonService
    {
        CKEntities _context;
        public int CreateReason(reason_codes objReason)
        {
            try
            {
                _context = new CKEntities();
                _context.reason_codes.Add(objReason);
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

        public IEnumerable<reason_codes> ReadAllReasons()
        {
            try
            {
                _context = new CKEntities();
                IEnumerable<reason_codes> objReasons = (from reasons in _context.reason_codes orderby reasons.Id descending select reasons);
                return objReasons;
            }
            catch
            {
                return null;
            }
        }

        public int UpdateReason(reason_codes objReason)
        {
            try
            {
                _context = new CKEntities();
                reason_codes objReasonToUpdate = (from reasons in _context.reason_codes where reasons.Id == objReason.Id select reasons).SingleOrDefault();
                objReasonToUpdate.description = objReason.description;
                objReasonToUpdate.active = objReason.active;
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

        public int DeleteReason(reason_codes objReason)
        {
            try
            {
                _context = new CKEntities();
                reason_codes objReasonToDelete = (from reasons in _context.reason_codes where reasons.Id == objReason.Id select reasons).Single();
                _context.reason_codes.Remove(objReasonToDelete);
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

        public IEnumerable<reason_codes> ReadAllActiveReasons()
        {
            try
            {
                _context = new CKEntities();
                IEnumerable<reason_codes> objReasons = (from reasons in _context.reason_codes where reasons.active==true orderby reasons.Id descending select reasons);
                return objReasons;
            }
            catch
            {
                return null;
            }
        }
    }
}
