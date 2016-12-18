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
    /// Interaction logic for WHItemQuantityInUnits.xaml
    /// </summary>
    public partial class WHItemQuantityInUnits : RadWindow
    {
        Telerik.Reporting.IReportDocument myReport;
        int g_wh_item_id;
        decimal g_wh_ck_qty;
        public WHItemQuantityInUnits()
        {
            InitializeComponent();
        }

        public WHItemQuantityInUnits(int wh_item_id, decimal wh_ck_qty)
        {
            InitializeComponent();
            g_wh_item_id = wh_item_id;
            g_wh_ck_qty = wh_ck_qty;
            ShowTaskBar.ShowInTaskbar(this, "Warehouse Item Quantity");
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
                myReport = new dipndipTLReports.Reports.WHItemQuantityInUnits(g_wh_item_id, g_wh_ck_qty);
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

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
