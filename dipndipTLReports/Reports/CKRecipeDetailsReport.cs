namespace dipndipTLReports.Reports
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;

    /// <summary>
    /// Summary description for CKRecipeDetailsReport.
    /// </summary>
    public partial class CKRecipeDetailsReport : Telerik.Reporting.Report
    {
        public CKRecipeDetailsReport()
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

        private void CKRecipeDetailsReport_NeedDataSource(object sender, EventArgs e)
        {
            //Take the Telerik.Reporting.Processing.Report instance
            Telerik.Reporting.Processing.Report report = (Telerik.Reporting.Processing.Report)sender;

            //string select_sql = "SELECT itd.[Id], itd.[ck_item_id], ci.ck_item_code, ci.ck_item_description, itd.[ckwh_item_id], wi.wh_item_code, ";
            //select_sql += "wi.wh_item_description, itd.[ckwh_item_qty], wi.ck_avg_unit_cost, itd.[ckwh_item_unit_id], cu.unit_description, ";
            //select_sql += "wu.cnv_factor, itd.[created_by], itd.[created_date], itd.[modified_by], itd.[modified_date], itd.[active] ";
            //select_sql += "FROM[dipck].[dbo].[ck_item_details] itd INNER JOIN ck_items ci ON itd.ck_item_id = ci.Id ";
            //select_sql += "INNER JOIN ckwh_items wi ON itd.ckwh_item_id = wi.Id INNER JOIN wh_item_unit wu ON itd.ckwh_item_unit_id = wu.Id ";
            //select_sql += "INNER JOIN ck_units cu ON wu.ck_unit_id = cu.Id ORDER BY itd.ck_item_id";

            string select_sql = "SELECT itd.[Id], itd.[ck_item_id], ci.ck_item_code, ci.ck_item_description, ci.ck_design_qty, cu1.unit_description yunit, ";
            select_sql += "itd.[ckwh_item_id], wi.wh_item_code, wi.wh_item_description, itd.[ckwh_item_qty], wi.ck_avg_unit_cost, itd.[ckwh_item_unit_id], ";
            select_sql += "cu.unit_description, wu.cnv_factor, itd.[created_by], itd.[created_date], itd.[modified_by], itd.[modified_date], itd.[active] ";
            select_sql += "FROM[dipck].[dbo].[ck_item_details] itd INNER JOIN ck_items ci ON itd.ck_item_id = ci.Id ";
            select_sql += "INNER JOIN ckwh_items wi ON itd.ckwh_item_id = wi.Id INNER JOIN wh_item_unit wu ON itd.ckwh_item_unit_id = wu.Id ";
            select_sql += "INNER JOIN ck_units cu ON wu.ck_unit_id = cu.Id INNER JOIN ck_units cu1 ON ci.ck_unit_id = cu1.Id ORDER BY itd.ck_item_id";

            this.CKItemRecipesqlDataSource.SelectCommand = select_sql;
            this.CKItemRecipesqlDataSource.SelectCommandType = SqlDataSourceCommandType.Text;

            report.DataSource = this.CKItemRecipesqlDataSource;
        }
    }
}