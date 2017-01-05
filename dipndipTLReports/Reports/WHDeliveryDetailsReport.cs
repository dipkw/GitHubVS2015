namespace dipndipTLReports.Reports
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;

    /// <summary>
    /// Summary description for WHDeliveryDetailsReport.
    /// </summary>
    public partial class WHDeliveryDetailsReport : Telerik.Reporting.Report
    {
        public WHDeliveryDetailsReport()
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

        private void WHDeliveryDetailsReport_NeedDataSource(object sender, EventArgs e)
        {
            //Take the Telerik.Reporting.Processing.Report instance
            Telerik.Reporting.Processing.Report report = (Telerik.Reporting.Processing.Report)sender;
            string select_sql = "SELECT wd.[Id], [delivery_master_id], wd.[order_id], wd.[order_no], dm.order_no, dm.order_date, dm.issue_date, ";
            select_sql += "s1.site_name order_from, s2.site_name order_to, dm.order_status, [ckwh_item_id], ci.wh_item_code, ci.wh_item_description, ";
            select_sql += "[wh_item_unit_id], cu.unit_description, [order_qty], [delivered_qty], wd.[active] FROM[dipck].[dbo].[wh_delivery_details] wd ";
            select_sql += "INNER JOIN ckwh_items ci ON wd.ckwh_item_id = ci.Id INNER JOIN wh_delivery_master dm ON wd.delivery_master_id = dm.Id ";
            select_sql += "INNER JOIN sites s1 ON dm.order_from_site_id = s1.Id INNER JOIN sites s2 ON dm.order_to_site_id = s2.Id ";
            select_sql += "INNER JOIN wh_item_unit wu ON wu.Id = wd.wh_item_unit_id INNER JOIN ck_units cu ON cu.Id = wu.ck_unit_id WHERE 1 = 1";
            textBox13.Visible = false;
            textBox14.Visible = false;
            if (report.Parameters["wh_item_code"].Value != null)
            {
                select_sql += " AND ci.wh_item_code = '";
                select_sql += report.Parameters["wh_item_code"].Value;
                select_sql += "'";
                textBox13.Visible = true;
                textBox14.Visible = true;
            }

            if ((report.Parameters["start_date"].Value != null && report.Parameters["end_date"].Value != null))
            {
                select_sql += " AND CAST(dm.issue_date as Date)>= '";
                select_sql += report.Parameters["start_date"].Value;
                select_sql += "' AND CAST(dm.issue_date as Date)<= '";
                select_sql += report.Parameters["end_date"].Value;
                select_sql += "'";
            }

            this.WHDeliveryDetailReportsqlDataSource.SelectCommand = select_sql;
            this.WHDeliveryDetailReportsqlDataSource.SelectCommandType = SqlDataSourceCommandType.Text;

            report.DataSource = this.WHDeliveryDetailReportsqlDataSource;
        }
    }
}