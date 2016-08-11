using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Telerik.Windows.Controls;

namespace dipndipInventory.Helpers
{
    public class ShowTaskBar
    {
        public static void ShowInTaskbar(RadWindow control, string title)
        {
            try
            {
                control.Show();
                var window = control.ParentOfType<Window>();
                window.ShowInTaskbar = true;
                window.Title = title;
            }
            catch { }
        }
    }
}
