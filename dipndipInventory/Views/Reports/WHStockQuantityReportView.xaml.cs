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
    /// Interaction logic for WHStockQuantityReportView.xaml
    /// </summary>
    public partial class WHStockQuantityReportView : RadWindow
    {
        Telerik.Reporting.IReportDocument myReport;
        public WHStockQuantityReportView()
        {
            InitializeComponent();
            ShowTaskBar.ShowInTaskbar(this, "Warehouse Item Stock");
            
            dtpDate.SelectedDate = DateTime.Now;
            FillCategory();
            
            //wiscontext.GetStockQtySP("CER001", Convert.ToDateTime("2016-12-01"));
            //LoadReport();
        }

        private void FillCategory()
        {
            try
            {
                WHItemService wiscontext = new WHItemService();
                List<string> wh_categories = wiscontext.GetWHCategories();
                wh_categories.Insert(0, "All");
                cmbCategory.ItemsSource = wh_categories;
                cmbCategory.Text = "All";
            }
            catch { }
        }
        private void LoadReport()
        {
            try
            {
                DateTime defaultDate = DateTime.Today.Date;
                //myReport = new dipndipTLReports.Reports.WHStockReport();
                //DateTime param_date = DateTime.Now;
                DateTime param_date = dtpDate.SelectedDate.Value.Date;
                myReport = new dipndipTLReports.Reports.WHItemsReport(param_date, cmbCategory.Text);

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
