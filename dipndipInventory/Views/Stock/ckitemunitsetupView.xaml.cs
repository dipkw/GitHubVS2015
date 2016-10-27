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
    /// Interaction logic for ckitemunitsetupView.xaml
    /// </summary>
    public partial class ckitemunitsetupView : RadWindow
    {
        CKItemService _context = new CKItemService();
        CKItemUnitService _ucontext = new CKItemUnitService();
        bool edit_mode = false;
        //string username = string.Empty;
        int id = 0;
        int selected_unit_id = 0;
        decimal selected_unit_cost = 0.000m;
        string base_unit = string.Empty;
        List<ItemUnitViewModel> itemUnits = new List<ItemUnitViewModel>();
        List<ck_units> cmbUnitList = new List<ck_units>();
        public ckitemunitsetupView()
        {
            InitializeComponent();
            ShowTaskBar.ShowInTaskbar(this, "Central Kitchen Item Unit Setup");
            ReadAllCKItems();
        }

        private void ReadAllCKItems()
        {
            IEnumerable<ck_items> objWarehouseItems = _context.ReadAllCKItems();
            dgCKItems.ItemsSource = objWarehouseItems;
            FillUnits();
            txtDescription.Focus();
        }

        public void FillUnits()
        {
            UnitService unitContext = new UnitService();
            IEnumerable<ck_units> objUnits = unitContext.ReadAllUnits();
            //cmbSupplier.DisplayMemberPath = "Supplier_code";
            cmbBaseUnit.DisplayMemberPath = "unit_description";
            cmbBaseUnit.SelectedValuePath = "Id";
            cmbUnit.DisplayMemberPath = "unit_description";
            cmbUnit.SelectedValuePath = "Id";
            //cmbUnit.ItemsSource = objUnits.ToList();
            cmbUnitList = objUnits.ToList();
            cmbBaseUnit.ItemsSource = cmbUnitList;
            cmbUnit.ItemsSource = cmbUnitList;
        }

        public void UpdateUnitList()
        {
            var updated_unit_list = cmbUnitList.Where(x => x.Id != Convert.ToInt32(cmbBaseUnit.SelectedValue.ToString())).ToList();
            cmbUnit.ItemsSource = null;
            cmbUnit.ItemsSource = updated_unit_list.ToList();
            UpdateGridWithBaseUnit();
            cmbBaseUnit.IsHitTestVisible = false;
        }

        public void UpdateGridWithBaseUnit()
        {
            itemUnits.Clear();
            ItemUnitViewModel objItemUnitViewModel = new ItemUnitViewModel();
            //objItemUnitViewModel.id = item_unit.Id;
            //objItemUnitViewModel.itemId = (int)item_unit.ck_item_id;
            objItemUnitViewModel.itemCode = txtItemCode.Value;
            objItemUnitViewModel.unitId = Convert.ToInt32(cmbBaseUnit.SelectedValue.ToString());
            objItemUnitViewModel.unitText = cmbBaseUnit.Text;
            objItemUnitViewModel.conversionFactor = 1;
            objItemUnitViewModel.baseUnit = cmbBaseUnit.Text;
            base_unit = cmbBaseUnit.Text;
            //objItemUnitViewModel.defaultUnit = (bool)chkDefaultUnit.IsChecked;
            //objItemUnitViewModel.unitCost = objItemUnitViewModel.conversionFactor * selected_unit_cost;
            if (MessageBox.Show("Do you want to set as default unit?", "Default Unit?", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                objItemUnitViewModel.defaultUnit = true;
                if ((bool)chkDefaultUnit.IsChecked)
                {
                    itemUnits.Select(u => { u.defaultUnit = false; return u; }).ToList();
                }
            }
            else
            {
                objItemUnitViewModel.defaultUnit = false;
            }
            itemUnits.Add(objItemUnitViewModel);
            dgCKItemUnits.ItemsSource = null;
            dgCKItemUnits.ItemsSource = itemUnits;
        }
        private void SelectItem()
        {
            try
            {
                if (dgCKItems.SelectedItem == null)
                {
                    return;
                }

                ck_items objCKItems = (dgCKItems.SelectedItem) as ck_items;

                id = objCKItems.Id;

                txtItemCode.Value = objCKItems.ck_item_code;
                txtItemCode.IsReadOnly = true;

                txtDescription.Value = objCKItems.ck_item_description;
                txtDescription.IsReadOnly = true;

                cmbUnit.SelectedIndex = -1;
                cmbUnit.IsHitTestVisible = false;
                txtConvFactor.IsReadOnly = true;

                btnAddUnit.IsEnabled = false;
                btnDeleteUnit.IsEnabled = false;
                btnDelete.IsEnabled = false;
                btnSaveItem.IsEnabled = false;
                btnSave.IsEnabled = false;

                //selected_unit_cost = (decimal)objCKItems.ck_item_unit_cost;
                base_unit = objCKItems.ck_units.unit_description;

                UpdateItemUnitList();
            }
            catch { }
        }

        private void UpdateItemUnitList()
        {
            //Read units from database for the selected item and update the 'itemUnits' List
            IEnumerable<ck_item_unit> item_units = _ucontext.ReadAllCKItemUnitsByCKItemId(id);
            CKItemService _icontext = new CKItemService();
            itemUnits.Clear();
            //MessageBox.Show(item_units.Count().ToString());
            foreach (ck_item_unit item_unit in item_units)
            {
                ItemUnitViewModel objItemUnitViewModel = new ItemUnitViewModel();
                objItemUnitViewModel.id = item_unit.Id;
                objItemUnitViewModel.itemId = (int)item_unit.ck_item_id;
                objItemUnitViewModel.itemCode = _icontext.GetItemCode(objItemUnitViewModel.itemId);
                objItemUnitViewModel.unitId = (int)item_unit.ck_unit_id;
                objItemUnitViewModel.unitText = item_unit.ck_units.unit_description;
                objItemUnitViewModel.conversionFactor = (decimal)item_unit.cnv_factor;
                objItemUnitViewModel.baseUnit = base_unit;
                objItemUnitViewModel.unitCost = objItemUnitViewModel.conversionFactor * selected_unit_cost;
                itemUnits.Add(objItemUnitViewModel);
            }
            dgCKItemUnits.ItemsSource = null;
            dgCKItemUnits.ItemsSource = itemUnits;
            dgCKItemUnits.Items.Refresh();
        }

        private void dgCKItems_SelectionChanged(object sender, SelectionChangeEventArgs e)
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

            if (dgCKItems.SelectedItem == null)
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
            objItemUnitViewModel.baseUnit = base_unit;
            objItemUnitViewModel.unitCost = objItemUnitViewModel.conversionFactor * selected_unit_cost;
            objItemUnitViewModel.defaultUnit = (bool)chkDefaultUnit.IsChecked;
            if ((bool)chkDefaultUnit.IsChecked)
            {
                itemUnits.Select(u => { u.defaultUnit = false; return u; }).ToList();
            }
            itemUnits.Add(objItemUnitViewModel);
            dgCKItemUnits.ItemsSource = itemUnits.ToList();
            //UpdateCmbUnitList();
            cmbUnit.SelectedIndex = -1;
            txtConvFactor.Value = 0.000;
            cmbUnit.Focus();
        }

        private void UpdateCmbUnitList()
        {
            var updated_unit_list = cmbUnitList.Where(x => x.Id != Convert.ToInt32(cmbUnit.SelectedValue.ToString())).ToList();
            cmbUnit.ItemsSource = null;
            cmbUnit.ItemsSource = updated_unit_list.ToList();
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

        private void dgCKItemUnits_SelectionChanged(object sender, SelectionChangeEventArgs e)
        {
            SelectUnit();
            btnDeleteUnit.IsEnabled = true;
        }

        private void SelectUnit()
        {
            try
            {
                if (dgCKItemUnits.SelectedItem == null)
                {
                    return;
                }

                ItemUnitViewModel objItemUnitViewModel = (dgCKItemUnits.SelectedItem) as ItemUnitViewModel;
                //selected_unit_id = objItemUnitViewModel.unitId;
                selected_unit_id = objItemUnitViewModel.id;
            }
            catch { }
        }

        private void btnDeleteUnit_Click(object sender, RoutedEventArgs e)
        {
            dgCKItemUnits.ItemsSource = null;
            //itemUnits.RemoveAll(x => x.unitId == selected_unit_id);
            itemUnits.RemoveAll(x => x.id == selected_unit_id);
            dgCKItemUnits.ItemsSource = itemUnits;
            //selected_unit_id = 0;
            //selected_unit_cost = 0.000m;
            btnDeleteUnit.IsEnabled = false;
        }

        private void SaveItemUnit()
        {
            string _dbresponse = string.Empty;
            foreach (ItemUnitViewModel itemUnit in itemUnits)
            {
                ck_item_unit objCKItemUnit = new ck_item_unit();
                objCKItemUnit.ck_item_id = id;
                objCKItemUnit.ck_unit_id = itemUnit.unitId;
                objCKItemUnit.cnv_factor = itemUnit.conversionFactor;
                objCKItemUnit.default_unit = itemUnit.defaultUnit;
                if (_ucontext.IsExistingCKItemUnit(id, itemUnit.unitId))
                {
                    objCKItemUnit.Id = itemUnit.id;
                    objCKItemUnit.modified_by = GlobalVariables.ActiveUser.Id;
                    objCKItemUnit.modified_date = DateTime.Now;
                    _dbresponse = _ucontext.UpdateCKItemUnit(objCKItemUnit) > 0 ? "Central Kitchen Item Unit Updated Successfully" : "Unable to Update Central Kitchen Item Unit Details";
                    if (_dbresponse == "Unable to Update Central Kitchen Item Unit Details")
                    {
                        break;
                    }
                }
                else
                {
                    objCKItemUnit.created_by = GlobalVariables.ActiveUser.Id;
                    objCKItemUnit.created_date = DateTime.Now;
                    _dbresponse = _ucontext.CreateCKItemUnit(objCKItemUnit) > 0 ? "Central Kitchen Item Unit Details Updated Successfully" : "Unable to Update Central Kitchen Item Unit Details";
                    if (_dbresponse == "Unable to Update Central Kitchen Item Unit Details")
                    {
                        break;
                    }
                }
            }
            //Delete item units if not in the new unit list
            IEnumerable<ck_item_unit> objCKItemUnitDetails = _ucontext.ReadAllCKItemUnitsByCKItemId(id);
            foreach (ck_item_unit itemUnitDetail in objCKItemUnitDetails)
            {
                //search_result = itemRecipeList.FirstOrDefault(item => item.wh_item_id == itemDetail.ckwh_item_id).ToString();
                //var search_result = itemUnits.Where(item => item.itemId == itemUnitDetail.wh_item_id);
                //var search_result = itemUnits.Where(item => item.id == itemUnitDetail.Id);
                var search_result = itemUnits.Where(item => ((item.itemId == itemUnitDetail.ck_item_id || item.itemId == 0) && item.unitId == itemUnitDetail.ck_unit_id));
                if (search_result.Count() == 0)
                {
                    _dbresponse = _ucontext.DeleteCKItemUnitById((int)itemUnitDetail.Id) > 0 ? "Central Kitchen Item Unit Details Updated Successfully" : "Unable to Update Central Kitchen Item Unit Details";
                    if (_dbresponse == "Unable to Update Central Kitchen Item Unit Details")
                    {
                        break;
                    }
                }
            }
            RadWindow.Alert(_dbresponse);
        }

        private void SaveItemUnit1()
        {
            //Update previous related records id with new id
            if (_ucontext.IsExistingCKItemUnitByCKItemId(id))
            {
                _ucontext.DeleteCKItemUnitByCKItemId(id);
                CreateItemUnits();
            }
            else
            {
                CreateItemUnits();
            }
        }

        public void CreateItemUnits()
        {
            int itemCount = 0;
            itemCount = itemUnits.Count();
            string _dbresponse = string.Empty;
            for (int i = 0; i < itemCount; i++)
            {
                ck_item_unit objCKItemUnit = new ck_item_unit();
                //objWHItemUnit.wh_item_id = itemUnits[i].itemId;
                objCKItemUnit.ck_item_id = id;
                objCKItemUnit.ck_unit_id = itemUnits[i].unitId;
                objCKItemUnit.cnv_factor = itemUnits[i].conversionFactor;
                _dbresponse = _ucontext.CreateCKItemUnit(objCKItemUnit) > 0 ? "Item Unit Details Updated Successfully" : "Unable to Update Item Unit Details"; ;
                RadWindow.Alert(_dbresponse);
            }
        }

        private void btnSaveItem_Click(object sender, RoutedEventArgs e)
        {
            RadWindow.Confirm("Do you want to Continue ?", this.onSave);
        }

        private void onSave(object sender, WindowClosedEventArgs e)
        {
            if (e.DialogResult == true)
            {
                SaveItemUnit();
            }
        }

        private void cmbBaseUnit_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateUnitList();
        }
    }
}
