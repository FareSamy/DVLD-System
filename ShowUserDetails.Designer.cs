namespace DVLD_System
{
    partial class ShowUserDetails
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
            this.pepoelInfoControl1 = new DVLD_System.PepoelInfoControl();
            this.labelMain = new System.Windows.Forms.Label();
            this.labelResultStatus = new System.Windows.Forms.Label();
            this.labelStatus = new System.Windows.Forms.Label();
            this.labelResultUserName = new System.Windows.Forms.Label();
            this.labelUserName = new System.Windows.Forms.Label();
            this.labelUserID = new System.Windows.Forms.Label();
            this.groupBoxUserInformation = new System.Windows.Forms.GroupBox();
            this.labelResultUserID = new System.Windows.Forms.Label();
            this.buttonClose = new System.Windows.Forms.Button();
            this.groupBoxUserInformation.SuspendLayout();
            this.SuspendLayout();
            // 
            // pepoelInfoControl1
            // 
            this.pepoelInfoControl1.BackColor = System.Drawing.Color.White;
            this.pepoelInfoControl1.Location = new System.Drawing.Point(-4, 65);
            this.pepoelInfoControl1.Name = "pepoelInfoControl1";
            this.pepoelInfoControl1.ShowCloseButton = true;
            this.pepoelInfoControl1.Size = new System.Drawing.Size(1071, 350);
            this.pepoelInfoControl1.TabIndex = 0;
            // 
            // labelMain
            // 
            this.labelMain.AutoSize = true;
            this.labelMain.Font = new System.Drawing.Font("Tahoma", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMain.ForeColor = System.Drawing.Color.DarkRed;
            this.labelMain.Location = new System.Drawing.Point(301, 20);
            this.labelMain.Name = "labelMain";
            this.labelMain.Size = new System.Drawing.Size(411, 45);
            this.labelMain.TabIndex = 36;
            this.labelMain.Text = "USER INFORMATION";
            // 
            // labelResultStatus
            // 
            this.labelResultStatus.AutoSize = true;
            this.labelResultStatus.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelResultStatus.Location = new System.Drawing.Point(672, 49);
            this.labelResultStatus.Name = "labelResultStatus";
            this.labelResultStatus.Size = new System.Drawing.Size(45, 24);
            this.labelResultStatus.TabIndex = 42;
            this.labelResultStatus.Text = "N/A";
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStatus.Location = new System.Drawing.Point(572, 49);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(94, 24);
            this.labelStatus.TabIndex = 41;
            this.labelStatus.Text = "Status : ";
            // 
            // labelResultUserName
            // 
            this.labelResultUserName.AutoSize = true;
            this.labelResultUserName.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelResultUserName.Location = new System.Drawing.Point(432, 50);
            this.labelResultUserName.Name = "labelResultUserName";
            this.labelResultUserName.Size = new System.Drawing.Size(111, 24);
            this.labelResultUserName.TabIndex = 40;
            this.labelResultUserName.Text = "username";
            // 
            // labelUserName
            // 
            this.labelUserName.AutoSize = true;
            this.labelUserName.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUserName.Location = new System.Drawing.Point(303, 49);
            this.labelUserName.Name = "labelUserName";
            this.labelUserName.Size = new System.Drawing.Size(132, 24);
            this.labelUserName.TabIndex = 39;
            this.labelUserName.Text = "UserName : ";
            // 
            // labelUserID
            // 
            this.labelUserID.AutoSize = true;
            this.labelUserID.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUserID.Location = new System.Drawing.Point(127, 49);
            this.labelUserID.Name = "labelUserID";
            this.labelUserID.Size = new System.Drawing.Size(95, 24);
            this.labelUserID.TabIndex = 38;
            this.labelUserID.Text = "User ID :";
            // 
            // groupBoxUserInformation
            // 
            this.groupBoxUserInformation.Controls.Add(this.labelResultUserID);
            this.groupBoxUserInformation.Controls.Add(this.labelResultStatus);
            this.groupBoxUserInformation.Controls.Add(this.labelStatus);
            this.groupBoxUserInformation.Controls.Add(this.labelResultUserName);
            this.groupBoxUserInformation.Controls.Add(this.labelUserName);
            this.groupBoxUserInformation.Controls.Add(this.labelUserID);
            this.groupBoxUserInformation.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxUserInformation.Location = new System.Drawing.Point(12, 421);
            this.groupBoxUserInformation.Name = "groupBoxUserInformation";
            this.groupBoxUserInformation.Size = new System.Drawing.Size(1030, 91);
            this.groupBoxUserInformation.TabIndex = 43;
            this.groupBoxUserInformation.TabStop = false;
            this.groupBoxUserInformation.Text = "User Information";
            // 
            // labelResultUserID
            // 
            this.labelResultUserID.AutoSize = true;
            this.labelResultUserID.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelResultUserID.Location = new System.Drawing.Point(228, 52);
            this.labelResultUserID.Name = "labelResultUserID";
            this.labelResultUserID.Size = new System.Drawing.Size(32, 22);
            this.labelResultUserID.TabIndex = 43;
            this.labelResultUserID.Text = "##";
            // 
            // buttonClose
            // 
            this.buttonClose.BackgroundImage = global::DVLD_System.Properties.Resources.close;
            this.buttonClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.buttonClose.CausesValidation = false;
            this.buttonClose.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonClose.Location = new System.Drawing.Point(895, 518);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(147, 41);
            this.buttonClose.TabIndex = 45;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // ShowUserDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1070, 570);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.groupBoxUserInformation);
            this.Controls.Add(this.labelMain);
            this.Controls.Add(this.pepoelInfoControl1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ShowUserDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "User Information";
            this.Load += new System.EventHandler(this.ShowUserDetails_Load);
            this.groupBoxUserInformation.ResumeLayout(false);
            this.groupBoxUserInformation.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PepoelInfoControl pepoelInfoControl1;
        private System.Windows.Forms.Label labelMain;
        private System.Windows.Forms.Label labelResultStatus;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.Label labelResultUserName;
        private System.Windows.Forms.Label labelUserName;
        private System.Windows.Forms.Label labelUserID;
        private System.Windows.Forms.GroupBox groupBoxUserInformation;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Label labelResultUserID;
    }
}