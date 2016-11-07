using dipndipInventory.EF;
using dipndipInventory.EF.DataServices;
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
using Telerik.Windows.Controls.GridView;

namespace dipndipInventory.Views.Stock
{
    /// <summary>
    /// Interaction logic for ckitembatchView.xaml
    /// </summary>
    public partial class ckitembatchView : RadWindow
    {
        CKIssueViewModel g_ck_issue_vm;
        //List<CKItemBatchViewModel> g_ck_item_batches;
        ckitemissueView g_ck_item_issue_view
        List<CKIssueViewModel> ck_item_list = new List<CKIssueViewModel>();
        public ckitembatchView()
        {
            InitializeComponent();
        }

        //public ckitembatchView(CKIssueViewModel ck_issue_vm, List<CKItemBatchViewModel> ck_item_batches)
        public ckitembatchView(CKIssueViewModel ck_issue_vm, ckitemissueView ck_item_issue_view)
        {
            InitializeComponent();
            g_ck_issue_vm = ck_issue_vm;
            //g_ck_item_batches = ck_item_batches;
            g_ck_item_issue_view = ck_item_issue_view;
            FillAllBatchItems(g_ck_issue_vm.itemCode);
        }

        private void FillAllBatchItems(string ck_item_code)
        {
            CKProductionService cpcontext = new CKProductionService();
            List<ck_prod> ck_batch_items = cpcontext.GetAvailableBatchItems(ck_item_code).ToList();
            List<CKItemBatchViewModel> ck_item_batches = new List<CKItemBatchViewModel>();
            int row_id = 0;
            foreach(ck_prod ck_batch_item in ck_batch_items)
            {
                CKItemBatchViewModel objCKItemBatchVM = new CKItemBatchViewModel();
                objCKItemBatchVM.ck_item_id = (int)ck_batch_item.ck_item_id;
                objCKItemBatchVM.ck_item_code = ck_batch_item.ck_item_code;
                objCKItemBatchVM.ck_item_description = ck_batch_item.ck_item_desc;
                objCKItemBatchVM.ck_item_unit_desc = ck_batch_item.ck_item_unit_desc;
                objCKItemBatchVM.batch_no = ck_batch_item.batch_no;
                objCKItemBatchVM.exp_date = (DateTime)ck_batch_item.exp_date;
                objCKItemBatchVM.bal_qty = (decimal)ck_batch_item.bal_qty;
                objCKItemBatchVM.qty_issued = 0.000m;
                objCKItemBatchVM.row_id = row_id++;
                ck_item_batches.Add(objCKItemBatchVM);
            }

            dgCKIssueDetails.ItemsSource = ck_item_batches;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            var rows = this.dgCKIssueDetails.ChildrenOfType<GridViewRow>();
            int result = 0;
            CKOrderService _ocontext = new CKOrderService();
            foreach (var row in rows)
            {
                if (row is GridViewNewRow)
                    continue;

                CKItemBatchViewModel objItemBatchVM = row.Item as CKItemBatchViewModel;


                
            }
        }
    }
}
