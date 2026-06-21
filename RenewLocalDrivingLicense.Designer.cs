namespace DVLD_System
{
    partial class RenewLocalDrivingLicense
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
            this.labelRenewLocalDriverLicense = new System.Windows.Forms.Label();
            this.buttonClose = new System.Windows.Forms.Button();
            this.buttonRenew = new System.Windows.Forms.Button();
            this.linkLabelShowLicenseInfo = new System.Windows.Forms.LinkLabel();
            this.linkLabelShowLicenseHistory = new System.Windows.Forms.LinkLabel();
            this.applicationNewLicenseInfo1 = new DVLD_System.ApplicationNewLicenseInfo();
            this.filterLicenseInfo1 = new DVLD_System.FilterLicenseInfo();
            this.SuspendLayout();
            // 
            // labelRenewLocalDriverLicense
            // 
            this.labelRenewLocalDriverLicense.AutoSize = true;
            this.labelRenewLocalDriverLicense.Font = new System.Drawing.Font("Tahoma", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRenewLocalDriverLicense.ForeColor = System.Drawing.Color.DarkRed;
            this.labelRenewLocalDriverLicense.Location = new System.Drawing.Point(155, 19);
            this.labelRenewLocalDriverLicense.Name = "labelRenewLocalDriverLicense";
            this.labelRenewLocalDriverLicense.Size = new System.Drawing.Size(735, 45);
            this.labelRenewLocalDriverLicense.TabIndex = 2;
            this.labelRenewLocalDriverLicense.Text = "RENEW LOCAL LICENSE APPLICATION";
            // 
            // buttonClose
            // 
            this.buttonClose.BackgroundImage = global::DVLD_System.Properties.Resources.close;
            this.buttonClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.buttonClose.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonClose.Location = new System.Drawing.Point(685, 900);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(147, 41);
            this.buttonClose.TabIndex = 35;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // buttonRenew
            // 
            this.buttonRenew.BackgroundImage = global::DVLD_System.Properties.Resources.renew32;
            this.buttonRenew.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.buttonRenew.Enabled = false;
            this.buttonRenew.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRenew.Location = new System.Drawing.Point(838, 900);
            this.buttonRenew.Name = "buttonRenew";
            this.buttonRenew.Size = new System.Drawing.Size(147, 41);
            this.buttonRenew.TabIndex = 34;
            this.buttonRenew.Text = "Renew";
            this.buttonRenew.UseVisualStyleBackColor = true;
            this.buttonRenew.Click += new System.EventHandler(this.buttonRenew_Click);
            // 
            // linkLabelShowLicenseInfo
            // 
            this.linkLabelShowLicenseInfo.AutoSize = true;
            this.linkLabelShowLicenseInfo.Enabled = false;
            this.linkLabelShowLicenseInfo.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabelShowLicenseInfo.Location = new System.Drawing.Point(209, 912);
            this.linkLabelShowLicenseInfo.Name = "linkLabelShowLicenseInfo";
            this.linkLabelShowLicenseInfo.Size = new System.Drawing.Size(150, 19);
            this.linkLabelShowLicenseInfo.TabIndex = 37;
            this.linkLabelShowLicenseInfo.TabStop = true;
            this.linkLabelShowLicenseInfo.Text = "Show License Info";
            this.linkLabelShowLicenseInfo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelShowLicenseInfo_LinkClicked);
            // 
            // linkLabelShowLicenseHistory
            // 
            this.linkLabelShowLicenseHistory.AutoSize = true;
            this.linkLabelShowLicenseHistory.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabelShowLicenseHistory.Location = new System.Drawing.Point(17, 912);
            this.linkLabelShowLicenseHistory.Name = "linkLabelShowLicenseHistory";
            this.linkLabelShowLicenseHistory.Size = new System.Drawing.Size(176, 19);
            this.linkLabelShowLicenseHistory.TabIndex = 36;
            this.linkLabelShowLicenseHistory.TabStop = true;
            this.linkLabelShowLicenseHistory.Text = "Show License History";
            this.linkLabelShowLicenseHistory.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelShowLicenseHistory_LinkClicked);
            // 
            // applicationNewLicenseInfo1
            // 
            this.applicationNewLicenseInfo1.BackColor = System.Drawing.Color.White;
            this.applicationNewLicenseInfo1.Enabled = false;
            this.applicationNewLicenseInfo1.Location = new System.Drawing.Point(17, 565);
            this.applicationNewLicenseInfo1.Name = "applicationNewLicenseInfo1";
            this.applicationNewLicenseInfo1.Size = new System.Drawing.Size(983, 331);
            this.applicationNewLicenseInfo1.TabIndex = 38;
            // 
            // filterLicenseInfo1
            // 
            this.filterLicenseInfo1.BackColor = System.Drawing.Color.White;
            this.filterLicenseInfo1.Location = new System.Drawing.Point(12, 61);
            this.filterLicenseInfo1.Name = "filterLicenseInfo1";
            this.filterLicenseInfo1.Size = new System.Drawing.Size(988, 504);
            this.filterLicenseInfo1.TabIndex = 3;
            // 
            // RenewLocalDrivingLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1020, 951);
            this.Controls.Add(this.applicationNewLicenseInfo1);
            this.Controls.Add(this.linkLabelShowLicenseInfo);
            this.Controls.Add(this.linkLabelShowLicenseHistory);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.buttonRenew);
            this.Controls.Add(this.filterLicenseInfo1);
            this.Controls.Add(this.labelRenewLocalDriverLicense);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RenewLocalDrivingLicense";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Renew Local Driving License";
            this.Load += new System.EventHandler(this.RenewLocalDrivingLicense_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelRenewLocalDriverLicense;
        private FilterLicenseInfo filterLicenseInfo1;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Button buttonRenew;
        private System.Windows.Forms.LinkLabel linkLabelShowLicenseInfo;
        private System.Windows.Forms.LinkLabel linkLabelShowLicenseHistory;
        private ApplicationNewLicenseInfo applicationNewLicenseInfo1;
    }
}