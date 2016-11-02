using dipndipInventory.EF;
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

namespace dipndipInventory.Views.Stock
{
    /// <summary>
    /// Interaction logic for ckproductionlistView.xaml
    /// </summary>
    public partial class ckproductionlistView : RadWindow
    {
        public string ReturnValue { get; set; }
        public ckproductionlistView()
        {
            InitializeComponent();
        }

        public ckproductionlistView(string prod_code, DateTime prod_date, List<ck_prod> production_list)
        {
            InitializeComponent();
            txtProductionCode.Value = prod_code;
            dtpProductionDate.SelectedDate = prod_date;
            dgCKProduction.ItemsSource = production_list;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            ReturnValue = "Save";
        }

        private void btnView_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
