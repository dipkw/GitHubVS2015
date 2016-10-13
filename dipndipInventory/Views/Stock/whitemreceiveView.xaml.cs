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
    /// Interaction logic for whitemreceiveView.xaml
    /// </summary>
    public partial class whitemreceiveView : RadWindow
    {
        long active_order_id;
        string active_receipt_no;
        public whitemreceiveView()
        {
            InitializeComponent();
        }

        public whitemreceiveView(long order_id, string order_no, DateTime order_date, DateTime issue_date)
        {
            InitializeComponent();
            ShowTaskBar.ShowInTaskbar(this, "Item Receiving Details");

            CKReceiptService _rcontext = new CKReceiptService();
            active_receipt_no = _rcontext.GetNewCKReceiptNo();

            dtpIssueDate.SelectedDate = issue_date.Date;
            dtpIssueDate.SelectedTime = issue_date.TimeOfDay;
            dtpReceiptDate.SelectedDate = DateTime.Now.Date;
            dtpReceiptDate.SelectedTime = DateTime.Now.TimeOfDay;
            active_order_id = order_id;
            txtOrderNo.Value = order_no.ToString();
            dtpDate.SelectedDate = order_date;
            CKOrderService _ocontext = new CKOrderService();
            IEnumerable<order_details> selected_order = _ocontext.ReadCKOrderDetailsByMasterId(order_id);
            List<OrderDetailsViewModel> order_detail_list = new List<OrderDetailsViewModel>();
            foreach (order_details order_detail in selected_order)
            {
                OrderDetailsViewModel order_detail_vm = new OrderDetailsViewModel();
                order_detail_vm.id = order_detail.Id;
                order_detail_vm.itemId = (int)order_detail.ckwh_item_id;
                order_detail_vm.itemCode = order_detail.ckwh_items.wh_item_code;
                order_detail_vm.itemDescription = order_detail.ckwh_items.wh_item_description;
                order_detail_vm.unitId = (int)order_detail.wh_item_unit_id;
                order_detail_vm.unitDescription = order_detail.wh_item_unit.ck_units.unit_description;
                order_detail_vm.qty = (decimal)order_detail.qty;
                if (order_detail.qty_issued != null)
                {
                    order_detail_vm.qty_issued = (decimal)order_detail.qty_issued;
                }
                if (order_detail.qty_received != null)
                {
                    order_detail_vm.qty_received = (decimal)order_detail.qty_received;
                }
                order_detail_list.Add(order_detail_vm);
            }
            dgCKOrderDetails.ItemsSource = null;
            dgCKOrderDetails.ItemsSource = order_detail_list;
        }

        private void dgCKOrderDetails_CellValidating(object sender, GridViewCellValidatingEventArgs e)
        {
            if (e.Cell.Column.UniqueName == "qty_received")
            {
                if ((Convert.ToDecimal(e.NewValue.ToString())) >= 0)
                {
                }
                else
                {
                    e.IsValid = false;
                    e.ErrorMessage = "Not a valid quantity";

                }
            }
        }

        private int CreateReceipt(DateTime receipt_date_time, List<receipt_details> receipt_detail_list)
        {
            int result = 0;
            CKReceiptService _rcontext = new CKReceiptService();
            SiteService _scontext = new SiteService();
            receipt receipt_master = new receipt();
            receipt_master.receipt_no = active_receipt_no;
            receipt_master.receipt_date = receipt_date_time;
            receipt_master.order_id = active_order_id;
            receipt_master.order_no = txtOrderNo.Value;
            receipt_master.issued_site = _scontext.GetSiteIDBySiteName("Central Warehouse");
            receipt_master.received_site = _scontext.GetSiteIDBySiteName("Central Kitchen"); //Active Site ID
            receipt_master.created_by = GlobalVariables.ActiveUser.Id;
            receipt_master.created_date = receipt_date_time;
            receipt_master.active = true;
            result = _rcontext.CreateReceipt(receipt_master, receipt_detail_list);
            return result;
        }

        private decimal CalculateAverageCost(decimal previous_cost, decimal previous_qty, decimal current_cost, decimal current_qty)
        {
            decimal avg_cost = 0m;
            avg_cost = ((previous_cost * previous_qty) + (current_cost * current_qty)) / (previous_qty + current_qty);
            return avg_cost;
        }

        private decimal CurrentAverageCost(int wh_item_id, decimal current_cost, decimal current_qty)
        {
            decimal current_average_cost = 0m;
            WHItemCostService _hcontext = new WHItemCostService();
            WHItemService _wicontext = new WHItemService();
            wh_item_cost_history lastWHItemCost = _hcontext.GetLastCost((int)(wh_item_id));
            decimal previous_cost;
            if (lastWHItemCost == null)
            {
                previous_cost = 0;
            }
            else
            {
                previous_cost = (decimal)lastWHItemCost.curr_cost;
                //previous_cost = current_cost;
            }
            decimal previous_qty = 0.0m;
            if (_wicontext.GetCurrentCKQty((int)wh_item_id) != null)
            {
                previous_qty = (decimal)_wicontext.GetCurrentCKQty((int)wh_item_id);
            }
            if (lastWHItemCost != null)
            {
                if (lastWHItemCost.curr_cost != current_cost)
                {
                    current_average_cost = CalculateAverageCost(previous_cost, previous_qty, current_cost, current_qty);
                }
                else
                {
                    current_average_cost = current_cost;
                }
            }
            else
            {
                current_average_cost = current_cost;
            }
            return current_average_cost;
        }

        private int UpdateItemCostHistory(List<receipt_details> receipt_detail_list)
        {
            int result = 0;
            WHItemCostService _hcontext = new WHItemCostService();
            WHItemService _wicontext = new WHItemService();
            foreach (receipt_details ReceiptDetail in receipt_detail_list)
            {
                wh_item_cost_history objWHItemCost = new wh_item_cost_history();
                wh_item_cost_history lastWHItemCost = _hcontext.GetLastCost((int)(ReceiptDetail.wh_item_id));
                //If item cost is in history table
                if (lastWHItemCost != null)
                {
                    //if cost changes
                    if (lastWHItemCost.curr_cost != ReceiptDetail.wh_item_unit_cost)
                    {
                        objWHItemCost.wh_item_id = ReceiptDetail.wh_item_id;
                        objWHItemCost.wh_item_code = ReceiptDetail.wh_item_code;
                        objWHItemCost.wh_item_description = ReceiptDetail.wh_item_description;
                        objWHItemCost.ord = lastWHItemCost.ord + 1;
                        objWHItemCost.prev_cost = lastWHItemCost.curr_cost;

                        decimal previous_cost = (decimal)objWHItemCost.prev_cost;
                        decimal previous_qty = (decimal)_wicontext.GetCurrentCKQty((int)objWHItemCost.wh_item_id);
                        decimal current_cost = (decimal)ReceiptDetail.wh_item_unit_cost;
                        decimal current_qty = (decimal)ReceiptDetail.qty_received;

                        decimal avg_current_cost = CalculateAverageCost(previous_cost, previous_qty, current_cost, current_qty);

                        //objWHItemCost.curr_cost = ReceiptDetail.wh_item_unit_cost; //Update with avg. cost
                        objWHItemCost.curr_cost = avg_current_cost;

                        objWHItemCost.created_by = GlobalVariables.ActiveUser.Id;
                        objWHItemCost.created_date = DateTime.Now;
                        result = _hcontext.UpdateWHItemCost(objWHItemCost);
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
                    objWHItemCost.wh_item_id = ReceiptDetail.wh_item_id;
                    objWHItemCost.wh_item_code = ReceiptDetail.wh_item_code;
                    objWHItemCost.wh_item_description = ReceiptDetail.wh_item_description;
                    objWHItemCost.ord = 1;
                    objWHItemCost.prev_cost = 0;

                    //decimal previous_cost = (decimal)objWHItemCost.prev_cost;
                    //decimal previous_qty = (decimal)_wicontext.GetCurrentCKQty((int)objWHItemCost.wh_item_id);
                    //decimal current_cost = (decimal)ReceiptDetail.wh_item_unit_cost;
                    //decimal current_qty = (decimal)ReceiptDetail.qty_received;

                    //decimal avg_current_cost = CalculateAverageCost(previous_cost, previous_qty, current_cost, current_qty);

                    //objWHItemCost.curr_cost = ReceiptDetail.wh_item_unit_cost; //Update with avg. cost
                    objWHItemCost.curr_cost = (decimal)ReceiptDetail.wh_item_unit_cost;

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
            }
            return result;
        }
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            var rows = this.dgCKOrderDetails.ChildrenOfType<GridViewRow>();
            int result = 0;

            DateTime receipt_date_time = (DateTime)dtpReceiptDate.SelectedDate + DateTime.Now.TimeOfDay;

            

            CKOrderService _ocontext = new CKOrderService();
            List<receipt_details> receipt_detail_list = new List<receipt_details>();
            WHItemService _wcontext = new WHItemService();
            
            foreach (var row in rows)
            {
                if (row is GridViewNewRow)
                    continue;

                OrderDetailsViewModel objOrderDetails = row.Item as OrderDetailsViewModel;

                result = _ocontext.UpdateReceivedQty(active_order_id, objOrderDetails.qty_received);
                if(result<=0)
                {
                    break;
                }



                decimal item_unit_cost = (decimal)_wcontext.GetCurrentCost(objOrderDetails.itemId);
                //decimal item_unit_cost = CurrentAverageCost(objOrderDetails.itemId, (decimal)_wcontext.GetCurrentCost(objOrderDetails.itemId), objOrderDetails.qty_received);
                receipt_details objReceiptDetail = new receipt_details();
                objReceiptDetail.receipt_no = active_receipt_no;
                objReceiptDetail.wh_item_id = objOrderDetails.itemId;
                objReceiptDetail.wh_item_code = objOrderDetails.itemCode;
                objReceiptDetail.wh_item_description = objOrderDetails.itemDescription;
                objReceiptDetail.wh_item_unit_id = objOrderDetails.unitId;
                objReceiptDetail.wh_item_description = objOrderDetails.unitDescription;
                objReceiptDetail.qty_ordered = objOrderDetails.qty;
                objReceiptDetail.qty_received = objOrderDetails.qty_received;
                objReceiptDetail.wh_item_unit_cost = item_unit_cost;
                objReceiptDetail.wh_item_ext_cost = item_unit_cost * objOrderDetails.qty_received;
                objReceiptDetail.active = true;
                objReceiptDetail.created_by = GlobalVariables.ActiveUser.Id;
                objReceiptDetail.created_date = receipt_date_time;

                receipt_detail_list.Add(objReceiptDetail);

                result = SaveTransaction(objOrderDetails, receipt_date_time, item_unit_cost);


                if(result<=0)
                {
                    break;
                }
                decimal current_item_qty = 0.0m;
                if(_wcontext.GetCurrentCKQty(objOrderDetails.itemId)!=null)
                {
                    current_item_qty = (decimal)_wcontext.GetCurrentCKQty(objOrderDetails.itemId);
                }
                
                decimal ck_updated_qty =  current_item_qty + objOrderDetails.qty_received;
                result = _wcontext.UpdateCKItemQty(objOrderDetails.itemId, ck_updated_qty, GlobalVariables.ActiveUser.Id);

                if(result<=0)
                {
                    break;
                }

                decimal current_average_cost = CurrentAverageCost(objOrderDetails.itemId, item_unit_cost, objOrderDetails.qty_received);
                result = _wcontext.UpdateCKItemAvgUnitCost(objOrderDetails.itemId, current_average_cost);

                if(result<=0)
                {
                    break;
                }
            }

            result = CreateReceipt(receipt_date_time, receipt_detail_list);
            result = UpdateItemCostHistory(receipt_detail_list);
            if (result > 0)
            {
                result = _ocontext.UpdateCKOrderReceiveStatus(active_order_id, "Received", receipt_date_time, GlobalVariables.ActiveUser.Id);
            }
            string response = result > 0 ? "Items Received Successfully" : "Unable to receive the Items. Please contact administrator";

            

            RadWindow.Alert(response);
        }

        private int SaveTransaction(OrderDetailsViewModel objOrderDetails, DateTime receipt_date_time, decimal item_unit_cost)
        {
            int result = 0;

            SiteService _scontext = new SiteService();
            TransactionService _tcontext = new TransactionService();
            transaction_details objTransactionDetail = new transaction_details();
            objTransactionDetail.trans_ref_no = active_receipt_no;
            objTransactionDetail.wh_item_id = objOrderDetails.itemId;
            objTransactionDetail.wh_item_code = objOrderDetails.itemCode;
            objTransactionDetail.wh_item_description = objOrderDetails.itemDescription;
            objTransactionDetail.trans_date = dtpReceiptDate.SelectedDate + DateTime.Now.TimeOfDay;
            objTransactionDetail.wh_item_unit_id = objOrderDetails.unitId;
            objTransactionDetail.ck_unit_description = objOrderDetails.unitDescription;
            objTransactionDetail.qty = objOrderDetails.qty_received;
            objTransactionDetail.unit_cost = item_unit_cost;
            objTransactionDetail.total_cost = (objTransactionDetail.qty * objTransactionDetail.unit_cost);
            objTransactionDetail.order_from_site_id = _scontext.GetSiteIDBySiteName("Central Warehouse");
            objTransactionDetail.order_to_site_id = _scontext.GetSiteIDBySiteName("Central Kitchen");
            objTransactionDetail.trans_type = "Receipt";
            objTransactionDetail.active = true;
            objTransactionDetail.created_by = GlobalVariables.ActiveUser.Id;
            objTransactionDetail.created_date = receipt_date_time;
            result = _tcontext.CreateTransaction(objTransactionDetail);

            return result;
        }
    }
}
