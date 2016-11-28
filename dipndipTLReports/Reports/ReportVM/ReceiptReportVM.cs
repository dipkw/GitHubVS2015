using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dipndipTLReports.Reports.ReportVM
{
    public class ReceiptReportVM
    {
        public string OrderNo { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime IssueDate { get; set; }
        public string ReceiptNo { get; set; }
        public DateTime ReceiptDate { get; set; }
        public string item_code { get; set; }
        public string item_description { get; set; }
        public string iten_unit { get; set; }
        public decimal order_qty { get; set; }
        public decimal issued_qty { get; set; }
        public decimal received_qty { get; set; }
    }
}
