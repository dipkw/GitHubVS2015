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
    /// Interaction logic for whitemissueView.xaml
    /// </summary>
    public partial class whitemissueView : RadWindow
    {
        long active_order_id;
        public whitemissueView()
        {
            InitializeComponent();
            dgCKOrderDetails.BeginInsert();
        }

        public whitemissueView(long order_id, string order_no, DateTime order_date)
        {
            InitializeComponent();
            ShowTaskBar.ShowInTaskbar(this, "Item Issue Details");
            dtpIssueDate.SelectedDate = DateTime.Now.Date;
            dtpIssueDate.SelectedTime = DateTime.Now.TimeOfDay;
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
                order_detail_list.Add(order_detail_vm);
            }
            dgCKOrderDetails.ItemsSource = null;
            dgCKOrderDetails.ItemsSource = order_detail_list;
        }

        private void dgCKOrderDetails_CellValidating(object sender, GridViewCellValidatingEventArgs e)
        {
            try
            {
                if (e.Cell.Column.UniqueName == "qty_issued")
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
            catch { }
        }

        private void btnAddItem_Click(object sender, RoutedEventArgs e)
        {
            //var rows = this.dgCKOrderDetails.ChildrenOfType<GridViewRow>();

            //foreach (var row in rows)
            //{
            //    if (row is GridViewNewRow)
            //        continue;

            //    foreach (var cell in row.Cells)
            //    {
            //        MessageBox.Show(cell.ToString());
            //    }
            //}


            //var rows = this.dgCKOrderDetails.ChildrenOfType<GridViewRow>();
            //foreach (var row in rows)
            //{
            //    if (row is GridViewNewRow)
            //        continue;

            //    OrderDetailsViewModel objOrderDetails = row.Item as OrderDetailsViewModel;
            //}
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
                
                //result = _ocontext.UpdateIssuedQty(active_order_id, objOrderDetails.qty_issued);
                result = _ocontext.UpdateIssuedQty(objOrderDetails.id, objOrderDetails.qty_issued);
            }
            if (result > 0)
            {
                result = _ocontext.UpdateCKOrderStatus(active_order_id, "Issued", (DateTime)(dtpIssueDate.SelectedDate+DateTime.Now.TimeOfDay),GlobalVariables.ActiveUser.Id);
            }
            string response = result > 0 ? "Items Issued Successfully" : "Unable to issue the Items";

            RadWindow.Alert(response);
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
