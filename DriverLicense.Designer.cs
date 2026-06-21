namespace DVLD_System
{
    partial class DriverLicense
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBoxDriverLicense = new System.Windows.Forms.GroupBox();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.labelLocalLisenceHistory = new System.Windows.Forms.Label();
            this.labelRecords = new System.Windows.Forms.Label();
            this.labelRecordCountLocal = new System.Windows.Forms.Label();
            this.dataGridViewLocalLicenseHistory = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.labelInterNationalHistory = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labelRecordCountInternational = new System.Windows.Forms.Label();
            this.dataGridViewInternationalLicenseHistory = new System.Windows.Forms.DataGridView();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBoxDriverLicense.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLocalLicenseHistory)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInternationalLicenseHistory)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.contextMenuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxDriverLicense
            // 
            this.groupBoxDriverLicense.Controls.Add(this.tabControl);
            this.groupBoxDriverLicense.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxDriverLicense.Location = new System.Drawing.Point(3, 3);
            this.groupBoxDriverLicense.Name = "groupBoxDriverLicense";
            this.groupBoxDriverLicense.Size = new System.Drawing.Size(1038, 383);
            this.groupBoxDriverLicense.TabIndex = 0;
            this.groupBoxDriverLicense.TabStop = false;
            this.groupBoxDriverLicense.Text = "Driver License";
            // 
            // tabControl
            // 
            this.tabControl.AccessibleName = "";
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Controls.Add(this.tabPage2);
            this.tabControl.Location = new System.Drawing.Point(6, 28);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1033, 350);
            this.tabControl.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.labelLocalLisenceHistory);
            this.tabPage1.Controls.Add(this.labelRecords);
            this.tabPage1.Controls.Add(this.labelRecordCountLocal);
            this.tabPage1.Controls.Add(this.dataGridViewLocalLicenseHistory);
            this.tabPage1.Location = new System.Drawing.Point(4, 31);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1025, 315);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Local";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // labelLocalLisenceHistory
            // 
            this.labelLocalLisenceHistory.AutoSize = true;
            this.labelLocalLisenceHistory.Location = new System.Drawing.Point(13, 11);
            this.labelLocalLisenceHistory.Name = "labelLocalLisenceHistory";
            this.labelLocalLisenceHistory.Size = new System.Drawing.Size(196, 22);
            this.labelLocalLisenceHistory.TabIndex = 43;
            this.labelLocalLisenceHistory.Text = "Local License History:";
            // 
            // labelRecords
            // 
            this.labelRecords.AutoSize = true;
            this.labelRecords.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRecords.Location = new System.Drawing.Point(23, 289);
            this.labelRecords.Name = "labelRecords";
            this.labelRecords.Size = new System.Drawing.Size(114, 24);
            this.labelRecords.TabIndex = 42;
            this.labelRecords.Text = "#Records:";
            // 
            // labelRecordCountLocal
            // 
            this.labelRecordCountLocal.AutoSize = true;
            this.labelRecordCountLocal.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRecordCountLocal.Location = new System.Drawing.Point(139, 289);
            this.labelRecordCountLocal.Name = "labelRecordCountLocal";
            this.labelRecordCountLocal.Size = new System.Drawing.Size(34, 24);
            this.labelRecordCountLocal.TabIndex = 41;
            this.labelRecordCountLocal.Text = "00";
            // 
            // dataGridViewLocalLicenseHistory
            // 
            this.dataGridViewLocalLicenseHistory.AllowUserToAddRows = false;
            this.dataGridViewLocalLicenseHistory.AllowUserToDeleteRows = false;
            this.dataGridViewLocalLicenseHistory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewLocalLicenseHistory.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewLocalLicenseHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewLocalLicenseHistory.ContextMenuStrip = this.contextMenuStrip1;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.PaleGreen;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewLocalLicenseHistory.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewLocalLicenseHistory.Location = new System.Drawing.Point(17, 36);
            this.dataGridViewLocalLicenseHistory.Name = "dataGridViewLocalLicenseHistory";
            this.dataGridViewLocalLicenseHistory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewLocalLicenseHistory.Size = new System.Drawing.Size(990, 247);
            this.dataGridViewLocalLicenseHistory.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.labelInterNationalHistory);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.labelRecordCountInternational);
            this.tabPage2.Controls.Add(this.dataGridViewInternationalLicenseHistory);
            this.tabPage2.Location = new System.Drawing.Point(4, 31);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1025, 315);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "International";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // labelInterNationalHistory
            // 
            this.labelInterNationalHistory.AutoSize = true;
            this.labelInterNationalHistory.Location = new System.Drawing.Point(15, 6);
            this.labelInterNationalHistory.Name = "labelInterNationalHistory";
            this.labelInterNationalHistory.Size = new System.Drawing.Size(252, 22);
            this.labelInterNationalHistory.TabIndex = 47;
            this.labelInterNationalHistory.Text = "International License History:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(25, 284);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 24);
            this.label2.TabIndex = 46;
            this.label2.Text = "#Records:";
            // 
            // labelRecordCountInternational
            // 
            this.labelRecordCountInternational.AutoSize = true;
            this.labelRecordCountInternational.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRecordCountInternational.Location = new System.Drawing.Point(141, 284);
            this.labelRecordCountInternational.Name = "labelRecordCountInternational";
            this.labelRecordCountInternational.Size = new System.Drawing.Size(34, 24);
            this.labelRecordCountInternational.TabIndex = 45;
            this.labelRecordCountInternational.Text = "00";
            // 
            // dataGridViewInternationalLicenseHistory
            // 
            this.dataGridViewInternationalLicenseHistory.AllowUserToAddRows = false;
            this.dataGridViewInternationalLicenseHistory.AllowUserToDeleteRows = false;
            this.dataGridViewInternationalLicenseHistory.AllowUserToResizeRows = false;
            this.dataGridViewInternationalLicenseHistory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewInternationalLicenseHistory.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewInternationalLicenseHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewInternationalLicenseHistory.ContextMenuStrip = this.contextMenuStrip2;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.PaleGreen;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewInternationalLicenseHistory.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewInternationalLicenseHistory.Location = new System.Drawing.Point(19, 31);
            this.dataGridViewInternationalLicenseHistory.Name = "dataGridViewInternationalLicenseHistory";
            this.dataGridViewInternationalLicenseHistory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewInternationalLicenseHistory.Size = new System.Drawing.Size(990, 247);
            this.dataGridViewInternationalLicenseHistory.TabIndex = 44;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(25, 25);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showLicenseToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(185, 36);
            // 
            // showLicenseToolStripMenuItem
            // 
            this.showLicenseToolStripMenuItem.Image = global::DVLD_System.Properties.Resources.info;
            this.showLicenseToolStripMenuItem.Name = "showLicenseToolStripMenuItem";
            this.showLicenseToolStripMenuItem.Size = new System.Drawing.Size(184, 32);
            this.showLicenseToolStripMenuItem.Text = "Show License Info";
            this.showLicenseToolStripMenuItem.Click += new System.EventHandler(this.showLicenseToolStripMenuItem_Click);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contextMenuStrip2.ImageScalingSize = new System.Drawing.Size(25, 25);
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.contextMenuStrip2.Name = "contextMenuStrip1";
            this.contextMenuStrip2.Size = new System.Drawing.Size(190, 58);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Image = global::DVLD_System.Properties.Resources.info;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(189, 32);
            this.toolStripMenuItem1.Text = "Show License Info";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // DriverLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.groupBoxDriverLicense);
            this.Name = "DriverLicense";
            this.Size = new System.Drawing.Size(1048, 389);
            this.groupBoxDriverLicense.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLocalLicenseHistory)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInternationalLicenseHistory)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.contextMenuStrip2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxDriverLicense;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView dataGridViewLocalLicenseHistory;
        private System.Windows.Forms.Label labelLocalLisenceHistory;
        private System.Windows.Forms.Label labelRecords;
        private System.Windows.Forms.Label labelRecordCountLocal;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label labelInterNationalHistory;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelRecordCountInternational;
        private System.Windows.Forms.DataGridView dataGridViewInternationalLicenseHistory;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem showLicenseToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
    }
}
