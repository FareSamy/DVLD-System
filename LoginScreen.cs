using DVLD_BusinessLayer;
using System;
using Microsoft.Win32;
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
            string HashedPassword = clsGlobal.ComputeHash(Password);
            
            clsUser User = clsUser.Find(UserName);
            //clsGlobal.CurrentUser = User;
            
            if (User != null && User.UserName == textBoxUserName.Text && User.Password == HashedPassword)
            {
                if (User.IsActive)
                {
                    if (checkBoxRememberMe.Checked)
                    {

                        SaveOrClearRegistryCredentials(UserName, Password, true);
                        clsGlobal.CurrentUser = User;
                    }
                    else
                    {
                       
                        SaveOrClearRegistryCredentials(UserName, Password, false);
                        clsGlobal.CurrentUser = User;
                    }
                   
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
        private void SaveOrClearRegistryCredentials(string UserName, string Password, bool IsRemmemberd)
        {
            string PathKey = @"HKEY_CURRENT_USER\SOFTWARE\DVLD_SYSTEM";

            try     
            {
                if (IsRemmemberd)
                {
                    Registry.SetValue(PathKey, "UserName", UserName);
                    Registry.SetValue(PathKey, "Password", Password);
                }
                else
                {
                    using (RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\DVLD_SYSTEM", true))
                    {
                        if (key != null)
                        {
                            key.DeleteValue("UserName", false);
                            key.DeleteValue("Password", false);
                        }
                        
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Registry Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoginScreen_Load(object sender, EventArgs e)
        {
            string KeyPath = @"HKEY_CURRENT_USER\SOFTWARE\DVLD_SYSTEM";
            string SavedUserName = Registry.GetValue(KeyPath,"UserName", null) as string;
            string SavedPassword = Registry.GetValue(KeyPath,"Password", null) as string;

            if (SavedUserName != null || SavedPassword != null)
            {
                textBoxPassword.Text = SavedPassword;
                textBoxUserName.Text = SavedUserName;
                checkBoxRememberMe.Checked = true;
            }
            else
            {
                checkBoxRememberMe.Checked = false;
            }
        }
    }
}
