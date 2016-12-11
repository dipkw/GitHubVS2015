using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dipndipTLReports.Reports.ReportVM
{
    public class WHStockReportVM
    {
        public int Id { get; set; }
        public int wh_item_id { get; set; }
        public string wh_item_code { get; set; }
        public string wh_item_description { get; set; }
        public int unit_id { get; set; }
        public string unit_description { get; set; }
        public decimal qty { get; set; }
        public decimal avg_unit_cost { get; set; }
        public decimal total_cost { get; set; }
        public decimal grand_total { get; set; }
    }
}
