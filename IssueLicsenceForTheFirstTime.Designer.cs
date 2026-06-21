namespace DVLD_System
{
    partial class IssueLicsenceForTheFirstTime
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
            this.textBoxNotes = new System.Windows.Forms.TextBox();
            this.labelNotes = new System.Windows.Forms.Label();
            this.pictureBoxNotes = new System.Windows.Forms.PictureBox();
            this.buttonClose = new System.Windows.Forms.Button();
            this.buttonIssue = new System.Windows.Forms.Button();
            this.licensApplicationInfo1 = new DVLD_System.LicensApplicationInfo();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxNotes)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxNotes
            // 
            this.textBoxNotes.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxNotes.Location = new System.Drawing.Point(203, 527);
            this.textBoxNotes.Multiline = true;
            this.textBoxNotes.Name = "textBoxNotes";
            this.textBoxNotes.Size = new System.Drawing.Size(816, 119);
            this.textBoxNotes.TabIndex = 1;
            // 
            // labelNotes
            // 
            this.labelNotes.AutoSize = true;
            this.labelNotes.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNotes.Location = new System.Drawing.Point(71, 534);
            this.labelNotes.Name = "labelNotes";
            this.labelNotes.Size = new System.Drawing.Size(75, 22);
            this.labelNotes.TabIndex = 2;
            this.labelNotes.Text = "Notes :";
            // 
            // pictureBoxNotes
            // 
            this.pictureBoxNotes.BackgroundImage = global::DVLD_System.Properties.Resources.notes;
            this.pictureBoxNotes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBoxNotes.Location = new System.Drawing.Point(152, 534);
            this.pictureBoxNotes.Name = "pictureBoxNotes";
            this.pictureBoxNotes.Size = new System.Drawing.Size(25, 26);
            this.pictureBoxNotes.TabIndex = 3;
            this.pictureBoxNotes.TabStop = false;
            // 
            // buttonClose
            // 
            this.buttonClose.BackgroundImage = global::DVLD_System.Properties.Resources.close;
            this.buttonClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.buttonClose.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonClose.Location = new System.Drawing.Point(719, 671);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(147, 41);
            this.buttonClose.TabIndex = 38;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // buttonIssue
            // 
            this.buttonIssue.BackgroundImage = global::DVLD_System.Properties.Resources.id_card;
            this.buttonIssue.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.buttonIssue.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonIssue.Location = new System.Drawing.Point(872, 671);
            this.buttonIssue.Name = "buttonIssue";
            this.buttonIssue.Size = new System.Drawing.Size(147, 41);
            this.buttonIssue.TabIndex = 37;
            this.buttonIssue.Text = "Issue";
            this.buttonIssue.UseVisualStyleBackColor = true;
            this.buttonIssue.Click += new System.EventHandler(this.buttonIssue_Click);
            // 
            // licensApplicationInfo1
            // 
            this.licensApplicationInfo1.BackColor = System.Drawing.Color.White;
            this.licensApplicationInfo1.Location = new System.Drawing.Point(12, 12);
            this.licensApplicationInfo1.Name = "licensApplicationInfo1";
            this.licensApplicationInfo1.Size = new System.Drawing.Size(1027, 509);
            this.licensApplicationInfo1.TabIndex = 0;
            // 
            // IssueLicsenceForTheFirstTime
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1058, 724);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.buttonIssue);
            this.Controls.Add(this.pictureBoxNotes);
            this.Controls.Add(this.labelNotes);
            this.Controls.Add(this.textBoxNotes);
            this.Controls.Add(this.licensApplicationInfo1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "IssueLicsenceForTheFirstTime";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Issue Licsence For The First Time";
            this.Load += new System.EventHandler(this.IssueLicsenceForTheFirstTime_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxNotes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private LicensApplicationInfo licensApplicationInfo1;
        private System.Windows.Forms.TextBox textBoxNotes;
        private System.Windows.Forms.Label labelNotes;
        private System.Windows.Forms.PictureBox pictureBoxNotes;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Button buttonIssue;
    }
}