using dipndipInventory.EF;
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

namespace dipndipInventory.Views.Stock
{
    /// <summary>
    /// Interaction logic for productiondetailView.xaml
    /// </summary>
    public partial class productiondetailView : RadWindow
    {
        string g_prod_code;
        public productiondetailView()
        {
            InitializeComponent();
        }

        public productiondetailView(string prod_code)
        {
            InitializeComponent();
            g_prod_code = prod_code;
            ShowTaskBar.ShowInTaskbar(this, "Production Details");
            FillProductionDetails(prod_code);
        }

        private void FillProductionDetails(string prod_code)
        {
            try
            {
                CKProductionService cpscontext = new CKProductionService();
                IEnumerable<ck_prod> production_list = cpscontext.ReadCKProductionDetails(prod_code);
                dgCKProduction.ItemsSource = production_list;
                txtProductionCode.Value = production_list.First().prod_code;
                dtpProductionDate.SelectedDate = production_list.First().prod_date;
            }
            catch { }
        }

        private void btnPrint_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                //Telerik.Reporting.IReportDocument myReport = new DieReports.DieDetailsReport(die_id, "Drawing");
                //Telerik.Reporting.IReportDocument myReport = new dipndipTLReports.PrintOrderReport("CKOR-0007");
                //Telerik.Reporting.IReportDocument myReport = new dipndipTLReports.Reports.OrderDetailsB("CKOR-0007");
                Telerik.Reporting.IReportDocument myReport = new dipndipTLReports.Reports.CKProductionDetails(txtProductionCode.Value);


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

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
