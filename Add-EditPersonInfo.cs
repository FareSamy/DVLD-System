using DVLD_BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.AccessControl;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using System.Resources;
using DVLD_System.Properties;

namespace DVLD_System
{
    public partial class Add_EditPersonInfo : Form
    {

        public enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode;
        int _PersonID;
        clsPerson _Person;

        public Add_EditPersonInfo(int PersonID)
        {
            InitializeComponent();
            _PersonID = PersonID;
            if (_PersonID == -1)
                _Mode = enMode.AddNew;
            else
                _Mode = enMode.Update;
        }
        private void _FillCountryInComboBox()
        {
            DataTable dtCountries = clsCountries.ListCountries();

            comboBoxCountry.DataSource = dtCountries;
            comboBoxCountry.DisplayMember = "CountryName";
            comboBoxCountry.ValueMember = "CountryID";
        }
        private void buttonClose_Click(object sender, EventArgs e)
        {
            CausesValidation = false;
            this.Close();
        }
        private void _NationalIDValidation(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxNationalNo.Text.Trim()))
            {
                if (textBoxNationalNo.Focused || ((Control)sender).Parent.ContainsFocus)
                {
                    e.Cancel = true;
                    errorProvider1.SetError(textBoxNationalNo, "This Cannot be Empty");
                }
               

            }
            else if (_Mode==enMode.AddNew && clsPerson.IsPersonExist(textBoxNationalNo.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(textBoxNationalNo, "National Number is Used For Another Person");
            }
           
        }
        private void _EmailValidation(object sender, CancelEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBoxEmail.Text) && !textBoxEmail.Text.Contains("@gmail.com"))
            {

                e.Cancel = true;
                errorProvider1.SetError(textBoxEmail, "Invalid Format");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(textBoxEmail, "");
            }
        }
        private void _NotEmptyValidation(object sender, CancelEventArgs e)
        {
            TextBox temp = (TextBox)sender;
            if (string.IsNullOrWhiteSpace(temp.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(temp, "This Cannot be Empty");

            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(temp, "");
            }

        }
        private void linkLabelRemove_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pictureBoxImage.ImageLocation = null;
            linkLabelRemove.Visible = false;
        }
        private void linkLabelSetImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string selectedFilePath = openFileDialog1.FileName;
                pictureBoxImage.Load(selectedFilePath);
                pictureBoxImage.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }
        private void _LoadData()
        {
            _FillCountryInComboBox();
            comboBoxCountry.SelectedIndex = 50;
            if (_Mode == enMode.AddNew)
            {
                label1labelAddEditPerson.Text = "ADD NEW PERSON";
                label1labelAddEditPerson.ForeColor = Color.DarkRed;

                dateTimePicker1.MaxDate = DateTime.Now.AddYears(-18);
                _NationalIDValidation(textBoxNationalNo, new CancelEventArgs());
                linkLabelRemove.Visible = false;
                linkLabelSetImage.Visible = true;
                _Person = new clsPerson();
                return;
            }
            _Person = clsPerson.Find(_PersonID);
            if (_Person == null)
            {
                MessageBox.Show("This form will be closed because No Person with ID = " + _Person);
                this.Close();
                return;
            }
            textBoxNationalNo.Enabled = false;
            label1labelAddEditPerson.Text = "Edit Person";
            labelPersonIDResult.Text = _PersonID.ToString();
            textBoxAddress.Text = _Person.Address.ToString();
            textBoxEmail.Text = _Person.Email.ToString();
            textBoxFirstName.Text = _Person.FirsName.ToString();
            textBoxSecoundName.Text = _Person.SecoundName.ToString();
            textBoxThirdName.Text = _Person.ThirdName.ToString();
            textBoxLastName.Text = _Person.LastName.ToString();
            textBoxNationalNo.Text = _Person.NationalNum.ToString();
            textBoxPhone.Text = _Person.Phone.ToString();
            comboBoxCountry.SelectedIndex = comboBoxCountry.FindString(clsCountries.Find(_Person.NationalCountryID).CountrieName);
            dateTimePicker1.Value = _Person.DateOfBirth;
            if (_Person.Gendor == 0)
            {
                radioButtonMale.Checked = true;
            }
            else
            {
                radioButtonFemale.Checked = true;
            }
            if (_Person.ImagePath != "")
            {
                pictureBoxImage.Load(_Person.ImagePath);
                //linkLabelRemove.Visible = true;
            }
            else
            {
                linkLabelSetImage.Visible = true;
                linkLabelRemove.Visible = false;
            }
            

        }
        private void radioButtonMale_CheckedChanged(object sender, EventArgs e)
        {
            pictureBoxImage.Image = Resources.Men;
            pictureBoxImage.SizeMode = PictureBoxSizeMode.Zoom;

        }
        private void radioButtonFemale_CheckedChanged(object sender, EventArgs e)
        {

            pictureBoxImage.Image = Resources.woman;
            pictureBoxImage.SizeMode = PictureBoxSizeMode.Zoom;

        }
        private void Add_EditPersonInfo_Load(object sender, EventArgs e)
        {
            _LoadData();
        }
        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Missing Inforamtion or Invalid National Number!!!");
                return; 
            }
            else
            {
            
                _Person.NationalNum = textBoxNationalNo.Text;
                _Person.FirsName = textBoxFirstName.Text;
                _Person.SecoundName = textBoxSecoundName.Text;
                _Person.ThirdName = textBoxThirdName.Text;
                _Person.LastName = textBoxLastName.Text;
                _Person.DateOfBirth = dateTimePicker1.Value.Date;
                if (radioButtonMale.Checked)
                {
                    _Person.Gendor = 0;
                }
                else
                {
                    _Person.Gendor = 1;
                }
                _Person.Address = textBoxAddress.Text;
                _Person.Phone = textBoxPhone.Text;
                _Person.Email = textBoxEmail.Text;
                _Person.NationalCountryID = Convert.ToInt32(comboBoxCountry.SelectedValue);
                _Person.ImagePath = pictureBoxImage.ImageLocation ?? "";

                if (_Person.Save())
                {
                    if(_Mode == enMode.AddNew)
                    MessageBox.Show("Person Added Successfully");
                    else
                    MessageBox.Show("Person Edited Successfully");
                }
                else
                
                    MessageBox.Show("Error!!");
                    _Mode = enMode.Update;
                labelPersonIDResult.Text = _Person.ID.ToString();
                label1labelAddEditPerson.Text = "Edit Person";
            }
            
            
            
        }
    }
}
