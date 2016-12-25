using dipndipInventory.EF;
using dipndipInventory.EF.DataServices;
using dipndipInventory.Helpers;
using dipndipInventory.ViewModels;
using Microsoft.SqlServer.Dts.Runtime;
using Microsoft.SqlServer.Management.IntegrationServices;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
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
using Telerik.Reporting.Processing;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.GridView;


namespace dipndipInventory.Views.Stock
{
    /// <summary>
    /// Interaction logic for whitemreceiveView.xaml
    /// </summary>
    public partial class whitemreceiveView : RadWindow
    {
        long active_order_id;
        string active_receipt_no;

        long g_order_detail_id = 0;
        decimal g_qty_received = 0.000m;

        receipt g_receipt_master = new receipt();
        List<receipt_details> g_receipt_detail_list = new List<receipt_details>();
        List<transaction_details> g_transaction_detail_list = new List<transaction_details>();
        List<ckwh_items> g_ckwh_items_list = new List<ckwh_items>();
        List<wh_item_cost_history> g_wh_item_cost_history_list = new List<wh_item_cost_history>();
        order g_order_master = new order();
        List<order_details> g_order_detail_list = new List<order_details>();
        ckorderView g_ck_order_view;

        public whitemreceiveView()
        {
            InitializeComponent();
        }


        public int UpdateWarehouseItems()
        {
            CKWHItemUpdateService ucontext = new CKWHItemUpdateService();
            int result = 0;
            result = ucontext.CKWHItemUpdate(GlobalVariables.ActiveUser.Id);
            return result;
        }
        //public int UpdateWarehouseItems()
        //{
        //    SqlConnection ssisConnection = new SqlConnection(@"Data Source=192.168.0.187\MSSQLSERVER14;Initial Catalog=dipck;Integrated Security=SSPI;");
        //    //string constr = @"Data Source=192.168.0.187\MSSQLSERVER14;Initial Catalog=dipck;User id=sa;Password=Dip@123.;";
        //    //SqlConnection ssisConnection = new SqlConnection(constr);
        //    IntegrationServices ssisServer = new IntegrationServices(ssisConnection);
        //    var projectBytes = ssisServer.Catalogs["SSISDB"]
        //                     .Folders["wh_item_updation"]
        //                     .Projects["wh_item_updation"].GetProjectBytes();

        //    // note that projectBytes is basically __URFILE__.ispac      
        //    using (var existingProject = Project.OpenProject(new MemoryStream(projectBytes)))
        //    {
        //        //existingProject.PackageItems["master.dtsx"].Package.Execute(.... todo....)
        //        DTSExecResult exec_result = existingProject.PackageItems["Package.dtsx"].Package.Execute();
        //        if (exec_result == DTSExecResult.Success)
        //        {
        //            //MessageBox.Show("Items Updated Successfully");
        //            return 1;
        //        }
        //        else
        //        {
        //            MessageBox.Show("Updation Failed");
        //            return 0;
        //        }
        //    }
        //}

        public whitemreceiveView(long order_id, string order_no, DateTime order_date, DateTime issue_date, ckorderView ck_order_view) 
        {
            InitializeComponent();
            g_ck_order_view = ck_order_view;
            if(UpdateWarehouseItems() == 0)
            {
                return;
            }
            ShowTaskBar.ShowInTaskbar(this, "Item Receiving Details");

            CKReceiptService _rcontext = new CKReceiptService();
            active_receipt_no = _rcontext.GetNewCKReceiptNo();

            dtpIssueDate.SelectedDate = issue_date.Date;
            dtpIssueDate.SelectedTime = issue_date.TimeOfDay;
            dtpReceiptDate.SelectedDate = DateTime.Now.Date;
            dtpReceiptDate.SelectedTime = DateTime.Now.TimeOfDay;
            active_order_id = order_id;
            txtOrderNo.Value = order_no.ToString();
            dtpDate.SelectedDate = order_date;
            CKOrderService _ocontext = new CKOrderService();
            IEnumerable<order_details> selected_order = _ocontext.ReadCKOrderDetailsByMasterId(order_id);
            List<OrderDetailsViewModel> order_detail_list = new List<OrderDetailsViewModel>();
            foreach (order_details order_detail in selected_order)
            {
                OrderDetailsViewModel order_detail_vm = new OrderDetailsViewModel();
                order_detail_vm.id = order_detail.Id;
                order_detail_vm.itemId = (int)order_detail.ckwh_item_id;
                order_detail_vm.itemCode = order_detail.ckwh_items.wh_item_code;
                order_detail_vm.itemDescription = order_detail.ckwh_items.wh_item_description;
                order_detail_vm.unitId = (int)order_detail.wh_item_unit_id;
                order_detail_vm.unitDescription = order_detail.wh_item_unit.ck_units.unit_description;
                order_detail_vm.qty = (decimal)order_detail.qty;
                if (order_detail.qty_issued != null)
                {
                    order_detail_vm.qty_issued = (decimal)order_detail.qty_issued;
                }
                if (order_detail.qty_received != null)
                {
                    order_detail_vm.qty_received = (decimal)order_detail.qty_received;
                }
                order_detail_list.Add(order_detail_vm);
            }
            dgCKOrderDetails.ItemsSource = null;
            dgCKOrderDetails.ItemsSource = order_detail_list;
        }

        private void dgCKOrderDetails_CellValidating(object sender, GridViewCellValidatingEventArgs e)
        {
            if (e.Cell.Column.UniqueName == "qty_received")
            {
                if ((Convert.ToDecimal(e.NewValue.ToString())) >= 0)
                {
                }
                else
                {
                    e.IsValid = false;
                    e.ErrorMessage = "Not a valid quantity";

                }
            }
        }

        private void CreateReceipt(DateTime receipt_date_time, List<receipt_details> receipt_detail_list)
        {
            //int result = 0;
            try
            {
                CKReceiptService _rcontext = new CKReceiptService();
                SiteService _scontext = new SiteService();
                receipt receipt_master = new receipt();
                receipt_master.receipt_no = active_receipt_no;
                receipt_master.receipt_date = receipt_date_time;
                receipt_master.order_id = active_order_id;
                receipt_master.order_no = txtOrderNo.Value;
                receipt_master.issued_site = _scontext.GetSiteIDBySiteName("Central Warehouse");
                receipt_master.received_site = _scontext.GetSiteIDBySiteName("Central Kitchen"); //Active Site ID
                receipt_master.created_by = GlobalVariables.ActiveUser.Id;
                receipt_master.created_date = receipt_date_time;
                receipt_master.active = true;
                //**Changed for making transaction
                //result = _rcontext.CreateReceipt(receipt_master, receipt_detail_list);
                //**Changed for making transaction
                g_receipt_master = receipt_master;
            }
            catch { }
            //return result;
        }

        private decimal CalculateAverageCost(decimal previous_cost, decimal previous_qty, decimal current_cost, decimal current_qty)
        {
            decimal avg_cost = 0m;
            avg_cost = ((previous_cost * previous_qty) + (current_cost * current_qty)) / (previous_qty + current_qty);
            return avg_cost;
        }

        private decimal CurrentAverageCost(int wh_item_id, decimal current_cost, decimal current_qty)
        {
            decimal current_average_cost = 0.000m;
            WHItemCostService _hcontext = new WHItemCostService();
            WHItemService _wicontext = new WHItemService();
            wh_item_cost_history lastWHItemCost = _hcontext.GetLastCost((int)(wh_item_id));
            decimal previous_cost;
            if (lastWHItemCost == null)
            {
                previous_cost = 0;
            }
            else
            {
                previous_cost = (decimal)lastWHItemCost.curr_cost;
                //previous_cost = current_cost;
            }
            decimal previous_qty = 0.0m;
            if (_wicontext.GetCurrentCKQty((int)wh_item_id) != null)
            {
                previous_qty = (decimal)_wicontext.GetCurrentCKQty((int)wh_item_id);
            }
            if (lastWHItemCost != null)
            {
                if (lastWHItemCost.curr_cost != current_cost)
                {
                    current_average_cost = CalculateAverageCost(previous_cost, previous_qty, current_cost, current_qty);
                }
                else
                {
                    current_average_cost = current_cost;
                }
            }
            else
            {
                current_average_cost = current_cost;
            }
            return current_average_cost;
        }

        private void UpdateItemCostHistory(List<receipt_details> receipt_detail_list)
        {
            //int result = 0;
            WHItemCostService _hcontext = new WHItemCostService();
            WHItemService _wicontext = new WHItemService();
            foreach (receipt_details ReceiptDetail in receipt_detail_list)
            {
                wh_item_cost_history objWHItemCost = new wh_item_cost_history();
                wh_item_cost_history lastWHItemCost = _hcontext.GetLastCost((int)(ReceiptDetail.wh_item_id));
                //If item cost is in history table
                if (lastWHItemCost != null)
                {
                    //if cost changes
                    //if (lastWHItemCost.curr_cost != ReceiptDetail.wh_item_unit_cost)
                    if (lastWHItemCost.curr_cost != Math.Truncate((decimal)(ReceiptDetail.wh_item_unit_cost) * 1000m) / 1000m)
                    {
                        objWHItemCost.wh_item_id = ReceiptDetail.wh_item_id;
                        objWHItemCost.wh_item_code = ReceiptDetail.wh_item_code;
                        objWHItemCost.wh_item_description = ReceiptDetail.wh_item_description;
                        objWHItemCost.ord = lastWHItemCost.ord + 1;
                        objWHItemCost.prev_cost = lastWHItemCost.curr_cost;

                        decimal previous_cost = (decimal)objWHItemCost.prev_cost;
                        decimal previous_qty = (decimal)_wicontext.GetCurrentCKQty((int)objWHItemCost.wh_item_id);
                        decimal current_cost = (decimal)ReceiptDetail.wh_item_unit_cost;
                        decimal current_qty = (decimal)ReceiptDetail.qty_received;

                        decimal avg_current_cost = CalculateAverageCost(previous_cost, previous_qty, current_cost, current_qty);

                        //objWHItemCost.curr_cost = ReceiptDetail.wh_item_unit_cost; //Update with avg. cost
                        objWHItemCost.curr_cost = avg_current_cost;

                        objWHItemCost.created_by = GlobalVariables.ActiveUser.Id;
                        objWHItemCost.created_date = DateTime.Now;

                        //**Changed for making transaction

                        ////result = _hcontext.UpdateWHItemCost(objWHItemCost);//_hcontext.CreateWHItemCost(objWHItemCost);
                        //_hcontext.CreateWHItemCost(objWHItemCost);
                        //if (result <= 0)
                        //{
                        //    MessageBox.Show("Warehouse Item Cost Updation Failed");
                        //    return result;
                        //}

                        //**Changed for making transaction

                        g_wh_item_cost_history_list.Add(objWHItemCost);
                    }
                    else
                    {
                        //return 1;
                        return;
                    }
                }
                else 
                {
                    objWHItemCost.wh_item_id = ReceiptDetail.wh_item_id;
                    objWHItemCost.wh_item_code = ReceiptDetail.wh_item_code;
                    objWHItemCost.wh_item_description = ReceiptDetail.wh_item_description;
                    objWHItemCost.ord = 1;
                    objWHItemCost.prev_cost = 0;

                    //decimal previous_cost = (decimal)objWHItemCost.prev_cost;
                    //decimal previous_qty = (decimal)_wicontext.GetCurrentCKQty((int)objWHItemCost.wh_item_id);
                    //decimal current_cost = (decimal)ReceiptDetail.wh_item_unit_cost;
                    //decimal current_qty = (decimal)ReceiptDetail.qty_received;

                    //decimal avg_current_cost = CalculateAverageCost(previous_cost, previous_qty, current_cost, current_qty);

                    //objWHItemCost.curr_cost = ReceiptDetail.wh_item_unit_cost; //Update with avg. cost
                    objWHItemCost.curr_cost = (decimal)ReceiptDetail.wh_item_unit_cost;

                    objWHItemCost.created_by = GlobalVariables.ActiveUser.Id;
                    objWHItemCost.created_date = DateTime.Now;

                    //**Changed for making transaction

                    ////result = _hcontext.UpdateWHItemCost(objWHItemCost);
                    //result = _hcontext.CreateWHItemCost(objWHItemCost);
                    //if (result <= 0)
                    //{
                    //    MessageBox.Show("Warehouse Item Cost Updation Failed");
                    //    return result;
                    //}
                    //**Changed for making transaction
                    g_wh_item_cost_history_list.Add(objWHItemCost);
                }
            }
            //return result;
        }
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if(MessageBox.Show("Do you want to continue?","Confirm",MessageBoxButton.YesNo) == MessageBoxResult.No)
            {
                return;
            }
            btnSave.IsEnabled = false;
            var rows = this.dgCKOrderDetails.ChildrenOfType<GridViewRow>();
            int result = 0;

            DateTime receipt_date_time = (DateTime)dtpReceiptDate.SelectedDate + DateTime.Now.TimeOfDay;

            

            CKOrderService _ocontext = new CKOrderService();
            //List<receipt_details> receipt_detail_list = new List<receipt_details>();
            WHItemService _wcontext = new WHItemService();
            
            foreach (var row in rows)
            {
                if (row is GridViewNewRow)
                    continue;

                OrderDetailsViewModel objOrderDetails = row.Item as OrderDetailsViewModel;

                // Update order_details table with received qty
                //result = _ocontext.UpdateReceivedQty(active_order_id, objOrderDetails.qty_received);

                order_details orderdetail = new order_details();
                orderdetail.Id = objOrderDetails.id;
                orderdetail.qty_received = objOrderDetails.qty_received;
                orderdetail.modified_by = GlobalVariables.ActiveUser.Id;
                orderdetail.modified_date = DateTime.Now;
                g_order_detail_list.Add(orderdetail);

                //g_order_detail_id = objOrderDetails.id;
                //g_qty_received = objOrderDetails.qty_received;

                //**Changed for making transaction

                //result = _ocontext.UpdateReceivedQty(objOrderDetails.id, objOrderDetails.qty_received);
                //if (result<=0)
                //{
                //    break;
                //}

                //**Changed for making transaction

                //Retreive current unit cost from ckwh_items table
                decimal item_unit_cost = (decimal)_wcontext.GetCurrentCost(objOrderDetails.itemId);
                //decimal item_unit_cost = CurrentAverageCost(objOrderDetails.itemId, (decimal)_wcontext.GetCurrentCost(objOrderDetails.itemId), objOrderDetails.qty_received);
                receipt_details objReceiptDetail = new receipt_details();
                objReceiptDetail.receipt_no = active_receipt_no;
                objReceiptDetail.wh_item_id = objOrderDetails.itemId;
                objReceiptDetail.wh_item_code = objOrderDetails.itemCode;
                objReceiptDetail.wh_item_description = objOrderDetails.itemDescription;
                objReceiptDetail.wh_item_unit_id = objOrderDetails.unitId;
                objReceiptDetail.ck_unit_description = objOrderDetails.unitDescription;
                objReceiptDetail.qty_ordered = objOrderDetails.qty;
                objReceiptDetail.qty_received = objOrderDetails.qty_received;
                objReceiptDetail.wh_item_unit_cost = item_unit_cost;
                objReceiptDetail.wh_item_ext_cost = item_unit_cost * objOrderDetails.qty_received;
                objReceiptDetail.active = true;
                objReceiptDetail.created_by = GlobalVariables.ActiveUser.Id;
                objReceiptDetail.created_date = receipt_date_time;

                g_receipt_detail_list.Add(objReceiptDetail);

                //Update new transaction in Transaction Table with current warehouse item cost as item_unit_cost

                //**Changed for making transaction
                //result = SaveTransaction(objOrderDetails, receipt_date_time, item_unit_cost);

                SaveTransaction(objOrderDetails, receipt_date_time, item_unit_cost);

                //if (result<=0)
                //{
                //    break;
                //}

                //**Changed for making transaction
                decimal current_item_qty = 0.0m;

                //Get current ck_qty from ckwh_items to update with the received qty
                if(_wcontext.GetCurrentCKQty(objOrderDetails.itemId)!=null)
                {
                    current_item_qty = (decimal)_wcontext.GetCurrentCKQty(objOrderDetails.itemId);
                }
                
                decimal ck_updated_qty =  current_item_qty + objOrderDetails.qty_received;

                //Update ck_qty with ck_updated_qty in ckwh_items table

                //**Changed for making transaction
                //result = _wcontext.UpdateCKItemQty(objOrderDetails.itemId, ck_updated_qty, GlobalVariables.ActiveUser.Id);
                //if (result <= 0)
                //{
                //    break;
                //}
                //**Changed for making transaction

                ckwh_items ckwhitem = new ckwh_items();
                ckwhitem.Id = objOrderDetails.itemId;
                ckwhitem.ck_qty = ck_updated_qty;
                decimal current_average_cost = CurrentAverageCost(objOrderDetails.itemId, item_unit_cost, objOrderDetails.qty_received);
                ckwhitem.ck_avg_unit_cost = current_average_cost;
                ckwhitem.modified_by = GlobalVariables.ActiveUser.Id;
                ckwhitem.modified_date = DateTime.Now;
                g_ckwh_items_list.Add(ckwhitem);



                //**Changed for making transaction

                //decimal current_average_cost = CurrentAverageCost(objOrderDetails.itemId, item_unit_cost, objOrderDetails.qty_received);
                //result = _wcontext.UpdateCKItemAvgUnitCost(objOrderDetails.itemId, current_average_cost);

                //if(result<=0)
                //{
                //    break;
                //}

                //**Changed for making transaction
            }

            //result = CreateReceipt(receipt_date_time, g_receipt_detail_list);
            //result = UpdateItemCostHistory(g_receipt_detail_list);
            CreateReceipt(receipt_date_time, g_receipt_detail_list);
            UpdateItemCostHistory(g_receipt_detail_list);

            //if (result > 0)
            //{
            //**Changed for making transaction
            //result = _ocontext.UpdateCKOrderReceiveStatus(active_order_id, "Received", receipt_date_time, GlobalVariables.ActiveUser.Id);
            //**Changed for making transaction
            //g_order_master.Id = active_order_id;
            //g_order_master.order_status = "Received";
            //g_order_master.receipt_date = receipt_date_time;
            //g_order_master.modified_by = GlobalVariables.ActiveUser.Id;
            //g_order_master.modified_date = DateTime.Now;
            //}
            g_order_master.Id = active_order_id;
            g_order_master.order_status = "Received";
            g_order_master.receipt_date = receipt_date_time;
            g_order_master.modified_by = GlobalVariables.ActiveUser.Id;
            g_order_master.modified_date = DateTime.Now;
            result = _ocontext.SaveReceipt(g_order_master, g_order_detail_list, g_transaction_detail_list, g_ckwh_items_list, g_receipt_master, g_receipt_detail_list, g_wh_item_cost_history_list);
            string response = result > 0 ? "Items Received Successfully" : "Unable to receive the Items. Please contact administrator";

            if(result>0)
            {
                SendMail();
                btnSave.IsEnabled = true;
                IEnumerable<order> g_orders = _ocontext.ReadAllActiveSiteOrders(GlobalVariables.ActiveSite.Id);
                g_ck_order_view.dgCKOrders.ItemsSource = g_orders;
                g_ck_order_view.dgCKOrders.Rebind();
            }

            //RadWindow.Alert(response);
            MessageBox.Show(response);
        }

        private void SaveTransaction(OrderDetailsViewModel objOrderDetails, DateTime receipt_date_time, decimal item_unit_cost)
        {
            //int result = 0;
            try
            {
                SiteService _scontext = new SiteService();
                TransactionService _tcontext = new TransactionService();
                transaction_details objTransactionDetail = new transaction_details();
                objTransactionDetail.trans_ref_no = active_receipt_no;
                objTransactionDetail.wh_item_id = objOrderDetails.itemId;
                objTransactionDetail.wh_item_code = objOrderDetails.itemCode;
                objTransactionDetail.wh_item_description = objOrderDetails.itemDescription;
                objTransactionDetail.trans_date = dtpReceiptDate.SelectedDate + DateTime.Now.TimeOfDay;
                objTransactionDetail.wh_item_unit_id = objOrderDetails.unitId;
                objTransactionDetail.ck_unit_description = objOrderDetails.unitDescription;
                objTransactionDetail.qty = objOrderDetails.qty_received;
                objTransactionDetail.unit_cost = item_unit_cost;
                objTransactionDetail.total_cost = (objTransactionDetail.qty * objTransactionDetail.unit_cost);
                objTransactionDetail.order_from_site_id = _scontext.GetSiteIDBySiteName("Central Warehouse");
                objTransactionDetail.order_to_site_id = _scontext.GetSiteIDBySiteName("Central Kitchen");
                objTransactionDetail.trans_type = "Receipt";
                objTransactionDetail.active = true;
                objTransactionDetail.created_by = GlobalVariables.ActiveUser.Id;
                objTransactionDetail.created_date = receipt_date_time;
                g_transaction_detail_list.Add(objTransactionDetail);

                //**Changed for making transaction
                //result = _tcontext.CreateTransaction(objTransactionDetail);
                //**Changed for making transaction
            }
            catch { }
            //return result;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnPrint_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                //Telerik.Reporting.IReportDocument myReport = new DieReports.DieDetailsReport(die_id, "Drawing");
                //Telerik.Reporting.IReportDocument myReport = new dipndipTLReports.PrintOrderReport("CKOR-0007");
                //Telerik.Reporting.IReportDocument myReport = new dipndipTLReports.Reports.OrderDetailsB("CKOR-0007");
                Telerik.Reporting.IReportDocument myReport = new dipndipTLReports.Reports.WHReceiptDetails(txtOrderNo.Value);


                // Obtain the settings of the default printer
                System.Drawing.Printing.PrinterSettings printerSettings
                    = new System.Drawing.Printing.PrinterSettings();

                //// The standard print controller comes with no UI
                System.Drawing.Printing.PrintController standardPrintController =
                    new System.Drawing.Printing.StandardPrintController();

                // Print the report using the custom print controller
                Telerik.Reporting.Processing.ReportProcessor reportProcessor
                    = new Telerik.Reporting.Processing.ReportProcessor();

                reportProcessor.PrintController = standardPrintController;

                Telerik.Reporting.InstanceReportSource instanceReportSource =
                    new Telerik.Reporting.InstanceReportSource();

                instanceReportSource.ReportDocument = myReport;

                reportProcessor.PrintReport(instanceReportSource, printerSettings);
            }
            catch (Exception ex)
            {

            }
        }

        private void SendMail()
        {
            //if (OrderPlaced())
            //{
            //    return;
            //}

            Telerik.Reporting.Report myReport = new dipndipTLReports.Reports.WHReceiptDetails(txtOrderNo.Value);
            string ftime = DateTime.Now.Hour.ToString() + "-" + DateTime.Now.Minute.ToString() + "-" + DateTime.Now.Second.ToString();
            //string fileName = @"D:\CKReceipts\Receipt-" + DateTime.Now.Date.ToString("dd-MM-yyyy") + "-" + ftime + ".pdf";
            string fileName = string.Empty;
            if (GlobalVariables.AppEnvironment == "Development")
            {
                fileName = @"D:\CKReceipts\" + active_receipt_no + ".pdf";
            }
            else
            {
                fileName = @"E:\CKReceipts\" + active_receipt_no + ".pdf";
            }
            SaveReport(myReport, fileName);

            Microsoft.Office.Interop.Outlook.Application app = new Microsoft.Office.Interop.Outlook.Application();
            Microsoft.Office.Interop.Outlook.MailItem mailItem = app.CreateItem(Microsoft.Office.Interop.Outlook.OlItemType.olMailItem);
            mailItem.Subject = "Central Kitchen Receipt";
            if (GlobalVariables.AppEnvironment == "Development")
            {
                mailItem.To = "jolly@dipndipkw.com";
            }
            else
            {
                try
                {
                    SiteService stcontext = new SiteService();
                    mailItem.To = stcontext.GetSiteMailBySiteCode("WH");
                }
                catch { MessageBox.Show("Please contact admin"); return; }
            }
            mailItem.Body = @"Dear Warehouse Officer,

Please find attached Receipt for Central Kitchen Order No: " + txtOrderNo.Value + ".";
            mailItem.Body += @"

Regards";
            mailItem.Body += @"
Central Kitchen";
            //string logPath = @"D:\items.pdf";
            string logPath = fileName;
            mailItem.Attachments.Add(logPath);//logPath is a string holding path to the log.txt file
            mailItem.Importance = Microsoft.Office.Interop.Outlook.OlImportance.olImportanceHigh;
            mailItem.ReadReceiptRequested = true;
            mailItem.Send();
            //mailItem.Display(false);

            //CKOrderService ckocontext = new CKOrderService();
            //if (ckocontext.UpdateCKOrderMail(txtOrderNo.Value) > 0)
            //{
            //    MessageBox.Show("You order has been placed");
            //}
            //else
            //{
            //    MessageBox.Show("Sorry");
            //}
        }

        void SaveReport(Telerik.Reporting.Report report, string fileName)
        {
            ReportProcessor reportProcessor = new ReportProcessor();
            Telerik.Reporting.InstanceReportSource instanceReportSource = new Telerik.Reporting.InstanceReportSource();
            instanceReportSource.ReportDocument = report;
            RenderingResult result = reportProcessor.RenderReport("PDF", instanceReportSource, null);
            if (File.Exists(fileName))
                File.Delete(fileName);
            using (FileStream fs = new FileStream(fileName, FileMode.Create))
            {
                fs.Write(result.DocumentBytes, 0, result.DocumentBytes.Length);
            }
        }
    }
}
