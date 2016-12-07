namespace dipndipTLReports.Reports
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;

    /// <summary>
    /// Summary description for CKWastageReport.
    /// </summary>
    public partial class CKWastageReport : Telerik.Reporting.Report
    {
        string g_wastage_code;
        public CKWastageReport()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }
        public CKWastageReport(string wastage_code)
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
            g_wastage_code = wastage_code;
            this.DataSource = null;
        }

        private void CKWastageReport_NeedDataSource(object sender, EventArgs e)
        {
            //Take the Telerik.Reporting.Processing.Report instance
            Telerik.Reporting.Processing.Report report = (Telerik.Reporting.Processing.Report)sender;
            // Transfer the value of the processing instance of ReportParameter
            // to the parameter value of the sqlDataSource component
            this.CKWastagesqlDataSource.Parameters[0].Value = g_wastage_code;

            // Set the SqlDataSource component as it's DataSource
            report.DataSource = this.CKWastagesqlDataSource;
        }
    }
}