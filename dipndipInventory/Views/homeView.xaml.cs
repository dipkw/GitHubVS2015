using dipndipInventory.EF;
using dipndipInventory.EF.DataServices;
using dipndipInventory.Helpers;
using dipndipInventory.Views.Reports;
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
            AppFormPermissionService afpcontext = new AppFormPermissionService();
            CKOrders.IsEnabled = afpcontext.GetAppRoleFormPermission(objUser.role_id, "CK Order", "Read");
            NewOrder.IsEnabled = afpcontext.GetAppRoleFormPermission(objUser.role_id, "WH Order Details", "Read");
            Adjustment.IsEnabled = afpcontext.GetAppRoleFormPermission(objUser.role_id, "WH Stock Adjustment", "Read");
            WHItemsMenu.IsEnabled = afpcontext.GetAppRoleFormPermission(objUser.role_id, "WH Items", "Read");
            ItemUnitsMenu.IsEnabled = afpcontext.GetAppRoleFormPermission(objUser.role_id, "WH Item Unit Setup", "Read");
            CKItemsMenu.IsEnabled = afpcontext.GetAppRoleFormPermission(objUser.role_id, "CK Items", "Read");
            CKItemsRecipeMenu.IsEnabled = afpcontext.GetAppRoleFormPermission(objUser.role_id, "CK Item Recipe", "Read");
            CKItemUnitsMenu.IsEnabled = afpcontext.GetAppRoleFormPermission(objUser.role_id, "CK Item Unit Setup", "Read");
            CKProductionMenu.IsEnabled = afpcontext.GetAppRoleFormPermission(objUser.role_id, "CK Production", "Read");
            CKIssueMenu.IsEnabled = afpcontext.GetAppRoleFormPermission(objUser.role_id, "CK Item Delivery", "Read");
            UnitsMenu.IsEnabled = afpcontext.GetAppRoleFormPermission(objUser.role_id, "Units", "Read");
            UsersMenu.IsEnabled = afpcontext.GetAppRoleFormPermission(objUser.role_id, "Users", "Read");
            SitesMenu.IsEnabled = afpcontext.GetAppRoleFormPermission(objUser.role_id, "Sites", "Read");
            FormPermissionsMenu.IsEnabled = afpcontext.GetAppRoleFormPermission(objUser.role_id, "Form Permissions", "Read");

            //if (objUser.role_id == 2)
            //{
            //    Adjustment.IsEnabled = afpcontext.GetAppRoleFormPermission(objUser.role_id, "Stock Adjustment", "Read");
            //    WHItemsMenu.IsEnabled = false;
            //    ItemUnitsMenu.IsEnabled = false;
            //    UnitsMenu.IsEnabled = false;
            //    UsersMenu.IsEnabled = false;
            //    SitesMenu.IsEnabled = false;
            //    FormPermissionsMenu.IsEnabled = false;
            //}

            //if (objUser.role_id == 3)
            //{
            //    NewOrder.IsEnabled = false;
            //    Adjustment.IsEnabled = false;
            //    WHItemsMenu.IsEnabled = false;
            //    ItemUnitsMenu.IsEnabled = false;
            //    CKItemsMenu.IsEnabled = false;
            //    CKIssueMenu.IsEnabled = false;
            //    CKItemsRecipeMenu.IsEnabled = false;
            //    CKItemUnitsMenu.IsEnabled = false;
            //    CKProductionMenu.IsEnabled = false;
            //    CKIssueMenu.IsEnabled = false;
            //    UnitsMenu.IsEnabled = false;
            //    UsersMenu.IsEnabled = false;
            //    SitesMenu.IsEnabled = false;
            //    FormPermissionsMenu.IsEnabled = false;
            //}

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
            AppFormService afscontext = new AppFormService();
            if (afscontext.GetAppFormLockStatus("orderdetailsView") == "locked")
            {
                MessageBox.Show("Window is locked");
                return;
            }

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
            ckitemwastageView cwv = new ckitemwastageView();
            cwv.Show();
        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selected_theme = ((ComboBoxItem)comboBox.SelectedItem).Content.ToString();
            switch (selected_theme)
            {
                case "Windows 8":
                    StyleManager.ApplicationTheme = new Windows8Theme();
                    break;
                case "Windows 7":
                    StyleManager.ApplicationTheme = new Windows7Theme();
                    break;
                case "Office Black":
                    StyleManager.ApplicationTheme = new Office_BlackTheme();
                    break;
                case "Office Blue":
                    StyleManager.ApplicationTheme = new Office_BlueTheme();
                    break;
                case "Office Silver":
                    StyleManager.ApplicationTheme = new Office_SilverTheme();
                    break;
                default:
                    break;
            }
        }

        private void FormPermissionsMenu_Click(object sender, RoutedEventArgs e)
        {
            formpermissionsView fpv = new formpermissionsView();
            fpv.Show();
        }

        private void CKProductions_Click(object sender, RoutedEventArgs e)
        {
            CKProductions cpv = new Stock.CKProductions();
            cpv.Show();
        }

        private void CKBranchDelivery_Click(object sender, RoutedEventArgs e)
        {
            ckbranchdeliverylistView bdv = new ckbranchdeliverylistView();
            bdv.Show();
        }

        private void WHStockAdjustment_Click(object sender, RoutedEventArgs e)
        {
            WHStockAdjReportView sav = new WHStockAdjReportView();
            sav.Show();
        }

        private void WHStockQuantity_Click(object sender, RoutedEventArgs e)
        {
            WHStockQuantityReportView wsv = new WHStockQuantityReportView();
            wsv.Show();
        }

        private void CKWastageReport_Click(object sender, RoutedEventArgs e)
        {
            CKWastageReportView wrv = new CKWastageReportView();
            wrv.Show();
        }
    }
}
