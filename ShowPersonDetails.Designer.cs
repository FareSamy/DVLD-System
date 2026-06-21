namespace DVLD_System
{
    partial class ShowPersonDetails
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
            this.labelPersonDetails = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // pepoelInfoControl1
            // 
            this.pepoelInfoControl1.BackColor = System.Drawing.Color.White;
            this.pepoelInfoControl1.Location = new System.Drawing.Point(-8, 64);
            this.pepoelInfoControl1.Name = "pepoelInfoControl1";
            this.pepoelInfoControl1.ShowCloseButton = true;
            this.pepoelInfoControl1.Size = new System.Drawing.Size(1071, 346);
            this.pepoelInfoControl1.TabIndex = 0;
            // 
            // labelPersonDetails
            // 
            this.labelPersonDetails.AutoSize = true;
            this.labelPersonDetails.Font = new System.Drawing.Font("Tahoma", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPersonDetails.ForeColor = System.Drawing.Color.DarkRed;
            this.labelPersonDetails.Location = new System.Drawing.Point(342, 25);
            this.labelPersonDetails.Name = "labelPersonDetails";
            this.labelPersonDetails.Size = new System.Drawing.Size(327, 42);
            this.labelPersonDetails.TabIndex = 1;
            this.labelPersonDetails.Text = "PERSON DETAILS";
            // 
            // ShowDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1055, 414);
            this.Controls.Add(this.labelPersonDetails);
            this.Controls.Add(this.pepoelInfoControl1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ShowDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Person Details";
            this.Load += new System.EventHandler(this.ShowDetails_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PepoelInfoControl pepoelInfoControl1;
        private System.Windows.Forms.Label labelPersonDetails;
    }
}