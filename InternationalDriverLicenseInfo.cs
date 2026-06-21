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
    public partial class InternationalDriverLicenseInfo : UserControl
    {
        int  _InternationalLicenseID;

        clsPerson _Person;
        clsLicense _Licens;
        clsInternationalLicense _InternationalLicense;
        clsDriver _Driver;
        public InternationalDriverLicenseInfo()
        {
            InitializeComponent();
        }

        private void InternationalDriverLicenseInfo_Load(object sender, EventArgs e)
        {

        }

        public void LoadInfo(int InternationalLicensID)
        {
            _InternationalLicenseID = InternationalLicensID;
            _LoadData();
        }
        private void _LoadData()
        {
            _InternationalLicense = new clsInternationalLicense();
            _InternationalLicense = clsInternationalLicense.Find(_InternationalLicenseID);
            if (_InternationalLicense != null)
            {
                _Driver = new clsDriver();
                _Driver = clsDriver.FindByDriverID(_InternationalLicense.DriverID);

                _Person = new clsPerson();
                _Person = clsPerson.Find(_Driver.PersonID);

                _Licens = new clsLicense();
                _Licens = clsLicense.FindByDriverID(_Driver.DriverID);


                labelNameResult.Text = _Person.FullName();
                labelLicensIDResult.Text = _Licens.LicenseID.ToString();
                labelInternationallicenseIDResult.Text = _InternationalLicense.InternationalLicenseID.ToString();
                labelNationalNoResult.Text = _Person.NationalNum.ToString();
                if (_Person.Gendor == 0)
                {
                    labelGenderResult.Text = "Male";

                }
                else
                {
                    labelGenderResult.Text = "Female";
                    pictureBoxDriverPic.Image = Resources.woman;
                }
                labelIssueDateResult.Text = _InternationalLicense.IssueDate.ToShortDateString();
                labelIsApplicationIDResult.Text = _InternationalLicense.ApplicationID.ToString();

                if (_InternationalLicense.IsActive)
                {
                    labelIsActiveResult.Text = "Yes";
                }
                else if (!_InternationalLicense.IsActive)
                {
                    labelIsActiveResult.Text = "No";
                }
                labelDateOfBirthResult.Text = _Person.DateOfBirth.ToShortDateString();
                labelDriverIDResult.Text = _Driver.DriverID.ToString();
                labelExpairationDateResult.Text = _InternationalLicense.ExpirationDate.ToShortDateString();
                if (_Person.ImagePath != "")
                {
                    pictureBoxDriverPic.Load(_Person.ImagePath);

                }

            }
        }
    }
}
