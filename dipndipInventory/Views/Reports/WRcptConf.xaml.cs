namespace dipndipInventory.Views.Reports
{
    using System;
    using System.Windows;
    using Telerik.Windows.Controls;

    public partial class WRcptConf : RadWindow
    {
        Telerik.Reporting.IReportDocument myReport;
        string g_order_no;
        public WRcptConf()
        {
            InitializeComponent();
        }

        public WRcptConf(string order_no)
        {
            InitializeComponent();
            g_order_no = order_no;
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

                this.ReportViewer1.ReportSource = instanceReportSource;
            }
            catch(Exception ex)
            {

            }
        }
    }
}