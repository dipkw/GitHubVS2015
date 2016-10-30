using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dipndipInventory.EF.DataServices
{
    public class CKProductionService
    {
        public int CreateCKProduction(ck_prod objCKProd)
        {
            using (var context = new CKEntities())
            {
                using (var dbcxtrx = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.ck_prod.Add(objCKProd);
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
    }
}
