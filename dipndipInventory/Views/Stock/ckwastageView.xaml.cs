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
    /// Interaction logic for ckwastageView.xaml
    /// </summary>
    public partial class ckwastageView : RadWindow
    {
        int selected_item_id = 0;
        decimal selected_ck_qty = 0.00000000m;
        decimal conversion_factor = 0.00000000m;
        string adj_code = string.Empty;
        decimal selected_item_unit_cost = 0.00000000m;

        List<CKWastageViewModel> g_ck_wastage_vm_list = new List<CKWastageViewModel>();

        ck_wastage_master g_ck_wastage_master = new ck_wastage_master();
        List<ck_wastage_details> g_ck_wastage_detail_list = new List<ck_wastage_details>();
        List<ck_prod> g_ck_prod_list = new List<ck_prod>();
        List<ck_items> g_ck_items = new List<ck_items>();
        List<ck_stock_trans> g_stock_trans = new List<ck_stock_trans>();

        public ckwastageView()
        {
            InitializeComponent();
            ShowTaskBar.ShowInTaskbar(this, "Central Kitchen Item Wastage");
            ReadAllCKItemsVM();
        }

        private void ReadAllCKItems()
        {
            CKItemService ckcontext = new CKItemService();
            dgCKItems.ItemsSource = null;
            IEnumerable<ck_items> objItems = ckcontext.ReadAllActiveCKItems();
            dgCKItems.ItemsSource = objItems;
        }

        private void ReadAllCKItemsVM()
        {
            CKItemService ckcontext = new CKItemService();
            dgCKItems.ItemsSource = null;
            IEnumerable<ck_items> ckitems = ckcontext.ReadAllActiveCKItems();
            foreach(ck_items ckitem in ckitems)
            {
                CKWastageViewModel ckw = new CKWastageViewModel();
                ckw.Id = ckitem.Id;
                ckw.ck_item_code = ckitem.ck_item_code;
                ckw.ck_item_description = ckitem.ck_item_description;
                ckw.unit_id = (int)ckitem.ck_unit_id;

                CKItemUnitService cucontext = new CKItemUnitService();
                IEnumerable<ck_item_unit> ckitemunits = cucontext.ReadAllCKItemUnitsByCKItemId(ckw.Id);
                List<int> unitids = new List<int>();
                List<string> unitdescs = new List<string>();
                unitids.Clear();
                unitdescs.Clear();
                foreach(ck_item_unit ckitemunit in ckitemunits)
                {
                    unitids.Add((int)ckitemunit.ck_unit_id);
                    unitdescs.Add(ckitemunit.ck_units.unit_description);
                }

                ckw.ck_item_unit_id = unitids;
                ckw.ck_item_unit_description = unitdescs;
                ckw.ck_wastage_qty = 0.000m;

                g_ck_wastage_vm_list.Add(ckw);
            }

            dgCKItems.ItemsSource = g_ck_wastage_vm_list.ToList();
        }

        private void FillAllUnits(int ck_item_id)
        {
            CKItemUnitService unitContext = new CKItemUnitService();
            IEnumerable<ck_item_unit> objUnits = unitContext.ReadAllCKItemUnitsByCKItemId(ck_item_id);
            cmbUnit.DisplayMemberPath = "ck_units.unit_description";
            //cmbUnit.SelectedValuePath = "ck_unit_id";
            cmbUnit.SelectedValuePath = "Id";
            cmbUnit.ItemsSource = objUnits.ToList();
            if (objUnits.Count() < 1)
            {
                MessageBox.Show("Please assign unit to make any Item Wastage Entry for this item");
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

        private void dgCKItems_SelectionChanged(object sender, SelectionChangeEventArgs e)
        {
            //WHStockAdjustmentViewModel objWHStkAdjVM = (dgCKWHItems.SelectedItem) as WHStockAdjustmentViewModel;

            //if(objWHStkAdjVM.wh_unit_id == 0)
            //{
            //    MessageBox.Show("Please configure unit ");
            //    return;
            //}
            //int wh_item_id = objWHStkAdjVM.wh_item_id;
            try
            {
                ck_items objItem = (dgCKItems.SelectedItem) as ck_items;
                int ck_item_id = objItem.Id;

                FillAllUnits(ck_item_id);
                FillAllReasons();
                txtItemCode.Value = objItem.ck_item_code;
                txtDescription.Value = objItem.ck_item_description;
                CKItemService _cicontext = new CKItemService();
                selected_item_id = _cicontext.GetItemId(txtItemCode.Value);
                //selected_item_unit_cost = (decimal)objItem.unit_cost;
                if (objItem.ck_item_unit_cost == null)
                {
                    selected_item_unit_cost = 0.000m;
                }
                else
                {
                    selected_item_unit_cost = (decimal)objItem.ck_item_unit_cost;
                }

                if (objItem.qty_on_hand != null)
                {
                    selected_ck_qty = (decimal)objItem.qty_on_hand;
                }
                cmbUnit.Focus();
            }
            catch { }
        }

        private void cmbUnit_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CKItemUnitService _wucontext = new CKItemUnitService();
            int? ck_unit_id = 0;
            CKItemUnitService _ciucontext = new CKItemUnitService();
            ck_unit_id = _ciucontext.GetCKUnitID((Convert.ToInt32(cmbUnit.SelectedValue)));
            if (cmbUnit.SelectedValue == null)
            {
                return;
            }
            //conversion_factor = (decimal)_wucontext.GetConversionFactorByWHItemId(selected_item_id, Convert.ToInt32(cmbUnit.SelectedValue.ToString()));
            conversion_factor = (decimal)_wucontext.GetConversionFactorByCKItemId(selected_item_id, (int)ck_unit_id);
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
