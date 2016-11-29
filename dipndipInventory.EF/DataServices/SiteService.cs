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
                IEnumerable<site> objSite = (from tmpsite in _context.sites orderby tmpsite.site_name ascending select tmpsite);
                return objSite;
            }
            catch
            {
                return null;
            }
        }

        public IEnumerable<site> ReadAllActiveSites()
        {
            try
            {
                _context = new CKEntities();
                IEnumerable<site> objSite = (from tmpsite in _context.sites where tmpsite.active==true orderby tmpsite.site_name ascending select tmpsite);
                return objSite;
            }
            catch
            {
                return null;
            }
        }

        public IEnumerable<site> ReadAllActiveOutletSites()
        {
            try
            {
                _context = new CKEntities();
                IEnumerable<site> objSite = (from tmpsite in _context.sites where (tmpsite.active == true && tmpsite.is_outlet == true) orderby tmpsite.site_name ascending select tmpsite);
                return objSite;
            }
            catch
            {
                return null;
            }
        }

        public IEnumerable<site> ReadWHCKSites()
        {
            try
            {
                _context = new CKEntities();
                IEnumerable<site> objSite = (from tmpsite in _context.sites where (tmpsite.site_id == "CK" || tmpsite.site_id == "WH") orderby tmpsite.site_name ascending select tmpsite);
                return objSite;
            }
            catch
            {
                return null;
            }
        }
        public IEnumerable<site> ReadAllActiveSitesWOActiveSite(int active_site_id)
        {
            try
            {
                _context = new CKEntities();
                IEnumerable<site> objSite = (from tmpsite in _context.sites where (tmpsite.active == true && tmpsite.Id!=active_site_id) orderby tmpsite.site_name ascending select tmpsite);
                return objSite;
            }
            catch
            {
                return null;
            }
        }

        public IEnumerable<site> ReadAllSitesSortByIdDesc()
        {
            try
            {
                _context = new CKEntities();
                IEnumerable<site> objSite = (from tmpsite in _context.sites orderby tmpsite.Id descending select tmpsite);
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
                site objSiteToUpdate = (from tmpsite in _context.sites where tmpsite.Id == objSite.Id select tmpsite).SingleOrDefault();
                objSiteToUpdate.site_name = objSite.site_name;
                objSiteToUpdate.is_outlet = objSite.is_outlet;
                objSiteToUpdate.active = objSite.active;
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
                site objSiteToDelete = (from tmpsite in _context.sites where tmpsite.Id == objSite.Id select tmpsite).Single();
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

            site objSite = (from tmpsite in _context.sites where tmpsite.Id == site_id select tmpsite).FirstOrDefault();

            if (objSite != null)
            {
                _result = true;
            }

            return _result;
        }

        public int GetSiteIDBySiteName(string site_name)
        {
            int site_id = 0;

            _context = new CKEntities();

            site_id = (from tmpsite in _context.sites where tmpsite.site_name == site_name select tmpsite.Id).FirstOrDefault();

            return site_id;
        }

        public string GetSiteCodeBySiteId(int id)
        {
            string site_code = string.Empty;

            _context = new CKEntities();

            site_code = (from tmpsite in _context.sites where tmpsite.Id == id select tmpsite.site_id).FirstOrDefault();

            return site_code;
        }

        public int GetSiteIdBySiteCode(string site_code)
        {
            int site_id = 0;

            _context = new CKEntities();

            site_id = (from tmpsite in _context.sites where tmpsite.site_id == site_code select tmpsite.Id).FirstOrDefault();

            return site_id;
        }
    }
}
