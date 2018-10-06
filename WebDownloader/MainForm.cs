using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebDownloader
{
    public partial class MainForm : Form
    {
        private Timer timer = new System.Windows.Forms.Timer();
        private Timer listUpdateTimer = new System.Windows.Forms.Timer();

        public MainForm()
        {
            InitializeComponent();

            timer.Interval = 200;
            timer.Tick += new EventHandler(Timer_Tick);
            timer.Enabled = true;
            timer.Start();

            listUpdateTimer.Interval = 1000;
            listUpdateTimer.Tick += new EventHandler(UpdateListTimer_Tick);
            listUpdateTimer.Enabled = true;
            listUpdateTimer.Start();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            DownloadProcesser.doWhenFinish += DownLoadFinished;
            DownloadProcesser.doWhenStoped += DownLoadStoped;

            DownLoadPsB.Value = 0;
            DownLoadPsB.Maximum = 100;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            List<TargetPageItem> pageList = DownloadProcesser.PageList;

            int totalCount = pageList.Count;
            int finishCount = pageList.Count(p => p.Status != DownloadStatus.未下载);
            DownLoadPsB.Value = totalCount == 0 ? 0 :finishCount / totalCount * 100;

            if (DownLoadPsB.Value > 0 && DownLoadPsB.Value < DownLoadPsB.Maximum)
            {
                DownLoadPsB.PerformStep();
            }
        }

        private void UpdateListTimer_Tick(object sender, EventArgs e)
        {
            RefreshListView();
        }

        private void FolderSelectBtn_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog path = new FolderBrowserDialog();
            path.ShowDialog();
            this.OutputFolderTxb.Text = path.SelectedPath;

            DownloadProcesser.OutputFolderPath = path.SelectedPath;
        }

        private void OpenMask()
        {
            WorkingPanel.Visible = true;
            this.Enabled = false;
        }

        private void CloseMask()
        {
            this.Enabled = true;
            WorkingPanel.Visible = false;
        }

        private void AddWebPageBtn_Click(object sender, EventArgs e)
        {
            string url = AddWebPageTxb.Text;

            List<TargetPageItem> pageList = DownloadProcesser.PageList;

            if (string.IsNullOrWhiteSpace(url))
            {
                MessageBox.Show("不能添加空地址", "空地址", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (pageList.FirstOrDefault(p => p.Url == url) != null)
            {
                MessageBox.Show("该页面已被添加过", "重复添加", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            OpenMask();

            try
            {
                DownloadProcesser.AddPage(url);
                AddWebPageTxb.Text = string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            RefreshListView();

            CloseMask();
        }

        private void RefreshListView()
        {
            List<TargetPageItem> pageList = DownloadProcesser.PageList;

            TargetPageListView.Items.Clear();

            foreach (var item in pageList)
            {
                ListViewItem addItem = new ListViewItem();
                addItem.Text = item.Url;
                addItem.SubItems.Add(item.Title);
                addItem.SubItems.Add(item.Status.ToString());
                TargetPageListView.Items.Add(addItem);
            }
        }

        private void StartDownloadBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.OutputFolderTxb.Text))
            {
                this.OutputFolderTxb.Text = DownloadProcesser.OutputFolderPath;
            }

            if (!System.IO.Directory.Exists(this.OutputFolderTxb.Text))
            {
                if (MessageBox.Show("路径文件夹不存在，是否创建？", "创建目录", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    System.IO.Directory.CreateDirectory(this.OutputFolderTxb.Text);
                }
            }

            DownloadProcesser.Start();
        }

        private void DownLoadFinished()
        {
            DownLoadPsB.Value = DownLoadPsB.Maximum;
            MessageBox.Show("下载完成", "完成", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void DownLoadStoped()
        {
            DownLoadPsB.Value = DownLoadPsB.Maximum;
            MessageBox.Show("下载终止", "终止", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DownloadProcesser.CloseDriver();
        }
    }
}
