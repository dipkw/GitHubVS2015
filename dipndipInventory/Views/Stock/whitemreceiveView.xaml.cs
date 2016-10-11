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
        public whitemreceiveView()
        {
            InitializeComponent();
        }

        public whitemreceiveView(long order_id, string order_no, DateTime order_date, DateTime issue_date)
        {
            InitializeComponent();
            ShowTaskBar.ShowInTaskbar(this, "Item Receiving Details");
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

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            var rows = this.dgCKOrderDetails.ChildrenOfType<GridViewRow>();
            int result = 0;
            CKOrderService _ocontext = new CKOrderService();
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
                result = SaveTransaction(objOrderDetails);
                if(result<=0)
                {
                    break;
                }
            }
            if (result > 0)
            {
                result = _ocontext.UpdateCKOrderReceiveStatus(active_order_id, "Received", (DateTime)(dtpReceiptDate.SelectedDate + DateTime.Now.TimeOfDay), GlobalVariables.ActiveUser.Id);
            }
            string response = result > 0 ? "Items Received Successfully" : "Unable to receive the Items";

            

            RadWindow.Alert(response);
        }

        private int SaveTransaction(OrderDetailsViewModel objOrderDetails)
        {
            int result = 0;

            WHItemService _wcontext = new WHItemService();
            SiteService _scontext = new SiteService();
            TransactionService _tcontext = new TransactionService();
            transaction_details objTransactionDetail = new transaction_details();
            objTransactionDetail.wh_item_id = objOrderDetails.itemId;
            objTransactionDetail.wh_item_code = objOrderDetails.itemCode;
            objTransactionDetail.wh_item_description = objOrderDetails.itemDescription;
            objTransactionDetail.trans_date = dtpReceiptDate.SelectedDate + DateTime.Now.TimeOfDay;
            objTransactionDetail.wh_item_unit_id = objOrderDetails.unitId;
            objTransactionDetail.ck_unit_description = objOrderDetails.unitDescription;
            objTransactionDetail.qty = objOrderDetails.qty_received;
            objTransactionDetail.unit_cost = _wcontext.GetCurrentCost(objOrderDetails.itemId);
            objTransactionDetail.total_cost = (objTransactionDetail.qty * objTransactionDetail.unit_cost);
            objTransactionDetail.order_from_site_id = _scontext.GetSiteIDBySiteName("Central Warehouse");
            objTransactionDetail.order_to_site_id = _scontext.GetSiteIDBySiteName("Central Kitchen");
            objTransactionDetail.trans_type = "Receipt";
            objTransactionDetail.active = true;
            objTransactionDetail.created_by = GlobalVariables.ActiveUser.Id;
            objTransactionDetail.created_date = DateTime.Now;
            result = _tcontext.CreateTransaction(objTransactionDetail);

            return result;
        }
    }
}
