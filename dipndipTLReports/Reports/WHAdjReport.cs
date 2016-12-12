namespace dipndipTLReports.Reports
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;

    /// <summary>
    /// Summary description for WHAdjReport.
    /// </summary>
    public partial class WHAdjReport : Telerik.Reporting.Report
    {
        public WHAdjReport()
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

        private void WHAdjReport_NeedDataSource(object sender, EventArgs e)
        {

            //Take the Telerik.Reporting.Processing.Report instance
            Telerik.Reporting.Processing.Report report = (Telerik.Reporting.Processing.Report)sender;
            // Set the SqlDataSource component as it's DataSource
            if (report.Parameters["start_date"].Value == null || report.Parameters["end_date"].Value == null)
            {
                textBox3.Visible = false;
                report.DataSource = this.WHAllAdjsqlDataSource;
            }
            else
            {
                textBox3.Visible = true;
                report.DataSource = this.WHAdjsqlDataSource;
            }
        }
    }
}