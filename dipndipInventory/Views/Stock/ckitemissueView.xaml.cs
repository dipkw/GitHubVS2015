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
        private string g_branch_order_no = "";
        List<CKIssueViewModel> g_ck_item_issue_list = new List<CKIssueViewModel>();

        List<CKProductionViewModel> g_ck_production_list = new List<CKProductionViewModel>();

        List<ck_items> g_ck_items_update_list = new List<ck_items>(); // for qty_on_hand
        List<ck_prod> g_ck_prod_update_list = new List<ck_prod>(); // for bal_qty
        ck_issue_master g_ck_issue_master = new ck_issue_master();
        List<ck_issue_detais> g_ck_issue_details = new List<ck_issue_detais>();
        List<ck_stock_trans> g_ck_stock_trans_list = new List<ck_stock_trans>();
        string result = string.Empty;

        public ckitemissueView()
        {
            InitializeComponent();
            ShowTaskBar.ShowInTaskbar(this, "Central Kitchen Item Issue");
            this.AddHandler(GridViewRow.MouseLeftButtonUpEvent, new MouseButtonEventHandler(this.GridViewRow_OnMouseLeftButtonUp), true);
            this._lastClick = DateTime.Now;
            //dtpOrderDate.SelectedDate = DateTime.Now.Date;
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
                try
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
                    ckitembatchView ckitembatch = new ckitembatchView(ck_issue_vm, g_ck_item_issue_list, g_ck_prod_update_list, g_ck_issue_details, this);
                    ckitembatch.Show();
                    //MessageBox.Show("You have double clicked!");
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
            g_ck_item_issue_list.Clear();
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
            dgCKIssueDetails.ItemsSource = null;
            dgCKIssueDetails.ItemsSource = g_ck_item_issue_list;
            dgCKIssueDetails.Rebind();
        }

        private void FillAllSites()
        {
            SiteService _scontext = new SiteService();
            //IEnumerable<site> activeSites = _scontext.ReadAllActiveSitesWOActiveSite(GlobalVariables.ActiveSite.Id);
            IEnumerable<site> activeSites = _scontext.ReadAllActiveOutletSites(); 
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
            g_branch_order_no = site_code + order_date.Date.ToString("dd") + order_date.Month + order_date.ToString("yy");

            txtIssueCode.Value = "";
        }

        private void cmbBranch_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SiteService _scontext = new SiteService();
            string site_code = _scontext.GetSiteCodeBySiteId((int)cmbBranch.SelectedValue);
            DateTime order_date = (DateTime)dtpOrderDate.SelectedDate;
            g_branch_order_no = site_code + order_date.Date.ToString("dd") + order_date.Month + order_date.ToString("yy");
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("test");
            //int row_id = 0;
            //foreach(ck_issue_detais ckissuedetail in g_ck_issue_details)
            //{
            //    try
            //    {
            //        g_ck_issue_details[row_id].ck_issue_code = txtIssueCode.Value;
            //        row_id++;
            //    }
            //    catch { }
            //}


            for(int row_index = 0; row_index<g_ck_issue_details.Count; row_index++)
            {
                try
                {
                    g_ck_issue_details[row_index].ck_issue_code = txtIssueCode.Value;
                }
                catch { }
            }

            //Update for ck_stock_trans
            foreach(ck_issue_detais tmpckissuedetail in g_ck_issue_details)
            {
                try
                {
                    ck_stock_trans ckstocktrans = new ck_stock_trans();
                    ckstocktrans.ck_item_id = tmpckissuedetail.ck_item_id;
                    ckstocktrans.ck_item_code = tmpckissuedetail.ck_item_code;
                    ckstocktrans.ck_item_desc = tmpckissuedetail.ck_item_desc;
                    ckstocktrans.trans_ref_no = txtIssueCode.Value;
                    if (dtpIssueDate.SelectedDate == null)
                    {
                        MessageBox.Show("Please enter the date");
                        return;
                    }
                    ckstocktrans.trans_date = dtpIssueDate.SelectedDate;
                    ckstocktrans.prod_code = tmpckissuedetail.ck_prod_code;
                    ckstocktrans.batch_no = tmpckissuedetail.ck_batch_no;
                    ckstocktrans.prod_date = tmpckissuedetail.ck_prod_date;
                    ckstocktrans.exp_date = tmpckissuedetail.ck_exp_date;
                    ckstocktrans.ck_unit_id = tmpckissuedetail.ck_item_unit_id;
                    //ckstocktrans.ck_unit_desc = tmpckissuedetail.
                    ckstocktrans.qty = tmpckissuedetail.qty_issued;
                    ckstocktrans.trans_type = "CKIssue";
                    ckstocktrans.unit_cost = tmpckissuedetail.ck_item_unit_cost;
                    ckstocktrans.total_cost = tmpckissuedetail.ck_item_total_cost;
                    ckstocktrans.trans_from = GlobalVariables.ActiveSite.Id;
                    if (cmbBranch.SelectedValue == null)
                    {
                        MessageBox.Show("Please select the branch");
                        return;
                    }
                    ckstocktrans.trans_to = Convert.ToInt32(cmbBranch.SelectedValue.ToString());
                    ckstocktrans.active = true;
                    //ckstocktrans.site.Id = Convert.ToInt32(cmbBranch.SelectedValue.ToString());
                    ckstocktrans.created_by = GlobalVariables.ActiveUser.Id;
                    ckstocktrans.created_date = DateTime.Now;
                    g_ck_stock_trans_list.Add(ckstocktrans);
                }
                catch{ }
            }


            UpdateAllList();
            //update ck_issue_details.ck_issue_master_id in DataService

            bool list_has_items_to_issue = g_ck_item_issue_list.Any(z => z.qtyIssued > 0);

            if (!list_has_items_to_issue)
            {
                MessageBox.Show("Please add items to issue");
                return;
            }

            if (dtpOrderDate.SelectedDate == null)
            {
                MessageBox.Show("Please select Order Date");
                return;
            }

            if(dtpIssueDate.SelectedDate == null)
            {
                MessageBox.Show("Please select Issue Date");
                return;
            }

            if(cmbBranch.SelectedIndex == -1)
            {
                MessageBox.Show("Please select branch");
                return;
            }

            CKIssueService ciscontext = new CKIssueService();
           
            result = ciscontext.SaveCKBranchIssue(g_ck_items_update_list, g_ck_prod_update_list, g_ck_issue_master, g_ck_issue_details, g_ck_stock_trans_list, GlobalVariables.ActiveUser.Id) > 0 ? "CK Branch Items Delivery Saved Successfully" : "Unable to Save CK Branch Items Delivery";
            MessageBox.Show(result);
            if (result == "CK Branch Items Delivery Saved Successfully")
            {
                if (MessageBox.Show("Do you want to print?", "Confirm", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    PrintDelivery();
                }
                //Clear All List after Save
                g_ck_prod_update_list.Clear();
                g_ck_issue_details.Clear();
                g_ck_stock_trans_list.Clear();

                //Clear Grid
                g_ck_item_issue_list.Clear();
                dgCKIssueDetails.ItemsSource = null;
                //FillAllCKItems();
                GenerateNewCKIssueCode();
                FillAllCKItems();
            }
        }
        /// Generate new issue_code
        /// 
        private void GenerateNewCKIssueCode()
        {
            
            CKIssueService cicontext = new CKIssueService();
            string issue_code = cicontext.GetNewCKIssueCode();
            txtIssueCode.Value = issue_code;
        }

        private void UpdateAllList()
        {
            foreach(CKIssueViewModel ck_issue_vm in g_ck_item_issue_list)
            {
                if(ck_issue_vm.qtyIssued>0)
                {
                    g_ck_items_update_list.RemoveAll(p => p.Id == ck_issue_vm.itemId);
                    //CK Item List Updation
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
            //Update for ck_issue_master
            try
            {
                g_ck_issue_master.ck_issue_code = txtIssueCode.Value;
                g_ck_issue_master.ck_issue_date = dtpIssueDate.SelectedDate;
                g_ck_issue_master.branch_order_no = g_branch_order_no;
                g_ck_issue_master.branch_order_date = dtpOrderDate.SelectedDate;
                g_ck_issue_master.issue_to_site_id = Convert.ToInt32(cmbBranch.SelectedValue.ToString());
                g_ck_issue_master.active = true;
                g_ck_issue_master.created_by = GlobalVariables.ActiveUser.Id;
                g_ck_issue_master.created_date = DateTime.Now;
            }
            catch { }
        }

        private void radGridView_RowValidating(object sender, Telerik.Windows.Controls.GridViewRowValidatingEventArgs e)
        {

            

        }

        private void dgCKIssueDetails_CellValidating(object sender, GridViewCellValidatingEventArgs e)
        {
            //if(e.Cell.Column.UniqueName == "qtyIssued")
            //{
                
            //    //decimal qty_on_hand = 
            //}
        }

        private void PrintDelivery()
        {
            try
            {

                //Telerik.Reporting.IReportDocument myReport = new DieReports.DieDetailsReport(die_id, "Drawing");
                //Telerik.Reporting.IReportDocument myReport = new dipndipTLReports.PrintOrderReport("CKOR-0007");
                //Telerik.Reporting.IReportDocument myReport = new dipndipTLReports.Reports.OrderDetailsB("CKOR-0007");
                Telerik.Reporting.IReportDocument myReport = new dipndipTLReports.Reports.CKItemDeliveryReport(txtIssueCode.Value);


                // Obtain the settings of the default printer
                System.Drawing.Printing.PrinterSettings printerSettings
                    = new System.Drawing.Printing.PrinterSettings();

                //// The standard print controller comes with no UI
                System.Drawing.Printing.PrintController standardPrintController =
                    new System.Drawing.Printing.StandardPrintController();

                // Print the report using the custom print controller
                Telerik.Reporting.Processing.ReportProcessor reportProcessor
                    = new Telerik.Reporting.Processing.ReportProcessor();

                reportProcessor.PrintController = standardPrintController;

                Telerik.Reporting.InstanceReportSource instanceReportSource =
                    new Telerik.Reporting.InstanceReportSource();

                instanceReportSource.ReportDocument = myReport;

                reportProcessor.PrintReport(instanceReportSource, printerSettings);
            }
            catch
            {

            }
        }

        //Generate Issue Code (Generate Code based on Site or not?)
    }
}
