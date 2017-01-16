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

        public string GetAppFormLockStatus(string form_id)
        {
            string lock_status = "open";
            try
            {
                _context = new CKEntities();
                //lock_status = (from app_form in _context.app_forms orderby app_form.form_desc ascending where app_form.form_id == form_id select app_form.locked).FirstOrDefault()==false?"open":"locked";
                app_forms appform = (from app_form in _context.app_forms orderby app_form.form_desc ascending where app_form.form_id == form_id select app_form).FirstOrDefault();
                if(appform.locked == false || appform.locked == null)
                {
                    lock_status = "open";
                }
                else
                {
                    lock_status = "locked";
                }
                return lock_status;
            }
            catch
            {
                return "open";
            }
        }

        public int SetAppFormLockStatus(string form_id, bool lock_status)
        {
            try
            {
                _context = new CKEntities();
                app_forms app_form_to_update = (from app_form in _context.app_forms orderby app_form.form_desc ascending where app_form.form_id == form_id select app_form).FirstOrDefault();
                //app_form_to_update.locked = lock_status;
                app_form_to_update.locked = false;
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
    }
}
