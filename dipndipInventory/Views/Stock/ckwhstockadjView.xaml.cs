using dipndipInventory.EF;
using dipndipInventory.EF.DataServices;
using dipndipInventory.Helpers;
using dipndipInventory.ViewModels;
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
    /// Interaction logic for ckwhstockadjView.xaml
    /// </summary>
    public partial class ckwhstockadjView : RadWindow
    {
        WHItemService _context = new WHItemService();
        bool edit_mode = false;
        //string username = string.Empty;
        int id = 0;

        int selected_item_id = 0;
        decimal selected_ck_qty = 0.00000000m;
        decimal conversion_factor = 0.00000000m;
        public ckwhstockadjView()
        {
            InitializeComponent();
            ShowTaskBar.ShowInTaskbar(this, "Stock Adjustment");

            ReadAllWHItems();
        }

        private void ReadAllWHItems()
        {
            IEnumerable<ckwh_items> objItems = _context.ReadAllWHItems();
            dgCKWHItems.ItemsSource = objItems;
            
            WHItemUnitService unitContext = new WHItemUnitService();
            //List<WHStockAdjustmentViewModel> objWHStkAdjVM = new List<WHStockAdjustmentViewModel>();
            //foreach(var stkItem in objItems)
            //{
            //    WHStockAdjustmentViewModel whsav = new WHStockAdjustmentViewModel();
            //    whsav.wh_item_id = stkItem.Id;
            //    whsav.wh_item_code = stkItem.wh_item_code;
            //    whsav.wh_item_description = stkItem.wh_item_description;
            //    whsav.wh_unit_id = (int)unitContext.GetIdOfBaseUnit(stkItem.Id);
            //    whsav.wh_unit_description = stkItem.wh_unit_description;
            //    whsav.adj_qty = 0m;
            //    //whsav.row_index = stkItem.;
            //    objWHStkAdjVM.Add(whsav);
            //}
            ////dgCKWHItems.ItemsSource = objItems;
            //dgCKWHItems.ItemsSource = null;

            //dgCKWHItems.ItemsSource = objWHStkAdjVM.ToList();
        }

        private void FillAllUnits(int wh_item_id)
        {
            WHItemUnitService unitContext = new WHItemUnitService();
            IEnumerable<wh_item_unit> objUnits = unitContext.ReadAllWHItemUnitsByWHItemId(wh_item_id);
            cmbUnit.DisplayMemberPath = "ck_units.unit_description";
            cmbUnit.SelectedValuePath = "ck_unit_id";
            cmbUnit.ItemsSource = objUnits.ToList();
            if(objUnits.Count()<1)
            {
                MessageBox.Show("Please assign unit to make any Stock Adustment for this item");
            }
        }

        private void FillAllReasons()
        {
            ReasonService _rcontext = new ReasonService();
            IEnumerable<reason_codes> objReasons = _rcontext.ReadAllActiveReasons();
            cmbReason.DisplayMemberPath = "description";
            cmbReason.SelectedValuePath = "Id";
            cmbReason.ItemsSource = objReasons.ToList();
        }

        private void dgCKWHItems_SelectionChanged(object sender, SelectionChangeEventArgs e)
        {
            //WHStockAdjustmentViewModel objWHStkAdjVM = (dgCKWHItems.SelectedItem) as WHStockAdjustmentViewModel;

            //if(objWHStkAdjVM.wh_unit_id == 0)
            //{
            //    MessageBox.Show("Please configure unit ");
            //    return;
            //}
            //int wh_item_id = objWHStkAdjVM.wh_item_id;

            ckwh_items objItem = (dgCKWHItems.SelectedItem) as ckwh_items;
            int wh_item_id = objItem.Id;

            FillAllUnits(wh_item_id);
            FillAllReasons();
            txtItemCode.Value = objItem.wh_item_code;
            txtDescription.Value = objItem.wh_item_description;
            WHItemService _wicontext = new WHItemService();
            selected_item_id = _wicontext.GetItemId(txtItemCode.Value);
            if (objItem.ck_qty != null)
            {
                selected_ck_qty = (decimal)objItem.ck_qty;
            }
            cmbUnit.Focus();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            decimal updated_ck_qty = 0.00000000m;
            updated_ck_qty = selected_ck_qty + ((decimal)(txtQty.Value)*conversion_factor);
            MessageBox.Show(updated_ck_qty.ToString());
        }

        private void cmbUnit_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            WHItemUnitService _wucontext = new WHItemUnitService();
            if(cmbUnit.SelectedValue==null)
            {
                return;
            }
            conversion_factor = (decimal)_wucontext.GetConversionFactorByWHItemId(selected_item_id, Convert.ToInt32(cmbUnit.SelectedValue.ToString()));
        }
    }
}
