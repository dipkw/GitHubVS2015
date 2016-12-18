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
    /// Interaction logic for ckproductionView.xaml
    /// </summary>
    public partial class ckproductionView : RadWindow
    {
        List<CKProductionViewModel> ProductionVMList = new List<CKProductionViewModel>();
        CKProductionService cpcontext = new CKProductionService();
        List<ck_items> ck_items_list = new List<ck_items>();
        List<ckwh_items> warehouse_items_list = new List<ckwh_items>();
        List<ck_prod> production_list = new List<ck_prod>();
        List<ck_item_cost_history> ck_item_cost_list = new List<ck_item_cost_history>();
        List<ck_stock_trans> ck_stock_trans_list = new List<ck_stock_trans>();
        List<transaction_details> transaction_details_list = new List<transaction_details>();
        public ckproductionView()
        {
            InitializeComponent();
            AssignNewProductionCode();            
            SetDate();
            ShowTaskBar.ShowInTaskbar(this, "Central Kitchen Item Production");
            FillProductionGrid();
        }

        private void AssignNewProductionCode()
        {
            string prod_code = cpcontext.GetNewProductionCode();
            txtProductionCode.Value = prod_code;
        }
        private void FillProductionGrid()
        {
            CKItemService _cicontext = new CKItemService();

            IEnumerable<ck_items> objCKItems = _cicontext.ReadAllCKItems();
            List<CKProductionViewModel> objCKProductionViewModel = new List<CKProductionViewModel>();

            foreach (ck_items ckitem in objCKItems)
            {
                CKProductionViewModel ckpvm = new CKProductionViewModel();
                try
                {
                    ckpvm.itemId = ckitem.Id;
                    ckpvm.itemCode = ckitem.ck_item_code;
                    ckpvm.itemDescription = ckitem.ck_item_description;
                    if (ckitem.ck_design_qty == null)
                    {
                        ckpvm.designQty = 0.000m;
                    }
                    else
                    {
                        ckpvm.designQty = (decimal)ckitem.ck_design_qty;
                    }
                    if (ckitem.qty_on_hand == null)
                    {
                        ckpvm.qtyonHand = 0.000m;
                    }
                    else
                    {
                        ckpvm.qtyonHand = (decimal)ckitem.qty_on_hand;
                    }
                    ckpvm.prodDate = DateTime.Today;
                    ckpvm.expDate = DateTime.Today;
                    if (ckitem.qty_on_hand == null)
                    {
                        ckpvm.qtyonHand = 0.000m;
                    }
                    else
                    {
                        ckpvm.qtyonHand = (decimal)ckitem.qty_on_hand;
                    }
                    ckpvm.ckUnit = ckitem.ck_units.unit_description;
                }
                catch
                {

                }

                objCKProductionViewModel.Add(ckpvm);
            }
            dgCKProduction.ItemsSource = null;
            dgCKProduction.ItemsSource = objCKProductionViewModel.ToList();
        }
        private void SetDate()
        {
            this.dtpProductionDate.Culture = new System.Globalization.CultureInfo("en-US");
            this.dtpProductionDate.Culture.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy";
            this.dtpProductionDate.SelectedDate = DateTime.Now.Date;
            this.dtpProductionDate.SelectedTime = DateTime.Now.TimeOfDay;
        }
        private void btnProcess_Click(object sender, RoutedEventArgs e)
        {
            ReadProductionGrid();

            if(!CKItemUnitsAssigned())
            {
                return;
            }

            if (MessageBox.Show("Do you want to save?", "Confirm", MessageBoxButton.YesNo) == MessageBoxResult.No)
            {
                return;
            }
            GenerateCKItemCostList();

            GenerateCKStockTransList();


            if(!CheckWarehouseItems())
            {
                return;
            }

            CKProductionService pscontext = new CKProductionService();
            string result = pscontext.SaveCKItemProduction(production_list, ck_items_list, warehouse_items_list, ck_item_cost_list, ck_stock_trans_list, transaction_details_list, GlobalVariables.ActiveUser.Id) > 0 ? "CK Branch Item Production Saved Successfully" : "Unable to Save CK Branch Item Production";
            MessageBox.Show(result);
            if(result == "CK Branch Item Production Saved Successfully")
            {
                if (MessageBox.Show("Do you want to print?", "Confirm", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    PrintProduction();
                }
                AssignNewProductionCode();
            }
            production_list.Clear();
            FillProductionGrid();
            transaction_details_list.Clear();
        }

        private bool CKItemUnitsAssigned()
        {
            CKItemUnitService ckucontext = new CKItemUnitService();
            foreach(ck_prod production_item in production_list)
            {
                try
                {
                    int default_unit_id = (int)ckucontext.GetDefaultUnitID((int)production_item.ck_item_id);
                    if(default_unit_id == 0)
                    {
                        MessageBox.Show("Please assign unit for " + production_item.ck_item_code + " (" + production_item.ck_item_desc + ")");
                        return false;
                    }
                }
                catch
                {
                    
                }
            }

            return true;
        }

        private bool CheckWarehouseItems()
        {
            foreach(ckwh_items ckwhitem in warehouse_items_list)
            {
                if(ckwhitem.ck_qty>=0)
                {
                    
                }
                else
                {
                    try
                    {
                        WHItemService whscontext = new WHItemService();

                        string wh_item_code = whscontext.GetItemCode(ckwhitem.Id);
                        string wh_item_desc = whscontext.GetItemDescription(ckwhitem.Id);
                        string msg = "Item: " + wh_item_code.Trim() + "(" + wh_item_desc.Trim() + ") - Quantity not sufficient for production";
                        MessageBox.Show(msg);
                        return false;
                    }
                    catch { }
                }
            }
            return true;
        }

        private void GenerateCKStockTransList()
        {
            ck_stock_trans_list.Clear();
            foreach(ck_prod ckprod in production_list)
            {
                ck_stock_trans ckstocktrans = new ck_stock_trans();
                ckstocktrans.ck_item_id = ckprod.ck_item_id;
                ckstocktrans.ck_item_code = ckprod.ck_item_code;
                ckstocktrans.ck_item_desc = ckprod.ck_item_desc;
                ckstocktrans.trans_ref_no = ckprod.prod_code;
                ckstocktrans.trans_date = ckprod.prod_date;
                ckstocktrans.prod_code = ckprod.prod_code;
                ckstocktrans.batch_no = ckprod.batch_no;
                ckstocktrans.prod_date = ckprod.prod_date;
                ckstocktrans.exp_date = ckprod.exp_date;
                ckstocktrans.ck_unit_id = ckprod.ck_item_unit_id;
                ckstocktrans.ck_unit_desc = ckprod.ck_item_unit_desc;
                ckstocktrans.qty = ckprod.prod_qty;
                ckstocktrans.trans_type = "Production";
                ckstocktrans.unit_cost = ckprod.unit_cost;
                ckstocktrans.total_cost = ckprod.total_cost;
                ckstocktrans.trans_from = GlobalVariables.ActiveSite.Id;
                ckstocktrans.trans_to = GlobalVariables.ActiveSite.Id;
                ckstocktrans.active = true;
                ckstocktrans.created_by = GlobalVariables.ActiveUser.Id;
                ckstocktrans.created_date = DateTime.Now;
                ck_stock_trans_list.Add(ckstocktrans);
            }
        }

        private void GenerateCKItemCostList()
        {
            foreach(ck_prod ckproduction in production_list)
            {
                CKItemCostService cscontext = new CKItemCostService();
                CKItemService citcontext = new CKItemService();
                int ck_item_id = (int)ckproduction.ck_item_id;
                decimal ck_item_current_cost_1 = cscontext.GetCurrentCKItemCost(ck_item_id);
                decimal ck_item_current_cost = citcontext.GetCurrentCKItemCost(ck_item_id);

                ck_item_cost_history ck_item_cost = new ck_item_cost_history();
                ck_item_cost.ck_item_id = ck_item_id;
                ck_item_cost.ck_item_code = ckproduction.ck_item_code;
                ck_item_cost.ck_item_description = ckproduction.ck_item_desc;

                ck_item_cost.created_by = GlobalVariables.ActiveUser.Id;
                ck_item_cost.created_date = DateTime.Now;

                if (ck_item_current_cost_1 == 0.000m)
                {
                    ck_item_cost.ord = 1;
                    ck_item_cost.prev_cost = 0.000m;
                    ck_item_cost.curr_cost = ckproduction.unit_cost;
                    ck_item_cost_list.Add(ck_item_cost);
                }
                else if(ck_item_current_cost != Math.Truncate((decimal)(ckproduction.unit_cost)*1000m)/1000m)
                {
                    ck_item_cost.ord = (cscontext.GetLastOrd(ck_item_id)) + 1;
                    ck_item_cost.prev_cost = ck_item_current_cost;
                    ck_item_cost.curr_cost = ckproduction.unit_cost;
                    ck_item_cost_list.Add(ck_item_cost);
                }
            }
        }

        private void ReadProductionGrid()
        {
            var rows = this.dgCKProduction.ChildrenOfType<GridViewRow>();
            int result = 0;
            CKOrderService _ocontext = new CKOrderService();
            production_list.Clear();
            foreach (var row in rows)
            {
                if (row is GridViewNewRow)
                    continue;

                CKProductionViewModel objCKProductionViewModel = row.Item as CKProductionViewModel;
                
                if (objCKProductionViewModel.prodQty > 0)
                {

                    ck_prod objProduction = new ck_prod();
                    objProduction.prod_code = txtProductionCode.Value;
                    objProduction.prod_date = dtpProductionDate.SelectedDate;
                    objProduction.exp_date = objCKProductionViewModel.expDate;
                    objProduction.ck_item_id = objCKProductionViewModel.itemId;
                    objProduction.ck_item_code = objCKProductionViewModel.itemCode;
                    objProduction.ck_item_desc = objCKProductionViewModel.itemDescription;
                    objProduction.batch_no = GetBatchNo(objCKProductionViewModel.itemCode);
                    CKItemUnitService cuscontext = new CKItemUnitService();
                    int ck_unit_id = (int)cuscontext.GetIdOfBaseUnit((int)objProduction.ck_item_id);
                    objProduction.ck_item_unit_id = ck_unit_id;
                    objProduction.conv_factor = 1.000m;
                    objProduction.ck_item_unit_desc = objCKProductionViewModel.ckUnit;
                    //objProduction.prod_qty = objCKProductionViewModel.prodQty;
                    objProduction.prod_qty = objCKProductionViewModel.prodQty*objCKProductionViewModel.designQty;
                    //objProduction.bal_qty = objCKProductionViewModel.prodQty;
                    objProduction.bal_qty = objCKProductionViewModel.prodQty * objCKProductionViewModel.designQty;
                    decimal cur_ck_item_prod_cost = GetCKItemProdCost(objCKProductionViewModel.itemId, objCKProductionViewModel.prodQty, objCKProductionViewModel.designQty);
                    decimal cur_ck_item_cost = ((cur_ck_item_prod_cost / objCKProductionViewModel.prodQty)/objCKProductionViewModel.designQty);
                    objProduction.unit_cost = GetCKItemAvgCost(objCKProductionViewModel.itemId,cur_ck_item_cost,objCKProductionViewModel.prodQty);
                    objProduction.total_cost = (decimal)(objProduction.bal_qty * objProduction.unit_cost);
                    //objProduction.total_cost = objCKProductionViewModel.prodQty * objProduction.unit_cost;
                    objProduction.created_by = GlobalVariables.ActiveUser.Id;
                    objProduction.created_date = DateTime.Now;
                    objProduction.active = 1;
                    production_list.Add(objProduction);

                    ck_items objCKItem = new ck_items();
                    CKItemService cicontext = new CKItemService();
                    decimal? ck_item_current_qty = cicontext.GetCurrentCKItemQty(objCKProductionViewModel.itemId);
                    if(ck_item_current_qty == null)
                    {
                        ck_item_current_qty = 0.000m;
                    }
                    objCKItem.Id = objCKProductionViewModel.itemId;
                    objCKItem.ck_item_unit_cost = objProduction.unit_cost;
                    //objCKItem.qty_on_hand = objCKProductionViewModel.prodQty + ck_item_current_qty;
                    objCKItem.qty_on_hand = objProduction.prod_qty + ck_item_current_qty;
                    ck_items_list.Add(objCKItem);

                    objCKProductionViewModel.prodCode = txtProductionCode.Value;
                    objCKProductionViewModel.batchNo = GetBatchNo(objCKProductionViewModel.itemCode);
                    //objCKProductionViewModel.prodItemCost = GetCKItemProdCost(objCKProductionViewModel.itemId, objCKProductionViewModel.prodQty, objCKProductionViewModel.designQty);
                    objCKProductionViewModel.prodItemCost = cur_ck_item_prod_cost;
                    //MessageBox.Show(objCKProductionViewModel.itemCode + " " + objCKProductionViewModel.itemDescription + " " + objCKProductionViewModel.prodItemCost);
                    ProductionVMList.Add(objCKProductionViewModel);

                   

                    //production_list.Clear();
                }
            }
        }

        private decimal GetCKItemAvgCost(int ck_item_id, decimal current_cost, decimal current_qty)
        {
            decimal ck_item_avg_cost = 0.000m;

            CKItemService cicontext = new CKItemService();
            decimal previous_ck_item_qty = cicontext.GetCurrentCKItemQty(ck_item_id);
            decimal previous_ck_item_cost = cicontext.GetCurrentCKItemCost(ck_item_id);

            ck_item_avg_cost = ((previous_ck_item_cost * previous_ck_item_qty) + (current_cost * current_qty)) / (previous_ck_item_qty+current_qty);

            return ck_item_avg_cost;
        }
        private string GetBatchNo(string itemCode)
        {
            string[] tmpItemCode = itemCode.Split('-');
            //DateTime curr_date = DateTime.Now.Date;
            DateTime curr_date = (DateTime)dtpProductionDate.SelectedDate;
            //string batch_no = tmpItemCode[0] + tmpItemCode[1] + DateTime.Today.Date.ToString("dd") + DateTime.Today.Month + DateTime.Now.Date.ToString("yy");
            string batch_no = tmpItemCode[0] + tmpItemCode[1] + curr_date.Date.ToString("dd") + curr_date.Month + curr_date.ToString("yy");

            return batch_no;
        }

        private decimal GetCKItemProdCost(int ck_item_id, decimal prodQty, decimal design_qty)
        {
            decimal production_item_cost = 0.000m;
            try
            {
                CKItemDetailService _cdcontext = new CKItemDetailService();
                WHItemService _wicontext = new WHItemService();
                WHItemUnitService _wucontext = new WHItemUnitService();
                IEnumerable<ck_item_details> CKItemRecipeList = _cdcontext.ReadAllCKItemRecipeByCKItemId(ck_item_id);
                decimal? ck_item_prod_qty = design_qty * prodQty;
                decimal recipe_unit_cost = 0.000m;
                transaction_details_list.Clear();
                foreach (ck_item_details item_recipe in CKItemRecipeList)
                {
                    int ckwh_item_id = (int)item_recipe.ckwh_item_id;
                    int wh_unit_id = (int)item_recipe.ckwh_item_unit_id;
                    decimal? avg_wh_item_cost = _wicontext.GetCKAvgCost(ckwh_item_id);
                    decimal? recipe_wh_item_qty = item_recipe.ckwh_item_qty;
                    decimal? conv_factor = _wucontext.GetConversionFactorByWHItemUnitId(ckwh_item_id, wh_unit_id);
                    if (conv_factor == null)
                    {
                        conv_factor = 0.000m;
                    }
                    decimal? used_wh_item_qty = ((item_recipe.ckwh_item_qty * conv_factor)* prodQty);
                    decimal? current_wh_item_qty = _wicontext.GetCurrentCKQty(ckwh_item_id);
                    if(current_wh_item_qty == null)
                    {
                        current_wh_item_qty = 0.000m;
                    }
                    //MessageBox.Show(item_recipe.ckwh_item_id + " " + used_wh_item_qty);

                    ckwh_items objCKWHItem = new ckwh_items();
                    objCKWHItem.Id = ckwh_item_id;
                    objCKWHItem.ck_qty = current_wh_item_qty - used_wh_item_qty;

                    warehouse_items_list.Add(objCKWHItem);
                    try
                    {
                        transaction_details transactiondetail = new transaction_details();
                        transactiondetail.trans_ref_no = txtProductionCode.Value;
                        transactiondetail.wh_item_id = ckwh_item_id;
                        //transactiondetail.wh_item_code = _wicontext.GetItemCode(ckwh_item_id);
                        transactiondetail.wh_item_code = item_recipe.ckwh_items.wh_item_code;
                        //transactiondetail.wh_item_description = _wicontext.GetItemDescription(ckwh_item_id);
                        transactiondetail.wh_item_description = item_recipe.ckwh_items.wh_item_description;
                        transactiondetail.trans_date = dtpProductionDate.SelectedDate;
                        transactiondetail.wh_item_unit_id = wh_unit_id;
                        transactiondetail.ck_unit_description = item_recipe.wh_item_unit.ck_units.unit_description;
                        transactiondetail.qty = (used_wh_item_qty) * (-1);
                        transactiondetail.unit_cost = (decimal)(avg_wh_item_cost * conv_factor) * (decimal)(recipe_wh_item_qty);
                        //transactiondetail.total_cost = transactiondetail.unit_cost * prodQty;
                        transactiondetail.total_cost = transactiondetail.unit_cost * transactiondetail.qty;
                        transactiondetail.order_from_site_id = GlobalVariables.ActiveSite.Id;
                        transactiondetail.order_to_site_id = GlobalVariables.ActiveSite.Id;
                        transactiondetail.trans_type = "Production";
                        transactiondetail.active = true;
                        transactiondetail.created_by = GlobalVariables.ActiveUser.Id;
                        transactiondetail.created_date = DateTime.Now;
                        transaction_details_list.Add(transactiondetail);
                    }
                    catch { }

                    if (avg_wh_item_cost == null)
                    {
                        avg_wh_item_cost = 0.000m;
                    }
                    recipe_unit_cost += (decimal)(avg_wh_item_cost * conv_factor)*(decimal)(recipe_wh_item_qty);
                    production_item_cost += (decimal)(avg_wh_item_cost * conv_factor * recipe_wh_item_qty * prodQty);
                }
                //MessageBox.Show(ck_item_prod_qty.ToString());
            }
            catch
            {
                return 0.000m;
            }

            return production_item_cost;
        }

        private void btnView_Click(object sender, RoutedEventArgs e)
        {
            ReadProductionGrid();
            ckproductionlistView cpv = new ckproductionlistView(txtProductionCode.Value, (DateTime)dtpProductionDate.SelectedDate, production_list);
            cpv.Show();
            production_list.Clear();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void PrintProduction()
        {
            try
            {

                //Telerik.Reporting.IReportDocument myReport = new DieReports.DieDetailsReport(die_id, "Drawing");
                //Telerik.Reporting.IReportDocument myReport = new dipndipTLReports.PrintOrderReport("CKOR-0007");
                //Telerik.Reporting.IReportDocument myReport = new dipndipTLReports.Reports.OrderDetailsB("CKOR-0007");
                Telerik.Reporting.IReportDocument myReport = new dipndipTLReports.Reports.CKProductionDetails(txtProductionCode.Value);


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
    }
}
