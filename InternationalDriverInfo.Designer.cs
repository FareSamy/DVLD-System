namespace DVLD_System
{
    partial class InternationalDriverInfo
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
            this.internationalDriverLicenseInfo1 = new DVLD_System.InternationalDriverLicenseInfo();
            this.labelDriverInternationalLicenseInfo = new System.Windows.Forms.Label();
            this.buttonClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // internationalDriverLicenseInfo1
            // 
            this.internationalDriverLicenseInfo1.BackColor = System.Drawing.Color.White;
            this.internationalDriverLicenseInfo1.Location = new System.Drawing.Point(3, 80);
            this.internationalDriverLicenseInfo1.Name = "internationalDriverLicenseInfo1";
            this.internationalDriverLicenseInfo1.Size = new System.Drawing.Size(988, 411);
            this.internationalDriverLicenseInfo1.TabIndex = 0;
            // 
            // labelDriverInternationalLicenseInfo
            // 
            this.labelDriverInternationalLicenseInfo.AutoSize = true;
            this.labelDriverInternationalLicenseInfo.Font = new System.Drawing.Font("Tahoma", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDriverInternationalLicenseInfo.ForeColor = System.Drawing.Color.DarkRed;
            this.labelDriverInternationalLicenseInfo.Location = new System.Drawing.Point(121, 22);
            this.labelDriverInternationalLicenseInfo.Name = "labelDriverInternationalLicenseInfo";
            this.labelDriverInternationalLicenseInfo.Size = new System.Drawing.Size(778, 45);
            this.labelDriverInternationalLicenseInfo.TabIndex = 2;
            this.labelDriverInternationalLicenseInfo.Text = "DRIVER INTERNATIONAL LICENSE INFO";
            // 
            // buttonClose
            // 
            this.buttonClose.BackgroundImage = global::DVLD_System.Properties.Resources.close;
            this.buttonClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.buttonClose.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonClose.Location = new System.Drawing.Point(833, 483);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(147, 41);
            this.buttonClose.TabIndex = 40;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // InternationalDriverInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1002, 536);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.labelDriverInternationalLicenseInfo);
            this.Controls.Add(this.internationalDriverLicenseInfo1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InternationalDriverInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "International Driver Info";
            this.Load += new System.EventHandler(this.InternationalDriverInfo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private InternationalDriverLicenseInfo internationalDriverLicenseInfo1;
        private System.Windows.Forms.Label labelDriverInternationalLicenseInfo;
        private System.Windows.Forms.Button buttonClose;
    }
}