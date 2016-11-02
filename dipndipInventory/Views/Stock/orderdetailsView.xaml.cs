using dipndipInventory.EF;
using dipndipInventory.EF.DataServices;
using dipndipInventory.Helpers;
using dipndipInventory.Validations;
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
    /// Interaction logic for orderdetailsView.xaml
    /// </summary>
    public partial class orderdetailsView : RadWindow
    {
        CKOrderService _context = new CKOrderService();
        bool edit_mode = false;
        bool item_edit_mode = false;
        //string username = string.Empty;
        long id = 0;
        List<OrderDetailsViewModel> OrderDetailsList = new List<OrderDetailsViewModel>();
        public orderdetailsView()
        {
            InitializeComponent();
            ShowTaskBar.ShowInTaskbar(this, "Order Details");
            SetDate();
            string order_no = _context.GetNewCKOrderNo();
            txtOrderNo.Value = order_no;
        }

        public orderdetailsView(long order_id, string order_no, DateTime order_date)
        {
            InitializeComponent();
            ShowTaskBar.ShowInTaskbar(this, "Order Details");
            txtOrderNo.Value = order_no.ToString();
            dtpDate.SelectedDate = order_date;
            CKOrderService _ocontext = new CKOrderService();
            IEnumerable<order_details> selected_order = _ocontext.ReadCKOrderDetailsByMasterId(order_id);
            List<OrderDetailsViewModel> order_detail_list = new List<OrderDetailsViewModel>();
            int row_index = 0;
            id = order_id;
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
                order_detail_vm.rowIndex = ++row_index;
                if (order_detail.qty_issued != null)
                {
                    order_detail_vm.qty_issued = (decimal)order_detail.qty_issued;
                }
                order_detail_list.Add(order_detail_vm);
            }
            dgCKOrderDetails.ItemsSource = null;
            dgCKOrderDetails.ItemsSource = order_detail_list;
            OrderDetailsList = order_detail_list;
            edit_mode = true;
        }

        private void SetDate()
        {
            this.dtpDate.Culture = new System.Globalization.CultureInfo("en-US");
            this.dtpDate.Culture.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy";
            this.dtpDate.SelectedDate = DateTime.Now.Date;
            this.dtpDate.SelectedTime = DateTime.Now.TimeOfDay;
        }
        private void txtItemCode_KeyUp(object sender, KeyEventArgs e)
        {

            if ((e.Key == Key.L) &&
                (Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl)))
            {
                warehouseitemsearchView whs = new warehouseitemsearchView(this);
                whs.Show();
            }

            if (e.Key == Key.Enter)
            {
                UpdateItems();
            }
        }

        private void UpdateItems()
        {
            if (txtItemCode.Value.Length > 0)
            {
                WHItemService _wcontext = new WHItemService();
                ckwh_items item_details = _wcontext.GetItemByCode(txtItemCode.Value);
                if (item_details != null)
                {
                    txtDescription.Value = item_details.wh_item_description;
                    txtItemID.Value = item_details.Id.ToString();
                    WHItemUnitService _wucontext = new WHItemUnitService();
                    int base_unit_id = (int)(_wucontext.GetIdOfBaseUnit(item_details.Id));
                    if (base_unit_id == 0)
                    {
                        RadWindow.Alert("Please configure Unit for Item Code: " + txtItemCode.Value);
                        return;
                    }
                    txtUnitID.Value = base_unit_id.ToString();
                    txtUnit.Value = item_details.wh_unit_description;
                    txtQty.Focus();
                }
                else
                {
                    txtItemCode.SelectAll();
                    //txtItemCode.Focus();
                }
            }
        }

        private void btnAddItem_Click(object sender, RoutedEventArgs e)
        {
            WHItemUnitService _wucontext = new WHItemUnitService();
            try
            {
                OrderDetailsViewModel odv = new OrderDetailsViewModel();
                if (ValidateOrderItem())
                {
                    if (txtQty.Value <= 0)
                    {
                        RadWindow.Alert("Invalid Quantity");
                        txtQty.Focus();
                        return;
                    }
                    if (item_edit_mode)
                    {
                        if (dgCKOrderDetails.SelectedItem != null)
                        {
                            OrderDetailsViewModel objOrderDetailsViewModel = (dgCKOrderDetails.SelectedItem) as OrderDetailsViewModel;
                            int indx = objOrderDetailsViewModel.rowIndex - 1;
                            OrderDetailsList[indx].itemCode = txtItemCode.Value;
                            OrderDetailsList[indx].itemDescription = txtDescription.Value;
                            OrderDetailsList[indx].itemId = Convert.ToInt32(txtItemID.Value);
                            int base_unit_id = (int)(_wucontext.GetIdOfBaseUnit(OrderDetailsList[indx].itemId));
                            if (base_unit_id == 0)
                            {
                                RadWindow.Alert("Please configure Unit for Item Code: " + txtItemCode.Value);
                                return;
                            }
                            OrderDetailsList[indx].unitId = base_unit_id;
                            OrderDetailsList[indx].unitDescription = txtUnit.Value;
                            OrderDetailsList[indx].qty = (decimal)txtQty.Value;
                            OrderDetailsList[indx].qty_issued = 0;
                            OrderDetailsList[indx].qty_received = 0;
                            dgCKOrderDetails.ItemsSource = null;
                            dgCKOrderDetails.ItemsSource = OrderDetailsList;
                        }
                        ClearItem();
                        txtItemCode.Focus();
                        return;
                    }
                    odv.rowIndex = OrderDetailsList.Count + 1;
                    odv.itemId = Convert.ToInt32(txtItemID.Value);
                    odv.itemCode = txtItemCode.Value;
                    odv.itemDescription = txtDescription.Value;
                    odv.unitId = Convert.ToInt32(txtUnitID.Value);
                    odv.unitDescription = txtUnit.Value;
                    odv.qty = (decimal)txtQty.Value;
                    OrderDetailsList.Add(odv);
                    dgCKOrderDetails.ItemsSource = null;
                    dgCKOrderDetails.ItemsSource = OrderDetailsList;
                    ClearItem();
                    txtItemCode.Focus();
                }
            }
            catch (Exception Ex) { }
        }

        private void ClearItem()
        {
            txtItemID.Value = "";
            txtItemCode.Value = "";
            txtDescription.Value = "";
            txtUnitID.Value = "";
            txtUnit.Value = "";
            txtQty.Value = 0;
            item_edit_mode = false;
            btnAddItem.Content = "Add Item";
        }

        private bool ValidateOrderItem()
        {
            if (Validate.TxtMaskBlankCheck(txtItemCode, "Item Code"))
            {
                return false;
            }

            if (Validate.TxtMaskBlankCheck(txtItemID, "Item ID"))
            {
                return false;
            }

            if (Validate.TxtMaskBlankCheck(txtUnit, "Unit Description"))
            {
                return false;
            }

            if (Validate.TxtMaskBlankCheck(txtUnitID, "Unit ID"))
            {
                return false;
            }

            if (Validate.TxtMaskNumericBlankCheck(txtQty, "Quantity"))
            {
                return false;
            }

            return true;
        }

        private void btnDeleteItem_Click(object sender, RoutedEventArgs e)
        {
            if (dgCKOrderDetails.SelectedItem == null)
            {
                return;
            }

            try
            {
                OrderDetailsViewModel odvm = (dgCKOrderDetails.SelectedItem) as OrderDetailsViewModel;

                OrderDetailsList.RemoveAt(((int)odvm.rowIndex) - 1);

                dgCKOrderDetails.ItemsSource = null;
                dgCKOrderDetails.ItemsSource = OrderDetailsList;
                ClearItem();
            }
            catch { }
        }

        private void dgCKOrderDetails_SelectionChanged(object sender, SelectionChangeEventArgs e)
        {
            SelectOrderItem();
        }

        private void SelectOrderItem()
        {
            if (dgCKOrderDetails.SelectedItem == null)
            {
                return;
            }
            OrderDetailsViewModel odvm = (dgCKOrderDetails.SelectedItem) as OrderDetailsViewModel;

            txtItemID.Value = odvm.itemId.ToString();
            txtItemID.IsEnabled = false;
            txtItemID.IsReadOnly = true;

            txtItemCode.Value = odvm.itemCode;
            txtItemCode.IsEnabled = false;
            txtItemCode.IsReadOnly = true;

            txtDescription.Value = odvm.itemDescription;
            txtDescription.IsEnabled = false;
            txtDescription.IsReadOnly = true;

            txtUnitID.Value = odvm.unitId.ToString();
            txtUnitID.IsEnabled = false;
            txtUnitID.IsReadOnly = true;

            txtUnit.Value = odvm.unitDescription;
            txtUnit.IsEnabled = false;
            txtUnit.IsReadOnly = true;

            txtQty.Value = (double)odvm.qty;
            txtQty.IsEnabled = false;
            txtQty.IsReadOnly = true;

            btnSave.IsEnabled = false;
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (dgCKOrderDetails.SelectedItem == null)
            {
                return;
            }

            item_edit_mode = true;

            txtItemID.IsEnabled = true;
            txtItemID.IsReadOnly = false;

            txtItemCode.IsEnabled = true;
            txtItemCode.IsReadOnly = false;

            txtDescription.IsEnabled = true;
            txtDescription.IsReadOnly = false;

            txtUnit.IsEnabled = true;
            txtUnit.IsReadOnly = false;

            txtQty.IsEnabled = true;
            txtQty.IsReadOnly = false;

            btnAddItem.Content = "Update Item";

            btnSave.IsEnabled = true;

            txtItemCode.Focus();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnNew_Click(object sender, RoutedEventArgs e)
        {
            ClearOrder();
        }

        private void ClearOrder()
        {
            edit_mode = false;
            btnSave.IsEnabled = true;
            string order_no = _context.GetNewCKOrderNo();
            txtOrderNo.Value = order_no;
            dgCKOrderDetails.ItemsSource = null;
            OrderDetailsList.Clear();
            ClearItem();
            SetDate();
            txtItemCode.Focus();
        }
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateOrderDetails())
            {
                RadWindow.Confirm("Do you want to Continue ?", this.onSave);
            }
        }

        private bool ValidateOrderDetails()
        {
            if (dtpDate.SelectedDate == null)
            {
                RadWindow.Alert("Please Enter " + "Order Date");
                dtpDate.Focus();
                return false;
            }

            if (OrderDetailsList.Count < 1)
            {
                RadWindow.Alert("Please add at least one item in the order");
                return false;
            }

            return true;
        }

        private void onSave(object sender, WindowClosedEventArgs e)
        {
            if (e.DialogResult == true)
            {
                saveOrder();
            }
        }

        private void saveOrder()
        {
            SiteService _scontext = new SiteService();
            if (OrderDetailsList.Count < 1)
            {
                RadWindow.Alert("Please add at least one item in the order");
                return;
            }
            order order_master = new order();
            order_master.Id = id;
            order_master.order_no = txtOrderNo.Value;
            order_master.order_date = dtpDate.SelectedDate + DateTime.Now.TimeOfDay;
            order_master.order_from_site_id = GlobalVariables.ActiveSite.Id;
            order_master.order_to_site_id = _scontext.GetSiteIDBySiteName("Central Warehouse");
            order_master.order_status = "Pending";
            order_master.active = true;

            List<order_details> order_detail_list = new List<order_details>();
            foreach (var odetail in OrderDetailsList)
            {
                order_details objOrderDetail = new order_details();
                objOrderDetail.order_id = id;
                objOrderDetail.Id = odetail.id;
                objOrderDetail.order_no = txtOrderNo.Value;
                objOrderDetail.ckwh_item_id = odetail.itemId;
                objOrderDetail.wh_item_unit_id = odetail.unitId;
                objOrderDetail.qty = odetail.qty;
                order_detail_list.Add(objOrderDetail);
            }

            CKOrderService _ocontext = new CKOrderService();

            string _result = string.Empty;

            try
            {
                if (edit_mode)
                {
                    order_master.modified_by = GlobalVariables.ActiveUser.Id;
                    order_master.modified_date = DateTime.Now;
                    _result = _ocontext.UpdateOrder(order_master, order_detail_list) > 0 ? "Order Details Updated Successfully" : "Unable to Update Order Details";
                    MessageBox.Show(_result);
                }
                else
                {
                    order_master.created_by = GlobalVariables.ActiveUser.Id;
                    order_master.created_date = DateTime.Now;
                    _result = _ocontext.CreateOrder(order_master, order_detail_list) > 0 ? "Order Details Created Successfully" : "Unable to Create Order Details";
                    RadWindow.Alert(_result);
                    if (_result == "Order Details Created Successfully")
                    {
                        ClearOrder();
                    }
                }
            }
            catch { }


        }

        private void btnMail_Click(object sender, RoutedEventArgs e)
        {
            SendMail();
        }

        private void SendMail()
        {
            Microsoft.Office.Interop.Outlook.Application app = new Microsoft.Office.Interop.Outlook.Application();
            Microsoft.Office.Interop.Outlook.MailItem mailItem = app.CreateItem(Microsoft.Office.Interop.Outlook.OlItemType.olMailItem);
            mailItem.Subject = "This is the subject";
            mailItem.To = "jolly@dipndipkw.com";
            mailItem.Body = "This is the message.";
            string logPath = @"D:\items.pdf";
            mailItem.Attachments.Add(logPath);//logPath is a string holding path to the log.txt file
            mailItem.Importance = Microsoft.Office.Interop.Outlook.OlImportance.olImportanceHigh;
            mailItem.ReadReceiptRequested = true;
            mailItem.Send();
            //mailItem.Display(false);
            
        }
    }
}
