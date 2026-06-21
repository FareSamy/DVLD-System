namespace DVLD_System
{
    partial class LicenseInfo
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
            this.labelDriverLicenseInfo = new System.Windows.Forms.Label();
            this.buttonClose = new System.Windows.Forms.Button();
            this.driverLicenseInfo1 = new DVLD_System.DriverLicenseInfo();
            this.SuspendLayout();
            // 
            // labelDriverLicenseInfo
            // 
            this.labelDriverLicenseInfo.AutoSize = true;
            this.labelDriverLicenseInfo.Font = new System.Drawing.Font("Tahoma", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDriverLicenseInfo.ForeColor = System.Drawing.Color.DarkRed;
            this.labelDriverLicenseInfo.Location = new System.Drawing.Point(235, 27);
            this.labelDriverLicenseInfo.Name = "labelDriverLicenseInfo";
            this.labelDriverLicenseInfo.Size = new System.Drawing.Size(449, 45);
            this.labelDriverLicenseInfo.TabIndex = 1;
            this.labelDriverLicenseInfo.Text = "DRIVER LICENSE INFO";
            // 
            // buttonClose
            // 
            this.buttonClose.BackgroundImage = global::DVLD_System.Properties.Resources.close;
            this.buttonClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.buttonClose.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonClose.Location = new System.Drawing.Point(822, 503);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(147, 41);
            this.buttonClose.TabIndex = 39;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // driverLicenseInfo1
            // 
            this.driverLicenseInfo1.BackColor = System.Drawing.Color.White;
            this.driverLicenseInfo1.Location = new System.Drawing.Point(-1, 99);
            this.driverLicenseInfo1.Name = "driverLicenseInfo1";
            this.driverLicenseInfo1.Size = new System.Drawing.Size(970, 407);
            this.driverLicenseInfo1.TabIndex = 0;
            // 
            // LicenseInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(991, 552);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.labelDriverLicenseInfo);
            this.Controls.Add(this.driverLicenseInfo1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LicenseInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LicenseInfo";
            this.Load += new System.EventHandler(this.LicenseInfo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DriverLicenseInfo driverLicenseInfo1;
        private System.Windows.Forms.Label labelDriverLicenseInfo;
        private System.Windows.Forms.Button buttonClose;
    }
}