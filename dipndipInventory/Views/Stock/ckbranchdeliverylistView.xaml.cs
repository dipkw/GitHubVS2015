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
    /// Interaction logic for ckbranchdeliverylistView.xaml
    /// </summary>
    public partial class ckbranchdeliverylistView : RadWindow
    {
        List<CKIssueViewModel> g_ck_item_issue_list = new List<CKIssueViewModel>();
        IEnumerable<ck_issue_master> g_ck_branch_delivery_list;

        private static TimeSpan DoubleClickThreshold = TimeSpan.FromMilliseconds(450);
        private DateTime _lastClick;

        public ckbranchdeliverylistView()
        {
            InitializeComponent();
            ShowTaskBar.ShowInTaskbar(this, "Central Kitchen Branch Delivery List");
            this.AddHandler(GridViewRow.MouseLeftButtonUpEvent, new MouseButtonEventHandler(this.GridViewRow_OnMouseLeftButtonUp), true);
            this._lastClick = DateTime.Now;
            FillAllCKBranchDeliveries();
        }

        private void GridViewRow_OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (DateTime.Now - this._lastClick <= DoubleClickThreshold)
            {
                try
                {
                    ck_issue_master selected_delivery = dgCKIssueDetails.SelectedItem as ck_issue_master;
                    ckbranchdeliverydetailsView bdv = new ckbranchdeliverydetailsView(selected_delivery.ck_issue_code);
                    bdv.Show();
                }
                catch { }
            }
            this._lastClick = DateTime.Now;
        }

        private void FillAllCKItems()
        {
            CKItemService citcontext = new CKItemService();
            IEnumerable<ck_items> ck_active_items = citcontext.ReadAllActiveCKItems();
            int row_indx = 0;
            foreach (ck_items ck_active_item in ck_active_items)
            {
                CKIssueViewModel ckivm = new CKIssueViewModel();
                ckivm.itemId = ck_active_item.Id;
                ckivm.itemCode = ck_active_item.ck_item_code;
                ckivm.itemDescription = ck_active_item.ck_item_description;
                ckivm.ckUnit = ck_active_item.ck_units.unit_description;
                if (ck_active_item.qty_on_hand == null)
                {
                    ckivm.qtyonHand = 0.000m;
                }
                else
                {
                    ckivm.qtyonHand = (decimal)ck_active_item.qty_on_hand;
                }

                CKItemUnitService cuscontext = new CKItemUnitService();
                IEnumerable<ck_item_unit> ck_item_units = cuscontext.ReadAllCKItemUnitsByCKItemId(ck_active_item.Id);
                //cmbCKUnit.DisplayMemberPath = "ck_units.unit_description";
                //cmbCKUnit.SelectedValueMemberPath = "Id";
                //cmbCKUnit.ItemsSource = ck_item_units.ToList();
                List<ckUnitVM> ck_item_unit_list = new List<ckUnitVM>();
                foreach (ck_item_unit ckitemunit in ck_item_units)
                {
                    ckUnitVM cvm = new ckUnitVM();
                    cvm.ckunitId = ckitemunit.Id;
                    cvm.ckunitDesc = ckitemunit.ck_units.unit_description;
                    ck_item_unit_list.Add(cvm);
                }
                ckivm.ckunitVM = ck_item_unit_list;

                ckivm.qtyIssued = 0.000m;
                ckivm.rowIndex = row_indx++;
                g_ck_item_issue_list.Add(ckivm);
            }
            dgCKIssueDetails.ItemsSource = null;
            dgCKIssueDetails.ItemsSource = g_ck_item_issue_list;
            dgCKIssueDetails.Rebind();
        }

        private void FillAllCKBranchDeliveries()
        {
            CKIssueService ciscontext = new CKIssueService();
            g_ck_branch_delivery_list = ciscontext.ReadAllCKBranchDelivery();
            dgCKIssueDetails.ItemsSource = null;
            dgCKIssueDetails.ItemsSource = g_ck_branch_delivery_list;
            dgCKIssueDetails.Rebind();
        }

        //private void btnView_Click(object sender, RoutedEventArgs e)
        //{
        //    if (dgCKIssueDetails.SelectedItem == null)
        //    {
        //        RadWindow.Alert("Please select a row to view");
        //        return;
        //    }
        //    try
        //    {
        //        ck_prod selected_production = dgCKIssueDetails.SelectedItem as ck_prod;
        //        productiondetailView pdv = new productiondetailView(selected_production.prod_code);
        //        pdv.Show();
        //    }
        //    catch { }

        //}

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
