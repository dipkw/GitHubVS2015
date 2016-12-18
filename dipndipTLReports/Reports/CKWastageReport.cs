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
                string dynamic_sql = "SELECT d.[Id], d.[wastage_master_id],d.[ck_wastage_code],m.wastage_date,s.site_name,d.[ck_prod_code],d.[ck_batch_no]";
                dynamic_sql += ",d.[ck_prod_date],d.[ck_exp_date],d.[ck_item_id],d.[ck_item_code],d.[ck_item_desc],d.[ck_item_unit_id],d.[wastage_qty]";
                dynamic_sql += ",d.[ck_item_unit_cost],d.[ck_item_total_cost],d.[created_by],d.[created_date],d.[modified_by],d.[modified_date],d.[active]";
                dynamic_sql += " FROM[dipck].[dbo].[ck_wastage_details] d INNER JOIN ck_wastage_master m ON d.wastage_master_id=m.Id";
                dynamic_sql += " INNER JOIN sites s ON m.site_id = s.Id WHERE 1 = 1";
                if (report.Parameters["ck_item_code"].Value != null)
                {
                    dynamic_sql += " AND d.[ck_item_code] = '";
                    dynamic_sql += report.Parameters["ck_item_code"].Value;
                    dynamic_sql += "'";
                }

                if ((report.Parameters["start_date"].Value != null && report.Parameters["end_date"].Value != null))
                {
                    dynamic_sql += " AND CAST(m.wastage_date as Date)>= '";
                    dynamic_sql += report.Parameters["start_date"].Value;
                    dynamic_sql += "' AND CAST(m.wastage_date as Date)<= '";
                    dynamic_sql += report.Parameters["end_date"].Value;
                    dynamic_sql += "'";
                }

                this.DynamicsqlDataSource.SelectCommand = dynamic_sql;
                this.DynamicsqlDataSource.SelectCommandType = SqlDataSourceCommandType.Text;

                report.DataSource = this.DynamicsqlDataSource;
                ////report.Parameters["start_date"].Value = g_start_date.Date.ToString("yyyy-MM-dd");
                ////report.Parameters["end_date"].Value = g_end_date.Date.ToString("yyyy-MM-dd");
                //    if (report.Parameters["ck_item_code"].Value == null && (report.Parameters["start_date"].Value == null || report.Parameters["end_date"].Value == null))
                //{
                //    report.DataSource = this.AllCKWastagesqlDataSource;
                //}
                //else if ((report.Parameters["ck_item_code"].Value == null && (report.Parameters["start_date"].Value != null && report.Parameters["end_date"].Value != null)))
                //{
                //    report.DataSource = this.CKDateWastagesqlDataSource;
                //}
                //else if (report.Parameters["ck_item_code"].Value != null)
                //{
                //    report.DataSource = this.CKItemCodeWastagesqlDataSource;
                //}
                //else
                //{
                //    report.DataSource = this.CKItemWastagesqlDataSource;
                //}
            }
        }
    }
}