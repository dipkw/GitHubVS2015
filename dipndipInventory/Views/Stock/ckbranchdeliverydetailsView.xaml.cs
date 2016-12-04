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
    /// Interaction logic for ckbranchdeliverydetailsView.xaml
    /// </summary>
    public partial class ckbranchdeliverydetailsView : RadWindow
    {
        string g_ck_issue_code;
        public ckbranchdeliverydetailsView()
        {
            InitializeComponent();
        }

        public ckbranchdeliverydetailsView(string ck_issue_code)
        {
            InitializeComponent();
            ShowTaskBar.ShowInTaskbar(this, "Central Kitchen Branch Delivery Details");
            g_ck_issue_code = ck_issue_code;
            FillBranchDeliveryDetail();
        }

        public void FillBranchDeliveryDetail()
        {
            try
            {
                CKIssueService ciscontext = new CKIssueService();
                dgCKIssueDetails.ItemsSource = null;
                dgCKIssueDetails.ItemsSource = ciscontext.GetBranchDeliveryByIssueCode(g_ck_issue_code);
                dgCKIssueDetails.Rebind();

                ck_issue_master objCKIssueMaster = ciscontext.GetIssueMasterInfo(g_ck_issue_code);
                txtDocNo.Value = objCKIssueMaster.ck_issue_code;
                txtOrderNo.Value = objCKIssueMaster.branch_order_no;
                txtBranch.Value = objCKIssueMaster.site.site_name;
                dtpOrderDate.SelectedDate = objCKIssueMaster.branch_order_date;
                dtpDeliveredDate.SelectedDate = objCKIssueMaster.ck_issue_date;
            }
            catch { }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnPrint_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                Telerik.Reporting.IReportDocument myReport = new dipndipTLReports.Reports.CKItemDeliveryReport(txtDocNo.Value);


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
    }
}
