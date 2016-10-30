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
    /// Interaction logic for ckproductionView.xaml
    /// </summary>
    public partial class ckproductionView : RadWindow
    {
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
                    ckpvm.itemCode = ckitem.ck_item_code;
                    ckpvm.itemDescription = ckitem.ck_item_description;
                    ckpvm.designQty = (decimal)ckitem.ck_design_qty;
                    ckpvm.qtyonHand = (decimal)ckitem.qty_on_hand;
                }
                catch
                {

                }

                objCKProductionViewModel.Add(ckpvm);
            }
            dgCKProduction.ItemsSource = objCKProductionViewModel.ToList();
        }
    }
}
