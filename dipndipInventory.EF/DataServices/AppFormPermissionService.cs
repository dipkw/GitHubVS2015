using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dipndipInventory.EF.DataServices
{
    public class AppFormPermissionService
    {
        CKEntities _context;
        public IEnumerable<app_form_permissions> ReadAppFormPermissions()
        {
            try
            {
                _context = new CKEntities();
                IEnumerable<app_form_permissions> objAppFormPermissions = (from app_form_permission in _context.app_form_permissions orderby app_form_permission.form_desc ascending  select app_form_permission);
                return objAppFormPermissions;
            }
            catch
            {
                return null;
            }
        }

        public app_form_permissions GetAppFormPermission(int role_id, int form_id)
        {
            try
            {
                _context = new CKEntities();
                app_form_permissions objAppFormPermissions = (from app_form_permission in _context.app_form_permissions where (app_form_permission.role_id == role_id && app_form_permission.form_id == form_id) orderby app_form_permission.form_desc ascending select app_form_permission).FirstOrDefault();
                return objAppFormPermissions;
            }
            catch
            { return null; }
        }

        public bool GetAppRoleFormPermission(int? role_id, int form_id, string permission)
        {
            bool permission_result = false;
            try
            {
                _context = new CKEntities();
                app_form_permissions objAppFormPermission = (from app_form_permission in _context.app_form_permissions where (app_form_permission.role_id == role_id && app_form_permission.form_id == form_id) orderby app_form_permission.form_desc ascending select app_form_permission).FirstOrDefault();
                if(objAppFormPermission == null)
                {
                    return false;
                }
                switch(permission)
                {
                    case "Create":
                        permission_result = (bool)objAppFormPermission.create_permission;
                        break;
                    case "Read":
                        permission_result = (bool)objAppFormPermission.read_permission;
                        break;
                    case "Update":
                        permission_result = (bool)objAppFormPermission.update_permission;
                        break;
                    case "Delete":
                        permission_result = (bool)objAppFormPermission.delete_permission;
                        break;
                    default:
                        return false;
                }
            }
            catch
            { return false; }
            return permission_result;
        }

        public bool GetAppRoleFormPermission(int? role_id, string form_desc, string permission)
        {
            bool permission_result = false;
            try
            {
                _context = new CKEntities();
                app_form_permissions objAppFormPermission = (from app_form_permission in _context.app_form_permissions where (app_form_permission.role_id == role_id && app_form_permission.form_desc == form_desc) orderby app_form_permission.form_desc ascending select app_form_permission).FirstOrDefault();
                if (objAppFormPermission == null)
                {
                    return false;
                }
                switch (permission)
                {
                    case "Create":
                        permission_result = (bool)objAppFormPermission.create_permission;
                        break;
                    case "Read":
                        permission_result = (bool)objAppFormPermission.read_permission;
                        break;
                    case "Update":
                        permission_result = (bool)objAppFormPermission.update_permission;
                        break;
                    case "Delete":
                        permission_result = (bool)objAppFormPermission.delete_permission;
                        break;
                    default:
                        return false;
                }
            }
            catch
            { return false; }
            return permission_result;
        }

        public int UpdateAppFormPermision(List<app_form_permissions> app_form_permission_list)
        {
            using (var context = new CKEntities())
            {
                using (var dbcxtrx = context.Database.BeginTransaction())
                {
                    try
                    {
                        foreach(app_form_permissions app_form_permission in app_form_permission_list)
                        {
                            int role_id = (int)app_form_permission.role_id;
                            int form_id = (int)app_form_permission.form_id;
                            app_form_permissions objAppFormPermission = (from appformpermission in context.app_form_permissions where (appformpermission.role_id == role_id && appformpermission.form_id == form_id) orderby appformpermission.form_desc ascending select appformpermission).FirstOrDefault();
                            //if (GetAppFormPermission((int)app_form_permission.role_id, (int)app_form_permission.form_id)==null)
                            if (objAppFormPermission == null)
                            {
                                context.app_form_permissions.Add(app_form_permission);
                                context.SaveChanges();
                            }
                            else
                            {
                                app_form_permissions app_form_permission_to_update = (from app_permission in context.app_form_permissions where (app_permission.role_id == role_id && app_permission.form_id == form_id) select app_permission).SingleOrDefault();
                                //app_form_permission_to_update.role_id = app_form_permission.role_id;
                                //app_form_permission_to_update.form_id = app_form_permission.form_id;
                                app_form_permission_to_update.form_desc = app_form_permission.form_desc;
                                app_form_permission_to_update.create_permission = app_form_permission.create_permission;
                                app_form_permission_to_update.read_permission = app_form_permission.read_permission;
                                app_form_permission_to_update.update_permission = app_form_permission.update_permission;
                                app_form_permission_to_update.delete_permission = app_form_permission.delete_permission;
                                app_form_permission_to_update.modified_by = app_form_permission.created_by;
                                app_form_permission_to_update.modified_date = app_form_permission.created_date; 
                                context.SaveChanges();
                            }
                        }
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
        }
    }
}
