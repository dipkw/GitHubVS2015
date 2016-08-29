using dipndipInventory.EF;
using dipndipInventory.EF.DataServices;
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
    /// Interaction logic for ckitemunitsetupView.xaml
    /// </summary>
    public partial class ckitemunitsetupView : RadWindow
    {
        WHItemService _context = new WHItemService();
        bool edit_mode = false;
        //string username = string.Empty;
        int id = 0;
        List<ItemUnitViewModel> itemUnits = new List<ItemUnitViewModel>();
        public ckitemunitsetupView()
        {
            InitializeComponent();
            ReadAllWHItems();
            //ReadAllWarehouseItemsSP();
        }

        private void ReadAllWHItems()
        {
            IEnumerable<ckwh_items> objWarehouseItems = _context.ReadAllWHItems();
            dgWHItems.ItemsSource = objWarehouseItems;
            FillUnits();
            txtDescription.Focus();
        }

        private void ReadAllWarehouseItemsSP()
        {
            IEnumerable<ckwh_items> objWarehouseItems = _context.ReadAllWarehouseItemsSP();
            dgWHItems.ItemsSource = objWarehouseItems;
            FillUnits();
            txtDescription.Focus();
        }

        public void FillUnits()
        {
            UnitService unitContext = new UnitService();
            IEnumerable<ck_units> objUnits = unitContext.ReadAllUnits();
            //cmbSupplier.DisplayMemberPath = "Supplier_code";
            cmbUnit.DisplayMemberPath = "unit_description";
            cmbUnit.SelectedValuePath = "Id";
            cmbUnit.ItemsSource = objUnits.ToList();
        }

        private void SelectItem()
        {
            try
            {
                if (dgWHItems.SelectedItem == null)
                {
                    return;
                }

                ckwh_items objWHItems = (dgWHItems.SelectedItem) as ckwh_items;

                id = objWHItems.Id;

                txtItemCode.Value = objWHItems.wh_item_code;
                txtItemCode.IsReadOnly = true;

                txtDescription.Value = objWHItems.wh_item_description;
                txtDescription.IsReadOnly = true;

                cmbUnit.SelectedIndex = -1;

                btnSave.IsEnabled = false;
            }
            catch { }
        }

        private void dgWHItems_SelectionChanged(object sender, SelectionChangeEventArgs e)
        {
            SelectItem();
        }

        public void UpdateUnitGrid()
        {
            itemUnits.Clear();
        }

        private void btnAddUnit_Click(object sender, RoutedEventArgs e)
        {
            ItemUnitViewModel objItemUnitViewModel = new ItemUnitViewModel();
            objItemUnitViewModel.itemCode = txtItemCode.Value;
            objItemUnitViewModel.unitId = (int)cmbUnit.SelectedValue;
            objItemUnitViewModel.unitText = cmbUnit.Text;
            objItemUnitViewModel.conversionFactor = (decimal)txtConvFactor.Value;
            itemUnits.Add(objItemUnitViewModel);
            dgWHItemUnits.ItemsSource = itemUnits.ToList();
        }
    }
}
