using DVLD_BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_System
{
    public partial class AddNewUser : Form
    {
        public AddNewUser()
        {
            InitializeComponent();
          
        }

        clsPerson SearchPerson = new clsPerson();
        string _NationalNo = "";
        string _UserName = "";
        int _PersonID = -1;
        bool _AllowTap2 = false;

        private void _FillComboBox()
        {
            comboBoxFilter.Items.Add("National ID");
            comboBoxFilter.Items.Add("Person ID");
           // comboBoxFilter.Items.Add("UserName");
            comboBoxFilter.SelectedIndex = 0;
        }
        private void AddNewUser_Load(object sender, EventArgs e)
        {
            _FillComboBox();
            this.ActiveControl = textBoxFilter;
        }
        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void textBoxFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (comboBoxFilter.SelectedIndex == 1)
            {
                if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
        }
        private void comboBoxFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBoxFilter.Clear();
        }
        private void buttonSearch_Click(object sender, EventArgs e)
        {
            if (comboBoxFilter.SelectedIndex == 0)
            { 
                _NationalNo = textBoxFilter.Text;
                clsPerson Person = clsPerson.Find(_NationalNo);
                
                if (Person != null)
                {
                    SearchPerson = Person;
                    pepoelInfoControl1.LoadPerson(Person.ID);
                }
                else
                {
                    MessageBox.Show("No person founded please try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (comboBoxFilter.SelectedIndex == 1)
            {
                _PersonID = int.Parse(textBoxFilter.Text);

                clsPerson Person = clsPerson.Find(_PersonID);
                if (Person != null)
                {
                    SearchPerson = Person;
                    pepoelInfoControl1.LoadPerson(Person.ID);
                }
                else
                {
                    MessageBox.Show("No person founded please try again", "Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
                
            }
            //else if (comboBoxFilter.SelectedIndex == 2)
            //{
            //    _UserName = textBoxFilter.Text;

            //    clsUser User = clsUser.Find(_UserName);
            //    if (User != null)
            //    {
            //        pepoelInfoControl1.LoadPerson(User.PersonID);

            //    }
            //    else
            //    {
            //        MessageBox.Show("Not Found !!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
            //}
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
                e.Cancel = false;
                errorProvider1.SetError(textBoxUserName, "UserName is Used For Another User");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(textBoxUserName, "");
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
        private void buttonSave_Click(object sender, EventArgs e)
        {
            clsUser NewUser = new clsUser();
            NewUser.PersonID = SearchPerson.ID;
            NewUser.UserName = textBoxUserName.Text;
            NewUser.Password = textBoxPassword.Text;
            if (checkBoxIsActive.Checked)
            {
                NewUser.IsActive = true;
            }
            else
            {
                NewUser.IsActive = false;
            }

            if (NewUser.Save())
            {
                MessageBox.Show("User account created sucssflly", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                labelResultUserID.Text = SearchPerson.ID.ToString();

            }
            else
            {
                MessageBox.Show("Faild to create user account", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void buttonNext_Click(object sender, EventArgs e)
        {

            if (SearchPerson.ID != -1)
            {
                _PersonID = SearchPerson.ID;
               
                if (clsUser.FindByPersonID(_PersonID) != null)
                {
                    MessageBox.Show("Selected person already has a user choose onther one", "Select onther person", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    _AllowTap2 = true;
                    tabControl1.SelectedIndex = 1;
                }
            }
            else
            {
                MessageBox.Show("No person selected please select person and try again", "Select a person", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }



        }
        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {

            if (e.TabPageIndex == 1 && !_AllowTap2)
            {
                e.Cancel = true;
                MessageBox.Show("Please select a person and click Next first.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if (e.TabPageIndex == 0)
            {
                _AllowTap2 = false;
            }
          
        }


    }       
}
