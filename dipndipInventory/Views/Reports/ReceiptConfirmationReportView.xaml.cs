using dipndipInventory.EF.DataServices;
using dipndipInventory.Helpers;
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

namespace dipndipInventory.Views.Reports
{
    /// <summary>
    /// Interaction logic for ReceiptConfirmationReportView.xaml
    /// </summary>
    public partial class ReceiptConfirmationReportView : RadWindow
    {
        Telerik.Reporting.IReportDocument myReport;
        string g_order_no;
        public ReceiptConfirmationReportView()
        {
            InitializeComponent();
        }

        public ReceiptConfirmationReportView(string order_no)
        {
            InitializeComponent();
            g_order_no = order_no;
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
            CKOrderService ckocontext = new CKOrderService();
            if(ckocontext.UpdateCKOrderConfirmStatus(g_order_no, "Confirmed", DateTime.Now, GlobalVariables.ActiveUser.Id)>0)
            {
                MessageBox.Show("Confirmed");
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
    }
}
