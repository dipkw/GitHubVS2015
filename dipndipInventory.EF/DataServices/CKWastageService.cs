using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dipndipInventory.EF.DataServices
{
    public class CKWastageService
    {
        CKEntities _context;
        public int CreateWastage(ck_wastage_master wastage_master, List<ck_wastage_details> ck_wastage_detail_list)
        {
            //int result = 0;

            using (var context = new CKEntities())
            {
                using (var dbcxtrx = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.ck_wastage_master.Add(wastage_master);
                        foreach (var ck_wastage_detail in ck_wastage_detail_list)
                        {
                            ck_wastage_detail.wastage_master_id = wastage_master.Id;
                            context.ck_wastage_details.Add(ck_wastage_detail);
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

        public IEnumerable<ck_wastage_details> ReadCKWastageDetailsByMasterId(long ckWastageMasterId)
        {
            try
            {
                _context = new CKEntities();
                IEnumerable<ck_wastage_details> objCKWastageDetails = (from ckwastagedetail in _context.ck_wastage_details where ckwastagedetail.wastage_master_id == ckWastageMasterId orderby ckwastagedetail.Id ascending select ckwastagedetail);
                return objCKWastageDetails;
            }
            catch
            {
                return null;
            }
        }


    }
}
