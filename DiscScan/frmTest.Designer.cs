namespace DiscScan
{
    partial class frmTest
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.textSourceFolder = new System.Windows.Forms.TextBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.cmd_SelectPath = new System.Windows.Forms.Button();
            this.cmd_Scan = new System.Windows.Forms.Button();
            this.cmd_SelectDestPath = new System.Windows.Forms.Button();
            this.textDestinationFolder = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmd_Sync = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Path";
            // 
            // textSourceFolder
            // 
            this.textSourceFolder.Location = new System.Drawing.Point(70, 29);
            this.textSourceFolder.Name = "textSourceFolder";
            this.textSourceFolder.Size = new System.Drawing.Size(231, 23);
            this.textSourceFolder.TabIndex = 1;
            // 
            // cmd_SelectPath
            // 
            this.cmd_SelectPath.Location = new System.Drawing.Point(313, 29);
            this.cmd_SelectPath.Name = "cmd_SelectPath";
            this.cmd_SelectPath.Size = new System.Drawing.Size(45, 23);
            this.cmd_SelectPath.TabIndex = 2;
            this.cmd_SelectPath.Text = "...";
            this.cmd_SelectPath.UseVisualStyleBackColor = true;
            this.cmd_SelectPath.Click += new System.EventHandler(this.cmd_SelectPath_Click);
            // 
            // cmd_Scan
            // 
            this.cmd_Scan.Location = new System.Drawing.Point(70, 77);
            this.cmd_Scan.Name = "cmd_Scan";
            this.cmd_Scan.Size = new System.Drawing.Size(75, 23);
            this.cmd_Scan.TabIndex = 3;
            this.cmd_Scan.Text = "Scan";
            this.cmd_Scan.UseVisualStyleBackColor = true;
            this.cmd_Scan.Click += new System.EventHandler(this.cmd_Scan_Click);
            // 
            // cmd_SelectDestPath
            // 
            this.cmd_SelectDestPath.Location = new System.Drawing.Point(313, 137);
            this.cmd_SelectDestPath.Name = "cmd_SelectDestPath";
            this.cmd_SelectDestPath.Size = new System.Drawing.Size(45, 23);
            this.cmd_SelectDestPath.TabIndex = 6;
            this.cmd_SelectDestPath.Text = "...";
            this.cmd_SelectDestPath.UseVisualStyleBackColor = true;
            this.cmd_SelectDestPath.Click += new System.EventHandler(this.cmd_SelectDestPath_Click);
            // 
            // textDestinationFolder
            // 
            this.textDestinationFolder.Location = new System.Drawing.Point(70, 137);
            this.textDestinationFolder.Name = "textDestinationFolder";
            this.textDestinationFolder.Size = new System.Drawing.Size(231, 23);
            this.textDestinationFolder.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 137);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Dest";
            // 
            // cmd_Sync
            // 
            this.cmd_Sync.Location = new System.Drawing.Point(76, 188);
            this.cmd_Sync.Name = "cmd_Sync";
            this.cmd_Sync.Size = new System.Drawing.Size(75, 23);
            this.cmd_Sync.TabIndex = 7;
            this.cmd_Sync.Text = "Sync";
            this.cmd_Sync.UseVisualStyleBackColor = true;
            this.cmd_Sync.Click += new System.EventHandler(this.cmd_Sync_Click);
            // 
            // frmTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.cmd_Sync);
            this.Controls.Add(this.cmd_SelectDestPath);
            this.Controls.Add(this.textDestinationFolder);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmd_Scan);
            this.Controls.Add(this.cmd_SelectPath);
            this.Controls.Add(this.textSourceFolder);
            this.Controls.Add(this.label1);
            this.Name = "frmTest";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private TextBox textSourceFolder;
        private FolderBrowserDialog folderBrowserDialog1;
        private Button cmd_SelectPath;
        private Button cmd_Scan;
        private Button cmd_SelectDestPath;
        private TextBox textDestinationFolder;
        private Label label2;
        private Button cmd_Sync;
    }
}