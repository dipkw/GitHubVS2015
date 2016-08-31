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
    /// Interaction logic for whitemunitsetupView.xaml
    /// </summary>
    public partial class whitemunitsetupView : RadWindow
    {
        WHItemService _context = new WHItemService();
        bool edit_mode = false;
        //string username = string.Empty;
        int id = 0;
        int selected_unit_id = 0;
        List<ItemUnitViewModel> itemUnits = new List<ItemUnitViewModel>();
        public whitemunitsetupView()
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
                cmbUnit.IsHitTestVisible = false;
                txtConvFactor.IsReadOnly = true;

                btnAddUnit.IsEnabled = false;
                btnDeleteUnit.IsEnabled = false;
                btnDelete.IsEnabled = false;
                btnSaveItem.IsEnabled = false;
                btnSave.IsEnabled = false;
            }
            catch { }
        }

        private void dgWHItems_SelectionChanged(object sender, SelectionChangeEventArgs e)
        {
            SelectItem();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            //if (GlobalVariables.ActiveUser.Role != "Admin")
            //{
            //    RadWindow.Alert("Access denied, Please contact Administrator");
            //    return;
            //}

            if (dgWHItems.SelectedItem == null)
            {
                return;
            }

            //txtDescription.IsReadOnly = false;
            
            //txtUsername.IsReadOnly = false;
            edit_mode = true;
            //btnSave.IsEnabled = true;
            cmbUnit.IsHitTestVisible = true;
            txtConvFactor.IsReadOnly = false;
            btnAddUnit.IsEnabled = true;
            btnSaveItem.IsEnabled = true;
            cmbUnit.Focus();
        }
        public void UpdateUnitGrid()
        {
            itemUnits.Clear();
        }

        private void btnAddUnit_Click(object sender, RoutedEventArgs e)
        {
            //if(cmbUnit.SelectedIndex==-1)
            //{
            //    MessageBox.Show("Please select a unit to add");
            //    return;
            //}
            if (!CheckUnitDetails())
            {
                return;
            }
            if (UnitExistForItem((int)cmbUnit.SelectedValue))
            {
                MessageBox.Show("Existing Unit");
                return;
            }
            ItemUnitViewModel objItemUnitViewModel = new ItemUnitViewModel();
            objItemUnitViewModel.itemCode = txtItemCode.Value;
            objItemUnitViewModel.unitId = (int)cmbUnit.SelectedValue;
            objItemUnitViewModel.unitText = cmbUnit.Text;
            objItemUnitViewModel.conversionFactor = (decimal)txtConvFactor.Value;
            itemUnits.Add(objItemUnitViewModel);
            dgWHItemUnits.ItemsSource = itemUnits.ToList();
            cmbUnit.SelectedIndex = -1;
            txtConvFactor.Value = 0.000;
            cmbUnit.Focus();
        }

        private bool UnitExistForItem(int unitId)
        {
            var search_result = itemUnits.Find(x => x.unitId == unitId);
            if (search_result == null)
            {
                return false;
            }
            return true;
        }

        private bool CheckUnitDetails()
        {
            if (cmbUnit.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a unit to add");
                return false;
            }
            if (txtConvFactor.Value <= 0 || txtConvFactor.Value == null)
            {
                MessageBox.Show("Invalid input for Conversion Factor");
                return false;
            }
            return true;
        }

        private void dgWHItemUnits_SelectionChanged(object sender, SelectionChangeEventArgs e)
        {
            SelectUnit();
            btnDeleteUnit.IsEnabled = true;
        }

        private void SelectUnit()
        {
            try
            {
                if (dgWHItemUnits.SelectedItem == null)
                {
                    return;
                }

                ItemUnitViewModel objItemUnitViewModel = (dgWHItemUnits.SelectedItem) as ItemUnitViewModel;
                selected_unit_id = objItemUnitViewModel.unitId;
            }
            catch { }
        }

        private void btnDeleteUnit_Click(object sender, RoutedEventArgs e)
        {
            dgWHItemUnits.ItemsSource = null;
            itemUnits.RemoveAll(x => x.unitId == selected_unit_id);
            dgWHItemUnits.ItemsSource = itemUnits;
            selected_unit_id = 0;
            btnDeleteUnit.IsEnabled = false;
        }

        private void UpdateItemUnitList()
        {
            //Read units from database for the selected item and update the 'itemUnits' List
        }

    }
}
