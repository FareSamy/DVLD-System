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
    public partial class LoginScreen : Form
    {
       
        public LoginScreen()
        {
            InitializeComponent();
            _LoginScreenLoad();
        }
        private void _LoginScreenLoad()
        {
            if (Properties.Settings.Default.IsRemembered)
            {
                textBoxUserName.Text = Properties.Settings.Default.UserName;
                textBoxPassword.Text = Properties.Settings.Default.Password;
                checkBoxRememberMe.Checked = true;
            }
        }
        private void buttonClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
            this.Close();
        }
        private void buttonLogin_Click(object sender, EventArgs e)
        {
            string UserName = textBoxUserName.Text;
            string Password = textBoxPassword.Text;
            clsUser User = clsUser.Find(UserName);
            clsGlobal.CurrentUser = User;
            
            if (User != null && User.UserName == textBoxUserName.Text && User.Password == textBoxPassword.Text)
            {
                if (User.IsActive)
                {
                    if (checkBoxRememberMe.Checked)
                    {
                        Properties.Settings.Default.UserName = textBoxUserName.Text.Trim();
                        Properties.Settings.Default.Password = textBoxPassword.Text.Trim();
                        Properties.Settings.Default.IsRemembered = true;
                    }
                    else
                    {
                        Properties.Settings.Default.UserName = "";
                        Properties.Settings.Default.Password = "";
                        Properties.Settings.Default.IsRemembered = false;
                    }
                    Properties.Settings.Default.Save();
                    clsGlobal.CurrentUser = User;
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else 
                {
                    MessageBox.Show("Your account deactiveted please contact your admin!","Wrong Credintiais",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
              
            }
            else
            {
                MessageBox.Show("Wrong Username/Password!", "Wrong Credintiais", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void LoginScreen_Load(object sender, EventArgs e)
        {

        }
    }
}
