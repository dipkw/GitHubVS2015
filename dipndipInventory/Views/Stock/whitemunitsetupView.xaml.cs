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
    /// Interaction logic for whitemunitsetupView.xaml
    /// </summary>
    public partial class whitemunitsetupView : RadWindow
    {
        WHItemService _context = new WHItemService();
        WHItemUnitService _ucontext = new WHItemUnitService();
        bool edit_mode = false;
        //string username = string.Empty;
        int id = 0;
        int selected_unit_id = 0;
        decimal selected_unit_cost = 0.000m;
        string base_unit = string.Empty;
        List<ItemUnitViewModel> itemUnits = new List<ItemUnitViewModel>();
        public whitemunitsetupView()
        {
            InitializeComponent();
            ShowTaskBar.ShowInTaskbar(this, "Warehouse Item Unit Setup");
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
            //IEnumerable<ckwh_items> objWarehouseItems = _context.ReadAllWarehouseItemsSP();
            //dgWHItems.ItemsSource = objWarehouseItems;
            //FillUnits();
            //txtDescription.Focus();
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

                selected_unit_cost = (decimal)objWHItems.unit_cost;
                base_unit = objWHItems.wh_unit_description;

                UpdateItemUnitList();
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
            objItemUnitViewModel.baseUnit = base_unit;
            objItemUnitViewModel.unitCost = objItemUnitViewModel.conversionFactor * selected_unit_cost;
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
                //selected_unit_id = objItemUnitViewModel.unitId;
                selected_unit_id = objItemUnitViewModel.id;
            }
            catch { }
        }

        private void btnDeleteUnit_Click(object sender, RoutedEventArgs e)
        {
            dgWHItemUnits.ItemsSource = null;
            //itemUnits.RemoveAll(x => x.unitId == selected_unit_id);
            itemUnits.RemoveAll(x => x.id == selected_unit_id);
            dgWHItemUnits.ItemsSource = itemUnits;
            //selected_unit_id = 0;
            //selected_unit_cost = 0.000m;
            btnDeleteUnit.IsEnabled = false;
        }


        private void SaveItemUnit()
        {
            string _dbresponse = string.Empty;
            foreach(ItemUnitViewModel  itemUnit in itemUnits)
            {
                wh_item_unit objWHItemUnit = new wh_item_unit();
                objWHItemUnit.wh_item_id = id;
                objWHItemUnit.ck_unit_id = itemUnit.unitId;
                objWHItemUnit.cnv_factor = itemUnit.conversionFactor;
                if(_ucontext.IsExistingWHItemUnit(id, itemUnit.unitId))
                {
                    objWHItemUnit.Id = itemUnit.id;
                    objWHItemUnit.modified_by = GlobalVariables.ActiveUser.Id;
                    objWHItemUnit.modified_date = DateTime.Now;
                    _dbresponse = _ucontext.UpdateWHItemUnit(objWHItemUnit) > 0 ? "Warehouse Item Unit Updated Successfully" : "Unable to Update Warehouse Item Unit Details";
                    if (_dbresponse == "Unable to Update Warehouse Item Unit Details")
                    {
                        break;
                    }
                }
                else
                {
                    objWHItemUnit.created_by = GlobalVariables.ActiveUser.Id;
                    objWHItemUnit.created_date = DateTime.Now;
                    _dbresponse = _ucontext.CreateWHItemUnit(objWHItemUnit) > 0 ? "Warehouse Item Unit Details Updated Successfully" : "Unable to Update Warehouse Item Unit Details";
                    if (_dbresponse == "Unable to Update Warehouse Item Unit Details")
                    {
                        break;
                    }
                }
            }
            //Delete item units if not in the new unit list
            IEnumerable<wh_item_unit> objCKItemUnitDetails = _ucontext.ReadAllWHItemUnitsByWHItemId(id);
            foreach (wh_item_unit itemUnitDetail in objCKItemUnitDetails)
            {
                //search_result = itemRecipeList.FirstOrDefault(item => item.wh_item_id == itemDetail.ckwh_item_id).ToString();
                //var search_result = itemUnits.Where(item => item.itemId == itemUnitDetail.wh_item_id);
                //var search_result = itemUnits.Where(item => item.id == itemUnitDetail.Id);
                var search_result = itemUnits.Where(item => ((item.itemId == itemUnitDetail.wh_item_id || item.itemId == 0) && item.unitId==itemUnitDetail.ck_unit_id));
                if (search_result.Count() == 0)
                {
                    _dbresponse = _ucontext.DeleteWHItemUnitById((int)itemUnitDetail.Id) > 0 ? "Warehouse Item Unit Details Updated Successfully" : "Unable to Update Warehouse Item Unit Details";
                    if (_dbresponse == "Unable to Update Warehouse Item Unit Details")
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
            if(_ucontext.IsExistingWHItemUnitByWHItemId(id))
            {
                _ucontext.DeleteWHItemUnitByWHItemId(id);
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
                wh_item_unit objWHItemUnit = new wh_item_unit();
                //objWHItemUnit.wh_item_id = itemUnits[i].itemId;
                objWHItemUnit.wh_item_id = id;
                objWHItemUnit.ck_unit_id = itemUnits[i].unitId;
                objWHItemUnit.cnv_factor = itemUnits[i].conversionFactor;
                _dbresponse = _ucontext.CreateWHItemUnit(objWHItemUnit) > 0 ? "Item Unit Details Updated Successfully" : "Unable to Update Item Unit Details"; ;
                RadWindow.Alert(_dbresponse);
            }
        }

        private void UpdateItemUnitList()
        {
            //Read units from database for the selected item and update the 'itemUnits' List
            IEnumerable<wh_item_unit> item_units = _ucontext.ReadAllWHItemUnitsByWHItemId(id);
            WHItemService _icontext = new WHItemService();
            itemUnits.Clear();
            //MessageBox.Show(item_units.Count().ToString());
            foreach (wh_item_unit item_unit in item_units)
            {
                ItemUnitViewModel objItemUnitViewModel = new ItemUnitViewModel();
                objItemUnitViewModel.id = item_unit.Id;
                objItemUnitViewModel.itemId = (int)item_unit.wh_item_id;
                objItemUnitViewModel.itemCode = _icontext.GetItemCode(objItemUnitViewModel.itemId);
                objItemUnitViewModel.unitId = (int)item_unit.ck_unit_id;
                objItemUnitViewModel.unitText = item_unit.ck_units.unit_description;
                objItemUnitViewModel.conversionFactor = (decimal)item_unit.cnv_factor;
                objItemUnitViewModel.baseUnit = base_unit;
                objItemUnitViewModel.unitCost = objItemUnitViewModel.conversionFactor * selected_unit_cost;
                itemUnits.Add(objItemUnitViewModel);
            }
            dgWHItemUnits.ItemsSource = null;
            dgWHItemUnits.ItemsSource = itemUnits;
            dgWHItemUnits.Items.Refresh();
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
    }
}
