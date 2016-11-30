using dipndipInventory.EF;
using dipndipInventory.EF.DataServices;
using dipndipInventory.Helpers;
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
    /// Interaction logic for CKProductions.xaml
    /// </summary>
    public partial class CKProductions : RadWindow
    {
        public CKProductions()
        {
            InitializeComponent();
            ShowTaskBar.ShowInTaskbar(this, "Production List");
            FillCKProductions();
        }

        private void FillCKProductions()
        {
            try
            {
                CKProductionService cpscontext = new CKProductionService();
                IEnumerable<ck_prod> ck_production_list = cpscontext.ReadAllProductions();

                var distinct_prod_codes = from ckproductionsc in ck_production_list
                                          group ckproductionsc by ckproductionsc.prod_code into unique_prod_codes
                                          select unique_prod_codes.FirstOrDefault();

                //dgCKProductions.ItemsSource = ck_production_list;
                dgCKProductions.ItemsSource = distinct_prod_codes.ToList();
            }
            catch { }
        }

        private void btnView_Click(object sender, RoutedEventArgs e)
        {
            if (dgCKProductions.SelectedItem == null)
            {
                RadWindow.Alert("Please select a Production to view");
                return;
            }
            try
            {
                ck_prod selected_production = dgCKProductions.SelectedItem as ck_prod;
                productiondetailView pdv = new productiondetailView(selected_production.prod_code);
                pdv.Show();
            }
            catch { }

        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
