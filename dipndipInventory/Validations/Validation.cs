using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

using Telerik.Windows.Controls;

namespace Foamco.Validations
{
   public class Validate
    {
        public static bool TxtMaskBlankCheck(RadMaskedTextInput tb, string mes)
        {
            if (tb.Value == null || tb.Value.Trim().Length < 1)
            {
                //MessageBox.Show("Please Enter " + mes, GlobalVariables.MESSAGE_TITLE, MessageBoxButton.OK, MessageBoxImage.Information);
                RadWindow.Alert("Please Enter " + mes);
                tb.Focus();
                return true;
            }
            else
            {
                return false;
            }

        }

        public static bool AutoCompleteBlankCheck(RadAutoCompleteBox acb, string mes)
        {
            if (acb.SearchText == null || acb.SearchText.Trim().Length < 1)
            {
                //MessageBox.Show("Please Enter " + mes, GlobalVariables.MESSAGE_TITLE, MessageBoxButton.OK, MessageBoxImage.Information);
                RadWindow.Alert("Please Enter " + mes);
                acb.Focus();
                return true;
            }
            else
            {
                return false;
            }

        }

        public static bool ComboMaskBlankCheck(RadComboBox cb, string mes)
        {
            if (cb.Text == null || cb.Text.Trim().Length < 1)
            {
                 // MessageBox.Show("Please Select " + mes, GlobalVariables.MESSAGE_TITLE, MessageBoxButton.OK, MessageBoxImage.Information);
              RadWindow.Alert("Please Enter " + mes);
                cb.Focus();
                return true; ;
            }
            else
            {
                return false;
            }
        }
        public static bool TxtMaskNumericBlankCheck(RadMaskedNumericInput tb, string mes)
        {
            if (tb.Value == null || tb.Text.Trim().Length < 1)
            {
              //  MessageBox.Show("Please Enter " + mes, GlobalVariables.MESSAGE_TITLE, MessageBoxButton.OK, MessageBoxImage.Information);
                RadWindow.Alert("Please Enter " + mes);
                tb.Focus();
                return true;
            }
            else
            {
                return false;
            }

        }
        public static bool RadComboBoxSelectedCheck(RadComboBox tb, string mes)
        {
            if (tb.SelectedIndex == -1)
            {
                // MessageBox.Show("Please Select" + mes, GlobalVariables.MESSAGE_TITLE, MessageBoxButton.OK, MessageBoxImage.Information);
               RadWindow.Alert("Please Select " + mes);
                tb.Focus();
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool txtPassWordBlankCheck(PasswordBox tb, string mes)
        {
            if (tb.Password == null || tb.Password.Trim().Length < 1)
            {
                //MessageBox.Show("Please Enter " + mes, GlobalVariables.MESSAGE_TITLE, MessageBoxButton.OK, MessageBoxImage.Information);
                RadWindow.Alert("Please Enter " + mes);
                tb.Focus();
                return true;
            }
            else
            {
                return false;
            }

        }


    }
}
