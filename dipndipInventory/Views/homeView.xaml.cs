using dipndipInventory.EF;
using dipndipInventory.Views.Site;
using dipndipInventory.Views.Stock;
using dipndipInventory.Views.Users;
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

namespace dipndipInventory.Views
{
    /// <summary>
    /// Interaction logic for homeView.xaml
    /// </summary>
    public partial class homeView : Window
    {
        public homeView()
        {
            InitializeComponent();
        }

        public homeView(ck_users objUser)
        {
            Telerik.Windows.Controls.StyleManager.ApplicationTheme = new Telerik.Windows.Controls.SummerTheme();
            InitializeComponent();
            StyleManager.SetTheme(radRibbonView1, new Telerik.Windows.Controls.Expression_DarkTheme());
            if (objUser.role != "Admin")
            {
                //StaffMenu.IsEnabled = false;
                //BackupDB.IsEnabled = false;
            }

            //lblUserName.Content = objStaff.User_name;
            //txtUserName.Text = objStaff.User_name;

            radRibbonView1.ApplicationName += " (Signed in as: " + objUser.username + ")";
        }
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            System.Environment.Exit(0);
            //Application.Current.Shutdown();
        }

        private void UsersMenu_Click(object sender, RoutedEventArgs e)
        {
            userView uv = new userView();
            uv.Show();
        }

        private void SitesMenu_Click(object sender, RoutedEventArgs e)
        {
            siteView sv = new siteView();
            sv.Show();
        }

        private void CategoryMenu_Click(object sender, RoutedEventArgs e)
        {
            itemcategoryView cv = new itemcategoryView();
            cv.Show();
        }

        private void UnitsMenu_Click(object sender, RoutedEventArgs e)
        {
            unitView uv = new unitView();
            uv.Show();
        }

        private void WHItemsMenu_Click(object sender, RoutedEventArgs e)
        {
            warehouseitemsView wv = new warehouseitemsView();
            wv.Show();
        }

        private void ItemUnitsMenu_Click(object sender, RoutedEventArgs e)
        {
            whitemunitsetupView usv = new whitemunitsetupView();
            usv.Show();
        }

        private void CKItemsMenu_Click(object sender, RoutedEventArgs e)
        {
            ckitemsView ckv = new ckitemsView();
            ckv.Show();
        }
    }
}
