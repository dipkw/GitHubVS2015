using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dipndipTLReports.Reports.ReportVM
{
    public class WHStockAdjReportVM
    {
        public int Id { get; set; }
        public string Adj_Code { get; set; }
        public string Item_Code { get; set; }
        public string Item_Description { get; set; }
        public string Unit { get; set; }
        public decimal Adj_Qty { get; set; }
        public DateTime Start_Date { get; set; }
        public DateTime End_Date { get; set; }
        public DateTime Created_Date { get; set; }
    }
}
