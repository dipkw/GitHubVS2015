using dipndipInventory.EF.DataServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Telerik.Windows.Controls;

namespace dipndipInventory.Views.Reports
{
    /// <summary>
    /// Interaction logic for WHStockQuantityReportView.xaml
    /// </summary>
    public partial class WHStockQuantityReportView : RadWindow
    {
        public WHStockQuantityReportView()
        {
            InitializeComponent();
            WHItemService wiscontext = new WHItemService();
            wiscontext.GetStockQtySP("CER001", Convert.ToDateTime("2016-12-11"));
        }
    }
}
