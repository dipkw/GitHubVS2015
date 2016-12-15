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
        string g_wastage_code = null;
        DateTime g_start_date = DateTime.Now;
        DateTime g_end_date = DateTime.Now;
        public CKWastageReport()
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

        public CKWastageReport(DateTime start_date, DateTime end_date)
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
            g_start_date = start_date;
            g_end_date = end_date;
            this.DataSource = null;
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
            if (g_wastage_code != null)
            {
                report.DataSource = this.CKWastagesqlDataSource;
            }
            //else if (g_start_date != null && g_end_date != null)
            //{
            //    //report.Parameters["start_date"].Value = g_start_date.Date.ToString("yyyy-MM-dd");
            //    //report.Parameters["end_date"].Value = g_end_date.Date.ToString("yyyy-MM-dd");
            //    //report.DataSource = this.CKDateWastagesqlDataSource;
            //}
            else
            {
                //report.Parameters["start_date"].Value = g_start_date.Date.ToString("yyyy-MM-dd");
                //report.Parameters["end_date"].Value = g_end_date.Date.ToString("yyyy-MM-dd");
                if (report.Parameters["ck_item_code"].Value == null && (report.Parameters["start_date"].Value == null || report.Parameters["end_date"].Value == null))
                {
                    report.DataSource = this.AllCKWastagesqlDataSource;
                }
                else if((report.Parameters["ck_item_code"].Value == null && (report.Parameters["start_date"].Value != null && report.Parameters["end_date"].Value != null)))
                {
                    report.DataSource = this.CKDateWastagesqlDataSource;
                }
                else
                {
                    report.DataSource = this.CKItemWastagesqlDataSource;
                }
            }
        }
    }
}