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
    /// Interaction logic for CKWastageReportView.xaml
    /// </summary>
    public partial class CKWastageReportView : RadWindow
    {
        Telerik.Reporting.IReportDocument myReport;
        public CKWastageReportView()
        {
            InitializeComponent();
            ShowTaskBar.ShowInTaskbar(this, "Central Kitchen Wastage Report");
            LoadReport();
        }

        private void LoadReport()
        {
            try
            {
                DateTime defaultDate = DateTime.Today.Date;
                myReport = new dipndipTLReports.Reports.CKWastageReport();
                //myReport = new dipndipTLReports.Reports.TestWst();

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

        private void btnView_Click(object sender, RoutedEventArgs e)
        {
            LoadReport();
        }
    }
}
