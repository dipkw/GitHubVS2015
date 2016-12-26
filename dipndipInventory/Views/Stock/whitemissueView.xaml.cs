using dipndipInventory.EF;
using dipndipInventory.EF.DataServices;
using dipndipInventory.Helpers;
using dipndipInventory.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
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
using Telerik.Reporting.Processing;
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
        ckorderView g_ck_order_view;
        public whitemissueView()
        {
            InitializeComponent();
            dgCKOrderDetails.BeginInsert();
        }

        public whitemissueView(long order_id, string order_no, DateTime order_date, ckorderView ck_order_view)
        {
            InitializeComponent();
            ShowTaskBar.ShowInTaskbar(this, "Item Issue Details");
            g_ck_order_view = ck_order_view;
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
            if(MessageBox.Show("Do you want to continue","Confirm",MessageBoxButton.YesNo)== MessageBoxResult.No)
            {
                return;
            }
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

            IEnumerable<order> g_orders = _ocontext.ReadAllActiveSiteOrders(GlobalVariables.ActiveSite.Id);
            g_ck_order_view.dgCKOrders.ItemsSource = g_orders;
            g_ck_order_view.dgCKOrders.Rebind();

            //RadWindow.Alert(response);
            MessageBox.Show(response);
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnPrint_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                //Telerik.Reporting.IReportDocument myReport = new DieReports.DieDetailsReport(die_id, "Drawing");
                //Telerik.Reporting.IReportDocument myReport = new dipndipTLReports.PrintOrderReport("CKOR-0007");
                //Telerik.Reporting.IReportDocument myReport = new dipndipTLReports.Reports.OrderDetailsB("CKOR-0007");
                Telerik.Reporting.IReportDocument myReport = new dipndipTLReports.Reports.WHDeliveryDetails(txtOrderNo.Value);


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
            catch(Exception ex)
            {

            }
        }

        private void btnMail_Click(object sender, RoutedEventArgs e)
        {
            SendMail();
        }

        private void SendMail()
        {
            //if (OrderPlaced())
            //{
            //    return;
            //}

            Telerik.Reporting.Report myReport = new dipndipTLReports.Reports.WHDeliveryDetails(txtOrderNo.Value);
            string ftime = DateTime.Now.Hour.ToString() + "-" + DateTime.Now.Minute.ToString() + "-" + DateTime.Now.Second.ToString();
            string fileName = @"D:\CKDeliveryOrders\DeliveryOrder-" + DateTime.Now.Date.ToString("dd-MM-yyyy") + "-" + ftime + ".pdf";
            SaveReport(myReport, fileName);

            Microsoft.Office.Interop.Outlook.Application app = new Microsoft.Office.Interop.Outlook.Application();
            Microsoft.Office.Interop.Outlook.MailItem mailItem = app.CreateItem(Microsoft.Office.Interop.Outlook.OlItemType.olMailItem);
            mailItem.Subject = "Central Warehouse Delivery Order";
            mailItem.To = "jolly@dipndipkw.com";
            mailItem.Body = @"Dear Central Kitchen Officer,

Please find attached Delivery Order for Central Kitchen Order No: " + txtOrderNo.Value + ".";
            mailItem.Body += @"

Regards";
            mailItem.Body += @"
Central Warehouse";
            //string logPath = @"D:\items.pdf";
            string logPath = fileName;
            mailItem.Attachments.Add(logPath);//logPath is a string holding path to the log.txt file
            mailItem.Importance = Microsoft.Office.Interop.Outlook.OlImportance.olImportanceHigh;
            mailItem.ReadReceiptRequested = true;
            mailItem.Send();
            //mailItem.Display(false);

            //CKOrderService ckocontext = new CKOrderService();
            //if (ckocontext.UpdateCKOrderMail(txtOrderNo.Value) > 0)
            //{
            //    MessageBox.Show("You order has been placed");
            //}
            //else
            //{
            //    MessageBox.Show("Sorry");
            //}
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
    }
}
