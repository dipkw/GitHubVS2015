﻿using dipndipInventory.EF;
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
        List<CKIssueViewModel> g_ck_item_issue_list = new List<CKIssueViewModel>();

        List<CKProductionViewModel> g_ck_production_list = new List<CKProductionViewModel>();

        List<ck_items> g_ck_items_update_list = new List<ck_items>(); // for qty_on_hand
        List<ck_prod> g_ck_prod_update_list = new List<ck_prod>(); // for bal_qty
        ck_issue_master g_ck_issue_master = new ck_issue_master();
        List<ck_issue_detais> g_ck_issue_details = new List<ck_issue_detais>();

        List<ck_stock_trans> g_ck_stock_trans_list = new List<ck_stock_trans>();

        public ckitemissueView()
        {
            InitializeComponent();
            ShowTaskBar.ShowInTaskbar(this, "Central Kitchen Item Issue");
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
                //ck_items ckitems = dgCKIssueDetails.SelectedItem as ck_items;
                CKIssueViewModel ckitems = dgCKIssueDetails.SelectedItem as CKIssueViewModel;
                CKIssueViewModel ck_issue_vm = new CKIssueViewModel();
                //List<CKItemBatchViewModel> ck_item_batches = new List<CKItemBatchViewModel>();
                //ck_issue_vm.itemCode = ckitems.ck_item_code;
                ck_issue_vm.itemId = ckitems.itemId;
                ck_issue_vm.itemCode = ckitems.itemCode;
                ck_issue_vm.rowIndex = ckitems.rowIndex;
                //ckitembatchView ckitembatch = new ckitembatchView(ck_issue_vm, ck_item_batches);
                ckitembatchView ckitembatch = new ckitembatchView(ck_issue_vm, g_ck_item_issue_list, g_ck_prod_update_list);
                ckitembatch.Show();
                //MessageBox.Show("You have double clicked!");
            }
            this._lastClick = DateTime.Now;
        }
        private void FillAllCKItems()
        {
            CKItemService citcontext = new CKItemService();
            IEnumerable<ck_items> ck_active_items = citcontext.ReadAllActiveCKItems();
            int row_indx = 0;
            foreach(ck_items ck_active_item in ck_active_items)
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
                foreach(ck_item_unit ckitemunit in ck_item_units)
                {
                    ckUnitVM cvm= new ckUnitVM();
                    cvm.ckunitId = ckitemunit.Id;
                    cvm.ckunitDesc = ckitemunit.ck_units.unit_description;
                    ck_item_unit_list.Add(cvm);
                }
                ckivm.ckunitVM = ck_item_unit_list;
                
                ckivm.qtyIssued = 0.000m;
                ckivm.rowIndex = row_indx++;
                g_ck_item_issue_list.Add(ckivm);
            }
            dgCKIssueDetails.ItemsSource = g_ck_item_issue_list;
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

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("test");
        }

        private void UpdateAllList()
        {
            foreach(CKIssueViewModel ck_issue_vm in g_ck_item_issue_list)
            {
                if(ck_issue_vm.qtyIssued>0)
                {
                    
                    try
                    {
                        ck_items ckitem = new ck_items();
                        decimal ck_item_current_qty = 0.000m;
                        CKItemService cscontext = new CKItemService();
                        ck_item_current_qty = cscontext.GetCurrentCKItemQty(ck_issue_vm.itemId);
                        ckitem.Id = ck_issue_vm.itemId;
                        ckitem.ck_item_code = ck_issue_vm.itemCode;
                        ckitem.qty_on_hand = ck_item_current_qty - ck_issue_vm.qtyIssued;
                        g_ck_items_update_list.Add(ckitem);
                    }
                    catch { }
                    try
                    {
                        ck_prod ckprod = new ck_prod();
                        decimal ck_item_batch_bal = 0.000m;

                    }
                    catch { }
                }
            }
        }

        //Generate Issue Code (Generate Code based on Site or not?)
    }
}
