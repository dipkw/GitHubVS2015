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
    /// Interaction logic for WHDeliveryReportView.xaml
    /// </summary>
    public partial class WHDeliveryReportView : RadWindow
    {
        Telerik.Reporting.IReportDocument myReport;
        public WHDeliveryReportView()
        {
            InitializeComponent();
            LoadReport();
        }
        public WHDeliveryReportView(string report_param)
        {
            InitializeComponent();
            LoadReportDetails();
        }
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void LoadReport()
        {
            try
            {
                DateTime defaultDate = DateTime.Today.Date;
                myReport = new dipndipTLReports.Reports.WarehouseDeliveryReport();

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

        private void LoadReportDetails()
        {
            try
            {
                DateTime defaultDate = DateTime.Today.Date;
                myReport = new dipndipTLReports.Reports.WHDeliveryDetailsReport();

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
    }
}
