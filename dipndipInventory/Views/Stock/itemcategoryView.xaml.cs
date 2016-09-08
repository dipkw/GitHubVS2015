using dipndipInventory.EF;
using dipndipInventory.EF.DataServices;
using dipndipInventory.Helpers;
using dipndipInventory.Validations;
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
    /// Interaction logic for itemcategoryView.xaml
    /// </summary>
    public partial class itemcategoryView : RadWindow
    {
        CategoryService _context = new CategoryService();
        bool edit_mode = false;
        //string username = string.Empty;
        int id = 0;
        public itemcategoryView()
        {
            InitializeComponent();
            ShowTaskBar.ShowInTaskbar(this, "Item Category");
            ReadAllCategories();
        }

        private void ReadAllCategories()
        {
            IEnumerable<ckwh_category> objCategories = _context.ReadAllCategories();
            dgCategories.ItemsSource = objCategories;
            txtCategoryName.Focus();
        }

        private void SelectCategory()
        {
            try
            {
                if (dgCategories.SelectedItem == null)
                {
                    return;
                }

                ckwh_category objCategory = (dgCategories.SelectedItem) as ckwh_category;

                id = objCategory.Id;
                //user_Id = objUser.user_id;

                //username = objUser.username;

                txtCategoryCode.Value = objCategory.category_code;
                txtCategoryCode.IsReadOnly = true;

                txtCategoryName.Value = objCategory.category_name;
                txtCategoryName.IsReadOnly = true;

                btnSave.IsEnabled = false;
            }
            catch { }
        }

        private void dgCategories_SelectionChanged(object sender, SelectionChangeEventArgs e)
        {
            SelectCategory();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            //if (GlobalVariables.ActiveUser.Role != "Admin")
            //{
            //    RadWindow.Alert("Access denied, Please contact Administrator");
            //    return;
            //}

            if (dgCategories.SelectedItem == null)
            {
                return;
            }

            txtCategoryName.IsReadOnly = false;
            //txtUsername.IsReadOnly = false;
            edit_mode = true;
            btnSave.IsEnabled = true;
            txtCategoryName.Focus();
        }

        private void ClearFields()
        {
            txtCategoryCode.IsReadOnly = false;
            txtCategoryCode.Value = string.Empty;

            txtCategoryName.IsReadOnly = false;

            txtCategoryName.Value = string.Empty;

            id = 0;
            //username = string.Empty;
            edit_mode = false;

            ReadAllCategories();
        }

        private void btnNew_Click(object sender, RoutedEventArgs e)
        {
            ClearFields();
            btnSave.IsEnabled = true;
        }

        private bool validateUser()
        {
            if (Validate.TxtMaskBlankCheck(txtCategoryCode, "Category Code"))
            {
                return false;
            }

            if (Validate.TxtMaskBlankCheck(txtCategoryName, "Category Name"))
            {
                return false;
            }

            return true;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (validateUser())
            {
                RadWindow.Confirm("Do you want to Continue ?", this.onSave);
            }
        }
        private void onSave(object sender, WindowClosedEventArgs e)
        {
            if (e.DialogResult == true)
            {
                saveCategory();
            }
        }

        private void saveCategory()
        {
            ckwh_category objCategory = new ckwh_category();
            objCategory.category_code = txtCategoryCode.Value;
            objCategory.category_name = txtCategoryName.Value;


            string _dbresponse = string.Empty;

            try
            {
                if (edit_mode)
                {
                    objCategory.Id = id;
                    // objUser.username = username;
                    objCategory.modified_by = GlobalVariables.ActiveUser.Id;
                    objCategory.modified_date = DateTime.Now;
                    _dbresponse = _context.UpdateCategory(objCategory) > 0 ? "Category Details Updated Successfully" : "Unable to Update Category Details";
                }
                else
                {
                    objCategory.created_by = GlobalVariables.ActiveUser.Id;
                    objCategory.created_date = DateTime.Now;
                    objCategory.active = true;
                    if (_context.IsExistingCategory(objCategory.Id))
                    {
                        RadWindow.Alert("Existing Category");
                        txtCategoryName.SelectionStart = txtCategoryName.Value.Length;
                        txtCategoryName.Focus();
                        return;
                    }
                    _dbresponse = _context.CreateCategory(objCategory) > 0 ? "Category Details Created Successfully" : "Unable to Save Category Details";
                }

                RadWindow.Alert(_dbresponse);
                ClearFields();
            }
            catch { }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            //if (GlobalVariables.ActiveUser.Role != "Admin")
            //{
            //    RadWindow.Alert("Access denied, Please contact Administrator");
            //    return;
            //}

            if (dgCategories.SelectedItem != null)
            {
                RadWindow.Confirm("Do you want to Continue?", this.onDeleteCategory);
            }
        }

        private void onDeleteCategory(object sender, WindowClosedEventArgs e)
        {
            if (e.DialogResult == true)
            {
                deleteCategory();
                ClearFields();
                ReadAllCategories();
            }
        }

        private void deleteCategory()
        {
            try
            {
                ckwh_category objCategory = new ckwh_category();
                objCategory.Id = id;

                string _dbresponse = _context.DeleteCategory(objCategory) > 0 ? "Category Details deleted successfully" : "Unable to delete Category Details";

                RadWindow.Alert(_dbresponse);
            }
            catch { }
        }
    }
}
