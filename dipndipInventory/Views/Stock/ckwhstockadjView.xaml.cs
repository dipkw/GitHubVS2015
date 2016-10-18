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

namespace dipndipInventory.Views.Stock
{
    /// <summary>
    /// Interaction logic for ckwhstockadjView.xaml
    /// </summary>
    public partial class ckwhstockadjView : RadWindow
    {
        WHItemService _context = new WHItemService();
        bool edit_mode = false;
        //string username = string.Empty;
        int id = 0;

        int selected_item_id = 0;
        decimal selected_ck_qty = 0.00000000m;
        decimal conversion_factor = 0.00000000m;
        string adj_code = string.Empty;
        public ckwhstockadjView()
        {
            InitializeComponent();
            ShowTaskBar.ShowInTaskbar(this, "Stock Adjustment");
            WHAdjService _adcontext = new WHAdjService();
            adj_code = _adcontext.GetNewWHAdjCode();
            ReadAllWHItems();
        }

        private void ReadAllWHItems()
        {
            IEnumerable<ckwh_items> objItems = _context.ReadAllWHItems();
            dgCKWHItems.ItemsSource = objItems;
            
            WHItemUnitService unitContext = new WHItemUnitService();
            //List<WHStockAdjustmentViewModel> objWHStkAdjVM = new List<WHStockAdjustmentViewModel>();
            //foreach(var stkItem in objItems)
            //{
            //    WHStockAdjustmentViewModel whsav = new WHStockAdjustmentViewModel();
            //    whsav.wh_item_id = stkItem.Id;
            //    whsav.wh_item_code = stkItem.wh_item_code;
            //    whsav.wh_item_description = stkItem.wh_item_description;
            //    whsav.wh_unit_id = (int)unitContext.GetIdOfBaseUnit(stkItem.Id);
            //    whsav.wh_unit_description = stkItem.wh_unit_description;
            //    whsav.adj_qty = 0m;
            //    //whsav.row_index = stkItem.;
            //    objWHStkAdjVM.Add(whsav);
            //}
            ////dgCKWHItems.ItemsSource = objItems;
            //dgCKWHItems.ItemsSource = null;

            //dgCKWHItems.ItemsSource = objWHStkAdjVM.ToList();
        }

        private void FillAllUnits(int wh_item_id)
        {
            WHItemUnitService unitContext = new WHItemUnitService();
            IEnumerable<wh_item_unit> objUnits = unitContext.ReadAllWHItemUnitsByWHItemId(wh_item_id);
            cmbUnit.DisplayMemberPath = "ck_units.unit_description";
            cmbUnit.SelectedValuePath = "ck_unit_id";
            cmbUnit.ItemsSource = objUnits.ToList();
            if(objUnits.Count()<1)
            {
                MessageBox.Show("Please assign unit to make any Stock Adustment for this item");
            }
        }

        private void FillAllReasons()
        {
            ReasonService _rcontext = new ReasonService();
            IEnumerable<reason_codes> objReasons = _rcontext.ReadAllActiveReasons();
            cmbReason.DisplayMemberPath = "description";
            cmbReason.SelectedValuePath = "Id";
            cmbReason.ItemsSource = objReasons.ToList();
        }

        private void dgCKWHItems_SelectionChanged(object sender, SelectionChangeEventArgs e)
        {
            //WHStockAdjustmentViewModel objWHStkAdjVM = (dgCKWHItems.SelectedItem) as WHStockAdjustmentViewModel;

            //if(objWHStkAdjVM.wh_unit_id == 0)
            //{
            //    MessageBox.Show("Please configure unit ");
            //    return;
            //}
            //int wh_item_id = objWHStkAdjVM.wh_item_id;

            ckwh_items objItem = (dgCKWHItems.SelectedItem) as ckwh_items;
            int wh_item_id = objItem.Id;

            FillAllUnits(wh_item_id);
            FillAllReasons();
            txtItemCode.Value = objItem.wh_item_code;
            txtDescription.Value = objItem.wh_item_description;
            WHItemService _wicontext = new WHItemService();
            selected_item_id = _wicontext.GetItemId(txtItemCode.Value);
            if (objItem.ck_qty != null)
            {
                selected_ck_qty = (decimal)objItem.ck_qty;
            }
            cmbUnit.Focus();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            WHItemService _wcontext = new WHItemService();
            //decimal current_ck_qty = 0.00000000m;
            decimal updated_ck_qty = 0.00000000m;
            updated_ck_qty = selected_ck_qty + ((decimal)(txtQty.Value)*conversion_factor);
            if(((decimal)txtQty.Value)>0)
            {
                CalcAdjAvgCost(((decimal)txtQty.Value));
            }
            else
            {
                //Update ck_qty
                _wcontext.UpdateCKItemQty(Convert.ToInt32(txtItemID.Value), updated_ck_qty, GlobalVariables.ActiveUser.Id);
                //update transaction

            }
            MessageBox.Show(updated_ck_qty.ToString());
        }

        private int SaveTransaction(OrderDetailsViewModel objOrderDetails, DateTime receipt_date_time, decimal item_unit_cost)
        {
            int result = 0;

            SiteService _scontext = new SiteService();
            TransactionService _tcontext = new TransactionService();
            transaction_details objTransactionDetail = new transaction_details();
            objTransactionDetail.trans_ref_no = adj_code;
            objTransactionDetail.wh_item_id = objOrderDetails.itemId;
            objTransactionDetail.wh_item_code = objOrderDetails.itemCode;
            objTransactionDetail.wh_item_description = objOrderDetails.itemDescription;
            //objTransactionDetail.trans_date = dtpReceiptDate.SelectedDate + DateTime.Now.TimeOfDay;
            objTransactionDetail.trans_date = DateTime.Now.Date + DateTime.Now.TimeOfDay;
            objTransactionDetail.wh_item_unit_id = objOrderDetails.unitId;
            objTransactionDetail.ck_unit_description = objOrderDetails.unitDescription;
            objTransactionDetail.qty = objOrderDetails.qty_received;
            objTransactionDetail.unit_cost = item_unit_cost;
            objTransactionDetail.total_cost = (objTransactionDetail.qty * objTransactionDetail.unit_cost);
            objTransactionDetail.order_from_site_id = _scontext.GetSiteIDBySiteName("Central Kitchen");
            objTransactionDetail.order_to_site_id = _scontext.GetSiteIDBySiteName("Central Kitchen");
            objTransactionDetail.trans_type = "Adjustment";
            objTransactionDetail.active = true;
            objTransactionDetail.created_by = GlobalVariables.ActiveUser.Id;
            objTransactionDetail.created_date = receipt_date_time;
            result = _tcontext.CreateTransaction(objTransactionDetail);

            return result;
        }

        private void CalcAdjAvgCost(decimal qty)
        {
            WHItemService _wcontext = new WHItemService();
            TransactionService _tcontext = new TransactionService();
            decimal current_item_qty = (decimal)_wcontext.GetCurrentCKQty(selected_item_id);
            decimal qty_sum = 0.000m;
            decimal avg_unit_cost = 0.000m;
            decimal total_ext_cost = 0.000m;
            
            IEnumerable<transaction_details> rcpt_transactions = _tcontext.ReadReceiptTransactions();
            foreach(var rcpt in rcpt_transactions)
            {
                qty_sum += (decimal)rcpt.qty;

                if(qty_sum>=qty)
                {
                    break;
                }
            }
        }

        private void cmbUnit_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            WHItemUnitService _wucontext = new WHItemUnitService();
            if(cmbUnit.SelectedValue==null)
            {
                return;
            }
            conversion_factor = (decimal)_wucontext.GetConversionFactorByWHItemId(selected_item_id, Convert.ToInt32(cmbUnit.SelectedValue.ToString()));
        }
    }
}
