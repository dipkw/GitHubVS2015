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
    /// Interaction logic for ckstockadjView.xaml
    /// </summary>
    public partial class ckstockadjView : RadWindow
    {
        bool edit_mode = false;
        //string username = string.Empty;
        int id = 0;

        int selected_item_id = 0;
        decimal selected_ck_qty = 0.00000000m;
        decimal conversion_factor = 0.00000000m;
        string adj_code = string.Empty;
        decimal selected_item_unit_cost = 0.00000000m;
        public ckstockadjView()
        {
            InitializeComponent();
            ShowTaskBar.ShowInTaskbar(this, "Central Kitchen Stock Adjustment");
            GetNewAdjCode();
            ReadAllCKItems();
        }

        private void GetNewAdjCode()
        {
            CKAdjService _adcontext = new CKAdjService();
            adj_code = _adcontext.GetNewCKAdjCode();
        }

        private void ReadAllCKItems()
        {
            CKItemService ckcontext = new CKItemService();
            dgCKItems.ItemsSource = null;
            IEnumerable<ck_items> objItems = ckcontext.ReadAllActiveCKItems();
            dgCKItems.ItemsSource = objItems;
        }
    }
}
