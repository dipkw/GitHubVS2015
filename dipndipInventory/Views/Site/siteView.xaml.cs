using dipndipInventory.EF;
using dipndipInventory.EF.DataServices;
using dipndipInventory.Helpers;
using dipndipInventory.Validations;
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

namespace dipndipInventory.Views.Site
{
    /// <summary>
    /// Interaction logic for siteView.xaml
    /// </summary>
    public partial class siteView : RadWindow
    {
        SiteService _context = new SiteService();
        bool edit_mode = false;
        //string username = string.Empty;
        int id = 0;
        public siteView()
        {
            InitializeComponent();
            ShowTaskBar.ShowInTaskbar(this, "Sites");
            ReadAllSites();
        }

        private void ReadAllSites()
        {
            IEnumerable<site> objSites = _context.ReadAllSites();
            dgSites.ItemsSource = objSites;
            txtSiteName.Focus();
        }

        private void SelectSite()
        {
            try
            {
                if (dgSites.SelectedItem == null)
                {
                    return;
                }

                site objSite = (dgSites.SelectedItem) as site;

                id = objSite.Id;
                //user_Id = objUser.user_id;

                //username = objUser.username;

                txtSiteID.Value = objSite.site_id;
                txtSiteID.IsReadOnly = true;

                txtSiteName.Value = objSite.site_name;
                txtSiteName.IsReadOnly = true;

                btnSave.IsEnabled = false;
            }
            catch { }
        }

        private void dgSites_SelectionChanged(object sender, SelectionChangeEventArgs e)
        {
            SelectSite();
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

            if (dgSites.SelectedItem == null)
            {
                return;
            }

            txtSiteName.IsReadOnly = false;
            //txtUsername.IsReadOnly = false;
            edit_mode = true;
            btnSave.IsEnabled = true;
            txtSiteName.Focus();
        }

        private void ClearFields()
        {
            txtSiteID.IsReadOnly = false;
            txtSiteID.Value = string.Empty;

            txtSiteName.IsReadOnly = false;

            txtSiteName.Value = string.Empty;

            id = 0;
            //username = string.Empty;
            edit_mode = false;

            ReadAllSites();
        }

        private void btnNew_Click(object sender, RoutedEventArgs e)
        {
            ClearFields();
            btnSave.IsEnabled = true;
        }

        private bool validateUser()
        {
            if (Validate.TxtMaskBlankCheck(txtSiteName, "Site Name"))
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
                saveSite();
            }
        }

        private void saveSite()
        {
            site objSite = new site();
            objSite.site_id = txtSiteID.Value;
            objSite.site_name = txtSiteName.Value;
            

            string _dbresponse = string.Empty;

            try
            {
                if (edit_mode)
                {
                    objSite.Id = id;
                    // objUser.username = username;
                    objSite.modified_by = GlobalVariables.ActiveUser.Id;
                    objSite.modified_date = DateTime.Now;
                    _dbresponse = _context.UpdateSite(objSite) > 0 ? "Site Details Updated Successfully" : "Unable to Update Site Details";
                }
                else
                {
                    objSite.created_by = GlobalVariables.ActiveUser.Id;
                    objSite.created_date = DateTime.Now;
                    if (_context.IsExistingSite(objSite.Id))
                    {
                        RadWindow.Alert("Existing Site");
                        txtSiteName.SelectionStart = txtSiteName.Value.Length;
                        txtSiteName.Focus();
                        return;
                    }
                    _dbresponse = _context.CreateSite(objSite) > 0 ? "Site Details Created Successfully" : "Unable to Save Site Details";
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

            if (dgSites.SelectedItem != null)
            {
                RadWindow.Confirm("Do you want to Continue?", this.onDeleteSite);
            }
        }

        private void onDeleteSite(object sender, WindowClosedEventArgs e)
        {
            if (e.DialogResult == true)
            {
                deleteSite();
                ClearFields();
                ReadAllSites();
            }
        }

        private void deleteSite()
        {
            try
            {
                site objSite = new site();
                objSite.Id = id;

                string _dbresponse = _context.DeleteSite(objSite) > 0 ? "Site Details deleted successfully" : "Unable to delete Site Details";

                RadWindow.Alert(_dbresponse);
            }
            catch { }
        }
    }
}
