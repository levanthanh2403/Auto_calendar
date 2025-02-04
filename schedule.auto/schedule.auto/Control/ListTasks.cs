using Microsoft.VisualBasic.Logging;
using Newtonsoft.Json;
using Quartz.Impl;
using Quartz;
using schedule.auto.Data;
using schedule.auto.Helper;
using schedule.auto.ScheduledTasks;
using Serilog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Log = Serilog.Log;
using schedule.auto.Models;

namespace schedule.auto.Control
{
    public partial class ListTasks : UserControl
    {
        private string jobId;
        private string jobName;
        private string ipSource;
        private string pathSource;
        private string ipDestination;
        private string pathDestination;
        private string frequency;
        private string dateExec;
        private string timeExec;
        private string status;
        [Browsable(true)]
        [Category("ActionClick")]
        [Description("Invoke when user clicks on button")]
        public event EventHandler ButtonClick;
        public ListTasks()
        {
            InitializeComponent();
            cbbFrequency.DataSource = CONST._freq;
            cbbFrequency.DisplayMember = "text";
            cbbFrequency.ValueMember = "value";
            cbbFrequency.DropDownStyle = ComboBoxStyle.DropDownList;
            cbbFrequency.SelectedValue = "1PD";
            txtDateExec.Enabled = false;
            lbDateExec.Visible = false;

            cbbStatus.DataSource = CONST._status;
            cbbStatus.DisplayMember = "text";
            cbbStatus.ValueMember = "value";
            cbbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cbbStatus.SelectedValue = "0";

            //JobId = txtJobId.Text;
            //JobName = txtJobName.Text;
            //IpSource = txtIpSource.Text;
            //IpDestination = txtIpDestination.Text;
            //PathSource = txtPathSource.Text;
            //PathDestination = txtPathDestination.Text;
            //Frequency = cbbFrequency.Text;
            //DateExec = txtDateExec.Text;
            //TimeExec = txtTimeExec.Text;
            //Status = cbbStatus.Text;

            //btnSave.Image = Properties.Resources.play1;
        }

        private void btnClosed_Click(object sender, EventArgs e)
        {
            ButtonClick?.Invoke(sender, e);
        }

        private void btnFolderSource_Click(object sender, EventArgs e)
        {
            try
            {
                //NetworkDriveMapper.MapNetworkDrive("Z", @"\\192.168.100.188\", "administrator", "techplus@123");

                //Application.EnableVisualStyles();
                //Application.SetCompatibleTextRenderingDefault(false);

                folderBrowserSource.Description = "Chọn thư mục nguồn";
                //folderBrowserSource.SelectedPath = @"C:\";

                //if (folderBrowserSource.ShowDialog() == DialogResult.OK)
                //{
                //    txtPathSource.Text = folderBrowserSource.SelectedPath;
                //}
                string defaultServerFolder = @"\\192.168.100.221\c";
                folderBrowserSource.RootFolder = Environment.SpecialFolder.NetworkShortcuts;
                folderBrowserSource.SelectedPath = defaultServerFolder;

                // Hiển thị FolderBrowserDialog và kiểm tra nếu người dùng chọn một thư mục
                if (folderBrowserSource.ShowDialog() == DialogResult.OK)
                {
                    // Lấy đường dẫn của thư mục được chọn
                    txtPathSource.Text = folderBrowserSource.SelectedPath;
                }
            }
            catch (Exception ex)
            {
                Log.Error($"Choose path Source: {ex}");
            }
        }

        private void btnFolderDestination_Click(object sender, EventArgs e)
        {
            try
            {
                folderBrowserDestination.Description = "Chọn thư mục đích";
                if (folderBrowserDestination.ShowDialog() == DialogResult.OK)
                {
                    txtPathDestination.Text = folderBrowserDestination.SelectedPath;
                }
            }
            catch (Exception ex)
            {
                Log.Error($"Choose path Destination: {ex}");
            }
        }

        private void cbbFrequency_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cbbFrequency.SelectedValue.ToString() == "1PD")
            {
                txtDateExec.Enabled = false;
                lbDateExec.Visible = false;
            }
            else
            {
                txtDateExec.Enabled = true;
                lbDateExec.Visible = true;
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbbStatus.SelectedValue.ToString() == "0") cbbStatus.SelectedValue = "1";
                else cbbStatus.SelectedValue = "0";
                backup_model item = new backup_model
                {
                    jobId = txtJobId.Text,
                    jobName = txtJobName.Text,
                    ipSource = txtIpSource.Text,
                    pathSource = txtPathSource.Text,
                    ipDestination = txtIpDestination.Text,
                    pathDestination = txtPathDestination.Text,
                    status = cbbStatus.SelectedValue.ToString(),
                    frequency = cbbFrequency.SelectedValue.ToString(),
                    dateExec = txtDateExec.Text,
                    timeExec = txtTimeExec.Text
                };
                List<backup_model> data = new List<backup_model>();
                data.Add(item);
                await ExecJob.Createjob(item);
                DataHelper _helper = new DataHelper();
                _helper.InsertDataToExcel(data);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public string JobId
        {
            get { return txtJobId.Text; }
            set { jobId = value; txtJobId.Text = jobId; }
        }
        public string JobName
        {
            get { return txtJobName.Text; }
            set { jobName = value; txtJobName.Text = value; }
        }
        public string IpSource
        {
            get { return txtIpSource.Text; }
            set { ipSource = value; txtIpSource.Text = value; }
        }
        public string PathSource
        {
            get { return txtPathSource.Text; }
            set { pathSource = value; txtPathSource.Text = value; }
        }
        public string IpDestination
        {
            get { return txtIpDestination.Text; }
            set { ipDestination = value; txtIpDestination.Text = value; }
        }
        public string PathDestination
        {
            get { return txtPathDestination.Text; }
            set { pathDestination = value; txtPathDestination.Text = value; }
        }
        public string Frequency
        {
            get { return cbbFrequency.SelectedValue.ToString(); }
            set { frequency = value; cbbFrequency.SelectedValue = (string.IsNullOrEmpty(value) ? "1PD" : value); }
        }
        public string DateExec
        {
            get { return txtDateExec.Text; }
            set { dateExec = value; txtDateExec.Text = value; }
        }
        public string TimeExec
        {
            get { return txtTimeExec.Text; }
            set { timeExec = value; txtTimeExec.Text = value; }
        }
        public string Status
        {
            get { return cbbStatus.SelectedValue.ToString(); }
            set { status = value; cbbStatus.SelectedValue = (string.IsNullOrEmpty(value) ? "1" : value); }
        }
        private void cbbStatus_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cbbStatus.SelectedValue.ToString() == "0")
            {
                btnSave.Image = Properties.Resources.play1;
                txtJobName.Enabled = true;
                txtIpSource.Enabled = true;
                txtIpDestination.Enabled = true;
                txtPathSource.Enabled = true;
                txtPathDestination.Enabled = true;
                cbbFrequency.Enabled = true;
                txtDateExec.Enabled = true;
                txtTimeExec.Enabled = true;
            }
            else
            {
                btnSave.Image = Properties.Resources.stop1;
                txtJobName.Enabled = false;
                txtIpSource.Enabled = false;
                txtIpDestination.Enabled = false;
                txtPathSource.Enabled = false;
                txtPathDestination.Enabled = false;
                cbbFrequency.Enabled = false;
                txtDateExec.Enabled = false;
                txtTimeExec.Enabled = false;
            }
        }
    }
}
