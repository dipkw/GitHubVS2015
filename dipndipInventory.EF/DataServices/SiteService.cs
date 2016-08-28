using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dipndipInventory.EF.DataServices
{
    public class SiteService
    {
        CKEntities _context;
        public int CreateSite(site objSite)
        {
            try
            {
                _context = new CKEntities();
                _context.sites.Add(objSite);
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

        public IEnumerable<site> ReadAllSites()
        {
            try
            {
                _context = new CKEntities();
                IEnumerable<site> objSite = (from site in _context.sites orderby site.Id descending select site);
                return objSite;
            }
            catch
            {
                return null;
            }
        }

        public int UpdateSite(site objSite)
        {
            try
            {
                _context = new CKEntities();
                //ck_users objUserToUpdate = new ck_users();
                site objSiteToUpdate = (from site in _context.sites where site.Id == objSite.Id select site).SingleOrDefault();
                objSiteToUpdate.site_name = objSite.site_name;
                objSiteToUpdate.modified_date = objSite.modified_date;
                objSiteToUpdate.modified_by = objSite.modified_by;
                objSiteToUpdate.active = objSite.active;
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

        public int DeleteSite(site objSite)
        {
            try
            {
                _context = new CKEntities();
                site objSiteToDelete = (from site in _context.sites where site.Id == objSite.Id select site).Single();
                _context.sites.Remove(objSiteToDelete);
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

        public bool IsExistingSite(int site_id)
        {
            bool _result = false;
            _context = new CKEntities();

            site objSite = (from site in _context.sites where site.Id == site_id select site).FirstOrDefault();

            if (objSite != null)
            {
                _result = true;
            }

            return _result;
        }


    }
}
