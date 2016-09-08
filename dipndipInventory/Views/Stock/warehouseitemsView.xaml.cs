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
    /// Interaction logic for warehouseitemsView.xaml
    /// </summary>
    public partial class warehouseitemsView : RadWindow
    {
        WHItemService _context = new WHItemService();
        bool edit_mode = false;
        //string username = string.Empty;
        int id = 0;
        public warehouseitemsView()
        {
            InitializeComponent();
            ShowTaskBar.ShowInTaskbar(this, "Warehouse Items");
            ReadAllWHItems();
        }

        private void ReadAllWHItems()
        {
            IEnumerable<ckwh_items> objUnits = _context.ReadAllWHItems();
            dgWHItems.ItemsSource = objUnits;
            txtDescription.Focus();
        }
    }
}
