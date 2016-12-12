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
    /// Summary description for WHItemsReport.
    /// </summary>
    public partial class WHItemsReport : Telerik.Reporting.Report
    {
        DateTime g_start_date = DateTime.Now;
        DateTime g_end_date = DateTime.Now;
        DateTime g_param_date = DateTime.Now;
        public WHItemsReport()
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

        public WHItemsReport(DateTime param_date)
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
            g_param_date = param_date;
            this.DataSource = null;
        }

        public WHItemsReport(DateTime start_date, DateTime end_date)
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

        private void WHItemsReport_NeedDataSource(object sender, EventArgs e)
        {
            //Take the Telerik.Reporting.Processing.Report instance
            Telerik.Reporting.Processing.Report report = (Telerik.Reporting.Processing.Report)sender;
            WHItemService wiscontext = new WHItemService();
            IEnumerable<ckwh_items> ckwhitems = wiscontext.ReadAllWHItems();
            List<WHStockReportVM> wh_stock_items = new List<WHStockReportVM>();
            foreach(ckwh_items ckwhitem in ckwhitems)
            {
                WHStockReportVM wh_stock_item = new WHStockReportVM();
                wh_stock_item.wh_item_code = ckwhitem.wh_item_code;
                wh_stock_item.wh_item_description = ckwhitem.wh_item_description;
                wh_stock_item.unit_description = ckwhitem.wh_unit_description;
                wh_stock_item.avg_unit_cost = (decimal)ckwhitem.unit_cost;
                wh_stock_item.qty =  wiscontext.GetStockQtySP(ckwhitem.wh_item_code.Trim(), g_param_date);
                wh_stock_items.Add(wh_stock_item);
            }
            this.DataSource = wh_stock_items;
        }
    }
}