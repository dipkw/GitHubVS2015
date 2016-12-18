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
    using System.Linq;

    /// <summary>
    /// Summary description for WHItemQuantityInUnits.
    /// </summary>
    public partial class WHItemQuantityInUnits : Telerik.Reporting.Report
    {
        int g_wh_item_id;
        decimal g_wh_ck_qty;
        public WHItemQuantityInUnits()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        public WHItemQuantityInUnits(int wh_item_id, decimal wh_ck_qty)
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
            g_wh_item_id = wh_item_id;
            g_wh_ck_qty = wh_ck_qty;
            this.DataSource = null;
        }

        private void WHItemQuantityInUnits_NeedDataSource(object sender, EventArgs e)
        {
            WHItemUnitService wucontext = new WHItemUnitService();
            IEnumerable<wh_item_unit> wh_item_units = wucontext.ReadAllWHItemUnitsByWHItemId(g_wh_item_id);
            List<wh_item_unit> wh_item_units_copy = wh_item_units.ToList();
            int i = 0;
            decimal item_qty = 0.00000000m;
            List<WHStockReportVM> wh_item_details = new List<WHStockReportVM>();
            foreach(wh_item_unit whitemunit in wh_item_units)
            {
                WHStockReportVM wh_item_details_vm = new WHStockReportVM();
                if(i == 0)
                {
                    wh_item_details_vm.unit_description = whitemunit.ck_units.unit_description;
                    wh_item_details_vm.qty = Math.Truncate(g_wh_ck_qty);
                    item_qty = Math.Truncate(g_wh_ck_qty)-wh_item_details_vm.qty;
                }
                else
                {
                    wh_item_details_vm.unit_description = whitemunit.ck_units.unit_description;
                    decimal cnv1 = (decimal)wh_item_units_copy[i - 1].cnv_factor;
                    decimal cnv2 = (decimal)wh_item_units_copy[i].cnv_factor;
                    wh_item_details_vm.qty = item_qty * (cnv1/ cnv2);
                    item_qty = Math.Truncate(wh_item_details_vm.qty);
                    wh_item_details_vm.qty = item_qty;
                }
                wh_item_details.Add(wh_item_details_vm);
                i++;
            }

        }
    }
}