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
    /// Interaction logic for ckitemrecipeView.xaml
    /// </summary>
    public partial class ckitemrecipeView : RadWindow
    {
        WHItemService _whcontext = new WHItemService();
        UnitService _ucontext = new UnitService();
        bool edit_mode = false;
        //string username = string.Empty;
        int id = 0;
        public ckitemrecipeView()
        {
            InitializeComponent();
            FillItems();
        }

        private void FillItems()
        {
            //cmbRecipeItem.DisplayMemberPath = "wh_item_code";
            //cmbRecipeItem.SelectedValuePath = "Id";
            cmbRecipeItem.ItemsSource = _whcontext.ReadAllWHItems().ToList();
        }
    }
}
