using dipndipInventory.EF;
using dipndipInventory.EF.DataServices;
using dipndipInventory.Helpers;
using dipndipInventory.Validations;
using dipndipInventory.ViewModels;
using dipndipInventory.Views.Reports;
using Microsoft.Office.Interop.Outlook;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
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
using Telerik.Reporting.Processing;
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
        ckorderView g_ck_order_view;
        List<OrderDetailsViewModel> OrderDetailsList = new List<OrderDetailsViewModel>();
        
        public orderdetailsView()
        {
            if (!ActiveSiteIsCK())
            {
                MessageBox.Show("Sorry, Active Branch is not Central Kitchen");
                return;
            }
            InitializeComponent();
            
            ShowTaskBar.ShowInTaskbar(this, "Order Details");
            SetDate();
            string order_no = _context.GetNewCKOrderNo();
            txtOrderNo.Value = order_no;

            DateTime delivery_date = DateTime.Now.AddDays(1);

            try
            {
                delivery_date = (DateTime)_context.GetDeliveryDate(order_no);
            }
            catch
            {

            }

            dtpDeliveryDate.SelectedDate = delivery_date;
        }

        public bool ActiveSiteIsCK()
        {
            try
            {
                SiteService stcontext = new SiteService();
                if (stcontext.GetSiteNameBySiteId(GlobalVariables.ActiveSite.Id) == "Central Kitchen")
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
            return false;
        }
        public orderdetailsView(long order_id, string order_no, DateTime order_date)
        {
            if (!ActiveSiteIsCK())
            {
                MessageBox.Show("Sorry, Active Branch is not Central Kitchen");
                return;
            }
            InitializeComponent();
            ShowTaskBar.ShowInTaskbar(this, "Order Details");
            txtOrderNo.Value = order_no.ToString();
            dtpDate.SelectedDate = order_date;
            CKOrderService _ocontext = new CKOrderService();
            DateTime delivery_date = DateTime.Now;
            
            try
            {
                delivery_date = (DateTime)_context.GetDeliveryDate(order_no);
            }
            catch
            {

            }

            dtpDeliveryDate.SelectedDate = delivery_date;

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

        public orderdetailsView(long order_id, string order_no, DateTime order_date, ckorderView ck_order_view)
        {
            InitializeComponent();
            ShowTaskBar.ShowInTaskbar(this, "Order Details");
            
            txtOrderNo.Value = order_no.ToString();
            dtpDate.SelectedDate = order_date;
            CKOrderService _ocontext = new CKOrderService();
            DateTime delivery_date = DateTime.Now;
            g_ck_order_view = ck_order_view;
            try
            {
                delivery_date = (DateTime)_context.GetDeliveryDate(order_no);
            }
            catch
            {

            }

            dtpDeliveryDate.SelectedDate = delivery_date;

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
            try
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
            catch { }
        }

        private void btnAddItem_Click(object sender, RoutedEventArgs e)
        {
            WHItemUnitService _wucontext = new WHItemUnitService();
            try
            {
                OrderDetailsViewModel odv = new OrderDetailsViewModel();
                if (ValidateOrderItem())
                {
                    if(ExistingItem() && !item_edit_mode)
                    {
                        MessageBox.Show("Item is already existing in the order list");
                        return;
                    }
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
            catch { }
        }

        private bool ExistingItem()
        {
            return OrderDetailsList.Any(z => z.itemCode == txtItemCode.Value);
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
                btnSave.IsEnabled = true;
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
            try
            {
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
            catch { }
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
            btnMail.IsEnabled = false;
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
            if (OrderPlaced())
            {
                return;
            }

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

            CKOrderService ckocontext = new CKOrderService();
            //if (ckocontext.IsExistingCKOrderByOrderNo(txtOrderNo.Value))
            //{
            //    return;
            //}

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
            order_master.delivery_date = dtpDeliveryDate.SelectedDate;
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
                    if(ExistingOrder())
                    {
                        MessageBox.Show("Sorry, you can make only one order per day");
                        return;
                    }
                    order_master.created_by = GlobalVariables.ActiveUser.Id;
                    order_master.created_date = DateTime.Now;
                    CallSaveReport();
                    _result = _ocontext.CreateOrder(order_master, order_detail_list) > 0 ? "Order Details Created Successfully" : "Unable to Create Order Details";
                    RadWindow.Alert(_result);
                    if (_result == "Order Details Created Successfully")
                    {
                        //SendMail();
                        if(MessageBox.Show("Do you want to print the order","Print",MessageBoxButton.YesNo)==MessageBoxResult.Yes)
                        {
                            PrintOrder(txtOrderNo.Value);
                        }
                        IEnumerable<order> g_orders = _ocontext.ReadAllActiveSiteOrders(GlobalVariables.ActiveSite.Id);
                        try
                        {
                            if (g_ck_order_view.dgCKOrders.ItemsSource != null)
                            {
                                g_ck_order_view.dgCKOrders.ItemsSource = null;
                            }
                            g_ck_order_view.dgCKOrders.ItemsSource = g_orders;
                            g_ck_order_view.dgCKOrders.Rebind();
                            ClearOrder();
                        }
                        catch { btnMail.IsEnabled = true; }
                    }
                }
                btnMail.IsEnabled = true;
            }
            catch(System.Exception ex)
            {

            }

            
        }

        private bool ExistingOrder()
        {
            bool result = false;
            try
            {
                CKOrderService ckocontext = new CKOrderService();
                result = ckocontext.ExistingOrder((DateTime)dtpDate.SelectedDate);
            }
            catch
            {
                result = false;
            }

            return result;
        }

        private void btnMail_Click(object sender, RoutedEventArgs e)
        {
            //SendMail();
            //SavePdfOrder();
            //MailOrder();
            if(MessageBox.Show("Do you want to confirm the order?","Order Confirmation",MessageBoxButton.YesNo) == MessageBoxResult.No)
            {
                return;
            }
            SendMail();
            CKOrderService ckocontext = new CKOrderService();
            if(ckocontext.UpdateCKOrderedStatus(id,"Ordered",(DateTime)dtpDate.SelectedDate, GlobalVariables.ActiveUser.Id)<1)
            {
                MessageBox.Show("Error");
            }
            IEnumerable<order> g_orders = ckocontext.ReadAllActiveSiteOrders(GlobalVariables.ActiveSite.Id);
            try
            {
                if (g_ck_order_view.dgCKOrders.ItemsSource != null)
                {
                    g_ck_order_view.dgCKOrders.ItemsSource = null;
                }
                g_ck_order_view.dgCKOrders.ItemsSource = g_orders;
                g_ck_order_view.dgCKOrders.Rebind();
                ClearOrder();
            }
            catch { }
        }

        private bool OrderPlaced()
        {
            bool result = false;

            CKOrderService ckocontext = new CKOrderService();
            try
            {
                if (ckocontext.OrderPlaced(txtOrderNo.Value, DateTime.Now))
                {
                    MessageBox.Show("Sorry, You can make only one order per day");
                    return true;
                }
            }
            catch
            {
                return true;
            }

            return result;
        }
        private void SendMail()
        {
            try
            {
                if (OrderPlaced())
                {
                    return;
                }

                Telerik.Reporting.Report myReport = new dipndipTLReports.Reports.OrderDetailsB(txtOrderNo.Value);
                string ftime = DateTime.Now.Hour.ToString() + "-" + DateTime.Now.Minute.ToString() + "-" + DateTime.Now.Second.ToString();
                string fileName = string.Empty;
                if (GlobalVariables.AppEnvironment == "Development")
                {
                    //fileName = @"D:\CKOrders\Order-" + DateTime.Now.Date.ToString("dd-MM-yyyy") + "-" + ftime + ".pdf";
                    fileName = @"D:\CKOrders\" + txtOrderNo.Value + ".pdf";
                }
                else
                {
                    //fileName = @"E:\CKOrders\Order-" + DateTime.Now.Date.ToString("dd-MM-yyyy") + "-" + ftime + ".pdf";
                    fileName = @"E:\WHOrders\" + txtOrderNo.Value + ".pdf";
                }
                SaveReport(myReport, fileName);

                Microsoft.Office.Interop.Outlook.Application app = new Microsoft.Office.Interop.Outlook.Application();
                Microsoft.Office.Interop.Outlook.MailItem mailItem = app.CreateItem(Microsoft.Office.Interop.Outlook.OlItemType.olMailItem);
                mailItem.Subject = "Central Kitchen Order";
                if (GlobalVariables.AppEnvironment == "Development")
                {
                    mailItem.To = "jolly@dipndipkw.com";
                }
                else
                {
                    try
                    {
                        SiteService stcontext = new SiteService();
                        mailItem.To = stcontext.GetSiteMailBySiteCode("WH");
                        mailItem.CC = GlobalVariables.ck_order_mail_cc;
                    }
                    catch { MessageBox.Show("Please contact admin"); return; }
                }
                mailItem.Body = @"Dear Warehouse Officer,

Please find attached Order for Central Kitchen to be delivered on " + DateTime.Now.AddDays(1).Date.ToString("dd-MM-yyyy") + ".";
                mailItem.Body += @"

Regards";
                mailItem.Body += @"
Central Kitchen";
                //string logPath = @"D:\items.pdf";
                string logPath = fileName;
                mailItem.Attachments.Add(logPath);//logPath is a string holding path to the log.txt file
                mailItem.Importance = Microsoft.Office.Interop.Outlook.OlImportance.olImportanceHigh;
                mailItem.ReadReceiptRequested = true;
                mailItem.Send();
                //mailItem.Display(false);

                CKOrderService ckocontext = new CKOrderService();
                if (ckocontext.UpdateCKOrderMail(txtOrderNo.Value) > 0)
                {
                    MessageBox.Show("You order has been placed");
                }
                else
                {
                    MessageBox.Show("Sorry");
                }
            }
            catch { MessageBox.Show("Please contact admin"); }
        }

        private void btnPrint_Click(object sender, RoutedEventArgs e)
        {
            //OrderDetailsPrint odp = new OrderDetailsPrint();
            //odp.Show();

            try
            {

                //Telerik.Reporting.IReportDocument myReport = new DieReports.DieDetailsReport(die_id, "Drawing");
                //Telerik.Reporting.IReportDocument myReport = new dipndipTLReports.PrintOrderReport("CKOR-0007");
                //Telerik.Reporting.IReportDocument myReport = new dipndipTLReports.Reports.OrderDetailsB("CKOR-0007");
                Telerik.Reporting.IReportDocument myReport = new dipndipTLReports.Reports.OrderDetailsB(txtOrderNo.Value);


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

        public void PrintOrder(string order_no)
        {
            try
            {

                //Telerik.Reporting.IReportDocument myReport = new DieReports.DieDetailsReport(die_id, "Drawing");
                //Telerik.Reporting.IReportDocument myReport = new dipndipTLReports.PrintOrderReport("CKOR-0007");
                Telerik.Reporting.IReportDocument myReport = new dipndipTLReports.Reports.OrderDetailsB(order_no);


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
            catch { }
        }

        public void SendOrder()
        {
            //string mimeType;
            //string extension;
            //Encoding encoding;

            //Telerik.Reporting.IReportDocument myReport = new dipndipTLReports.Reports.OrderDetailsB(txtOrderNo.Value);

            //ReportProcessor rp = new ReportProcessor();
            //rp.RenderReport("PDF", myReport, myReport,null);

            //byte[] reportBytes = ReportProcessor.Render("PDF", myReport, null, out mimeType, out extension, out encoding);

            //MemoryStream ms = new MemoryStream(reportBytes);
            //ms.Position = 0;

            //System.Net.Mime.ContentType ct = new System.Net.Mime.ContentType(System.Net.Mime.MediaTypeNames.Text.Plain);
            //System.Net.Mail.Attachment attach = new System.Net.Mail.Attachment(ms, ct);
            //attach.ContentDisposition.FileName = "myFile.txt";
        }

        public void MailOrder()
        {

            Telerik.Reporting.Processing.ReportProcessor reportProcessor =
                new Telerik.Reporting.Processing.ReportProcessor();

            // set any deviceInfo settings if necessary
            System.Collections.Hashtable deviceInfo = new System.Collections.Hashtable();

            Telerik.Reporting.InstanceReportSource instanceReportSource =
                new Telerik.Reporting.InstanceReportSource();

            Telerik.Reporting.IReportDocument myReport = new dipndipTLReports.Reports.OrderDetailsB(txtOrderNo.Value);

            instanceReportSource.ReportDocument = myReport;

            // "OrderNumber" is the name of the parameter and "SO43659" is the default value
            //instanceReportSource.Parameters.Add(new Telerik.Reporting.Parameter("OrderNumber", "SO43659"));

            Telerik.Reporting.Processing.RenderingResult result =
                reportProcessor.RenderReport("PDF", instanceReportSource, deviceInfo);

            // The rest of the snippet goes here
            byte[] reportBytes = result.DocumentBytes;
            MemoryStream ms = new MemoryStream(reportBytes);
            ms.Position = 0;

            System.Net.Mime.ContentType ct = new System.Net.Mime.ContentType(System.Net.Mime.MediaTypeNames.Text.Plain);
            System.Net.Mail.Attachment attach = new System.Net.Mail.Attachment(ms, ct);
            attach.ContentDisposition.FileName = @"D:\" + result.DocumentName + "." + result.Extension;

            FileStream fstr = new FileStream(attach.ContentDisposition.FileName, FileMode.Truncate);
            fstr.CopyTo(ms);

            Microsoft.Office.Interop.Outlook.Application app = new Microsoft.Office.Interop.Outlook.Application();
            Microsoft.Office.Interop.Outlook.MailItem mailItem = app.CreateItem(Microsoft.Office.Interop.Outlook.OlItemType.olMailItem);

            mailItem.Subject = "This is the subject";
            mailItem.To = "jolly@dipndipkw.com";
            mailItem.Body = "This is the message.";
            mailItem.Attachments.Add(attach.ContentDisposition.FileName);
            mailItem.Importance = Microsoft.Office.Interop.Outlook.OlImportance.olImportanceHigh;
            mailItem.ReadReceiptRequested = true;
            mailItem.Send();
        }

        public void SavePdfOrder()
        {
            Telerik.Reporting.Processing.ReportProcessor reportProcessor =
            new Telerik.Reporting.Processing.ReportProcessor();

            // set any deviceInfo settings if necessary
            System.Collections.Hashtable deviceInfo =
                new System.Collections.Hashtable();

            Telerik.Reporting.TypeReportSource typeReportSource =
                         new Telerik.Reporting.TypeReportSource();
            //Telerik.Reporting.IReportDocument myReport = new dipndipTLReports.Reports.OrderDetailsB(txtOrderNo.Value);
            Telerik.Reporting.IReportDocument myReport = new dipndipTLReports.Reports.OrderDetailsB("CKOR-0007");
            // reportName is the Assembly Qualified Name of the report

            typeReportSource.TypeName = typeof(dipndipTLReports.Reports.OrderDetailsB).AssemblyQualifiedName;
            Telerik.Reporting.Processing.RenderingResult result =
                reportProcessor.RenderReport("PDF", typeReportSource, deviceInfo);

            string fileName = @"D:\Order-" + DateTime.Now.Date.ToString("dd-MM-yyyy") + "." + result.Extension;
            string path = System.IO.Path.GetTempPath();
            string filePath = System.IO.Path.Combine(path, fileName);

            using (System.IO.FileStream fs = new System.IO.FileStream(filePath, System.IO.FileMode.Create))
            {
                fs.Write(result.DocumentBytes, 0, result.DocumentBytes.Length);
            }
        }

        public void CallSaveReport()
        {
            //Telerik.Reporting.Report myReport = new dipndipTLReports.Reports.OrderDetailsB("CKOR-0007");
            Telerik.Reporting.Report myReport = new dipndipTLReports.Reports.OrderDetailsB(txtOrderNo.Value);
            //string fileName = @"D:\Order-" + DateTime.Now.Date.ToString("dd-MM-yyyy") + ".pdf";
            string fileName = string.Empty;
            if (GlobalVariables.AppEnvironment == "Development")
            {
                //fileName = @"D:\CKOrders\Order-" + DateTime.Now.Date.ToString("dd-MM-yyyy") + "-" + ftime + ".pdf";
                fileName = @"D:\CKOrders\" + txtOrderNo.Value + ".pdf";
            }
            else
            {
                //fileName = @"E:\CKOrders\Order-" + DateTime.Now.Date.ToString("dd-MM-yyyy") + "-" + ftime + ".pdf";
                fileName = @"E:\WHOrders\" + txtOrderNo.Value + ".pdf";
            }
            SaveReport(myReport, fileName);
        }
        void SaveReport(Telerik.Reporting.Report report, string fileName)
        {
            ReportProcessor reportProcessor = new ReportProcessor();
            Telerik.Reporting.InstanceReportSource instanceReportSource = new Telerik.Reporting.InstanceReportSource();
            instanceReportSource.ReportDocument = report;
            RenderingResult result = reportProcessor.RenderReport("PDF", instanceReportSource, null);

            using (FileStream fs = new FileStream(fileName, FileMode.Create))
            {
                fs.Write(result.DocumentBytes, 0, result.DocumentBytes.Length);
            }
        }

        private void RadWindow_Closed(object sender, WindowClosedEventArgs e)
        {
            AppFormService afscontext = new AppFormService();
            afscontext.SetAppFormLockStatus("orderdetailsView", false);
        }

        private void RadWindow_Loaded(object sender, RoutedEventArgs e)
        {
            AppFormService afscontext = new AppFormService();
            afscontext.SetAppFormLockStatus("orderdetailsView", true);
        }
    }
}
