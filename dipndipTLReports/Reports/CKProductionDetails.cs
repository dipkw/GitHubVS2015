namespace dipndipTLReports.Reports
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;

    /// <summary>
    /// Summary description for CKProductionDetails.
    /// </summary>
    public partial class CKProductionDetails : Telerik.Reporting.Report
    {
        public CKProductionDetails()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        public CKProductionDetails(string prod_code)
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //

            ReportParameter report_param = new ReportParameter();
            report_param.Name = "prod_code";
            report_param.Value = prod_code;
            ReportParameters.Add(report_param);
            this.DataSource = null;
        }

        private void CKProductionDetails_NeedDataSource(object sender, EventArgs e)
        {
            //Take the Telerik.Reporting.Processing.Report instance
            Telerik.Reporting.Processing.Report report = (Telerik.Reporting.Processing.Report)sender;
            // Transfer the value of the processing instance of ReportParameter
            // to the parameter value of the sqlDataSource component
            this.ProductionDetailsqlDataSource.Parameters[0].Value = report.Parameters["prod_code"].Value;

            // Set the SqlDataSource component as it's DataSource
            report.DataSource = this.ProductionDetailsqlDataSource;
        }
    }
}