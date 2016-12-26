using dipndipInventory.EF;
using dipndipInventory.EF.DataServices;
using dipndipInventory.Helpers;
using dipndipInventory.Views.Stock;
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

namespace dipndipInventory.Views.Reports
{
    /// <summary>
    /// Interaction logic for ReceiptConfirmationReportView.xaml
    /// </summary>
    public partial class ReceiptConfirmationReportView : RadWindow
    {
        Telerik.Reporting.IReportDocument myReport;
        string g_order_no;
        string g_receipt_no = string.Empty;
        ckorderView g_ck_order_view;
        public ReceiptConfirmationReportView()
        {
            InitializeComponent();
        }

        public ReceiptConfirmationReportView(string order_no, ckorderView ck_order_view)
        {
            InitializeComponent();
            g_order_no = order_no;
            g_ck_order_view = ck_order_view;
            CKReceiptService ckrcontext = new CKReceiptService();
            try
            {
                g_receipt_no = ckrcontext.GetCKReceiptNoByOrderNo(g_order_no);
            }
            catch { }
            //ShowTaskBar.ShowInTaskbar(this, "Central Kitchen Confirmation");
        }

        private void RadWindow_Activated(object sender, EventArgs e)
        {
            InitializeReport();
        }

        private void InitializeReport()
        {
            try
            {
                DateTime defaultDate = DateTime.Today.Date;
                myReport = new dipndipTLReports.Reports.WHReceiptConfirmation(g_order_no);
                //myReport = new dipndipTLReports.Reports.TestReport();

                //// Obtain the settings of the default printer
                //System.Drawing.Printing.PrinterSettings printerSettings
                //    = new System.Drawing.Printing.PrinterSettings();

                ////// The standard print controller comes with no UI
                //System.Drawing.Printing.PrintController standardPrintController =
                //    new System.Drawing.Printing.StandardPrintController();

                //// Print the report using the custom print controller
                //Telerik.Reporting.Processing.ReportProcessor reportProcessor
                //    = new Telerik.Reporting.Processing.ReportProcessor();

                //reportProcessor.PrintController = standardPrintController;

                Telerik.Reporting.InstanceReportSource instanceReportSource =
                    new Telerik.Reporting.InstanceReportSource();

                instanceReportSource.ReportDocument = myReport;

                this.ReportViewer1.ReportSource = null;
                this.ReportViewer1.ReportSource = instanceReportSource;
                this.ReportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {

            }
        }

        private void btnConfirm_Click(object sender, RoutedEventArgs e)
        {
            if(MessageBox.Show("Do you want to continue?","Confirm",MessageBoxButton.YesNo) == MessageBoxResult.No)
            {
                return;
            }
            CKOrderService ckocontext = new CKOrderService();
            if(ckocontext.UpdateCKOrderConfirmStatus(g_order_no, "Confirmed", DateTime.Now, GlobalVariables.ActiveUser.Id)>0)
            {
                SendMail();
                MessageBox.Show("Confirmed");
                if (MessageBox.Show("Do you want to print the Receipt", "Print", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    PrintOrder(g_order_no);
                }
                CKOrderService _ocontext = new CKOrderService();
                IEnumerable<order> g_orders = _ocontext.ReadAllActiveSiteOrders(GlobalVariables.ActiveSite.Id);
                g_ck_order_view.dgCKOrders.ItemsSource = g_orders;
                g_ck_order_view.dgCKOrders.Rebind();
            }
            else
            {
                MessageBox.Show("Confirmation Failed");
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SendMail()
        {
            Telerik.Reporting.Report myReport = new dipndipTLReports.Reports.WHReceiptConfirmation(g_order_no);
            string ftime = DateTime.Now.Hour.ToString() + "-" + DateTime.Now.Minute.ToString() + "-" + DateTime.Now.Second.ToString();
            string fileName = string.Empty;
            if (GlobalVariables.AppEnvironment == "Development")
            {
                //fileName = @"D:\WHReceipts\Receipt-" + DateTime.Now.Date.ToString("dd-MM-yyyy") + "-" + ftime + ".pdf";
                fileName = @"D:\WHReceipts\" + g_receipt_no + ".pdf";
            }
            else
            {
                //fileName = @"K:\Receipts\CK\Receipt-" + DateTime.Now.Date.ToString("dd-MM-yyyy") + "-" + ftime + ".pdf";
                fileName = @"K:\Receipts\CK\" + g_receipt_no + ".pdf";
            }
            SaveReport(myReport, fileName);

            Microsoft.Office.Interop.Outlook.Application app = new Microsoft.Office.Interop.Outlook.Application();
            Microsoft.Office.Interop.Outlook.MailItem mailItem = app.CreateItem(Microsoft.Office.Interop.Outlook.OlItemType.olMailItem);
            mailItem.Subject = "Warehouse Receipt Confirmation";
            if (GlobalVariables.AppEnvironment == "Development")
            {
                mailItem.To = "jolly@dipndipkw.com";
            }
            else
            {
                try
                {
                    SiteService stcontext = new SiteService();
                    mailItem.To = stcontext.GetSiteMailBySiteCode("HO");
                    mailItem.CC = GlobalVariables.wh_receipt_mail_conf_cc;
                }
                catch { MessageBox.Show("Please contact admin"); return; }
            }
            mailItem.Body = @"Good Day,

Please find attached Receipt Confirmation for Central Kitchen.";
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

        public void PrintOrder(string order_no)
        {
            try
            {

                //Telerik.Reporting.IReportDocument myReport = new DieReports.DieDetailsReport(die_id, "Drawing");
                //Telerik.Reporting.IReportDocument myReport = new dipndipTLReports.PrintOrderReport("CKOR-0007");
                Telerik.Reporting.IReportDocument myReport = new dipndipTLReports.Reports.WHReceiptConfirmation(order_no);


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
    }
}
