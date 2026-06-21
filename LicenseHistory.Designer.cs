namespace DVLD_System
{
    partial class LicenseHistory
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
            this.labelLicenseHistory = new System.Windows.Forms.Label();
            this.driverLicense1 = new DVLD_System.DriverLicense();
            this.pepoelInfoControl1 = new DVLD_System.PepoelInfoControl();
            this.buttonClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelLicenseHistory
            // 
            this.labelLicenseHistory.AutoSize = true;
            this.labelLicenseHistory.Font = new System.Drawing.Font("Tahoma", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLicenseHistory.ForeColor = System.Drawing.Color.DarkRed;
            this.labelLicenseHistory.Location = new System.Drawing.Point(359, 24);
            this.labelLicenseHistory.Name = "labelLicenseHistory";
            this.labelLicenseHistory.Size = new System.Drawing.Size(365, 45);
            this.labelLicenseHistory.TabIndex = 0;
            this.labelLicenseHistory.Text = "LICENSE HISTORY";
            // 
            // driverLicense1
            // 
            this.driverLicense1.BackColor = System.Drawing.Color.White;
            this.driverLicense1.Location = new System.Drawing.Point(12, 453);
            this.driverLicense1.Name = "driverLicense1";
            this.driverLicense1.Size = new System.Drawing.Size(1048, 389);
            this.driverLicense1.TabIndex = 2;
            // 
            // pepoelInfoControl1
            // 
            this.pepoelInfoControl1.BackColor = System.Drawing.Color.White;
            this.pepoelInfoControl1.Location = new System.Drawing.Point(12, 84);
            this.pepoelInfoControl1.Name = "pepoelInfoControl1";
            this.pepoelInfoControl1.ShowCloseButton = true;
            this.pepoelInfoControl1.Size = new System.Drawing.Size(1071, 350);
            this.pepoelInfoControl1.TabIndex = 1;
            // 
            // buttonClose
            // 
            this.buttonClose.BackgroundImage = global::DVLD_System.Properties.Resources.close;
            this.buttonClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.buttonClose.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonClose.Location = new System.Drawing.Point(913, 830);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(147, 41);
            this.buttonClose.TabIndex = 39;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // LicenseHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1112, 883);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.driverLicense1);
            this.Controls.Add(this.pepoelInfoControl1);
            this.Controls.Add(this.labelLicenseHistory);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LicenseHistory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "License History";
            this.Load += new System.EventHandler(this.LicenseHistory_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelLicenseHistory;
        private PepoelInfoControl pepoelInfoControl1;
        private DriverLicense driverLicense1;
        private System.Windows.Forms.Button buttonClose;
    }
}