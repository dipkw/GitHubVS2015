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

namespace dipndipInventory.Views.Users
{
    /// <summary>
    /// Interaction logic for formpermissionsView.xaml
    /// </summary>
    public partial class formpermissionsView : RadWindow
    {
        List<AppFormPermissionViewModel> g_app_form_permission_list = new List<AppFormPermissionViewModel>();
        public formpermissionsView()
        {
            InitializeComponent();
            ShowTaskBar.ShowInTaskbar(this, "Form Permissions");
            FillActiveRoles();
            UpdateFormPermissions();
        }

        private void UpdateFormPermissions()
        {
            try
            {
                AppFormService afscontext = new AppFormService();
                IEnumerable<app_forms> app_form_list = afscontext.GetAllAppForms();
                g_app_form_permission_list.Clear();
                int row_index = 0;
                foreach(app_forms app_form in app_form_list)
                {
                    AppFormPermissionViewModel app_form_permission = new AppFormPermissionViewModel();
                    app_form_permission.role_id = (int)cmbRole.SelectedValue;
                    app_form_permission.form_id = app_form.Id;
                    app_form_permission.form_desc = app_form.form_desc;
                    AppFormPermissionService afpcontext = new AppFormPermissionService();
                    app_form_permissions form_permission = afpcontext.GetAppFormPermission(app_form_permission.role_id, app_form.Id);
                    if(form_permission == null)
                    {
                        app_form_permission.create_permission = false;
                        app_form_permission.read_permission = false;
                        app_form_permission.update_permission = false;
                        app_form_permission.delete_permission = false;
                    }
                    else
                    {
                        app_form_permission.create_permission = (bool)form_permission.create_permission;
                        app_form_permission.read_permission = (bool)form_permission.read_permission;
                        app_form_permission.update_permission = (bool)form_permission.update_permission;
                        app_form_permission.delete_permission = (bool)form_permission.delete_permission;
                    }
                    app_form_permission.row_index = row_index++;
                    g_app_form_permission_list.Add(app_form_permission);
                }
                dgAppFormPermissions.ItemsSource = null;
                dgAppFormPermissions.ItemsSource = g_app_form_permission_list;
                dgAppFormPermissions.Rebind();
            }
            catch { }
        }

        public void FillActiveRoles()
        {
            try
            {
                UserRoleService urscontext = new UserRoleService();
                IEnumerable<user_roles> objUnits = urscontext.ReadAllActiveUserRoles();
                cmbRole.DisplayMemberPath = "role_desc";
                cmbRole.SelectedValuePath = "Id";
                cmbRole.ItemsSource = objUnits.ToList();
                cmbRole.SelectedIndex = 0;
            }
            catch { }
        }

        private void cmbRole_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateFormPermissions();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if(MessageBox.Show("Do you want to continue?", "Confirm",MessageBoxButton.YesNo) == MessageBoxResult.No)
            {
                return;
            }
            AppFormPermissionService afpcontext = new AppFormPermissionService();
            List<app_form_permissions> app_form_permission_list = new List<app_form_permissions>();
            foreach(AppFormPermissionViewModel  app_form_permission_vm in g_app_form_permission_list)
            {
                app_form_permissions app_form_permission = new app_form_permissions();
                app_form_permission.role_id = app_form_permission_vm.role_id;
                app_form_permission.form_id = app_form_permission_vm.form_id;
                app_form_permission.form_desc = app_form_permission_vm.form_desc;
                app_form_permission.create_permission = app_form_permission_vm.create_permission;
                app_form_permission.read_permission = app_form_permission_vm.read_permission;
                app_form_permission.update_permission = app_form_permission_vm.update_permission;
                app_form_permission.delete_permission = app_form_permission_vm.delete_permission;
                app_form_permission.created_by = GlobalVariables.ActiveUser.Id;
                app_form_permission.created_date = DateTime.Now;
                app_form_permission_list.Add(app_form_permission);
            }
            int result = afpcontext.UpdateAppFormPermision(app_form_permission_list);
            if(result > 0)
            {
                MessageBox.Show("Updated Successfully");
            }
            else
            {
                MessageBox.Show("Updation Failed");
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
