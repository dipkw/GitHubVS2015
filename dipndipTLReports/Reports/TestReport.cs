namespace dipndipTLReports.Reports
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;

    /// <summary>
    /// Summary description for TestReport.
    /// </summary>
    public partial class TestReport : Telerik.Reporting.Report
    {
        public TestReport()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
            this.DataSource = null;
        }

        private void TestReport_NeedDataSource(object sender, EventArgs e)
        {
            //Take the Telerik.Reporting.Processing.Report instance
            Telerik.Reporting.Processing.Report report = (Telerik.Reporting.Processing.Report)sender;
            // Transfer the value of the processing instance of ReportParameter
            // to the parameter value of the sqlDataSource component

            // Set the SqlDataSource component as it's DataSource
            report.DataSource = this.sqlDataSource1;
        }
    }
}