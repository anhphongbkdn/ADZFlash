
namespace ADZFlash
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txbLog = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ckbRestoreData = new System.Windows.Forms.CheckBox();
            this.ckbFlashGApps = new System.Windows.Forms.CheckBox();
            this.ckbFlashMagisk = new System.Windows.Forms.CheckBox();
            this.ckbFlashROM = new System.Windows.Forms.CheckBox();
            this.btnFlash = new System.Windows.Forms.Button();
            this.btnGetDevices = new System.Windows.Forms.Button();
            this.cbbDevices = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.24468F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 66.75532F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(518, 376);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txbLog);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 127);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(512, 246);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Log";
            // 
            // txbLog
            // 
            this.txbLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txbLog.Location = new System.Drawing.Point(3, 16);
            this.txbLog.Multiline = true;
            this.txbLog.Name = "txbLog";
            this.txbLog.ReadOnly = true;
            this.txbLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txbLog.Size = new System.Drawing.Size(506, 227);
            this.txbLog.TabIndex = 0;
            this.txbLog.TextChanged += new System.EventHandler(this.txbLog_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ckbRestoreData);
            this.groupBox1.Controls.Add(this.ckbFlashGApps);
            this.groupBox1.Controls.Add(this.ckbFlashMagisk);
            this.groupBox1.Controls.Add(this.ckbFlashROM);
            this.groupBox1.Controls.Add(this.btnFlash);
            this.groupBox1.Controls.Add(this.btnGetDevices);
            this.groupBox1.Controls.Add(this.cbbDevices);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(512, 118);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Config";
            // 
            // ckbRestoreData
            // 
            this.ckbRestoreData.AutoSize = true;
            this.ckbRestoreData.Enabled = false;
            this.ckbRestoreData.Location = new System.Drawing.Point(250, 48);
            this.ckbRestoreData.Name = "ckbRestoreData";
            this.ckbRestoreData.Size = new System.Drawing.Size(89, 17);
            this.ckbRestoreData.TabIndex = 7;
            this.ckbRestoreData.Text = "Restore Data";
            this.ckbRestoreData.UseVisualStyleBackColor = true;
            this.ckbRestoreData.CheckedChanged += new System.EventHandler(this.ckbRestoreData_CheckedChanged);
            // 
            // ckbFlashGApps
            // 
            this.ckbFlashGApps.AutoSize = true;
            this.ckbFlashGApps.Enabled = false;
            this.ckbFlashGApps.Location = new System.Drawing.Point(102, 73);
            this.ckbFlashGApps.Name = "ckbFlashGApps";
            this.ckbFlashGApps.Size = new System.Drawing.Size(86, 17);
            this.ckbFlashGApps.TabIndex = 6;
            this.ckbFlashGApps.Text = "Flash GApps";
            this.ckbFlashGApps.UseVisualStyleBackColor = true;
            this.ckbFlashGApps.CheckedChanged += new System.EventHandler(this.ckbFlashGApps_CheckedChanged);
            // 
            // ckbFlashMagisk
            // 
            this.ckbFlashMagisk.AutoSize = true;
            this.ckbFlashMagisk.Enabled = false;
            this.ckbFlashMagisk.Location = new System.Drawing.Point(102, 97);
            this.ckbFlashMagisk.Name = "ckbFlashMagisk";
            this.ckbFlashMagisk.Size = new System.Drawing.Size(88, 17);
            this.ckbFlashMagisk.TabIndex = 5;
            this.ckbFlashMagisk.Text = "Flash Magisk";
            this.ckbFlashMagisk.UseVisualStyleBackColor = true;
            this.ckbFlashMagisk.CheckedChanged += new System.EventHandler(this.ckbFlashMagisk_CheckedChanged);
            // 
            // ckbFlashROM
            // 
            this.ckbFlashROM.AutoSize = true;
            this.ckbFlashROM.Enabled = false;
            this.ckbFlashROM.Location = new System.Drawing.Point(102, 49);
            this.ckbFlashROM.Name = "ckbFlashROM";
            this.ckbFlashROM.Size = new System.Drawing.Size(79, 17);
            this.ckbFlashROM.TabIndex = 4;
            this.ckbFlashROM.Text = "Flash ROM";
            this.ckbFlashROM.UseVisualStyleBackColor = true;
            this.ckbFlashROM.CheckedChanged += new System.EventHandler(this.ckbFlashROM_CheckedChanged);
            // 
            // btnFlash
            // 
            this.btnFlash.Location = new System.Drawing.Point(345, 75);
            this.btnFlash.Name = "btnFlash";
            this.btnFlash.Size = new System.Drawing.Size(161, 39);
            this.btnFlash.TabIndex = 3;
            this.btnFlash.Text = "Flash";
            this.btnFlash.UseVisualStyleBackColor = true;
            this.btnFlash.Click += new System.EventHandler(this.btnFlash_Click);
            // 
            // btnGetDevices
            // 
            this.btnGetDevices.Location = new System.Drawing.Point(345, 19);
            this.btnGetDevices.Name = "btnGetDevices";
            this.btnGetDevices.Size = new System.Drawing.Size(124, 23);
            this.btnGetDevices.TabIndex = 2;
            this.btnGetDevices.Text = "Get Devices (fastboot)";
            this.btnGetDevices.UseVisualStyleBackColor = true;
            this.btnGetDevices.Click += new System.EventHandler(this.button1_Click);
            // 
            // cbbDevices
            // 
            this.cbbDevices.FormattingEnabled = true;
            this.cbbDevices.Location = new System.Drawing.Point(102, 21);
            this.cbbDevices.Name = "cbbDevices";
            this.cbbDevices.Size = new System.Drawing.Size(237, 21);
            this.cbbDevices.TabIndex = 1;
            this.cbbDevices.SelectedIndexChanged += new System.EventHandler(this.cbbDevices_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Devices: ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(518, 376);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "ZFlash";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox ckbFlashGApps;
        private System.Windows.Forms.CheckBox ckbFlashMagisk;
        private System.Windows.Forms.CheckBox ckbFlashROM;
        private System.Windows.Forms.Button btnFlash;
        private System.Windows.Forms.Button btnGetDevices;
        private System.Windows.Forms.ComboBox cbbDevices;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txbLog;
        private System.Windows.Forms.CheckBox ckbRestoreData;
    }
}

