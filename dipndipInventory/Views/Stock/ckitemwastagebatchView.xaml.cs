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
    /// Interaction logic for ckitemwastagebatchView.xaml
    /// </summary>
    public partial class ckitemwastagebatchView : RadWindow
    {
        CKIssueViewModel g_ck_issue_vm;
        //List<CKItemBatchViewModel> g_ck_item_batches;
        ckitemwastageView g_ck_item_issue_view;
        List<CKIssueViewModel> g_ck_item_issue_list = new List<CKIssueViewModel>();
        List<CKProductionViewModel> g_ck_production_list = new List<CKProductionViewModel>();
        List<ck_wastage_details> g_ck_wastage_details = new List<ck_wastage_details>();
        List<CKItemBatchViewModel> g_ck_item_batches = new List<CKItemBatchViewModel>();
        List<ck_prod> g_ck_prod_update_list = new List<ck_prod>();
        decimal g_conv_factor = 0.000m;

        public ckitemwastagebatchView()
        {
            InitializeComponent();
        }

        public ckitemwastagebatchView(CKIssueViewModel ck_issue_vm, List<CKIssueViewModel> ck_item_issue_list, List<ck_prod> ck_production_list, List<ck_wastage_details> ckwastage_details, ckitemwastageView ck_item_issue_view)
        {
            InitializeComponent();
            ShowTaskBar.ShowInTaskbar(this, "Central Kitchen Item Wastage");
            g_ck_issue_vm = ck_issue_vm;
            //g_ck_item_batches = ck_item_batches;
            g_ck_item_issue_view = ck_item_issue_view;

            g_ck_item_issue_list = ck_item_issue_list;
            g_ck_prod_update_list = ck_production_list;
            g_ck_wastage_details = ckwastage_details;

            FillUnits(g_ck_issue_vm.itemId);
            UpdateConvFactor();
            FillAllBatchItems(g_ck_issue_vm.itemCode);
        }

        private void FillUnits(int itemId)
        {
            CKItemUnitService cuscontext = new CKItemUnitService();
            IEnumerable<ck_item_unit> ck_item_units = cuscontext.ReadAllCKItemUnitsByCKItemId(itemId);
            cmbUnit.DisplayMemberPath = "ck_units.unit_description";
            cmbUnit.SelectedValuePath = "Id";
            cmbUnit.ItemsSource = ck_item_units.ToList();
            int? default_unit = cuscontext.GetDefaultUnitID(itemId);
            if (default_unit != null)
            {
                cmbUnit.SelectedValue = default_unit;
            }
        }

        private void FillAllBatchItems(string ck_item_code)
        {
            try
            {
                CKProductionService cpcontext = new CKProductionService();
                List<ck_prod> ck_batch_items = cpcontext.GetAvailableBatchItems(ck_item_code).ToList();

                int row_id = 0;
                foreach (ck_prod ck_batch_item in ck_batch_items)
                {
                    CKItemBatchViewModel objCKItemBatchVM = new CKItemBatchViewModel();
                    objCKItemBatchVM.ck_prod_code = ck_batch_item.prod_code;
                    objCKItemBatchVM.ck_item_id = (int)ck_batch_item.ck_item_id;
                    objCKItemBatchVM.ck_item_code = ck_batch_item.ck_item_code;
                    objCKItemBatchVM.ck_item_description = ck_batch_item.ck_item_desc;
                    try
                    {
                        objCKItemBatchVM.ck_item_unit_id = (int)ck_batch_item.ck_item_unit_id;
                    }
                    catch { }
                    objCKItemBatchVM.ck_item_unit_desc = ck_batch_item.ck_item_unit_desc;
                    objCKItemBatchVM.batch_no = ck_batch_item.batch_no;
                    objCKItemBatchVM.prod_date = (DateTime)ck_batch_item.prod_date;
                    objCKItemBatchVM.exp_date = (DateTime)ck_batch_item.exp_date;
                    objCKItemBatchVM.qty_issued = 0.000m;
                    objCKItemBatchVM.bal_qty = (decimal)ck_batch_item.bal_qty;
                    objCKItemBatchVM.rem_qty = (decimal)ck_batch_item.bal_qty / g_conv_factor;
                    objCKItemBatchVM.tmp_ck_unit_cost = (decimal)ck_batch_item.unit_cost;
                    objCKItemBatchVM.ck_unit_cost = (decimal)(ck_batch_item.unit_cost * g_conv_factor) * (objCKItemBatchVM.qty_issued);
                    objCKItemBatchVM.ck_total_cost = (decimal)(ck_batch_item.total_cost * g_conv_factor) * (objCKItemBatchVM.qty_issued);

                    objCKItemBatchVM.row_id = row_id++;
                    g_ck_item_batches.Add(objCKItemBatchVM);
                }

                dgCKIssueDetails.ItemsSource = g_ck_item_batches;
            }
            catch { }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            var rows = this.dgCKIssueDetails.ChildrenOfType<GridViewRow>();
            int result = 0;
            decimal total_qty_issued = 0.000m;
            CKOrderService _ocontext = new CKOrderService();
            foreach (var row in rows)
            {
                try
                {
                    if (row is GridViewNewRow)
                        continue;

                    CKItemBatchViewModel objItemBatchVM = row.Item as CKItemBatchViewModel;
                    if (objItemBatchVM.qty_issued > 0)
                    {
                        g_ck_prod_update_list.RemoveAll(p => (p.prod_code == objItemBatchVM.ck_prod_code && p.batch_no == objItemBatchVM.batch_no));

                        total_qty_issued += objItemBatchVM.qty_issued;

                        ck_prod ckprod = new ck_prod();
                        ckprod.prod_code = objItemBatchVM.ck_prod_code;
                        ckprod.batch_no = objItemBatchVM.batch_no;
                        ckprod.prod_date = objItemBatchVM.prod_date;
                        ckprod.exp_date = objItemBatchVM.exp_date;
                        ckprod.ck_item_id = objItemBatchVM.ck_item_id;
                        ckprod.modified_by = GlobalVariables.ActiveUser.Id;
                        ckprod.modified_date = DateTime.Now;

                        CKProductionService pscontext = new CKProductionService();
                        decimal ck_item_batch_qty = pscontext.GetCurrentCKItemBatchQty(ckprod.prod_code, ckprod.batch_no);

                        decimal prod_item_conv_factor = 0.000m;
                        CKItemService cscontext = new CKItemService();
                        CKItemUnitService cucontext = new CKItemUnitService();
                        prod_item_conv_factor = (decimal)cucontext.GetConversionFactor(Convert.ToInt32(cmbUnit.SelectedValue.ToString()));

                        ckprod.bal_qty = (ck_item_batch_qty) - (objItemBatchVM.qty_issued * prod_item_conv_factor);
                        g_ck_prod_update_list.Add(ckprod);


                        //Updation for CK Issue Details
                        g_ck_wastage_details.RemoveAll(p => (p.ck_prod_code == objItemBatchVM.ck_prod_code && p.ck_batch_no == objItemBatchVM.batch_no));
                        ck_wastage_details ckwastagedetail = new ck_wastage_details();
                        ckwastagedetail.ck_prod_code = objItemBatchVM.ck_prod_code;
                        ckwastagedetail.ck_batch_no = objItemBatchVM.batch_no;
                        ckwastagedetail.ck_prod_date = objItemBatchVM.prod_date;
                        ckwastagedetail.ck_exp_date = objItemBatchVM.exp_date;
                        ckwastagedetail.ck_item_id = objItemBatchVM.ck_item_id;
                        ckwastagedetail.ck_item_code = objItemBatchVM.ck_item_code;
                        ckwastagedetail.ck_item_desc = objItemBatchVM.ck_item_description;
                        ckwastagedetail.ck_item_unit_id = objItemBatchVM.ck_item_unit_id;
                        //ckwastagedetail.wastage_qty = objItemBatchVM.qty_issued;
                        ckwastagedetail.wastage_qty = objItemBatchVM.qty_issued * g_conv_factor; //Edited on 05-12-2016
                        ckwastagedetail.ck_item_unit_cost = (objItemBatchVM.tmp_ck_unit_cost * g_conv_factor);
                        ckwastagedetail.ck_item_total_cost = (objItemBatchVM.tmp_ck_unit_cost * g_conv_factor) * (objItemBatchVM.qty_issued);
                        ckwastagedetail.created_by = GlobalVariables.ActiveUser.Id;
                        ckwastagedetail.created_date = DateTime.Now;
                        ckwastagedetail.active = true;
                        g_ck_wastage_details.Add(ckwastagedetail);

                    }
                }
                catch { }
                //
                try
                {

                }
                catch { }
            }
            try
            {
                //Updation for ckitemissueView grid items
                //g_ck_item_issue_list[g_ck_issue_vm.rowIndex].qtyIssued = total_qty_issued;
                g_ck_item_issue_list[g_ck_issue_vm.rowIndex].qtyIssued = total_qty_issued * g_conv_factor; //Edited on 05-12-2016
                decimal ck_item_unit_cost = 0.000m;
                decimal item_conv_factor = 0.000m;
                CKItemService cscontext = new CKItemService();
                ck_item_unit_cost = cscontext.GetCurrentCKItemCost(g_ck_issue_vm.itemId);
                CKItemUnitService cucontext = new CKItemUnitService();
                item_conv_factor = (decimal)cucontext.GetConversionFactor(Convert.ToInt32(cmbUnit.SelectedValue.ToString()));
                g_ck_item_issue_list[g_ck_issue_vm.rowIndex].unit_cost = ck_item_unit_cost * item_conv_factor;
                g_ck_item_issue_list[g_ck_issue_vm.rowIndex].total_cost = g_ck_item_issue_list[g_ck_issue_vm.rowIndex].unit_cost * g_ck_item_issue_list[g_ck_issue_vm.rowIndex].qtyIssued;
                g_ck_item_issue_view.dgCKIssueDetails.ItemsSource = g_ck_item_issue_list;
                g_ck_item_issue_view.dgCKIssueDetails.CommitEdit();
                g_ck_item_issue_view.dgCKIssueDetails.Rebind();
            }
            catch { }
            this.Close();
        }

        private void cmbUnit_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (CKItemBatchViewModel ck_item_batch_vm in g_ck_item_batches)
            {
                try
                {
                    UpdateConvFactor();
                    ck_item_batch_vm.rem_qty = ck_item_batch_vm.bal_qty / g_conv_factor;
                    g_ck_item_batches[ck_item_batch_vm.row_id].bal_qty = ck_item_batch_vm.bal_qty;
                    ck_item_batch_vm.ck_unit_cost = ck_item_batch_vm.tmp_ck_unit_cost * g_conv_factor;
                    g_ck_item_batches[ck_item_batch_vm.row_id].tmp_ck_unit_cost = ck_item_batch_vm.tmp_ck_unit_cost;
                }
                catch { }
            }
            dgCKIssueDetails.Rebind();
        }

        private void UpdateConvFactor()
        {
            CKItemUnitService ciscontext = new CKItemUnitService();
            g_conv_factor = (decimal)ciscontext.GetConversionFactor(Convert.ToInt32(cmbUnit.SelectedValue.ToString()));
        }
    }
}
