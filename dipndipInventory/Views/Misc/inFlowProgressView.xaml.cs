using dipndipInventory.EF.DataServices;
using dipndipInventory.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace dipndipInventory.Views.Misc
{
    /// <summary>
    /// Interaction logic for inFlowProgressView.xaml
    /// </summary>
    public partial class inFlowProgressView : Window
    {
        int g_update_status = 0;
        public inFlowProgressView()
        {
            InitializeComponent();
        }

        public inFlowProgressView(int update_status)
        {
            InitializeComponent();
            g_update_status = update_status;
        }
        public void UpdateItems()
        {
            CKWHItemUpdateService ucontext = new CKWHItemUpdateService();
            int result = 0;
            result = ucontext.CKWHItemUpdate(GlobalVariables.ActiveUser.Id);
            if (result > 0)
            {
                MessageBox.Show("Items Updated Successfully");
                g_update_status = 1;
            }
            else
            {
                MessageBox.Show("Updation Failed");
                g_update_status = 0;
            }
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            
        }

        private void Window_ContentRendered(object sender, EventArgs e)
        {
            BackgroundWorker worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true;
            worker.DoWork += worker_DoWork;
            worker.ProgressChanged += worker_ProgressChanged;
            worker.RunWorkerCompleted += RunWorkerCompleted;

            worker.RunWorkerAsync();
        }

        private void RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Close();
        }

        void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            //for (int i = 0; i < 100; i++)
            //{
            //    (sender as BackgroundWorker).ReportProgress(i);
            //    Thread.Sleep(100);
            //}
            UpdateItems();
        }

        void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pbStatus.Value = e.ProgressPercentage;
        }


    }
}
