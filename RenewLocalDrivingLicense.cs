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
    public partial class RenewLocalDrivingLicense : Form
    {
        clsLicense _license , _Newlicense;
        clsApplication _Application;
        clsPerson _Person;
        clsDriver _Driver;
        clsApplicationType _ApplicationType;
        clsLicenseClasses _LicenseClasses;

        string _Note;
        public RenewLocalDrivingLicense()
        {
            InitializeComponent();
            filterLicenseInfo1.LicenseSelected += LicenseSelected;
            applicationNewLicenseInfo1.Notes += Note;
        }
        private void LicenseSelected(clsLicense license)
        {
            _license = license;
            if (_license != null)
            {
                if (_license.ExpirationDate > DateTime.Now)
                {
                    MessageBox.Show("The selected license is not yet expired; it will expire on  " + _license.ExpirationDate.ToShortDateString(), "Cannot Renew", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    linkLabelShowLicenseInfo.Enabled = true;
                }
                else if (!_license.IsActive)
                {
                    MessageBox.Show("The selected license is Not active and you cant renew it ", "Cannot Renew", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else
                {
                    applicationNewLicenseInfo1.Enabled = true;
                    applicationNewLicenseInfo1.LoadInfo(_license.LicenseID);
                    buttonRenew.Enabled = true;
                }
            }
        }
        private void Note(string Note)
        {
            _Note = Note;
        }
        private void RenewLocalDrivingLicense_Load(object sender, EventArgs e)
        {
            

        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void linkLabelShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (_Newlicense == null)
            {
                return;
            }
            clsLocalDrivingLicenseApplications local = clsLocalDrivingLicenseApplications.FindByApplicationID(_Newlicense.ApplicationID);

            LicenseInfo frm = new LicenseInfo( local.AppID);
            frm.ShowDialog();
            linkLabelShowLicenseInfo.Enabled = false;
        }

        private void buttonRenew_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to Renew an license to Driver ID " + _license.DriverID.ToString(), "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                return;
            }
            _license.IsActive = false;
            _license.Save();

            _Driver = new clsDriver();
            _Driver = clsDriver.FindByDriverID(_license.DriverID);

            _Person = new clsPerson();
            _Person = clsPerson.Find(_Driver.PersonID);

            _ApplicationType = new clsApplicationType();
            _ApplicationType = clsApplicationType.Find(2);

            _Application = new clsApplication();

            _Application.AppPersonID = _Person.ID;
            _Application.AppDate = DateTime.Now;
            _Application.AppTypeID = _ApplicationType.AppTypeID;
            _Application.AppStatus = 3;
            _Application.LastStatusDate = DateTime.Now;
            _Application.PaidFees = _ApplicationType.AppFees;
            _Application.CreatedByUserID = clsGlobal.CurrentUser.UserID;

            if (_Application.Save())
            {
                _Newlicense = new clsLicense();
                _LicenseClasses = new clsLicenseClasses();
                _LicenseClasses = clsLicenseClasses.Find(_license.LicenseClass);

                _Newlicense.ApplicationID = _Application.AppID;
                _Newlicense.DriverID = _license.DriverID;
                _Newlicense.LicenseClass = _LicenseClasses.ID;
                _Newlicense.IssueDate = DateTime.Now;
                _Newlicense.ExpirationDate = DateTime.Now.AddYears(_LicenseClasses.DefaultValidityLength);
                _Newlicense.Notes = _Note;
                _Newlicense.PaidFees = _LicenseClasses.ClassFees;
                _Newlicense.IsActive = true;
                _Newlicense.IssueReason = 2;
                _Newlicense.CreatedByUserID = clsGlobal.CurrentUser.UserID;
                if (_Newlicense.Save())
                {
                    MessageBox.Show("License Renewed Successuffly with license ID " + _Newlicense.LicenseID.ToString(), "License Issued", MessageBoxButtons.OK, MessageBoxIcon.Question);

                }
                else
                {
                    MessageBox.Show("Error[02]Somthing wrong!!!");
                }
            }
            else
            {
                MessageBox.Show("Error[01]Somthing wrong!!!");
            }
            
        }

        private void linkLabelShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (_license == null)
            {
                return;
            }
            _Driver = new clsDriver();
            _Driver = clsDriver.FindByDriverID(_license.DriverID);
            _Person = new clsPerson();
            _Person = clsPerson.Find(_Driver.PersonID);

            LicenseHistory frm = new LicenseHistory(_Person.NationalNum);
            frm.ShowDialog();
        }
    }
}
