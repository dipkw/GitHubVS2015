using dipndipInventory.EF;
using dipndipInventory.EF.DataServices;
using dipndipInventory.Helpers;
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
    /// Interaction logic for ckorderView.xaml
    /// </summary>
    public partial class ckorderView : RadWindow
    {
        CKOrderService _context = new CKOrderService();
        bool edit_mode = false;
        //string username = string.Empty;
        int id = 0;
        public ckorderView()
        {
            InitializeComponent();
            ShowTaskBar.ShowInTaskbar(this, "Central Kitchen Orders");
            ReadAllCKOrders();
        }

        private void ReadAllCKOrders()
        {
            IEnumerable<order> objOrders = _context.ReadAllActiveCKOrders();
            dgCKOrders.ItemsSource = objOrders;
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
