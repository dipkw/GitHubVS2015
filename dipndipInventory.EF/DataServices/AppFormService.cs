using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dipndipInventory.EF.DataServices
{
    public class AppFormService
    {
        CKEntities _context;
        public IEnumerable<app_forms> GetAllAppForms()
        {
            try
            {
                _context = new CKEntities();
                IEnumerable<app_forms> objAppForms = (from app_form in _context.app_forms orderby app_form.form_desc ascending select app_form);
                return objAppForms;
            }
            catch
            {
                return null;
            }
        }
    }
}
