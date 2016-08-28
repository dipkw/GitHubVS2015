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
    /// Interaction logic for unitView.xaml
    /// </summary>
    public partial class unitView : RadWindow
    {
        UnitService _context = new UnitService();
        bool edit_mode = false;
        //string username = string.Empty;
        int id = 0;
        public unitView()
        {
            InitializeComponent();
            ReadAllUnits();
        }

        private void ReadAllUnits()
        {
            IEnumerable<ck_units> objUnits = _context.ReadAllUnits();
            dgUnits.ItemsSource = objUnits;
            txtDescription.Focus();
        }

        private void SelectUnit()
        {
            try
            {
                if (dgUnits.SelectedItem == null)
                {
                    return;
                }

                ck_units objUnit = (dgUnits.SelectedItem) as ck_units;

                id = objUnit.Id;
                //user_Id = objUser.user_id;

                //username = objUser.username;

                //txtUnitID.Value = objUnit.unit_description;
                //txtUnitID.IsReadOnly = true;

                txtDescription.Value = objUnit.unit_description;
                txtDescription.IsReadOnly = true;

                btnSave.IsEnabled = false;
            }
            catch { }
        }

        private void dgUnits_SelectionChanged(object sender, SelectionChangeEventArgs e)
        {
            SelectUnit();
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

            if (dgUnits.SelectedItem == null)
            {
                return;
            }

            txtDescription.IsReadOnly = false;
            //txtUsername.IsReadOnly = false;
            edit_mode = true;
            btnSave.IsEnabled = true;
            txtDescription.Focus();
        }

        private void ClearFields()
        {
            txtUnitID.IsReadOnly = false;
            txtUnitID.Value = string.Empty;

            txtDescription.IsReadOnly = false;

            txtDescription.Value = string.Empty;

            id = 0;
            //username = string.Empty;
            edit_mode = false;

            ReadAllUnits();
        }

        private void btnNew_Click(object sender, RoutedEventArgs e)
        {
            ClearFields();
            btnSave.IsEnabled = true;
        }

        private bool validateUser()
        {
            //if (Validate.TxtMaskBlankCheck(txtUnitID, "Unit ID"))
            //{
            //    return false;
            //}

            if (Validate.TxtMaskBlankCheck(txtDescription, "Description"))
            {
                return false;
            }

            return true;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (validateUser())
            {
                RadWindow.Confirm("Do you want to Continue?", this.onSave);
            }
        }

        private void onSave(object sender, WindowClosedEventArgs e)
        {
            if (e.DialogResult == true)
            {
                saveUnit();
            }
        }

        private void saveUnit()
        {
            ck_units objUnit = new ck_units();
            objUnit.unit_description = txtDescription.Value;
            //objUnit.category_name = txtCategoryName.Value;


            string _dbresponse = string.Empty;

            try
            {
                if (edit_mode)
                {
                    objUnit.Id = id;
                    // objUser.username = username;
                    objUnit.modified_by = GlobalVariables.ActiveUser.Id;
                    objUnit.modified_date = DateTime.Now;
                    _dbresponse = _context.UpdateUnit(objUnit) > 0 ? "Unit Details Updated Successfully" : "Unable to Update Unit Details";
                }
                else
                {
                    objUnit.created_by = GlobalVariables.ActiveUser.Id;
                    objUnit.created_date = DateTime.Now;
                    objUnit.active = true;
                    if (_context.IsExistingUnit(objUnit.Id))
                    {
                        RadWindow.Alert("Existing Category");
                        txtDescription.SelectionStart = txtDescription.Value.Length;
                        txtDescription.Focus();
                        return;
                    }
                    _dbresponse = _context.CreateUnit(objUnit) > 0 ? "Unit Details Created Successfully" : "Unable to Save Unit Details";
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

            if (dgUnits.SelectedItem != null)
            {
                RadWindow.Confirm("Do you want to Continue?", this.onDeleteUnit);
            }
        }

        private void onDeleteUnit(object sender, WindowClosedEventArgs e)
        {
            if (e.DialogResult == true)
            {
                deleteUnit();
                ClearFields();
                ReadAllUnits();
            }
        }

        private void deleteUnit()
        {
            try
            {
                ck_units objUnit = new ck_units();
                objUnit.Id = id;

                string _dbresponse = _context.DeleteUnit(objUnit) > 0 ? "Unit Details deleted successfully" : "Unable to delete Unit Details";

                RadWindow.Alert(_dbresponse);
            }
            catch { }
        }
    }
}
