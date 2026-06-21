namespace DVLD_System
{
    partial class ChangePassword
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
            this.labelChangePassword = new System.Windows.Forms.Label();
            this.labelUserInformation = new System.Windows.Forms.Label();
            this.labelUserID = new System.Windows.Forms.Label();
            this.labelResultUserID = new System.Windows.Forms.Label();
            this.labelUserName = new System.Windows.Forms.Label();
            this.labelResultUserName = new System.Windows.Forms.Label();
            this.labelStatus = new System.Windows.Forms.Label();
            this.labelResultStatus = new System.Windows.Forms.Label();
            this.labelCurrentPassword = new System.Windows.Forms.Label();
            this.labelNewPassword = new System.Windows.Forms.Label();
            this.labelComfirmPassword = new System.Windows.Forms.Label();
            this.textBoxCurrentPassword = new System.Windows.Forms.TextBox();
            this.textBoxNewPassword = new System.Windows.Forms.TextBox();
            this.textBoxComfirmPassword = new System.Windows.Forms.TextBox();
            this.pepoelInfoControl1 = new DVLD_System.PepoelInfoControl();
            this.buttonClose = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelChangePassword
            // 
            this.labelChangePassword.AutoSize = true;
            this.labelChangePassword.Font = new System.Drawing.Font("Arial Black", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelChangePassword.ForeColor = System.Drawing.Color.DarkRed;
            this.labelChangePassword.Location = new System.Drawing.Point(354, 356);
            this.labelChangePassword.Name = "labelChangePassword";
            this.labelChangePassword.Size = new System.Drawing.Size(384, 45);
            this.labelChangePassword.TabIndex = 1;
            this.labelChangePassword.Text = "CHANGE PASSWORD";
            // 
            // labelUserInformation
            // 
            this.labelUserInformation.AutoSize = true;
            this.labelUserInformation.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUserInformation.Location = new System.Drawing.Point(29, 410);
            this.labelUserInformation.Name = "labelUserInformation";
            this.labelUserInformation.Size = new System.Drawing.Size(151, 23);
            this.labelUserInformation.TabIndex = 2;
            this.labelUserInformation.Text = "User Information";
            // 
            // labelUserID
            // 
            this.labelUserID.AutoSize = true;
            this.labelUserID.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUserID.Location = new System.Drawing.Point(241, 449);
            this.labelUserID.Name = "labelUserID";
            this.labelUserID.Size = new System.Drawing.Size(95, 24);
            this.labelUserID.TabIndex = 3;
            this.labelUserID.Text = "User ID :";
            // 
            // labelResultUserID
            // 
            this.labelResultUserID.AutoSize = true;
            this.labelResultUserID.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelResultUserID.Location = new System.Drawing.Point(339, 451);
            this.labelResultUserID.Name = "labelResultUserID";
            this.labelResultUserID.Size = new System.Drawing.Size(32, 22);
            this.labelResultUserID.TabIndex = 4;
            this.labelResultUserID.Text = "##";
            // 
            // labelUserName
            // 
            this.labelUserName.AutoSize = true;
            this.labelUserName.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUserName.Location = new System.Drawing.Point(417, 449);
            this.labelUserName.Name = "labelUserName";
            this.labelUserName.Size = new System.Drawing.Size(132, 24);
            this.labelUserName.TabIndex = 5;
            this.labelUserName.Text = "UserName : ";
            // 
            // labelResultUserName
            // 
            this.labelResultUserName.AutoSize = true;
            this.labelResultUserName.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelResultUserName.Location = new System.Drawing.Point(546, 450);
            this.labelResultUserName.Name = "labelResultUserName";
            this.labelResultUserName.Size = new System.Drawing.Size(111, 24);
            this.labelResultUserName.TabIndex = 6;
            this.labelResultUserName.Text = "username";
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStatus.Location = new System.Drawing.Point(686, 449);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(94, 24);
            this.labelStatus.TabIndex = 7;
            this.labelStatus.Text = "Status : ";
            // 
            // labelResultStatus
            // 
            this.labelResultStatus.AutoSize = true;
            this.labelResultStatus.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelResultStatus.Location = new System.Drawing.Point(786, 449);
            this.labelResultStatus.Name = "labelResultStatus";
            this.labelResultStatus.Size = new System.Drawing.Size(45, 24);
            this.labelResultStatus.TabIndex = 8;
            this.labelResultStatus.Text = "N/A";
            // 
            // labelCurrentPassword
            // 
            this.labelCurrentPassword.AutoSize = true;
            this.labelCurrentPassword.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCurrentPassword.Location = new System.Drawing.Point(29, 540);
            this.labelCurrentPassword.Name = "labelCurrentPassword";
            this.labelCurrentPassword.Size = new System.Drawing.Size(204, 24);
            this.labelCurrentPassword.TabIndex = 9;
            this.labelCurrentPassword.Text = "Current Password :";
            // 
            // labelNewPassword
            // 
            this.labelNewPassword.AutoSize = true;
            this.labelNewPassword.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNewPassword.Location = new System.Drawing.Point(64, 587);
            this.labelNewPassword.Name = "labelNewPassword";
            this.labelNewPassword.Size = new System.Drawing.Size(169, 24);
            this.labelNewPassword.TabIndex = 10;
            this.labelNewPassword.Text = "New Password :";
            // 
            // labelComfirmPassword
            // 
            this.labelComfirmPassword.AutoSize = true;
            this.labelComfirmPassword.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelComfirmPassword.Location = new System.Drawing.Point(19, 633);
            this.labelComfirmPassword.Name = "labelComfirmPassword";
            this.labelComfirmPassword.Size = new System.Drawing.Size(214, 24);
            this.labelComfirmPassword.TabIndex = 11;
            this.labelComfirmPassword.Text = "Comfirm Password :";
            // 
            // textBoxCurrentPassword
            // 
            this.textBoxCurrentPassword.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxCurrentPassword.Location = new System.Drawing.Point(245, 540);
            this.textBoxCurrentPassword.Multiline = true;
            this.textBoxCurrentPassword.Name = "textBoxCurrentPassword";
            this.textBoxCurrentPassword.PasswordChar = '●';
            this.textBoxCurrentPassword.Size = new System.Drawing.Size(196, 33);
            this.textBoxCurrentPassword.TabIndex = 0;
            this.textBoxCurrentPassword.Validating += new System.ComponentModel.CancelEventHandler(this._CurrentPasswordValidation);
            // 
            // textBoxNewPassword
            // 
            this.textBoxNewPassword.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxNewPassword.Location = new System.Drawing.Point(245, 587);
            this.textBoxNewPassword.Multiline = true;
            this.textBoxNewPassword.Name = "textBoxNewPassword";
            this.textBoxNewPassword.PasswordChar = '●';
            this.textBoxNewPassword.Size = new System.Drawing.Size(196, 33);
            this.textBoxNewPassword.TabIndex = 1;
            this.textBoxNewPassword.Validating += new System.ComponentModel.CancelEventHandler(this._NotEmptyValidation);
            // 
            // textBoxComfirmPassword
            // 
            this.textBoxComfirmPassword.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxComfirmPassword.Location = new System.Drawing.Point(245, 633);
            this.textBoxComfirmPassword.Multiline = true;
            this.textBoxComfirmPassword.Name = "textBoxComfirmPassword";
            this.textBoxComfirmPassword.PasswordChar = '●';
            this.textBoxComfirmPassword.Size = new System.Drawing.Size(196, 33);
            this.textBoxComfirmPassword.TabIndex = 2;
            this.textBoxComfirmPassword.Validating += new System.ComponentModel.CancelEventHandler(this._ComfirmPasswordValidation);
            // 
            // pepoelInfoControl1
            // 
            this.pepoelInfoControl1.BackColor = System.Drawing.Color.White;
            this.pepoelInfoControl1.Location = new System.Drawing.Point(3, 4);
            this.pepoelInfoControl1.Name = "pepoelInfoControl1";
            this.pepoelInfoControl1.ShowCloseButton = true;
            this.pepoelInfoControl1.Size = new System.Drawing.Size(1071, 453);
            this.pepoelInfoControl1.TabIndex = 0;
            // 
            // buttonClose
            // 
            this.buttonClose.BackgroundImage = global::DVLD_System.Properties.Resources.close;
            this.buttonClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.buttonClose.CausesValidation = false;
            this.buttonClose.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonClose.Location = new System.Drawing.Point(752, 642);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(147, 41);
            this.buttonClose.TabIndex = 33;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.BackgroundImage = global::DVLD_System.Properties.Resources.Save32;
            this.buttonSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.buttonSave.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSave.Location = new System.Drawing.Point(905, 642);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(147, 41);
            this.buttonSave.TabIndex = 32;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // ChangePassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1098, 696);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.textBoxComfirmPassword);
            this.Controls.Add(this.textBoxNewPassword);
            this.Controls.Add(this.textBoxCurrentPassword);
            this.Controls.Add(this.labelComfirmPassword);
            this.Controls.Add(this.labelNewPassword);
            this.Controls.Add(this.labelCurrentPassword);
            this.Controls.Add(this.labelResultStatus);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.labelResultUserName);
            this.Controls.Add(this.labelUserName);
            this.Controls.Add(this.labelResultUserID);
            this.Controls.Add(this.labelUserID);
            this.Controls.Add(this.labelUserInformation);
            this.Controls.Add(this.labelChangePassword);
            this.Controls.Add(this.pepoelInfoControl1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChangePassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ChangePassword";
            this.Load += new System.EventHandler(this.ChangePassword_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PepoelInfoControl pepoelInfoControl1;
        private System.Windows.Forms.Label labelChangePassword;
        private System.Windows.Forms.Label labelUserInformation;
        private System.Windows.Forms.Label labelUserID;
        private System.Windows.Forms.Label labelResultUserID;
        private System.Windows.Forms.Label labelUserName;
        private System.Windows.Forms.Label labelResultUserName;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.Label labelResultStatus;
        private System.Windows.Forms.Label labelCurrentPassword;
        private System.Windows.Forms.Label labelNewPassword;
        private System.Windows.Forms.Label labelComfirmPassword;
        private System.Windows.Forms.TextBox textBoxCurrentPassword;
        private System.Windows.Forms.TextBox textBoxNewPassword;
        private System.Windows.Forms.TextBox textBoxComfirmPassword;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}