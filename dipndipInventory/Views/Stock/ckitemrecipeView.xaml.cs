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
    /// Interaction logic for ckitemrecipeView.xaml
    /// </summary>
    public partial class ckitemrecipeView : RadWindow
    {
        WHItemService _whcontext = new WHItemService();
        WHItemUnitService _whucontext = new WHItemUnitService();
        UnitService _ucontext = new UnitService();
        CKItemService _ckcontext = new CKItemService();
        CKItemDetailService _dtcontext = new CKItemDetailService();
        bool edit_mode = false;
        //string username = string.Empty;
        int id = 0;

        int wh_item_id = 0;
        decimal? wh_item_curr_cost = 0.0m;
        decimal ck_item_cost = 0.0m;
        int selected_recipe_item_id = 0;

        List<CKItemRecipeViewModel> itemRecipeList = new List<CKItemRecipeViewModel>();
        IEnumerable<ck_items> objCKItems;
        public ckitemrecipeView()
        {
            InitializeComponent();
            //ReadAllCKItems();
            LoadAllItemRecipeList();
            FillWHItems();
        }

        private void ReadAllCKItems()
        {
            objCKItems = _ckcontext.ReadAllCKItems();
            dgCKItems.ItemsSource = objCKItems;
        }
        private void FillWHItems()
        {
            //cmbRecipeItem.DisplayMemberPath = "wh_item_code";
            cmbRecipeItem.SelectedValuePath = "Id";
            cmbRecipeItem.ItemsSource = _whcontext.ReadAllWHItems().ToList();
        }

        private void FillWarehouseItemUnits(int wh_item_id)
        {
            IEnumerable<wh_item_unit> item_units = _whucontext.ReadAllWHItemUnitsByWHItemId(wh_item_id);
            //cmbUnit.DisplayMemberPath = "unit_description";
            cmbUnit.DisplayMemberPath = "ck_units.unit_description";
            cmbUnit.SelectedValuePath = "Id";
            cmbUnit.ItemsSource = item_units.ToList();
        }
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void cmbRecipeItem_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(cmbRecipeItem.SelectedValue == null)
            {
                return;
            }
            wh_item_id = (int)cmbRecipeItem.SelectedValue;
            wh_item_curr_cost = (decimal)_whcontext.GetCurrentCost(wh_item_id);
            FillWarehouseItemUnits(wh_item_id);
        }

        private void btnAddRecipeItem_Click(object sender, RoutedEventArgs e)
        {
            if(!RecipeDetailsValid())
            {
                MessageBox.Show("Please fill all the required fields");
                return;
            }

            if (RecipeItemExist(wh_item_id))
            {
                MessageBox.Show("Item already added in the Recipe List");
                return;
            }

            decimal conv_factor = 0.0m;
            int unit_id = (int)cmbUnit.SelectedValue;
            CKItemRecipeViewModel objCKItemRecipeViewModel = new CKItemRecipeViewModel();
            objCKItemRecipeViewModel.wh_item_id = wh_item_id;
            objCKItemRecipeViewModel.wh_item_code = _whcontext.GetItemCode(wh_item_id);
            objCKItemRecipeViewModel.wh_item_description = _whcontext.GetItemDescription(wh_item_id);
            objCKItemRecipeViewModel.quantity = (decimal)txtQty.Value;
            objCKItemRecipeViewModel.uom = cmbUnit.Text;
            objCKItemRecipeViewModel.wh_item_unit_id = unit_id;
            conv_factor = (decimal)_whucontext.GetConversionFactor(unit_id);
            objCKItemRecipeViewModel.unit_cost = (decimal)((wh_item_curr_cost * conv_factor) * objCKItemRecipeViewModel.quantity);
            ck_item_cost += objCKItemRecipeViewModel.unit_cost;
            itemRecipeList.Add(objCKItemRecipeViewModel);
            dgCKItemRecipe.ItemsSource = itemRecipeList.ToList();
            cmbRecipeItem.SelectedIndex = -1;
            cmbUnit.SelectedIndex = -1;
            txtQty.Value = 0;

            //var toUpdate = objCKItems.Single(x => x.Id == wh_item_id);
            //toUpdate.ck_item_unit_cost = ck_item_cost;

            //var query = (from itm in objCKItems
            //             where itm.Id == wh_item_id
            //             select itm);
            UpdateCKItemUnitCost();
        }

        private void UpdateCKItemUnitCost()
        {
            objCKItems.Where(p => p.Id == id).Select(u => { u.ck_item_unit_cost = ck_item_cost; return u; }).ToList();
            dgCKItems.ItemsSource = null;
            //dgCKItems.ItemsSource = objCKItems.ToList();
            dgCKItems.ItemsSource = objCKItems;
        }

        private void UpdateCKItemUnitCostById(int param_id)
        {
            objCKItems.Where(p => p.Id == param_id).Select(u => { u.ck_item_unit_cost = ck_item_cost; return u; }).ToList();
            dgCKItems.ItemsSource = null;
            dgCKItems.ItemsSource = objCKItems.ToList();
        }
        private bool RecipeItemExist(int whitem_id)
        {
            var search_result = itemRecipeList.Find(x => x.wh_item_id == whitem_id);
            if (search_result == null)
            {
                return false;
            }
            return true;
        }

        private bool RecipeDetailsValid()
        {
            bool result = true;

            if(cmbRecipeItem.SelectedIndex ==-1)
            {
                return false;
            }
            
            if(txtQty.Value<=0 || txtQty.Value == null)
            {
                return false;
            }

            if(cmbUnit.SelectedIndex==-1)
            {
                return false;
            }

            return result;
        }
        private void btnDeleteRecipeItem_Click(object sender, RoutedEventArgs e)
        {
            ck_item_cost-= itemRecipeList.Find(x => x.wh_item_id == selected_recipe_item_id).unit_cost;
            dgCKItemRecipe.ItemsSource = null;
            itemRecipeList.RemoveAll(x => x.wh_item_id == selected_recipe_item_id);
            dgCKItemRecipe.ItemsSource = itemRecipeList;
            //wh_item_id = 0;
            wh_item_curr_cost = 0.000m;
            btnDeleteRecipeItem.IsEnabled = false;

            cmbRecipeItem.SelectedIndex = -1;
            cmbUnit.SelectedIndex = -1;
            txtQty.Value = 0;
            UpdateCKItemUnitCost();
        }

        private void dgCKItems_SelectionChanged(object sender, SelectionChangeEventArgs e)
        {
            SelectItem();
            LoadItemRecipeList();
        }

        private void SelectItem()
        {
            try
            {
                if(dgCKItems.SelectedItem == null)
                {
                    return;
                }

                cmbRecipeItem.IsEnabled = false;
                cmbRecipeItem.IsReadOnly = true;
                cmbRecipeItem.IsHitTestVisible = false;
                txtQty.IsEnabled = false;
                txtQty.IsReadOnly = true;
                txtQty.IsHitTestVisible = false;
                cmbUnit.IsEnabled = false;
                cmbUnit.IsReadOnly = true;
                cmbUnit.IsHitTestVisible = false;
                btnAddRecipeItem.IsEnabled = false;
                btnDeleteRecipeItem.IsEnabled = false;
                btnSaveItem.IsEnabled = false;

                ck_items objCK_Items = (dgCKItems.SelectedItem) as ck_items;
                id = objCK_Items.Id;
            }
            catch { }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if(dgCKItems.SelectedItem == null)
            {
                return;
            }

            cmbRecipeItem.IsEnabled = true;
            cmbRecipeItem.IsReadOnly = false;
            cmbRecipeItem.IsHitTestVisible = true;

            txtQty.IsEnabled = true;
            txtQty.IsReadOnly = false;
            txtQty.IsHitTestVisible = true;

            cmbUnit.IsEnabled = true;
            cmbUnit.IsReadOnly = false;
            cmbUnit.IsHitTestVisible = true;

            btnAddRecipeItem.IsEnabled = true;
            btnDeleteRecipeItem.IsEnabled = true;
            btnSaveItem.IsEnabled = true;
        }

        private void CalculateUnitCost(int ck_item_id)
        {
            //var search_result = itemRecipeList.Find(x => x. == whitem_id);
            //if (search_result == null)
        }

        private void dgCKItemRecipe_SelectionChanged(object sender, SelectionChangeEventArgs e)
        {
            try
            {
                if (dgCKItemRecipe.SelectedItem == null)
                {
                    return;
                }

                CKItemRecipeViewModel objCKItemRecipeViewModel = (dgCKItemRecipe.SelectedItem) as CKItemRecipeViewModel;
                selected_recipe_item_id = objCKItemRecipeViewModel.wh_item_id;
            }
            catch { }
            btnDeleteRecipeItem.IsEnabled = true;
        }

        private void btnSaveItem_Click(object sender, RoutedEventArgs e)
        {
            RadWindow.Confirm("Do you want to Continue ?", this.onSave);
        }

        private void onSave(object sender, WindowClosedEventArgs e)
        {
            if (e.DialogResult == true)
            {
                SaveItemRecipe();
            }
        }

        private void SaveItemRecipe()
        {
            if (_dtcontext.IsExistingCKItemRecipeByCKItemId(id))
            {
                _dtcontext.DeleteCKItemRecipeByCKItemId(id);
                CreateItemUnits();
            }
            else
            {
                CreateItemUnits();
            }
        }

        private void CreateItemUnits()
        {
            int itemrecipeCount = 0;
            itemrecipeCount = itemRecipeList.Count();
            string _dbresponse = string.Empty;
            for (int i = 0; i < itemrecipeCount; i++)
            {
                ck_item_details objCKItemDetails = new ck_item_details();
                //objWHItemUnit.wh_item_id = itemUnits[i].itemId;
                objCKItemDetails.ck_item_id = id;
                objCKItemDetails.ckwh_item_id = itemRecipeList[i].wh_item_id;
                objCKItemDetails.ckwh_item_qty = itemRecipeList[i].quantity;
                objCKItemDetails.ckwh_item_unit_id = itemRecipeList[i].wh_item_unit_id;
                _dbresponse = _dtcontext.CreateCKItemDetails(objCKItemDetails) > 0 ? "CK Item Recipe Updated Successfully" : "Unable to Update CK Item Recipe Details"; ;
                RadWindow.Alert(_dbresponse);
            }
        }

        private void LoadItemRecipeList()
        {
            //Read units from database for the selected item and update the 'itemUnits' List
            IEnumerable<ck_item_details> item_recipes = _dtcontext.ReadAllCKItemRecipeByCKItemId(id);
            itemRecipeList.Clear();
            ck_item_cost = 0.0m;
            //MessageBox.Show(item_units.Count().ToString());
            foreach (ck_item_details item_recipe in item_recipes)
            {
                CKItemRecipeViewModel objItemRecipeViewModel = new CKItemRecipeViewModel();
                objItemRecipeViewModel.wh_item_id = (int)item_recipe.ckwh_item_id;
                objItemRecipeViewModel.wh_item_code = _whcontext.GetItemCode(objItemRecipeViewModel.wh_item_id);
                objItemRecipeViewModel.wh_item_description = _whcontext.GetItemDescription(objItemRecipeViewModel.wh_item_id);
                objItemRecipeViewModel.quantity = (decimal)item_recipe.ckwh_item_qty;
                objItemRecipeViewModel.uom = item_recipe.wh_item_unit.ck_units.unit_description;
                //objItemRecipeViewModel.unit_cost = objItemRecipeViewModel.conversionFactor * selected_unit_cost;
                wh_item_curr_cost = (decimal)_whcontext.GetCurrentCost(objItemRecipeViewModel.wh_item_id);
                objItemRecipeViewModel.unit_cost = ((decimal)(item_recipe.wh_item_unit.cnv_factor*wh_item_curr_cost)* objItemRecipeViewModel.quantity);
                ck_item_cost += objItemRecipeViewModel.unit_cost;
                itemRecipeList.Add(objItemRecipeViewModel);
            }
            dgCKItemRecipe.ItemsSource = null;
            dgCKItemRecipe.ItemsSource = itemRecipeList;
            dgCKItemRecipe.Items.Refresh();
            //UpdateCKItemUnitCost();
        }

        private void LoadAllItemRecipeList()
        {
            objCKItems = _ckcontext.ReadAllCKItems();
            dgCKItems.ItemsSource = objCKItems;
            foreach (ck_items ck_item in objCKItems)
            {
                ck_item_cost = 0.0m;
                IEnumerable<ck_item_details> item_recipes = _dtcontext.ReadAllCKItemRecipeByCKItemId(ck_item.Id);
                itemRecipeList.Clear();
                foreach (ck_item_details item_recipe in item_recipes)
                {
                    //MessageBox.Show(item_units.Count().ToString());
                    CKItemRecipeViewModel objItemRecipeViewModel = new CKItemRecipeViewModel();
                    objItemRecipeViewModel.wh_item_id = (int)item_recipe.ckwh_item_id;
                    objItemRecipeViewModel.wh_item_code = _whcontext.GetItemCode(objItemRecipeViewModel.wh_item_id);
                    objItemRecipeViewModel.wh_item_description = _whcontext.GetItemDescription(objItemRecipeViewModel.wh_item_id);
                    objItemRecipeViewModel.quantity = (decimal)item_recipe.ckwh_item_qty;
                    objItemRecipeViewModel.uom = item_recipe.wh_item_unit.ck_units.unit_description;
                    //objItemRecipeViewModel.unit_cost = objItemRecipeViewModel.conversionFactor * selected_unit_cost;
                    wh_item_curr_cost = (decimal)_whcontext.GetCurrentCost(objItemRecipeViewModel.wh_item_id);
                    objItemRecipeViewModel.unit_cost = ((decimal)(item_recipe.wh_item_unit.cnv_factor * wh_item_curr_cost) * objItemRecipeViewModel.quantity);
                    ck_item_cost += objItemRecipeViewModel.unit_cost;
                    //itemRecipeList.Add(objItemRecipeViewModel);
                    //dgCKItemRecipe.ItemsSource = null;
                    //dgCKItemRecipe.ItemsSource = itemRecipeList;
                    //dgCKItemRecipe.Items.Refresh();
                }
                UpdateCKItemUnitCostById(ck_item.Id);
            }
        }
    }
}
