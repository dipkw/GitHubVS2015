using dipndipInventory.EF;
using dipndipInventory.EF.DataServices;
using dipndipInventory.Helpers;
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

namespace dipndipInventory.Views.Stock
{
    /// <summary>
    /// Interaction logic for ckitemissueView.xaml
    /// </summary>
    public partial class ckitemissueView : RadWindow
    {
        public ckitemissueView()
        {
            InitializeComponent();
            dtpOrderDate.SelectedDate = DateTime.Now.Date;
            FillAllSites();
        }

        private void FillAllSites()
        {
            SiteService _scontext = new SiteService();
            IEnumerable<site> activeSites = _scontext.ReadAllActiveSitesWOActiveSite(GlobalVariables.ActiveSite.Id);
            cmbBranch.DisplayMemberPath = "site_name";
            cmbBranch.SelectedValuePath = "Id";
            cmbBranch.ItemsSource = activeSites.ToList();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void dtpOrderDate_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(cmbBranch.SelectedIndex == -1 || cmbBranch.SelectedValue == null)
            {
                return;
            }

            SiteService _scontext = new SiteService();
            string site_code = _scontext.GetSiteCodeBySiteId((int)cmbBranch.SelectedValue);
            DateTime order_date = (DateTime)dtpOrderDate.SelectedDate;
            string branch_order_no = site_code + order_date.Date.ToString("dd") + order_date.Month + order_date.ToString("yy");

            txtIssueCode.Value = "";
        }

        private void cmbBranch_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SiteService _scontext = new SiteService();
            string site_code = _scontext.GetSiteCodeBySiteId((int)cmbBranch.SelectedValue);
            DateTime order_date = (DateTime)dtpOrderDate.SelectedDate;
            string branch_order_no = site_code + order_date.Date.ToString("dd") + order_date.Month + order_date.ToString("yy");
        }

        //Generate Issue Code (Generate Code based on Site or not?)
    }
}
