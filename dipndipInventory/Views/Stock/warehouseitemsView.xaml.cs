using dipndipInventory.EF;
using dipndipInventory.EF.DataServices;
using dipndipInventory.Helpers;
using dipndipInventory.Views.Reports;
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
using Telerik.Windows.Controls.GridView;

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
        private static TimeSpan DoubleClickThreshold = TimeSpan.FromMilliseconds(450);
        private DateTime _lastClick;
        public warehouseitemsView()
        {
            InitializeComponent();
            ShowTaskBar.ShowInTaskbar(this, "Warehouse Items");
            this.AddHandler(GridViewRow.MouseLeftButtonUpEvent, new MouseButtonEventHandler(this.GridViewRow_OnMouseLeftButtonUp), true);
            this._lastClick = DateTime.Now;
            ReadAllWHItems();
        }

        private void ReadAllWHItems()
        {
            IEnumerable<ckwh_items> objItems = _context.ReadAllWHItems();
            dgWHItems.ItemsSource = objItems;
            txtDescription.Focus();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void GridViewRow_OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (DateTime.Now - this._lastClick <= DoubleClickThreshold)
            {
                try
                {
                    ckwh_items ckwhitems = dgWHItems.SelectedItem as ckwh_items;
                    WHItemQuantityInUnits wh_item_qty = new WHItemQuantityInUnits(ckwhitems.Id, (decimal)ckwhitems.ck_qty);
                    wh_item_qty.Show();
                }
                catch { }
            }
            this._lastClick = DateTime.Now;
        }
    }
}
