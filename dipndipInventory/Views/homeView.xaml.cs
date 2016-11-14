﻿using dipndipInventory.EF;
using dipndipInventory.Helpers;
using dipndipInventory.Views.Site;
using dipndipInventory.Views.Stock;
using dipndipInventory.Views.Users;
using Microsoft.SqlServer.Dts.Runtime;
using Microsoft.SqlServer.Management.IntegrationServices;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.IO.Packaging;
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

        public homeView(ck_users objUser, site objSite)
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

            radRibbonView1.ApplicationName += " Signed in as: " + objUser.username + " / Active Branch: " + objSite.site_name;
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

        private void CKItemsRecipeMenu_Click(object sender, RoutedEventArgs e)
        {
            ckitemrecipeView irv = new ckitemrecipeView();
            irv.Show();
        }

        private void UpdateWHCost_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection ssisConnection = new SqlConnection(@"Data Source=192.168.0.187\MSSQLSERVER14;Initial Catalog=dipck;Integrated Security=SSPI;");
            IntegrationServices ssisServer = new IntegrationServices(ssisConnection);
            var projectBytes = ssisServer.Catalogs["SSISDB"]
                             .Folders["wh_item_updation"]
                             .Projects["wh_item_updation"].GetProjectBytes();

            // note that projectBytes is basically __URFILE__.ispac      
            using (var existingProject = Project.OpenProject(new MemoryStream(projectBytes)))
            {
                //existingProject.PackageItems["master.dtsx"].Package.Execute(.... todo....)
                DTSExecResult exec_result = existingProject.PackageItems["Package.dtsx"].Package.Execute();
                if (exec_result == DTSExecResult.Success)
                {
                    MessageBox.Show("Items Updated Successfully");
                }
                else
                {
                    MessageBox.Show("Updation Failed");
                }
            }
        }

        private void UpdateWHCost_Click1(object sender, RoutedEventArgs e)
        {
            //string pkgLocation = @"D:\Prj\SSIS\ImportCostChangeHistory\ImportCostChangeHistory\ImportCostChange.dtsx";
            //string pkgLocation = @"D:\Prj\test\ssisexec\ImportCostChange.dtsx";
            string pkgLocation = @"Package.dtsx";

            Microsoft.SqlServer.Dts.Runtime.Package pkg;
            Microsoft.SqlServer.Dts.Runtime.Application app;
            DTSExecResult pkgResults;
            Variables vars;

            app = new Microsoft.SqlServer.Dts.Runtime.Application();
            pkg = app.LoadPackage(pkgLocation, null);

            //vars = pkg.Variables;
            //vars["A_Variable"].Value = "Some value";

            //pkgResults = pkg.Execute(null, vars, null, null, null);
            pkgResults = pkg.Execute();

            if (pkgResults == DTSExecResult.Success)
                //Console.WriteLine("Package ran successfully");
                MessageBox.Show("Cost Change History Updated Successfully");
            else
                //Console.WriteLine("Package failed");
                MessageBox.Show("Cost Change History Updation Failed");
        }

        private void Order_Click(object sender, RoutedEventArgs e)
        {
            orderdetailsView odv = new orderdetailsView();
            odv.Show();
        }

        private void CKOrders_Click(object sender, RoutedEventArgs e)
        {
            ckorderView cko = new ckorderView();
            cko.Show();
        }

        private void Adjustment_Click(object sender, RoutedEventArgs e)
        {
            ckwhstockadjView sta = new ckwhstockadjView();
            sta.Show();
        }

        private void CKItemUnitsMenu_Click(object sender, RoutedEventArgs e)
        {
            ckitemunitsetupView csv = new ckitemunitsetupView();
            csv.Show();
        }

        private void CKProductionMenu_Click(object sender, RoutedEventArgs e)
        {
            ckproductionView cpv = new ckproductionView();
            cpv.Show();
        }

        private void CKIssueMenu_Click(object sender, RoutedEventArgs e)
        {
            ckitemissueView civ = new ckitemissueView();
            civ.Show();
        }

        private void CKAdjustment_Click(object sender, RoutedEventArgs e)
        {
            ckstockadjView csv = new ckstockadjView();
            csv.Show();
        }

        private void Wastage_Click(object sender, RoutedEventArgs e)
        {
            ckwastageView cwv = new ckwastageView();
            cwv.Show();
        }
    }
}
