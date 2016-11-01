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
using Telerik.Windows.Controls.GridView;

namespace dipndipInventory.Views.Stock
{
    /// <summary>
    /// Interaction logic for ckproductionView.xaml
    /// </summary>
    public partial class ckproductionView : RadWindow
    {
        List<CKProductionViewModel> ProductionList = new List<CKProductionViewModel>();
        public ckproductionView()
        {
            InitializeComponent();
            ShowTaskBar.ShowInTaskbar(this, "Central Kitchen Item Production");
            CKItemService _cicontext = new CKItemService();
            IEnumerable<ck_items> objCKItems = _cicontext.ReadAllCKItems();
            List<CKProductionViewModel> objCKProductionViewModel = new List<CKProductionViewModel>();
            foreach(ck_items ckitem in objCKItems)
            {
                CKProductionViewModel ckpvm = new CKProductionViewModel();
                try
                {
                    ckpvm.itemId = ckitem.Id;
                    ckpvm.itemCode = ckitem.ck_item_code;
                    ckpvm.itemDescription = ckitem.ck_item_description;
                    if (ckitem.ck_design_qty == null)
                    {
                        ckpvm.designQty = 0.000m;
                    }
                    else
                    {
                        ckpvm.designQty = (decimal)ckitem.ck_design_qty;
                    }
                    if (ckitem.qty_on_hand == null)
                    {
                        ckpvm.qtyonHand = 0.000m;
                    }
                    else
                    {
                        ckpvm.qtyonHand = (decimal)ckitem.qty_on_hand;
                    }
                    ckpvm.prodDate = DateTime.Today;
                    ckpvm.expDate = DateTime.Today;
                    if(ckitem.qty_on_hand == null)
                    {
                        ckpvm.qtyonHand = 0.000m;
                    }
                    else
                    {
                        ckpvm.qtyonHand = (decimal)ckitem.qty_on_hand;
                    }
                    ckpvm.ckUnit = ckitem.ck_units.unit_description;
                }
                catch
                {

                }

                objCKProductionViewModel.Add(ckpvm);
            }
            dgCKProduction.ItemsSource = objCKProductionViewModel.ToList();
        }

        private void btnProcess_Click(object sender, RoutedEventArgs e)
        {
            ReadProductionGrid();
        }

        private void ReadProductionGrid()
        {
            var rows = this.dgCKProduction.ChildrenOfType<GridViewRow>();
            int result = 0;
            CKOrderService _ocontext = new CKOrderService();
            
            foreach (var row in rows)
            {
                if (row is GridViewNewRow)
                    continue;

                CKProductionViewModel objCKProductionViewModel = row.Item as CKProductionViewModel;
                if (objCKProductionViewModel.prodQty > 0)
                {
                    objCKProductionViewModel.prodItemCost = GetCKItemProdCost(objCKProductionViewModel.itemId, objCKProductionViewModel.prodQty, objCKProductionViewModel.designQty);
                    MessageBox.Show(objCKProductionViewModel.itemCode + " " + objCKProductionViewModel.itemDescription + " " + objCKProductionViewModel.prodItemCost);
                    ProductionList.Add(objCKProductionViewModel);
                }
            }
        }

        private decimal GetCKItemProdCost(int ck_item_id, decimal prodQty, decimal design_qty)
        {
            decimal production_item_cost = 0.000m;
            try
            {
                CKItemDetailService _cdcontext = new CKItemDetailService();
                WHItemService _wicontext = new WHItemService();
                WHItemUnitService _wucontext = new WHItemUnitService();
                IEnumerable<ck_item_details> CKItemRecipeList = _cdcontext.ReadAllCKItemRecipeByCKItemId(ck_item_id);
                decimal? ck_item_prod_qty = design_qty * prodQty;
                foreach (ck_item_details item_recipe in CKItemRecipeList)
                {
                    int ckwh_item_id = (int)item_recipe.ckwh_item_id;
                    int wh_unit_id = (int)item_recipe.ckwh_item_unit_id;
                    decimal? avg_wh_item_cost = _wicontext.GetCKAvgCost(ckwh_item_id);
                    decimal? recipe_wh_item_qty = item_recipe.ckwh_item_qty;
                    decimal? used_wh_item_qty = item_recipe.ckwh_item_qty * prodQty;
                    

                    //MessageBox.Show(item_recipe.ckwh_item_id + " " + used_wh_item_qty);
                    

                    if (avg_wh_item_cost == null)
                    {
                        avg_wh_item_cost = 0.000m;
                    }
                    decimal? conv_factor = _wucontext.GetConversionFactorByWHItemUnitId(ckwh_item_id, wh_unit_id);
                    if(conv_factor == null)
                    {
                        conv_factor = 0.000m;
                    }
                    production_item_cost += (decimal)(avg_wh_item_cost * conv_factor * recipe_wh_item_qty * prodQty);
                }
                MessageBox.Show(ck_item_prod_qty.ToString());
            }
            catch
            {
                return 0.000m;
            }

            return production_item_cost;
        }
    }
}
