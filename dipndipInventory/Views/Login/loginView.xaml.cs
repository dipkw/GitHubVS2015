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
using dipndipInventory.Helpers;
using dipndipInventory.GlobalObjects;
using dipndipInventory.EF;
using md5crypt;
using System.Windows.Threading;
using Telerik.Windows.Controls;
using dipndipInventory.EF.DataServices;

namespace dipndipInventory.Views.Login
{
    /// <summary>
    /// Interaction logic for loginView.xaml
    /// </summary>
    public partial class loginView : Window
    {
        public delegate void ReadyToShowDelegate(object sender, EventArgs args);

        public event ReadyToShowDelegate ReadyToShow;

        private DispatcherTimer timer;

        CKEntities _context;
        public loginView()
        {
            InitializeComponent();
            txtUserName.Focus();
            FillAllSites();
        }

        private void FillAllSites()
        {
            SiteService _scontext = new SiteService();
            //IEnumerable<site> objSites = _scontext.ReadAllSites();
            IEnumerable<site> objSites = _scontext.ReadWHCKSites();
            cmbSites.DisplayMemberPath = "site_name";
            cmbSites.SelectedValuePath = "Id";
            cmbSites.ItemsSource = objSites.ToList();
            cmbSites.SelectedIndex = -1;
        }
        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(cmbSites.SelectedIndex==-1)
                {
                    MessageBox.Show("Please Select Branch");
                    return;
                }
                ck_users objUser= new ck_users();
                site objSite = new site();
                objSite.Id = (int)cmbSites.SelectedValue;
                objSite.site_name = cmbSites.Text;
                string username = txtUserName.Text;
                string password = txtPassword.Password;
                objUser = VerifyUser(username, password);
                if (objUser != null)
                {
                    //if ((txtUserName.MaskedText == "admin" && txtPassword.Password == "admin"))
                    //{
                    GlobalVariables.ActiveUser = objUser;
                    GlobalVariables.ActiveSite.Id = (int)cmbSites.SelectedValue;
                    //homeView objHomeView = new homeView(objUser);
                    homeView objHomeView = new homeView(objUser,objSite);
                    objHomeView.Show();
                    this.Hide();

                    //}
                }
                else
                {

                    RadWindow.Alert("Login Failed! Invalid Username or Password");
                    txtUserName.SelectionStart = txtUserName.Text.Length;
                    txtUserName.Focus();
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message.ToString());
            }

        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                btnOk_Click(sender, e);
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_KeyDown_1(object sender, KeyEventArgs e)
        {
            ChangeFocus.OnEnter(sender, e);
        }

        private void txtPassword_GotFocus(object sender, RoutedEventArgs e)
        {
            txtPassword.SelectAll();
        }

        public ck_users VerifyUser(string username, string password)
        {
            _context = new CKEntities();
            //IEnumerable<Customer> temp = datacontextobj.Customers;
            //Systemuserinfo temp = (from tbl in datacontextobj.Systemuserinfos where tbl.Username == username && tbl.Password == password select tbl).FirstOrDefault();
            //ActiveUser _user = new ActiveUser();
            //string encPassword = Crypto.EncryptStringAES(password, username);
            string encPassword = Crypto.CalculateHash(password, username);
            ck_users objStaff = (from user in _context.ck_users where user.username == username && user.password == encPassword select user).FirstOrDefault();
            return objStaff;
        }
    }
}
