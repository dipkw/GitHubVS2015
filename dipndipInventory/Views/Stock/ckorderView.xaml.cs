using dipndipInventory.EF;
using dipndipInventory.EF.DataServices;
using dipndipInventory.Helpers;
using dipndipInventory.Views.Reports;
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
    /// Interaction logic for ckorderView.xaml
    /// </summary>
    public partial class ckorderView : RadWindow
    {
        CKOrderService _context = new CKOrderService();
        bool edit_mode = false;
        //string username = string.Empty;
        int id = 0;
        //IEnumerable<order> objOrders;
        public ckorderView()
        {
            InitializeComponent();
            ShowTaskBar.ShowInTaskbar(this, "Central Kitchen Orders");
            ReadAllCKOrders();
        }

        private void ReadAllCKOrders()
        {
            try
            {
                //IEnumerable<order> objOrders = _context.ReadAllActiveCKOrders();
                IEnumerable<order> objOrders = _context.ReadAllActiveSiteOrders(GlobalVariables.ActiveSite.Id);
                //objOrders = _context.ReadAllActiveSiteOrders(GlobalVariables.ActiveSite.Id);
                dgCKOrders.ItemsSource = objOrders;
            }
            catch { }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (dgCKOrders.SelectedItem == null)
            {
                RadWindow.Alert("Please select an order to edit");
                return;
            }

            order objOrder = (dgCKOrders.SelectedItem) as order;
            if ((GlobalVariables.ActiveSite.Id == objOrder.order_from_site_id) && objOrder.order_status == "Pending")
            {
                //Open Edit Window For From_Site (CK) to update the order
                //orderdetailsView odv = new orderdetailsView(objOrder.Id, objOrder.order_no, (DateTime)objOrder.order_date);
                orderdetailsView odv = new orderdetailsView(objOrder.Id, objOrder.order_no, (DateTime)objOrder.order_date, this);
                odv.Show();
            }
            else if ((GlobalVariables.ActiveSite.Id == objOrder.order_from_site_id) && objOrder.order_status == "Issued")
            {
                //Open Receive Window For From_Site (CK) to receive the items
                if (objOrder.issue_date == null)
                {
                    objOrder.issue_date = DateTime.Now;
                }
                whitemreceiveView irv = new whitemreceiveView(objOrder.Id, objOrder.order_no, (DateTime)objOrder.order_date, (DateTime)objOrder.issue_date, this);
                irv.Show();

            }
            //else if ((GlobalVariables.ActiveSite.Id == objOrder.order_to_site_id) && (objOrder.order_status != "Received" || objOrder.order_status != "Confirmed"))
            else if ((GlobalVariables.ActiveSite.Id == objOrder.order_to_site_id) && (objOrder.order_status != "Received" && objOrder.order_status != "Confirmed"))
            {
                //Open Order Issue Window For To_Site(Warehouse) to issue the items
                whitemissueView itmissueView = new whitemissueView(objOrder.Id, objOrder.order_no, (DateTime)objOrder.order_date, this);
                itmissueView.Show();
                return;
            }
            else if ((GlobalVariables.ActiveSite.Id == objOrder.order_to_site_id) && objOrder.order_status == "Received")
            {
                //Open Receipt Confirmation Window For To_Site(Warehouse) to confirm the receipt
                //MessageBox.Show(objOrder.order_no);
                //WRcptConf wcv = new WRcptConf(objOrder.order_no);
                ReceiptConfirmationReportView wcv = new ReceiptConfirmationReportView(objOrder.order_no, this);
                wcv.Show();
                //return;
            }
        }

        private void btnView_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
