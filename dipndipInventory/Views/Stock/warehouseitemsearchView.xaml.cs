using dipndipInventory.EF;
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

namespace dipndipInventory.Views.Stock
{
    /// <summary>
    /// Interaction logic for warehouseitemsearchView.xaml
    /// </summary>
    public partial class warehouseitemsearchView : RadWindow
    {
        WHItemService _context = new WHItemService();
        bool edit_mode = false;
        //string username = string.Empty;
        int id = 0;

        orderdetailsView objOrderDetailsView;
        public warehouseitemsearchView()
        {
            InitializeComponent();
        }

        public warehouseitemsearchView(orderdetailsView ov)
        {
            InitializeComponent();
            objOrderDetailsView = ov;
            dgWHItems.ItemsSource = _context.ReadAllActiveWHItems();
        }

        private void dgWHItems_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (dgWHItems.SelectedItem == null)
            {
                return;
            }
            try
            {
                ckwh_items objWarehouseItem = (dgWHItems.SelectedItem) as ckwh_items;
                objOrderDetailsView.txtItemCode.Value = objWarehouseItem.wh_item_code;
                objOrderDetailsView.txtDescription.Value = objWarehouseItem.wh_item_description;
                objOrderDetailsView.txtUnit.Value = objWarehouseItem.wh_unit_description;
                objOrderDetailsView.txtItemID.Value = objWarehouseItem.Id.ToString();
                WHItemUnitService _wucontext = new WHItemUnitService();
                int base_unit_id = (int)(_wucontext.GetIdOfBaseUnit(objWarehouseItem.Id));
                if (base_unit_id == 0)
                {
                    RadWindow.Alert("Please configure Unit for Item Code: " + objWarehouseItem.wh_item_code);
                    return;
                }
                objOrderDetailsView.txtUnitID.Value = base_unit_id.ToString();
                objOrderDetailsView.txtQty.Focus();
            }
            catch { }
            this.Close();
        }
    }
}
