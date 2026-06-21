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
    public partial class UpdateUser : Form
    {
        int _UserID = -1;
        clsUser _User;
        public UpdateUser(int UserID)
        {
            InitializeComponent();
             _UserID = UserID;
            _User = clsUser.Find(_UserID);
        }

        private void UpdateUser_Load(object sender, EventArgs e)
        {
            
            if (_User != null)
            {
                labelResultUserID.Text = _User.UserID.ToString();
                textBoxUserName.Text = _User.UserName;
                textBoxPassword.Text = _User.Password;
                textBoxComfirmPassword.Text = _User.Password;
                if (_User.IsActive == true)
                {
                    checkBoxIsActive.Checked = true;
                }
                else
                {
                    checkBoxIsActive.Checked = false;
                }
            }
            else
            {
                MessageBox.Show("No user founded please enter vaild user ID", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void _UserNameValidation(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxUserName.Text.Trim()))
            {
                if (textBoxUserName.Focused || ((Control)sender).Parent.ContainsFocus)
                {
                    e.Cancel = false;
                    errorProvider1.SetError(textBoxUserName, "This Cannot be Empty");
                }

            }
            else if (clsUser.IsUserNameExist(textBoxUserName.Text.Trim()))
            {
                if (textBoxUserName.Text == _User.UserName)
                {
                    
                }
                else
                {
                    e.Cancel = false;
                    errorProvider1.SetError(textBoxUserName, "UserName is Used For Another User");
                }
              //  e.Cancel = false;
                //errorProvider1.SetError(textBoxUserName, "UserName is Used For Another User");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(textBoxUserName, "");
            }

        }

        private void _ComfirmPasswordValidation(object sender, CancelEventArgs e)
        {
            if (textBoxComfirmPassword.Text != textBoxPassword.Text)
            {
                e.Cancel = false;
                errorProvider1.SetError(textBoxComfirmPassword, "Password not match");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(textBoxComfirmPassword, "");
            }


        }
        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (textBoxPassword.Text != textBoxComfirmPassword.Text)
            {
                errorProvider1.SetError(textBoxComfirmPassword, "Password Confirmation does not match!");
                MessageBox.Show("Please confirm your password correctly.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _User.UserName = textBoxUserName.Text;
            _User.Password = textBoxComfirmPassword.Text;
            if (checkBoxIsActive.Checked)
            {
                _User.IsActive = true;
            }
            else
            {
                _User.IsActive = false;
            }
            if (_User.Save())
            {
               
                MessageBox.Show("User Updated successfully", "User update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
               // UsersScreen frm = new UsersScreen();
                //frm.ShowDialog();
                
            }
            else
            {
                MessageBox.Show("Faild to update iser", "User update", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
    }
}
