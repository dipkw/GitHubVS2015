namespace dipndipTLReports.Reports
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;

    /// <summary>
    /// Summary description for WHReceiptDetails.
    /// </summary>
    public partial class WHReceiptDetails : Telerik.Reporting.Report
    {
        public WHReceiptDetails()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        public WHReceiptDetails(string order_no)
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //

            ReportParameter report_param = new ReportParameter();
            report_param.Name = "order_no";
            report_param.Value = order_no;
            ReportParameters.Add(report_param);
            this.DataSource = null;
        }

        private void WHReceiptDetails_NeedDataSource(object sender, EventArgs e)
        {
            //Take the Telerik.Reporting.Processing.Report instance
            Telerik.Reporting.Processing.Report report = (Telerik.Reporting.Processing.Report)sender;
            // Transfer the value of the processing instance of ReportParameter
            // to the parameter value of the sqlDataSource component
            this.OrderDetailsqlDataSource.Parameters[0].Value = report.Parameters["order_no"].Value;

            // Set the SqlDataSource component as it's DataSource
            report.DataSource = this.OrderDetailsqlDataSource;
        }
    }
}