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
    public partial class DriverLicenseInfo : UserControl
    {
        int  _ApplicationID;
        clsApplication _Application;
        clsLocalDrivingLicenseApplications _LDLA;
        clsPerson _Person;
        clsUser _User;
        clsApplicationType _AppType;
        clsLicenseClasses _LicensClass;
        clsLicense _Licens;
        clsDriver _Driver;

        public DriverLicenseInfo()
        {
            InitializeComponent();
        }
        public void LoadInfo( int ApplicationID)
        {
           
            _ApplicationID = ApplicationID;
            _LoadData();
        }
        private void _LoadData()
        {
            
            _Application = clsApplication.Find(_ApplicationID);
            if (_ApplicationID != null)
            {
                _Licens = clsLicense.FindByApplicationID(_ApplicationID);
                _LicensClass = clsLicenseClasses.Find(_Licens.LicenseClass);
                _Person = clsPerson.Find(_Application.AppPersonID);
                _Driver = clsDriver.FindByPersonID(_Person.ID);

                labelClassResult.Text = _LicensClass.ClassName.ToString();
                labelNameResult.Text = _Person.FullName();
                labelLicensIDResult.Text = _Licens.LicenseID.ToString();
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
                labelIssueDateResult.Text = _Licens.IssueDate.ToShortDateString();
                //labelIssueReasonResult.Text = _Licens.IssueReason.ToString();
                if (_Licens.IssueReason == 1)
                {
                    labelIssueReasonResult.Text = "First Time";
                }
                else if (_Licens.IssueReason == 2)
                {
                    labelIssueReasonResult.Text = "Renew";
                }
                else if (_Licens.IssueReason == 3)
                {
                    labelIssueReasonResult.Text = "Replacment For Damage";
                }
                else if (_Licens.IssueReason == 4)
                {
                    labelIssueReasonResult.Text = "Replacment For Lost";
                }
                labelNotesResult.Text = _Licens.Notes.ToString();
                if (_Licens.IsActive)
                {
                    labelIsActiveResult.Text = "Yes";
                }
                else if (!_Licens.IsActive)
                {
                    labelIsActiveResult.Text = "No";
                }
                labelDateOfBirthResult.Text = _Person.DateOfBirth.ToShortDateString();
                labelDriverIDResult.Text = _Driver.DriverID.ToString();
                labelExpairationDateResult.Text = _Licens.ExpirationDate.ToShortDateString();
                if (clsDetainedLicense.IsLicenseDetained(_Licens.LicenseID))
                {
                    labelIsDetainedResult.Text = " Yes";
                }
                else
                {
                    labelIsDetainedResult.Text = "No";
                }
                
                if (_Person.ImagePath != "")
                {
                    pictureBoxDriverPic.Load(_Person.ImagePath);

                }
                else
                {
                    if (_Person.Gendor == 0)
                    {
                        pictureBoxDriverPic.Image = Resources.Men;
                    }
                    else
                    {
                        
                        pictureBoxDriverPic.Image = Resources.woman;
                    }
                }
                if (_Licens.Notes == "")
                {
                    labelNotesResult.Text = "No Notes";
                }
            }
        }
        private void DriverLicenseInfo_Load(object sender, EventArgs e)
        {

        }
    }
}
