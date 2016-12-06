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
    /// Interaction logic for WHStockAdjReportView.xaml
    /// </summary>
    public partial class WHStockAdjReportView : RadWindow
    {
        Telerik.Reporting.IReportDocument myReport;
        public WHStockAdjReportView()
        {
            InitializeComponent();

            dtpStartDate.SelectedDate = DateTime.Now;
            dtpEndDate.SelectedDate = DateTime.Now;
        }

        private void btnView_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DateTime defaultDate = DateTime.Today.Date;
                //myReport = new dipndipTLReports.Reports.WHItemAdjReport((DateTime)dtpStartDate.SelectedDate, (DateTime)dtpEndDate.SelectedDate);
                myReport = new dipndipTLReports.Reports.WHStockAdjReport((DateTime)dtpStartDate.SelectedDate, (DateTime)dtpEndDate.SelectedDate);
                
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
