using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dipndipInventory.EF.DataServices
{
    public class CKStockTransactionService
    {
        CKEntities _context;
        public ck_stock_trans ReadNProdTransaction(int skip_no)
        {
            try
            {
                _context = new CKEntities();
                ck_stock_trans objCKStockTransactionDetail = (from ckstocktrans in _context.ck_stock_trans where (ckstocktrans.trans_type == "Production" || ckstocktrans.trans_type == "AdjIn") orderby ckstocktrans.Id descending select ckstocktrans).Skip(skip_no).Take(1).FirstOrDefault();
                return objCKStockTransactionDetail;
            }
            catch
            {
                return null;
            }
        }
    }
}
