namespace dipndipTLReports.Reports
{
    using dipndipInventory.EF;
    using dipndipInventory.EF.DataServices;
    using ReportVM;
    using System;
    using System.Collections.Generic;
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
        DateTime g_start_date = DateTime.Now;
        DateTime g_end_date = DateTime.Now;
        public WHAdjReport()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
            //g_start_date = Convert.ToDateTime(ReportParameters["start_date"].Value);
            //g_end_date = Convert.ToDateTime(ReportParameters["end_date"].Value);
            this.Report.ReportParameters[0].Value = DateTime.Now;
            this.Report.ReportParameters[1].Value = DateTime.Now;
            this.DataSource = null;
        }

        private void WHAdjReport_NeedDataSource(object sender, EventArgs e)
        {

            //Take the Telerik.Reporting.Processing.Report instance
            Telerik.Reporting.Processing.Report report = (Telerik.Reporting.Processing.Report)sender;
            List<WHStockAdjObjVM> objDataSource = new List<WHStockAdjObjVM>();
            // Set the SqlDataSource component as it's DataSource
            if (report.Parameters["start_date"].Value == null || report.Parameters["end_date"].Value == null)
            {
                textBox3.Visible = false;
                report.DataSource = this.WHAllAdjsqlDataSource;
                //CKAdjService cascontext = new CKAdjService();
                //IEnumerable<ckwh_items_adj> stock_adjustments = cascontext.GetAllActiveAdj();
                //foreach (ckwh_items_adj ckwhitemadj in stock_adjustments)
                //{
                //    WHStockAdjObjVM objAdj = new WHStockAdjObjVM();
                //    objAdj.adj_code = ckwhitemadj.adj_code;
                //    objAdj.wh_item_code = ckwhitemadj.wh_item_code;
                //    objAdj.wh_item_description = ckwhitemadj.wh_item_description;
                //    objAdj.wh_item_unit_description = ckwhitemadj.wh_item_unit_description;
                //    objAdj.adj_qty = ckwhitemadj.adj_qty;
                //    objAdj.created_date = ckwhitemadj.created_date;
                //    objDataSource.Add(objAdj);
                //}
                ////report.DataSource = this.WHStockAdjobjectDataSource;
                //report.DataSource = objDataSource;
            }
            else
            {
                textBox3.Visible = true;
                report.DataSource = this.WHAdjsqlDataSource;
                //CKAdjService cascontext = new CKAdjService();
                //DateTime start_date = Convert.ToDateTime(Report.ReportParameters[0].Value);
                //DateTime end_date = Convert.ToDateTime(Report.ReportParameters[1].Value);
                //IEnumerable<ckwh_items_adj> stock_adjustments = cascontext.GetAllAdjByDate(start_date, end_date);
                //foreach (ckwh_items_adj ckwhitemadj in stock_adjustments)
                //{
                //    WHStockAdjObjVM objAdj = new WHStockAdjObjVM();
                //    objAdj.adj_code = ckwhitemadj.adj_code;
                //    objAdj.wh_item_code = ckwhitemadj.wh_item_code;
                //    objAdj.wh_item_description = ckwhitemadj.wh_item_description;
                //    objAdj.wh_item_unit_description = ckwhitemadj.wh_item_unit_description;
                //    objAdj.adj_qty = ckwhitemadj.adj_qty;
                //    objAdj.created_date = ckwhitemadj.created_date;
                //    objDataSource.Add(objAdj);
                //}
                ////report.DataSource = this.WHStockAdjobjectDataSource;
                //report.DataSource = objDataSource;
            }
        }
    }
}