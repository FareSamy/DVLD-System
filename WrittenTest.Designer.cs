namespace DVLD_System
{
    partial class WrittenTest
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.labelRecords = new System.Windows.Forms.Label();
            this.labelRecordCount = new System.Windows.Forms.Label();
            this.dataGridViewAppoiments = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.takeTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.labelAppoiments = new System.Windows.Forms.Label();
            this.labelWrittrnTest = new System.Windows.Forms.Label();
            this.pictureBoxWrittenest = new System.Windows.Forms.PictureBox();
            this.buttonClose = new System.Windows.Forms.Button();
            this.buttonAddDate = new System.Windows.Forms.Button();
            this.licensApplicationInfo1 = new DVLD_System.LicensApplicationInfo();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAppoiments)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxWrittenest)).BeginInit();
            this.SuspendLayout();
            // 
            // labelRecords
            // 
            this.labelRecords.AutoSize = true;
            this.labelRecords.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRecords.Location = new System.Drawing.Point(29, 901);
            this.labelRecords.Name = "labelRecords";
            this.labelRecords.Size = new System.Drawing.Size(114, 24);
            this.labelRecords.TabIndex = 58;
            this.labelRecords.Text = "#Records:";
            // 
            // labelRecordCount
            // 
            this.labelRecordCount.AutoSize = true;
            this.labelRecordCount.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRecordCount.Location = new System.Drawing.Point(145, 901);
            this.labelRecordCount.Name = "labelRecordCount";
            this.labelRecordCount.Size = new System.Drawing.Size(34, 24);
            this.labelRecordCount.TabIndex = 57;
            this.labelRecordCount.Text = "00";
            // 
            // dataGridViewAppoiments
            // 
            this.dataGridViewAppoiments.AllowUserToAddRows = false;
            this.dataGridViewAppoiments.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewAppoiments.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewAppoiments.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewAppoiments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAppoiments.ContextMenuStrip = this.contextMenuStrip1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.PaleGoldenrod;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewAppoiments.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewAppoiments.Location = new System.Drawing.Point(30, 719);
            this.dataGridViewAppoiments.Name = "dataGridViewAppoiments";
            this.dataGridViewAppoiments.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewAppoiments.Size = new System.Drawing.Size(992, 176);
            this.dataGridViewAppoiments.TabIndex = 56;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(25, 25);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripMenuItem,
            this.takeTestToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(190, 90);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Image = global::DVLD_System.Properties.Resources.edit;
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(189, 32);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click_1);
            // 
            // takeTestToolStripMenuItem
            // 
            this.takeTestToolStripMenuItem.Image = global::DVLD_System.Properties.Resources.info;
            this.takeTestToolStripMenuItem.Name = "takeTestToolStripMenuItem";
            this.takeTestToolStripMenuItem.Size = new System.Drawing.Size(189, 32);
            this.takeTestToolStripMenuItem.Text = "Take Test";
            this.takeTestToolStripMenuItem.Click += new System.EventHandler(this.takeTestToolStripMenuItem_Click_1);
            // 
            // labelAppoiments
            // 
            this.labelAppoiments.AutoSize = true;
            this.labelAppoiments.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAppoiments.Location = new System.Drawing.Point(26, 681);
            this.labelAppoiments.Name = "labelAppoiments";
            this.labelAppoiments.Size = new System.Drawing.Size(133, 22);
            this.labelAppoiments.TabIndex = 54;
            this.labelAppoiments.Text = "Appoiments :";
            // 
            // labelWrittrnTest
            // 
            this.labelWrittrnTest.AutoSize = true;
            this.labelWrittrnTest.Font = new System.Drawing.Font("Tahoma", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelWrittrnTest.ForeColor = System.Drawing.Color.DarkRed;
            this.labelWrittrnTest.Location = new System.Drawing.Point(238, 9);
            this.labelWrittrnTest.Name = "labelWrittrnTest";
            this.labelWrittrnTest.Size = new System.Drawing.Size(592, 45);
            this.labelWrittrnTest.TabIndex = 59;
            this.labelWrittrnTest.Text = "WRITTRN TESET APPOIMENTS";
            // 
            // pictureBoxWrittenest
            // 
            this.pictureBoxWrittenest.BackgroundImage = global::DVLD_System.Properties.Resources.written_test;
            this.pictureBoxWrittenest.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBoxWrittenest.Location = new System.Drawing.Point(444, 57);
            this.pictureBoxWrittenest.Name = "pictureBoxWrittenest";
            this.pictureBoxWrittenest.Size = new System.Drawing.Size(114, 112);
            this.pictureBoxWrittenest.TabIndex = 60;
            this.pictureBoxWrittenest.TabStop = false;
            // 
            // buttonClose
            // 
            this.buttonClose.BackgroundImage = global::DVLD_System.Properties.Resources.close;
            this.buttonClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.buttonClose.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonClose.Location = new System.Drawing.Point(875, 901);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(147, 41);
            this.buttonClose.TabIndex = 55;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click_1);
            // 
            // buttonAddDate
            // 
            this.buttonAddDate.BackColor = System.Drawing.Color.White;
            this.buttonAddDate.BackgroundImage = global::DVLD_System.Properties.Resources.add_date;
            this.buttonAddDate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonAddDate.FlatAppearance.BorderSize = 0;
            this.buttonAddDate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAddDate.Location = new System.Drawing.Point(977, 657);
            this.buttonAddDate.Name = "buttonAddDate";
            this.buttonAddDate.Size = new System.Drawing.Size(46, 46);
            this.buttonAddDate.TabIndex = 53;
            this.buttonAddDate.UseVisualStyleBackColor = false;
            this.buttonAddDate.Click += new System.EventHandler(this.buttonAddDate_Click_1);
            // 
            // licensApplicationInfo1
            // 
            this.licensApplicationInfo1.BackColor = System.Drawing.Color.White;
            this.licensApplicationInfo1.Location = new System.Drawing.Point(12, 161);
            this.licensApplicationInfo1.Name = "licensApplicationInfo1";
            this.licensApplicationInfo1.Size = new System.Drawing.Size(1027, 509);
            this.licensApplicationInfo1.TabIndex = 52;
            // 
            // WrittenTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1038, 948);
            this.Controls.Add(this.pictureBoxWrittenest);
            this.Controls.Add(this.labelWrittrnTest);
            this.Controls.Add(this.labelRecords);
            this.Controls.Add(this.labelRecordCount);
            this.Controls.Add(this.dataGridViewAppoiments);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.labelAppoiments);
            this.Controls.Add(this.buttonAddDate);
            this.Controls.Add(this.licensApplicationInfo1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WrittenTest";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WrittenTest";
            this.Load += new System.EventHandler(this.WrittenTest_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAppoiments)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxWrittenest)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelRecords;
        private System.Windows.Forms.Label labelRecordCount;
        private System.Windows.Forms.DataGridView dataGridViewAppoiments;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Label labelAppoiments;
        private System.Windows.Forms.Button buttonAddDate;
        private LicensApplicationInfo licensApplicationInfo1;
        private System.Windows.Forms.PictureBox pictureBoxWrittenest;
        private System.Windows.Forms.Label labelWrittrnTest;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem takeTestToolStripMenuItem;
    }
}