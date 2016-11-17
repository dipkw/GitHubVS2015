using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.Integration;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Telerik.Windows.Controls;

namespace dipndipInventory.Views.Reports
{
    /// <summary>
    /// Interaction logic for OrderDetailsPrint.xaml
    /// </summary>
    public partial class OrderDetailsPrint : RadWindow
    {
        public ReportViewer ReportViewer;
        private WindowsFormsHost _viewer = new WindowsFormsHost();
        public OrderDetailsPrint()
        {
            InitializeComponent();
            
        }

        private void ReportViewer_Load(object sender, EventArgs e)
        {
            try
            {
                repViewer.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Remote;
                repViewer.ServerReport.ReportServerUrl = new Uri(@"http://jolly/ReportServer_MSSQLSERVER14");
                repViewer.ServerReport.ReportPath = "/dipndipReports/PrintOrder";
                repViewer.ServerReport.Refresh();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        
    }
}
