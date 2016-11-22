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
    /// Summary description for WHReceiptConfirmation.
    /// </summary>
    public partial class WHReceiptConfirmation : Telerik.Reporting.Report
    {
        string g_order_no;
        public WHReceiptConfirmation()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        public WHReceiptConfirmation(string order_no)
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
            
            this.DataSource = null;
            this.NeedDataSource += new System.EventHandler(this.WHReceiptConfirmation_NeedDataSource);
            //this.Report.ReportParameters["order_no"].Value = order_no;
            g_order_no = order_no;
            this.DataSource = null;
        }

        private void WHReceiptConfirmation_NeedDataSource(object sender, EventArgs e)
        {
            //Take the Telerik.Reporting.Processing.Report instance
            Telerik.Reporting.Processing.Report report = (Telerik.Reporting.Processing.Report)sender;
            CKReceiptService crscontext = new CKReceiptService();
            IEnumerable<receipt_details> receipt_detail_list = crscontext.ReadReceiptByOrderNo(g_order_no);
            List<ReceiptReportVM> receipt_report_vm_list = new List<ReceiptReportVM>();
            foreach(receipt_details receipt_item in receipt_detail_list)
            {
                ReceiptReportVM receipt_report_vm = new ReceiptReportVM();
                receipt_report_vm.item_code = receipt_item.wh_item_code;
                receipt_report_vm.item_description = receipt_item.wh_item_description;
                //receipt_report_vm.iten_unit = receipt_item.wh_item_unit.ck_units.unit_description;
                receipt_report_vm.order_qty = receipt_report_vm.order_qty;
                receipt_report_vm_list.Add(receipt_report_vm);
            }
            report.DataSource = receipt_report_vm_list;
        }
    }
}