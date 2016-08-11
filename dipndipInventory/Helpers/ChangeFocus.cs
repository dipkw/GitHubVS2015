using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace dipndipInventory.Helpers
{
   public class ChangeFocus
    {
       public static void OnEnter(object sender, KeyEventArgs e)
       {
           if (e.Key == Key.Enter)
           {
               TraversalRequest tRequest = new TraversalRequest(FocusNavigationDirection.Next);
               UIElement keyboardFocus = Keyboard.FocusedElement as UIElement;

               if (keyboardFocus != null)
               {
                   keyboardFocus.MoveFocus(tRequest);
               }

               e.Handled = true;
           }
       }
    }
}
