using dipndipInventory.EF;
using dipndipInventory.EF.DataServices;
using dipndipInventory.Validations;
using dipndipInventory.ViewModels;
using md5crypt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Telerik.Windows.Controls;

namespace dipndipInventory.Views.Users
{
    /// <summary>
    /// Interaction logic for userView.xaml
    /// </summary>
    /// 

    public partial class userView : RadWindow
    {
        UserService _context = new UserService();
        bool edit_mode = false;
        //string username = string.Empty;
        int id = 0; 
        public userView()
        {
            InitializeComponent();
            ReadAllUsers();
        }

        private void ReadAllUsers()
        {
            IEnumerable<ck_users> objUsers = _context.ReadAllUsers();
            //var objUsers = _context.ReadUsers();
            //IEnumerable<UserViewModel> objUsers = (IEnumerable<UserViewModel>)_context.ReadUsers();
            dgUsers.ItemsSource = objUsers;
            txtName.Focus();
        }

        private void SelectUser()
        {
            try
            {
                if (dgUsers.SelectedItem == null)
                {
                    return;
                }

                ck_users objUser = (dgUsers.SelectedItem) as ck_users;

                id = objUser.Id;
                //user_Id = objUser.user_id;

                //username = objUser.username;

                txtName.Value = objUser.uname;
                txtName.IsReadOnly = true;

                txtUsername.Value = objUser.username;
                txtUsername.IsReadOnly = true;

                //txtPassword.MaskedText = Crypto.DecryptStringAES(objStaff.Password, objStaff.User_name);
                //txtPassword.MaskedText = Crypto.CalculateHash(objStaff.Password, objStaff.User_name);
                txtPassword.IsReadOnly = true;

                cmbRole.Text = objUser.role;
                cmbRole.IsReadOnly = true;
                cmbRole.IsHitTestVisible = false;

                btnSave.IsEnabled = false;
            }
            catch { }
        }

        private void dgUsers_SelectionChanged(object sender, SelectionChangeEventArgs e)
        {
            SelectUser();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            //if (GlobalVariables.ActiveUser.Role != "Admin")
            //{
            //    RadWindow.Alert("Access denied, Please contact Administrator");
            //    return;
            //}

            if (dgUsers.SelectedItem == null)
            {
                return;
            }

            txtName.IsReadOnly = false;
            //txtUsername.IsReadOnly = false;
            txtPassword.IsReadOnly = false;
            cmbRole.IsHitTestVisible = true;

            edit_mode = true;
            btnSave.IsEnabled = true;
            txtName.Focus();
        }

        private void ClearFields()
        {
            txtName.IsReadOnly = false;
            txtUsername.IsReadOnly = false;
            txtPassword.IsReadOnly = false;

            txtName.Value = string.Empty;
            txtUsername.Value = string.Empty;
            txtPassword.Value = string.Empty;
            cmbRole.IsHitTestVisible = true;

            id = 0;
            //username = string.Empty;
            edit_mode = false;

            ReadAllUsers();
        }
        private void btnNew_Click(object sender, RoutedEventArgs e)
        {
            ClearFields();
            btnSave.IsEnabled = true;
        }

        public bool validateUser()
        {

            if (Validate.TxtMaskBlankCheck(txtName, "Name"))
            {
                return false;
            }

            if (Validate.TxtMaskBlankCheck(txtUsername, "Username"))
            {
                return false;
            }

            if (Validate.TxtMaskBlankCheck(txtPassword, "Password"))
            {
                return false;
            }

            if (Validate.ComboMaskBlankCheck(cmbRole, "Role"))
            {
                return false;
            }

            return true;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (validateUser())
            {
                RadWindow.Confirm("Do you want to Continue ?", this.onSave);
            }
        }

        private void onSave(object sender, WindowClosedEventArgs e)
        {
            if (e.DialogResult == true)
            {
                saveUser();
            }
        }

        private void saveUser()
        {
            ck_users objUser = new ck_users();

            objUser.uname = txtName.Value;
            objUser.username = txtUsername.Value;
            //objUser.User_name = txtUsername.MaskedText;
            //objStaff.Password = Crypto.EncryptStringAES(txtPassword.MaskedText, txtUsername.MaskedText);
            objUser.password = Crypto.CalculateHash(txtPassword.Value, txtUsername.Value);
            objUser.role = cmbRole.Text;

            string _dbresponse = string.Empty;

            try
            {
                if (edit_mode)
                {
                    objUser.Id = id;
                    // objUser.username = username;
                    _dbresponse = _context.UpdateUser(objUser) > 0 ? "User Details Updated Successfully" : "Unable to Update User Details";
                }
                else
                {
                    if (_context.IsExistingUser(objUser.username))
                    {
                        RadWindow.Alert("Existing User");
                        txtUsername.SelectionStart = txtUsername.Value.Length;
                        txtUsername.Focus();
                        return;
                    }
                    _dbresponse = _context.CreateUser(objUser) > 0 ? "User Details Created Successfully" : "Unable to Save User Details";
                }

                RadWindow.Alert(_dbresponse);
                ClearFields();
            }
            catch { }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            //if (GlobalVariables.ActiveUser.Role != "Admin")
            //{
            //    RadWindow.Alert("Access denied, Please contact Administrator");
            //    return;
            //}

            if (dgUsers.SelectedItem != null)
            {
                RadWindow.Confirm("Do you want to Continue?", this.onDeleteUser);
            }
        }

        private void onDeleteUser(object sender, WindowClosedEventArgs e)
        {
            if (e.DialogResult == true)
            {
                deleteUser();
                ClearFields();
                ReadAllUsers();
            }
        }

        private void deleteUser()
        {
            try
            {
                ck_users objUser = new ck_users();
                objUser.Id = id;

                string _dbresponse = _context.DeleteUser(objUser) > 0 ? "User Details deleted successfully" : "Unable to delete User Details";

                RadWindow.Alert(_dbresponse);
            }
            catch { }
        }
    }
}
