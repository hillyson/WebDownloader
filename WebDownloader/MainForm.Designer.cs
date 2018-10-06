namespace WebDownloader
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.label1 = new System.Windows.Forms.Label();
            this.OutputFolderTxb = new System.Windows.Forms.TextBox();
            this.FolderSelectBtn = new System.Windows.Forms.Button();
            this.AddWebPageBtn = new System.Windows.Forms.Button();
            this.AddWebPageTxb = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.StopDownloadBtn = new System.Windows.Forms.Button();
            this.StartDownloadBtn = new System.Windows.Forms.Button();
            this.DownLoadPsB = new System.Windows.Forms.ProgressBar();
            this.label3 = new System.Windows.Forms.Label();
            this.TargetPageListView = new System.Windows.Forms.ListView();
            this.columnHeader_url = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_title = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_status = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.WorkingPanel = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.WorkingPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "输出路径：";
            // 
            // OutputFolderTxb
            // 
            this.OutputFolderTxb.Location = new System.Drawing.Point(76, 9);
            this.OutputFolderTxb.Name = "OutputFolderTxb";
            this.OutputFolderTxb.Size = new System.Drawing.Size(420, 21);
            this.OutputFolderTxb.TabIndex = 1;
            // 
            // FolderSelectBtn
            // 
            this.FolderSelectBtn.Location = new System.Drawing.Point(503, 8);
            this.FolderSelectBtn.Name = "FolderSelectBtn";
            this.FolderSelectBtn.Size = new System.Drawing.Size(75, 23);
            this.FolderSelectBtn.TabIndex = 2;
            this.FolderSelectBtn.Text = "选择目录";
            this.FolderSelectBtn.UseVisualStyleBackColor = true;
            this.FolderSelectBtn.Click += new System.EventHandler(this.FolderSelectBtn_Click);
            // 
            // AddWebPageBtn
            // 
            this.AddWebPageBtn.Location = new System.Drawing.Point(503, 39);
            this.AddWebPageBtn.Name = "AddWebPageBtn";
            this.AddWebPageBtn.Size = new System.Drawing.Size(75, 23);
            this.AddWebPageBtn.TabIndex = 5;
            this.AddWebPageBtn.Text = "添加";
            this.AddWebPageBtn.UseVisualStyleBackColor = true;
            this.AddWebPageBtn.Click += new System.EventHandler(this.AddWebPageBtn_Click);
            // 
            // AddWebPageTxb
            // 
            this.AddWebPageTxb.Location = new System.Drawing.Point(76, 40);
            this.AddWebPageTxb.Name = "AddWebPageTxb";
            this.AddWebPageTxb.Size = new System.Drawing.Size(420, 21);
            this.AddWebPageTxb.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "添加网页：";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.WorkingPanel);
            this.groupBox1.Controls.Add(this.StopDownloadBtn);
            this.groupBox1.Controls.Add(this.StartDownloadBtn);
            this.groupBox1.Controls.Add(this.DownLoadPsB);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.TargetPageListView);
            this.groupBox1.Location = new System.Drawing.Point(15, 67);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(560, 325);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "目标网页列表";
            // 
            // StopDownloadBtn
            // 
            this.StopDownloadBtn.Location = new System.Drawing.Point(501, 297);
            this.StopDownloadBtn.Name = "StopDownloadBtn";
            this.StopDownloadBtn.Size = new System.Drawing.Size(53, 23);
            this.StopDownloadBtn.TabIndex = 4;
            this.StopDownloadBtn.Text = "取消";
            this.StopDownloadBtn.UseVisualStyleBackColor = true;
            // 
            // StartDownloadBtn
            // 
            this.StartDownloadBtn.Location = new System.Drawing.Point(440, 297);
            this.StartDownloadBtn.Name = "StartDownloadBtn";
            this.StartDownloadBtn.Size = new System.Drawing.Size(55, 23);
            this.StartDownloadBtn.TabIndex = 3;
            this.StartDownloadBtn.Text = "开始";
            this.StartDownloadBtn.UseVisualStyleBackColor = true;
            this.StartDownloadBtn.Click += new System.EventHandler(this.StartDownloadBtn_Click);
            // 
            // DownLoadPsB
            // 
            this.DownLoadPsB.Location = new System.Drawing.Point(71, 297);
            this.DownLoadPsB.Name = "DownLoadPsB";
            this.DownLoadPsB.Size = new System.Drawing.Size(363, 23);
            this.DownLoadPsB.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 302);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "下载进度：";
            // 
            // TargetPageListView
            // 
            this.TargetPageListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader_url,
            this.columnHeader_title,
            this.columnHeader_status});
            this.TargetPageListView.Location = new System.Drawing.Point(7, 21);
            this.TargetPageListView.Name = "TargetPageListView";
            this.TargetPageListView.Size = new System.Drawing.Size(547, 271);
            this.TargetPageListView.TabIndex = 0;
            this.TargetPageListView.UseCompatibleStateImageBehavior = false;
            this.TargetPageListView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader_url
            // 
            this.columnHeader_url.Text = "地址";
            this.columnHeader_url.Width = 298;
            // 
            // columnHeader_title
            // 
            this.columnHeader_title.Text = "歌名";
            this.columnHeader_title.Width = 173;
            // 
            // columnHeader_status
            // 
            this.columnHeader_status.Text = "状态";
            this.columnHeader_status.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader_status.Width = 74;
            // 
            // WorkingPanel
            // 
            this.WorkingPanel.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.WorkingPanel.Controls.Add(this.label4);
            this.WorkingPanel.ForeColor = System.Drawing.Color.Firebrick;
            this.WorkingPanel.Location = new System.Drawing.Point(121, 52);
            this.WorkingPanel.Name = "WorkingPanel";
            this.WorkingPanel.Size = new System.Drawing.Size(329, 135);
            this.WorkingPanel.TabIndex = 5;
            this.WorkingPanel.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(108, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(125, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "添加中，请稍候。。。";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(587, 402);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.AddWebPageBtn);
            this.Controls.Add(this.AddWebPageTxb);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.FolderSelectBtn);
            this.Controls.Add(this.OutputFolderTxb);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "网页文件下载器";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.WorkingPanel.ResumeLayout(false);
            this.WorkingPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox OutputFolderTxb;
        private System.Windows.Forms.Button FolderSelectBtn;
        private System.Windows.Forms.Button AddWebPageBtn;
        private System.Windows.Forms.TextBox AddWebPageTxb;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button StopDownloadBtn;
        private System.Windows.Forms.Button StartDownloadBtn;
        private System.Windows.Forms.ProgressBar DownLoadPsB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListView TargetPageListView;
        private System.Windows.Forms.ColumnHeader columnHeader_url;
        private System.Windows.Forms.ColumnHeader columnHeader_title;
        private System.Windows.Forms.ColumnHeader columnHeader_status;
        private System.Windows.Forms.Panel WorkingPanel;
        private System.Windows.Forms.Label label4;
    }
}

