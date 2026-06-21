using DVLD_BusinessLayer;
using DVLD_System.Properties;
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
    public partial class PepoelInfoControl : UserControl
    {
    
        int _PersonID;
        clsPerson _Person;

        public bool ShowCloseButton
        {
            get { return buttonClose.Visible; }
            set { buttonClose.Visible = value; }
        }
        public PepoelInfoControl(int PersonID)
        {
            _PersonID = PersonID;
            InitializeComponent();
        }
        public void LoadPerson(int personID)
        {
            _PersonID = personID;
            _LoadData();
        }
        public PepoelInfoControl()
        {
            InitializeComponent();
        }

        private void _LoadData()
        {
            if (_PersonID <= 0)
            {

                labelResultID.Text = "[???]";
                label1ResultFullName.Text = "[???]";
                labelResultNationalNo.Text = "[???]";
                labelResultEmail.Text = "[???]";
                labelResultAddress.Text = "[???]";
                labelResultDate.Text = "[???]";
                labelResultPhone.Text = "[???]";
                pictureBoxImage.Image = Resources.Men;
                labelResultGender.Text = "[???]";
                labelResultCountry.Text = "[???]";
                return;
            }
                

            _Person = clsPerson.Find(_PersonID);

            if (_Person == null)
                return;
            labelResultID.Text = _Person.ID.ToString();
            label1ResultFullName.Text = _Person.FullName().ToString();
            labelResultNationalNo.Text = _Person.NationalNum.ToString();
            //labelResultGender.Text = _Person.Gendor.ToString();
            labelResultEmail.Text = _Person.Email.ToString();
            labelResultAddress.Text = _Person.Address.ToString();
            labelResultDate.Text = _Person.DateOfBirth.Date.ToShortDateString();
            labelResultPhone.Text = _Person.Phone.ToString();
            labelResultCountry.Text = clsCountries.Find(_Person.NationalCountryID).CountrieName.ToString();


            if (_Person.ImagePath != "")
            {
                pictureBoxImage.Load(_Person.ImagePath);
                if (_Person.Gendor == 0)
                {
                    labelResultGender.Text = "Male";
                }
                else
                {
                    labelResultGender.Text = "Female";
                }
            }
            else
            {
                if (_Person.Gendor == 0)
                {
                    pictureBoxImage.Image = Resources.Men;
                    labelResultGender.Text = "Male";

                }
                else
                {
                    pictureBoxImage.Image = Resources.woman;
                    labelResultGender.Text = "Female";
                }
            }
        }
        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.FindForm()?.Close();
        }
        private void PepoelInfoControl_Load(object sender, EventArgs e)
        {
          
            if (!this.DesignMode)
            {
                _LoadData();
            }
        }

        private void linkLabelEditPerson_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Add_EditPersonInfo frm = new Add_EditPersonInfo(_PersonID);
            frm.ShowDialog();
        }
    }
}
