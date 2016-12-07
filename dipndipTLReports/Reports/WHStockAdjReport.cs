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
    /// Summary description for WHStockAdjReport.
    /// </summary>
    public partial class WHStockAdjReport : Telerik.Reporting.Report
    {
        DateTime g_start_date;
        DateTime g_end_date;
        public WHStockAdjReport()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        public WHStockAdjReport(DateTime start_date, DateTime end_date)
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

        private void WHStockAdjReport_NeedDataSource(object sender, EventArgs e)
        {
            Telerik.Reporting.Processing.Report report = (Telerik.Reporting.Processing.Report)sender;
            CKAdjService adjcontext = new CKAdjService();
            try
            {
                //IEnumerable<ckwh_items_adj> stock_adjustments = adjcontext.GetAllAdjByDate(g_start_date, g_end_date);
                IEnumerable<ckwh_items_adj> stock_adjustments = adjcontext.GetAllAdjByDate(Convert.ToDateTime("2016-11-01"), Convert.ToDateTime("2016-12-07"));
                List<WHStockAdjReportVM> stock_adj_report_src = new List<WHStockAdjReportVM>();
                foreach (ckwh_items_adj adj in stock_adjustments)
                {
                    WHStockAdjReportVM stock_adj = new WHStockAdjReportVM();
                    stock_adj.Adj_Code = adj.adj_code;
                    stock_adj.Item_Code = adj.wh_item_code;
                    stock_adj.Item_Description = adj.wh_item_description;
                    stock_adj.Unit = adj.wh_item_unit_description;
                    stock_adj.Adj_Qty = (decimal)adj.adj_qty;

                    stock_adj_report_src.Add(stock_adj);
                }

                report.DataSource = stock_adj_report_src;
            }
            catch { }

        }
    }
}