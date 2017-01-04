namespace dipndipTLReports.Reports
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;

    /// <summary>
    /// Summary description for CKWHReceiptReport.
    /// </summary>
    public partial class CKWHReceiptReport : Telerik.Reporting.Report
    {
        public CKWHReceiptReport()
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

        private void CKWHReceiptReport_NeedDataSource(object sender, EventArgs e)
        {
//            Telerik.Reporting.Processing.Report report = (Telerik.Reporting.Processing.Report)sender;
//            string select_sql = "SELECT rd.[Id], rd.[receipt_id], om.order_no
//	  ,om.order_date
//	  ,om.issue_date
//      ,rd.[receipt_no]
//	  ,rm.receipt_date
//      ,rd.[wh_item_id]
//      ,rd.[wh_item_code]
//      ,rd.[wh_item_description]
//      ,rd.[wh_item_unit_id]
//      ,rd.[ck_unit_description]
//      ,rd.[qty_ordered]
//      ,rd.[qty_received]
//      ,rd.[qyt_returned]
//      ,rd.[wh_item_unit_cost]
//      ,rd.[wh_item_ext_cost]
//      ,rd.[remarks]
//      ,rd.[created_by]
//      ,rd.[created_date]
//      ,rd.[modified_by]
//      ,rd.[modified_date]
//      ,rd.[active]
//  FROM[dipck].[dbo].[receipt_details]
//        rd
//INNER JOIN receipts rm ON rd.receipt_id = rm.Id
//INNER JOIN orders om ON rm.order_id = om.Id";
        }
    }
}