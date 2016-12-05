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
    /// Interaction logic for ckitemsView.xaml
    /// </summary>
    public partial class ckitemsView : RadWindow
    {
        CKItemService _context = new CKItemService();
        UnitService _ucontext = new UnitService();
        bool edit_mode = false;
        //string username = string.Empty;
        int id = 0;
        public ckitemsView()
        {
            InitializeComponent();
            ShowTaskBar.ShowInTaskbar(this, "Central Kitchen Items");
            CheckUserPermissions();
            ReadAllCKItems();
            FillUnits();
        }

        private void CheckUserPermissions()
        {
            AppFormPermissionService afpcontext = new AppFormPermissionService();
            btnNew.IsEnabled = afpcontext.GetAppRoleFormPermission(GlobalVariables.ActiveUser.role_id, "CK Items", "Create");
            btnSave.IsEnabled = afpcontext.GetAppRoleFormPermission(GlobalVariables.ActiveUser.role_id, "CK Items", "Create");
            btnDelete.IsEnabled = afpcontext.GetAppRoleFormPermission(GlobalVariables.ActiveUser.role_id, "CK Items", "Delete");
        }

        private void ReadAllCKItems()
        {
            IEnumerable<ck_items> objCKItems = _context.ReadAllCKItems();
            dgCKItems.ItemsSource = objCKItems;
            txtItemCode.Value = _context.GetNewItemCode();
            ck_item_barcode.Text = txtItemCode.Value;
            txtItemCode.IsEnabled = false;
            txtItemCode.IsReadOnly = true;
            txtDescription.Focus();
        }

        public void FillUnits()
        {
            IEnumerable<ck_units> objUnits = _ucontext.ReadAllUnits();
            cmbUnit.DisplayMemberPath = "unit_description";
            cmbUnit.SelectedValuePath = "Id";
            cmbUnit.ItemsSource = objUnits.ToList();
        }
        private void SelectCKItem()
        {
            try
            {
                if (dgCKItems.SelectedItem == null)
                {
                    return;
                }

                ck_items objCKItem = (dgCKItems.SelectedItem) as ck_items;

                id = objCKItem.Id;
                //user_Id = objUser.user_id;

                //username = objUser.username;

                //txtUnitID.Value = objUnit.unit_description;
                //txtUnitID.IsReadOnly = true;
                txtItemCode.Value = objCKItem.ck_item_code;
                ck_item_barcode.Text = txtItemCode.Value;
                txtItemCode.IsEnabled = false;
                txtItemCode.IsReadOnly = true;

                txtDescription.Value = objCKItem.ck_item_description;
                txtDescription.IsReadOnly = true;

                cmbUnit.SelectedValue = objCKItem.ck_unit_id;
                cmbUnit.IsReadOnly = true;
                cmbUnit.IsHitTestVisible = false;

                txtDesignQty.Value = (double)objCKItem.ck_design_qty;
                txtDesignQty.IsReadOnly = true;

                btnSave.IsEnabled = false;
            }
            catch { }
        }

        private void dgCKItems_SelectionChanged(object sender, SelectionChangeEventArgs e)
        {
            SelectCKItem();
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
            AppFormPermissionService afpcontext = new AppFormPermissionService();
            if(afpcontext.GetAppRoleFormPermission(GlobalVariables.ActiveUser.role_id, "CK Items", "Update") == false)
            {
                MessageBox.Show("Access Denied");
                return;
            }

            if (dgCKItems.SelectedItem == null)
            {
                return;
            }

            txtDescription.IsReadOnly = false;
            cmbUnit.IsReadOnly = false;
            cmbUnit.IsHitTestVisible = true;
            txtDesignQty.IsReadOnly = false;
            //txtUsername.IsReadOnly = false;
            edit_mode = true;
            btnSave.IsEnabled = true;
            txtDescription.Focus();
        }

        private void ClearFields()
        {
            txtUnitID.IsReadOnly = false;
            txtUnitID.Value = string.Empty;

            txtItemCode.IsReadOnly = true;
            //txtItemCode.Value = string.Empty;
            txtItemCode.Value = _context.GetNewItemCode();

            txtDescription.IsReadOnly = false;
            txtDescription.Value = string.Empty;

            cmbUnit.SelectedIndex = -1;
            cmbUnit.IsReadOnly = false;
            cmbUnit.IsHitTestVisible = true;

            txtDesignQty.Value = 0;
            txtDesignQty.IsReadOnly = false;

            id = 0;
            //username = string.Empty;
            edit_mode = false;

            ReadAllCKItems();
        }

        private void btnNew_Click(object sender, RoutedEventArgs e)
        {
            ClearFields();
            btnSave.IsEnabled = true;
        }

        private bool validateCKItem()
        {
            //if (Validate.TxtMaskBlankCheck(txtUnitID, "Unit ID"))
            //{
            //    return false;
            //}

            //if (Validate.TxtMaskBlankCheck(txtItemCode, "Item Code"))
            //{
            //    return false;
            //}

            if (Validate.TxtMaskBlankCheck(txtDescription, "Description"))
            {
                return false;
            }

            if (Validate.ComboMaskBlankCheck(cmbUnit, "Unit"))
            {
                return false;
            }

            if (Validate.TxtMaskNumericBlankCheck(txtDesignQty, "Design Quantity"))
            {
                return false;
            }

            return true;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (validateCKItem())
            {
                RadWindow.Confirm("Do you want to Continue?", this.onSave);
            }
        }

        private void onSave(object sender, WindowClosedEventArgs e)
        {
            if (e.DialogResult == true)
            {
                saveCKItem();
            }
        }

        private void saveCKItem()
        {
            ck_items objCKItem = new ck_items();
            objCKItem.ck_item_description = txtDescription.Value;
            objCKItem.ck_unit_id = (int)cmbUnit.SelectedValue;
            objCKItem.ck_design_qty = (decimal)txtDesignQty.Value;
            //objUnit.category_name = txtCategoryName.Value;


            string _dbresponse = string.Empty;

            try
            {
                if (edit_mode)
                {
                    objCKItem.Id = id;
                    // objUser.username = username;
                    objCKItem.modified_by = GlobalVariables.ActiveUser.Id;
                    objCKItem.modified_date = DateTime.Now;
                    _dbresponse = _context.UpdateCKItem(objCKItem) > 0 ? "Item Updated Successfully" : "Unable to Update Central Kitchen Item";
                }
                else
                {
                    objCKItem.ck_item_code = _context.GetNewItemCode();
                    objCKItem.created_by = GlobalVariables.ActiveUser.Id;
                    objCKItem.created_date = DateTime.Now;
                    objCKItem.active = true;
                    if (_context.IsExistingCKItem(objCKItem.Id))
                    {
                        RadWindow.Alert("Existing Item");
                        txtDescription.SelectionStart = txtDescription.Value.Length;
                        txtDescription.Focus();
                        return;
                    }
                    _dbresponse = _context.CreateCKItems(objCKItem) > 0 ? "Item Created Successfully" : "Unable to Save Item";
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

            if (dgCKItems.SelectedItem != null)
            {
                RadWindow.Confirm("Do you want to Continue?", this.onDeleteCKItem);
            }
        }

        private void onDeleteCKItem(object sender, WindowClosedEventArgs e)
        {
            if (e.DialogResult == true)
            {
                deleteCKItem();
                ClearFields();
                ReadAllCKItems();
            }
        }

        private void deleteCKItem()
        {
            try
            {
                ck_items objCKItem = new ck_items();
                objCKItem.Id = id;

                string _dbresponse = _context.DeleteUnit(objCKItem) > 0 ? "Item deleted successfully" : "Unable to delete Item";

                RadWindow.Alert(_dbresponse);
            }
            catch { }
        }
    }
}
