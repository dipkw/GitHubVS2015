using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dipndipInventory.EF.DataServices
{
    public class UserRoleService
    {
        CKEntities _context;
        public IEnumerable<user_roles> ReadAllActiveUserRoles()
        {
            try
            {
                _context = new CKEntities();
                IEnumerable<user_roles> objUserRoles = (from user_role in _context.user_roles orderby user_role.Id descending where user_role.active == true select user_role);
                return objUserRoles;
            }
            catch
            {
                return null;
            }
        }
    }
}
