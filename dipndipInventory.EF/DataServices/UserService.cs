using dipndipInventory.EF.CustomModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dipndipInventory.EF.DataServices
{
    public class UserService
    {
        CKEntities _context;

        public int CreateUser(ck_users objUser)
        {
            try
            {
                _context = new CKEntities();
                _context.ck_users.Add(objUser);
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

        public IEnumerable<ck_users> ReadAllUsers()
        {
            try
            {
                _context = new CKEntities();
                IEnumerable<ck_users> objUsers = (from user in _context.ck_users orderby user.Id descending select user);
                return objUsers;
            }
            catch
            {
                return null;
            }
        }

        public int UpdateUser(ck_users objUser)
        {
            try
            {
                _context = new CKEntities();
                //ck_users objUserToUpdate = new ck_users();
                ck_users objUserToUpdate = (from user in _context.ck_users where user.Id == objUser.Id select user).SingleOrDefault();
                objUserToUpdate.uname = objUser.uname;
                objUserToUpdate.password = objUser.password;
                objUserToUpdate.role = objUser.role;

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

        public int DeleteUser(ck_users objUser)
        {
            try
            {
                _context = new CKEntities();
                ck_users objUserToDelete = (from user in _context.ck_users where user.Id == objUser.Id select user).Single();
                _context.ck_users.Remove(objUserToDelete);
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

        public bool IsExistingUser(string username)
        {
            bool _result = false;
            _context = new CKEntities();

            ck_users objUser = (from user in _context.ck_users where user.username == username select user).FirstOrDefault();

            if (objUser != null)
            {
                _result = true;
            }

            return _result;
        }

        public IEnumerable<UserCustomModel> ReadUsers()
        {
            //UserCustomModel users;
            _context = new CKEntities();
            var result=(IEnumerable<UserCustomModel>)null;
            try
            {
                 result = (from cusers in _context.ck_users where cusers.Id > 0 select new UserCustomModel { Id = cusers.Id, uname = cusers.uname, username = cusers.username, role = cusers.role });
            }
            catch(Exception e)
            {

            }
            //users = (IEnumerable < UserCustomModel >) result;
            //return users;
            return result.ToList<UserCustomModel>();
        }

        public dynamic ReadUsers1()
        {
            _context = new CKEntities();
            var result = (from cusers in _context.ck_users where cusers.Id > 0 select new UserCustomModel { Id = cusers.Id, uname = cusers.uname, username = cusers.username, role = cusers.role });
            try
            {
                
            }
            catch (Exception e)
            {

            }
            //users = (IEnumerable < UserCustomModel >) result;
            //return users;
            return result.ToList();
        }

    }
}
