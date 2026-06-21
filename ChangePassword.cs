using DVLD_BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_System
{
    public partial class ChangePassword : Form
    {
        private clsUser _User;
        int _UserID = -1;
        public ChangePassword()
        {
            InitializeComponent();
            _UserID = clsGlobal.CurrentUser.UserID;
        }
        public ChangePassword(int UserID)
        {
            InitializeComponent();
            _UserID = UserID;
        }
        private void ChangePassword_Load(object sender, EventArgs e)
        {

            _User = clsUser.Find(_UserID);
            if (_User == null)
            {
                MessageBox.Show("Could not find user data!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
            pepoelInfoControl1.LoadPerson(_User.PersonID);
            pepoelInfoControl1.ShowCloseButton = false;
            labelResultUserID.Text = _User.UserID.ToString();
            labelResultUserName.Text = _User.UserName;
            if (_User.IsActive == true)
            {
                labelResultStatus.Text = "Active";
            }
            else
            {
                labelResultStatus.Text = "Deactive";
            }
           
        }
        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void _ComfirmPasswordValidation(object sender, CancelEventArgs e)
        {
            if (textBoxComfirmPassword.Text != textBoxNewPassword.Text)
            {
                e.Cancel = true;
                errorProvider1.SetError(textBoxComfirmPassword, "Password not match");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(textBoxComfirmPassword, "");
            }


        }
        private void _NotEmptyValidation(object sender, CancelEventArgs e)
        {
            TextBox temp = (TextBox)sender;
            if (string.IsNullOrWhiteSpace(temp.Text))
            {
                e.Cancel = false;
                errorProvider1.SetError(temp, "This Cannot be Empty");

            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(temp, "");
            }

        }
        private void _CurrentPasswordValidation(object sender, CancelEventArgs e)
        {
            if (textBoxCurrentPassword.Text != _User.Password)
            {
                e.Cancel = true;
                errorProvider1.SetError(textBoxCurrentPassword, "Wrong password");
            }
            else
            {
               
                    e.Cancel = false;
                    errorProvider1.SetError(textBoxCurrentPassword, "");
                
            }
        }
        private void buttonSave_Click(object sender, EventArgs e)
        {
          
            _User.Password = textBoxComfirmPassword.Text;

            if (_User.Save())
            {
                MessageBox.Show("Password changed successfully", "Password changed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Erro Password NOT changed successfully", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
    }
}
