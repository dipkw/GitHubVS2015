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
        decimal selected_item_unit_cost = 0.00000000m;

        ckwh_items g_ckwh_item;
        transaction_details g_transaction_details;
        ckwh_items_adj g_ckwh_items_adj;
        wh_item_cost_history g_wh_item_cost_history;

        public ckwhstockadjView()
        {
            InitializeComponent();
            ShowTaskBar.ShowInTaskbar(this, "Stock Adjustment");
            GetNewAdjCode();
            ReadAllWHItems();
        }

        private void GetNewAdjCode()
        {
            WHAdjService _adcontext = new WHAdjService();
            adj_code = _adcontext.GetNewWHAdjCode();
        }
        private void ReadAllWHItems()
        {
            dgCKWHItems.ItemsSource = null;
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
            //cmbUnit.SelectedValuePath = "ck_unit_id";
            cmbUnit.SelectedValuePath = "Id";
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
            try
            {
                ckwh_items objItem = (dgCKWHItems.SelectedItem) as ckwh_items;
                int wh_item_id = objItem.Id;

                FillAllUnits(wh_item_id);
                FillAllReasons();
                txtItemCode.Value = objItem.wh_item_code;
                txtDescription.Value = objItem.wh_item_description;
                WHItemService _wicontext = new WHItemService();
                selected_item_id = _wicontext.GetItemId(txtItemCode.Value);
                //selected_item_unit_cost = (decimal)objItem.unit_cost;
                if (objItem.ck_avg_unit_cost == null)
                {
                    selected_item_unit_cost = 0.000m;
                }
                else
                {
                    selected_item_unit_cost = (decimal)objItem.ck_avg_unit_cost;
                }

                if (objItem.ck_qty != null)
                {
                    selected_ck_qty = (decimal)objItem.ck_qty;
                }
                cmbUnit.Focus();
            }
            catch { }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            WHItemService _wcontext = new WHItemService();
            WHItemUnitService _wiucontext = new WHItemUnitService();
            WHItemService _wicontext = new WHItemService();
            decimal conv_factor = 0.000m;
            decimal item_unit_cost = 0.000m;
            decimal updated_average_cost = 0.000m;
            int? ck_unit_id = 0;
            try
            {
                ck_unit_id =_wiucontext.GetCKUnitID(Convert.ToInt32(cmbUnit.SelectedValue));
                //conv_factor = (decimal)_wiucontext.GetConversionFactorByWHItemId(selected_item_id, Convert.ToInt32(cmbUnit.SelectedValue.ToString()));
                conv_factor = (decimal)_wiucontext.GetConversionFactorByWHItemId(selected_item_id, (int)ck_unit_id);
            }
            catch { return; }
            
            //decimal current_ck_qty = 0.00000000m;
            decimal updated_ck_qty = 0.00000000m;
            decimal adj_qty = (decimal)(txtQty.Value)*conv_factor;
            string trans_type = string.Empty;
            //updated_ck_qty = selected_ck_qty + (adj_qty*conversion_factor);
            updated_ck_qty = selected_ck_qty + (adj_qty);
            if (((decimal)txtQty.Value)>0)
            {
                updated_average_cost = GetAdjAvgCost(adj_qty);
                item_unit_cost = updated_average_cost;
                trans_type = "AdjIn";
                if(updated_average_cost != selected_item_unit_cost)
                {
                    //Create new record in wh_item_cost_history
                    //UpdateCostHistory(updated_average_cost);
                    CreateCost(updated_average_cost);
                }
            }
            else
            {
                item_unit_cost = selected_item_unit_cost * conv_factor;
                updated_average_cost = item_unit_cost;
                trans_type = "AdjOut";
                //Update ck_qty
                
                //update transaction
                
            }

            ////Update CK Quantity
            //_wcontext.UpdateCKItemQty(Convert.ToInt32(selected_item_id), updated_ck_qty, GlobalVariables.ActiveUser.Id);

            ////Update Item CK Item Avg Unit Cost
            //_wicontext.UpdateCKItemAvgUnitCost(selected_item_id, updated_average_cost);

            g_ckwh_item = new ckwh_items();
            g_ckwh_item.Id = selected_item_id;
            g_ckwh_item.ck_qty = updated_ck_qty;
            g_ckwh_item.ck_avg_unit_cost = updated_average_cost;
            g_ckwh_item.modified_by = GlobalVariables.ActiveUser.Id;
            g_ckwh_item.modified_date = DateTime.Now;

            //Update Transaction
            SaveTransaction(DateTime.Now, item_unit_cost, adj_qty, trans_type);

            SaveStockAdj(conv_factor,item_unit_cost);

            WHAdjService adjcontext = new WHAdjService();
            int result = adjcontext.SaveStockItemAdjustment(g_ckwh_item, g_transaction_details, g_ckwh_items_adj, g_wh_item_cost_history);
            if(result > 0)
            {
                MessageBox.Show("Stock Quantity Adjusted Successfully");
                GetNewAdjCode();
                ReadAllWHItems();
                ClearFields();
            }
            else
            {
                MessageBox.Show("Stock Quantity Adjustment Failed");
            }
            //Update item_cost_history table with new item_avg_cost

            //Update adj_code after saving
            
            //MessageBox.Show(updated_ck_qty.ToString());
            
        }

        private void ClearFields()
        {
            txtItemCode.Value = "";
            txtDescription.Value = "";
            cmbUnit.SelectedIndex = -1;
            txtQty.Value = 0.00000000;
        }
        //private int CreateCost(decimal updated_average_cost)
        private void CreateCost(decimal updated_average_cost)
        {
            WHItemCostService _hcontext = new WHItemCostService();
            wh_item_cost_history objWHItemCost = new wh_item_cost_history();
            wh_item_cost_history lastWHItemCost = _hcontext.GetLastCost((int)(selected_item_id));

            //int result = 0;

            //If item cost is in history table
            if (lastWHItemCost != null)
            {
                objWHItemCost.prev_cost = lastWHItemCost.curr_cost;
                objWHItemCost.ord = lastWHItemCost.ord + 1;
            }
            else
            {
                objWHItemCost.prev_cost = 0;
                objWHItemCost.ord = 1;
            }
            objWHItemCost.wh_item_id = selected_item_id;
            objWHItemCost.wh_item_code = txtItemCode.Value;
            objWHItemCost.wh_item_description = txtDescription.Value;
            objWHItemCost.curr_cost = updated_average_cost;
            objWHItemCost.created_by = GlobalVariables.ActiveUser.Id;
            objWHItemCost.created_date = DateTime.Now;
            //result = _hcontext.UpdateWHItemCost(objWHItemCost);//_hcontext.CreateWHItemCost(objWHItemCost);
            g_wh_item_cost_history = new wh_item_cost_history();
            g_wh_item_cost_history = objWHItemCost;

            //result = _hcontext.CreateWHItemCost(objWHItemCost);
            //if (result <= 0)
            //{
            //     MessageBox.Show("Warehouse Item Cost Updation Failed");
            //}
            //return result;
        }
        private void SaveStockAdj(decimal conv_factor, decimal item_unit_cost)
        {
            WHAdjService _adcontext = new WHAdjService();
            ckwh_items_adj objWHAdj = new ckwh_items_adj();
            //int result = 0;
            objWHAdj.adj_code = adj_code;
            objWHAdj.wh_item_id = selected_item_id;
            objWHAdj.wh_item_code = txtItemCode.Value;
            objWHAdj.wh_item_description = txtDescription.Value;
            objWHAdj.wh_item_unit_id = Convert.ToInt32(cmbUnit.SelectedValue.ToString());
            objWHAdj.wh_item_unit_description = cmbUnit.Text;
            objWHAdj.conversion_factor = conv_factor;
            objWHAdj.adj_qty = (decimal)txtQty.Value;
            objWHAdj.unit_cost = item_unit_cost;
            objWHAdj.ext_cost = (Math.Abs((decimal)(objWHAdj.adj_qty)) * objWHAdj.conversion_factor) * item_unit_cost;
            objWHAdj.created_by = GlobalVariables.ActiveUser.Id;
            objWHAdj.created_date = DateTime.Now;
            objWHAdj.active = 1;
            //result = _adcontext.CreateWHAdj(objWHAdj);

            g_ckwh_items_adj = new ckwh_items_adj();
            g_ckwh_items_adj = objWHAdj;
         }

        private decimal CalculateAverageCost(decimal previous_cost, decimal previous_qty, decimal current_cost, decimal current_qty)
        {
            decimal avg_cost = 0m;
            avg_cost = ((previous_cost * previous_qty) + (current_cost * current_qty)) / (previous_qty + current_qty);
            return avg_cost;
        }
        private int UpdateCostHistory(decimal average_unit_cost)
        {
            WHItemCostService _hcontext = new WHItemCostService();
            wh_item_cost_history objWHItemCost = new wh_item_cost_history();
            wh_item_cost_history lastWHItemCost = _hcontext.GetLastCost((int)(selected_item_id));
            int result = 0;
            //If item cost is in history table
            if (lastWHItemCost != null)
            {
                //if cost changes
                if (lastWHItemCost.curr_cost != average_unit_cost)
                {
                    objWHItemCost.wh_item_id = selected_item_id;
                    objWHItemCost.wh_item_code = txtItemCode.Value;
                    objWHItemCost.wh_item_description = txtDescription.Value;
                    objWHItemCost.ord = lastWHItemCost.ord + 1;
                    objWHItemCost.prev_cost = lastWHItemCost.curr_cost;

                    decimal previous_cost = (decimal)objWHItemCost.prev_cost;
                    //decimal previous_qty = (decimal)_wicontext.GetCurrentCKQty((int)objWHItemCost.wh_item_id);
                    decimal previous_qty = (decimal)selected_ck_qty;
                    decimal current_cost = (decimal)average_unit_cost;
                    decimal current_qty = (decimal)(txtQty.Value);

                    decimal avg_current_cost = CalculateAverageCost(previous_cost, previous_qty, current_cost, current_qty);

                    //objWHItemCost.curr_cost = ReceiptDetail.wh_item_unit_cost; //Update with avg. cost
                    objWHItemCost.curr_cost = avg_current_cost;

                    objWHItemCost.created_by = GlobalVariables.ActiveUser.Id;
                    objWHItemCost.created_date = DateTime.Now;
                    //result = _hcontext.UpdateWHItemCost(objWHItemCost);//_hcontext.CreateWHItemCost(objWHItemCost);
                    result = _hcontext.CreateWHItemCost(objWHItemCost);
                    if (result <= 0)
                    {
                        MessageBox.Show("Warehouse Item Cost Updation Failed");
                        return result;
                    }
                }
                else
                {
                    return 1;
                }
            }
            else
            {
                objWHItemCost.wh_item_id = selected_item_id;
                objWHItemCost.wh_item_code = txtItemCode.Value;
                objWHItemCost.wh_item_description = txtDescription.Value;
                objWHItemCost.ord = 1;
                objWHItemCost.prev_cost = 0;

                //decimal previous_cost = (decimal)objWHItemCost.prev_cost;
                //decimal previous_qty = (decimal)_wicontext.GetCurrentCKQty((int)objWHItemCost.wh_item_id);
                //decimal current_cost = (decimal)ReceiptDetail.wh_item_unit_cost;
                //decimal current_qty = (decimal)ReceiptDetail.qty_received;

                //decimal avg_current_cost = CalculateAverageCost(previous_cost, previous_qty, current_cost, current_qty);

                //objWHItemCost.curr_cost = ReceiptDetail.wh_item_unit_cost; //Update with avg. cost
                objWHItemCost.curr_cost = (decimal)selected_item_unit_cost;

                objWHItemCost.created_by = GlobalVariables.ActiveUser.Id;
                objWHItemCost.created_date = DateTime.Now;
                //result = _hcontext.UpdateWHItemCost(objWHItemCost);
                result = _hcontext.CreateWHItemCost(objWHItemCost);
                if (result <= 0)
                {
                    MessageBox.Show("Warehouse Item Cost Updation Failed");
                    return result;
                }
            }
            return result;
        }

        //private int SaveTransaction(DateTime adj_date_time, decimal item_unit_cost, decimal qty_adjusted, string trans_type)
        private void SaveTransaction(DateTime adj_date_time, decimal item_unit_cost, decimal qty_adjusted, string trans_type)
        {
            //int result = 0;

            SiteService _scontext = new SiteService();
            TransactionService _tcontext = new TransactionService();
            transaction_details objTransactionDetail = new transaction_details();
            objTransactionDetail.trans_ref_no = adj_code;
            objTransactionDetail.wh_item_id = selected_item_id;
            objTransactionDetail.wh_item_code = txtItemCode.Value;
            objTransactionDetail.wh_item_description = txtDescription.Value;
            //objTransactionDetail.trans_date = dtpReceiptDate.SelectedDate + DateTime.Now.TimeOfDay;
            objTransactionDetail.trans_date = adj_date_time;
            objTransactionDetail.wh_item_unit_id = Convert.ToInt32(cmbUnit.SelectedValue.ToString());
            objTransactionDetail.ck_unit_description = cmbUnit.Text;
            objTransactionDetail.qty = qty_adjusted;
            objTransactionDetail.unit_cost = item_unit_cost;
            objTransactionDetail.total_cost = Math.Abs(qty_adjusted) * item_unit_cost;
            objTransactionDetail.order_from_site_id = _scontext.GetSiteIDBySiteName("Central Kitchen");
            objTransactionDetail.order_to_site_id = _scontext.GetSiteIDBySiteName("Central Kitchen");
            objTransactionDetail.trans_type = trans_type;
            objTransactionDetail.active = true;
            objTransactionDetail.created_by = GlobalVariables.ActiveUser.Id;
            objTransactionDetail.created_date = adj_date_time;
            //result = _tcontext.CreateTransaction(objTransactionDetail);

            //return result;
            g_transaction_details = new transaction_details();
            g_transaction_details = objTransactionDetail;
        }

        private decimal GetAdjAvgCost(decimal adj_qty)
        {
            WHItemService _wcontext = new WHItemService();
            TransactionService _tcontext = new TransactionService();
            decimal current_item_qty = (decimal)_wcontext.GetCurrentCKQty(selected_item_id);
            decimal qty_sum = 0.000m;
            decimal avg_unit_cost = 0.000m;
            decimal total_ext_cost = 0.000m;
            int skip_no = 0;
            decimal qty = 0.000m;
            transaction_details rcpt_transaction;
            while (true)
            {
                rcpt_transaction = _tcontext.ReadNReceiptTransaction(selected_item_id, skip_no);
                if(rcpt_transaction == null)
                {
                    break;
                }
                if (qty_sum + (decimal)(rcpt_transaction.qty)> adj_qty)
                {
                    //qty = (qty_sum + (decimal)rcpt_transaction.qty) - (adj_qty);
                    qty = adj_qty - qty_sum;
                    qty_sum += qty;
                    total_ext_cost += (decimal)rcpt_transaction.unit_cost * qty;
                    break;
                }
                else
                {
                    qty = (decimal)rcpt_transaction.qty;
                    qty_sum += qty;
                }
                total_ext_cost += (decimal)rcpt_transaction.unit_cost * qty;
                skip_no++;
            }
            avg_unit_cost = total_ext_cost / qty_sum;
            return avg_unit_cost;
        }

        private void cmbUnit_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            WHItemUnitService _wucontext = new WHItemUnitService();
            int? ck_unit_id = 0;
            WHItemUnitService _wiucontext = new WHItemUnitService();
            ck_unit_id = _wiucontext.GetCKUnitID((Convert.ToInt32(cmbUnit.SelectedValue)));
            if(cmbUnit.SelectedValue==null)
            {
                return;
            }
            //conversion_factor = (decimal)_wucontext.GetConversionFactorByWHItemId(selected_item_id, Convert.ToInt32(cmbUnit.SelectedValue.ToString()));
            conversion_factor = (decimal)_wucontext.GetConversionFactorByWHItemId(selected_item_id, (int)ck_unit_id);
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
