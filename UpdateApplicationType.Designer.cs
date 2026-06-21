namespace DVLD_System
{
    partial class UpdateApplicationType
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
            this.labelUpdateApplicationTypes = new System.Windows.Forms.Label();
            this.labelID = new System.Windows.Forms.Label();
            this.labelTitle = new System.Windows.Forms.Label();
            this.labelFees = new System.Windows.Forms.Label();
            this.buttonClose = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.textBoxTitle = new System.Windows.Forms.TextBox();
            this.textBoxFees = new System.Windows.Forms.TextBox();
            this.labelIDResult = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelUpdateApplicationTypes
            // 
            this.labelUpdateApplicationTypes.AutoSize = true;
            this.labelUpdateApplicationTypes.Font = new System.Drawing.Font("Tahoma", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUpdateApplicationTypes.ForeColor = System.Drawing.Color.DarkRed;
            this.labelUpdateApplicationTypes.Location = new System.Drawing.Point(-3, 18);
            this.labelUpdateApplicationTypes.Name = "labelUpdateApplicationTypes";
            this.labelUpdateApplicationTypes.Size = new System.Drawing.Size(570, 45);
            this.labelUpdateApplicationTypes.TabIndex = 2;
            this.labelUpdateApplicationTypes.Text = "UPDATE APPLICATION TYPES";
            // 
            // labelID
            // 
            this.labelID.AutoSize = true;
            this.labelID.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelID.Location = new System.Drawing.Point(30, 99);
            this.labelID.Name = "labelID";
            this.labelID.Size = new System.Drawing.Size(43, 24);
            this.labelID.TabIndex = 3;
            this.labelID.Text = "ID :";
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitle.Location = new System.Drawing.Point(9, 141);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(65, 24);
            this.labelTitle.TabIndex = 4;
            this.labelTitle.Text = "Title :";
            // 
            // labelFees
            // 
            this.labelFees.AutoSize = true;
            this.labelFees.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFees.Location = new System.Drawing.Point(3, 192);
            this.labelFees.Name = "labelFees";
            this.labelFees.Size = new System.Drawing.Size(72, 24);
            this.labelFees.TabIndex = 5;
            this.labelFees.Text = "Fees :";
            // 
            // buttonClose
            // 
            this.buttonClose.BackgroundImage = global::DVLD_System.Properties.Resources.close;
            this.buttonClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.buttonClose.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonClose.Location = new System.Drawing.Point(252, 254);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(147, 41);
            this.buttonClose.TabIndex = 37;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.BackgroundImage = global::DVLD_System.Properties.Resources.Save32;
            this.buttonSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.buttonSave.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSave.Location = new System.Drawing.Point(405, 254);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(147, 41);
            this.buttonSave.TabIndex = 36;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // textBoxTitle
            // 
            this.textBoxTitle.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxTitle.Location = new System.Drawing.Point(75, 137);
            this.textBoxTitle.Multiline = true;
            this.textBoxTitle.Name = "textBoxTitle";
            this.textBoxTitle.Size = new System.Drawing.Size(467, 33);
            this.textBoxTitle.TabIndex = 38;
            // 
            // textBoxFees
            // 
            this.textBoxFees.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxFees.Location = new System.Drawing.Point(75, 186);
            this.textBoxFees.Multiline = true;
            this.textBoxFees.Name = "textBoxFees";
            this.textBoxFees.Size = new System.Drawing.Size(467, 33);
            this.textBoxFees.TabIndex = 39;
            // 
            // labelIDResult
            // 
            this.labelIDResult.AutoSize = true;
            this.labelIDResult.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelIDResult.Location = new System.Drawing.Point(80, 99);
            this.labelIDResult.Name = "labelIDResult";
            this.labelIDResult.Size = new System.Drawing.Size(63, 24);
            this.labelIDResult.TabIndex = 40;
            this.labelIDResult.Text = "[???]";
            // 
            // UpdateApplicationType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(564, 306);
            this.Controls.Add(this.labelIDResult);
            this.Controls.Add(this.textBoxFees);
            this.Controls.Add(this.textBoxTitle);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.labelFees);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.labelID);
            this.Controls.Add(this.labelUpdateApplicationTypes);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UpdateApplicationType";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Update Application Type";
            this.Load += new System.EventHandler(this.UpdateApplicationType_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelUpdateApplicationTypes;
        private System.Windows.Forms.Label labelID;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelFees;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.TextBox textBoxTitle;
        private System.Windows.Forms.TextBox textBoxFees;
        private System.Windows.Forms.Label labelIDResult;
    }
}