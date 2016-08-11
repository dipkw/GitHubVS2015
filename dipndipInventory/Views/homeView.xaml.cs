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
    }
}
