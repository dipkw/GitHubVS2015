using dipndipInventory.EF;
using dipndipInventory.EF.DataServices;
using dipndipInventory.Helpers;
using dipndipInventory.ViewModels;
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
using Telerik.Windows.Controls.GridView;

namespace dipndipInventory.Views.Stock
{
    /// <summary>
    /// Interaction logic for ckitemissueView.xaml
    /// </summary>
    public partial class ckitemissueView : RadWindow
    {
        private static TimeSpan DoubleClickThreshold = TimeSpan.FromMilliseconds(450);
        private DateTime _lastClick;
        public ckitemissueView()
        {
            InitializeComponent();
            this.AddHandler(GridViewRow.MouseLeftButtonUpEvent, new MouseButtonEventHandler(this.GridViewRow_OnMouseLeftButtonUp), true);
            this._lastClick = DateTime.Now;
            dtpOrderDate.SelectedDate = DateTime.Now.Date;
            FillAllSites();
            CKIssueService cicontext = new CKIssueService();
            string issue_code = cicontext.GetNewCKIssueCode();
            txtIssueCode.Value = issue_code;
            FillAllCKItems();
        }

        private void GridViewRow_OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (DateTime.Now - this._lastClick <= DoubleClickThreshold)
            {
                ck_items ckitems = dgCKIssueDetails.SelectedItem as ck_items;
                CKIssueViewModel ck_issue_vm = new CKIssueViewModel();
                //List<CKItemBatchViewModel> ck_item_batches = new List<CKItemBatchViewModel>();
                ck_issue_vm.itemCode = ckitems.ck_item_code;
                //ck_issue_vm.rowIndex = 
                //ckitembatchView ckitembatch = new ckitembatchView(ck_issue_vm, ck_item_batches);
                ckitembatchView ckitembatch = new ckitembatchView(ck_issue_vm, this);
                ckitembatch.Show();
                //MessageBox.Show("You have double clicked!");
            }
            this._lastClick = DateTime.Now;
        }
        private void FillAllCKItems()
        {
            CKItemService citcontext = new CKItemService();
            dgCKIssueDetails.ItemsSource = citcontext.ReadAllActiveCKItems();
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
