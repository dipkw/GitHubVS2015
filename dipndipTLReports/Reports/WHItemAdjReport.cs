namespace dipndipTLReports.Reports
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;

    /// <summary>
    /// Summary description for WHItemAdjReport.
    /// </summary>
    public partial class WHItemAdjReport : Telerik.Reporting.Report
    {
        DateTime g_start_date;
        DateTime g_end_date;
        public WHItemAdjReport()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        public WHItemAdjReport(DateTime start_date, DateTime end_date)
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //

            //ReportParameter report_param = new ReportParameter();
            //report_param.Name = "start_date";
            //report_param.Value = start_date;
            //ReportParameters.Add(report_param);
            //report_param.Name = "end_date";
            //report_param.Value = end_date;
            //ReportParameters.Add(report_param);
            g_start_date = start_date;
            g_end_date = end_date;
            this.DataSource = null;
        }

        private void WHItemAdjReport_NeedDataSource(object sender, EventArgs e)
        {
            //Take the Telerik.Reporting.Processing.Report instance
            Telerik.Reporting.Processing.Report report = (Telerik.Reporting.Processing.Report)sender;
            // Transfer the value of the processing instance of ReportParameter
            // to the parameter value of the sqlDataSource component
            this.WHAdjsqlDataSource.Parameters[0].Value = g_start_date;
            this.WHAdjsqlDataSource.Parameters[1].Value = g_end_date;

            // Set the SqlDataSource component as it's DataSource
            report.DataSource = this.WHAdjsqlDataSource;
        }
    }
}