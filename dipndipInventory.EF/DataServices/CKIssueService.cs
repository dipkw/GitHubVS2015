using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dipndipInventory.EF.DataServices
{
    public class CKIssueService
    {
        CKEntities _context;
        public string GetNewCKIssueCode()
        {
            try
            {
                string new_issue_code = string.Empty;
                string last_issue_code = string.Empty;
                _context = new CKEntities();
                //var result = _context.ck_items.OrderByDescending(i => i.Id).FirstOrDefault().ck_item_code;
                var result = _context.ck_issue_master.OrderByDescending(i => i.Id).FirstOrDefault();
                if (result == null)
                {
                    return "CKIS-0001";
                }

                last_issue_code = ((ck_issue_master)result).ck_issue_code;
                string[] tmpIssueCode = last_issue_code.Split('-');

                new_issue_code = "CKIS-" + (Convert.ToInt32(tmpIssueCode[1]) + 1).ToString("D4");

                return new_issue_code;
            }
            catch (Exception e) { return string.Empty; }
        }
    }
}
