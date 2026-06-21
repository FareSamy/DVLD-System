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
    public partial class ReleaseDetainedLicense : Form
    {
        clsLicense _license, _Newlicense;
        clsApplication _Application;
        clsPerson _Person;
        clsDriver _Driver;
        clsApplicationType _ApplicationType;
        clsLicenseClasses _LicenseClasses;
        clsDetainedLicense _DetainLicense;
        public ReleaseDetainedLicense()
        {
            InitializeComponent();
            filterLicenseInfo1.LicenseSelected += LicenseSelected;
        }
        private void LicenseSelected(clsLicense license)
        {
            _license = license;
            if (_license != null)
            {
                if (!clsDetainedLicense.IsLicenseDetained(_license.LicenseID))
                {
                    Reset();
                    MessageBox.Show("The selected license is Not detained ", "Release License", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    linkLabelShowLicenseInfo.Enabled = true;
                    return;
                }
                else
                {
                    groupBoxDetainInfo.Enabled = true;
                    buttonRelease.Enabled = true;
                }
            }
            else
            {
                return;
            }
            labelDetainResult.Text = DateTime.Now.ToShortDateString();
            labelLicensIDResult.Text = _license.LicenseID.ToString();
            labelCreatedByResult.Text = clsGlobal.CurrentUser.UserName;

            _DetainLicense = new clsDetainedLicense();
            _ApplicationType = new clsApplicationType();
            _ApplicationType = clsApplicationType.Find(5);
            _DetainLicense = clsDetainedLicense.Find(_license.LicenseID);
            if (_DetainLicense != null)
            {
                labelDetainDResult.Text = _DetainLicense.DetainID.ToString();
                labelFineFeesResult.Text = _DetainLicense.FineFees.ToString("N0");
                labelApplicationFeesResult.Text = _ApplicationType.AppFees.ToString("N0");
                labeltotalFeesResult.Text = (_DetainLicense.FineFees + _ApplicationType.AppFees).ToString("N0");
            }
            

        }
        private void Reset()
        {
            labelDetainResult.Text = "[???]";
            labelLicensIDResult.Text = "[???]";
            labelCreatedByResult.Text = "[???]";
            labelFineFeesResult.Text = "[???]";
            labelDetainDResult.Text = "[???]";
            labelFineFeesResult.Text = "[???]";
            labelApplicationFeesResult.Text = "[???]";
            labeltotalFeesResult.Text = "[???]";
            groupBoxDetainInfo.Enabled = false;
            buttonRelease.Enabled = false;

        }

        private void linkLabelShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (_license == null)
            {
                return;
            }
            clsLocalDrivingLicenseApplications local = clsLocalDrivingLicenseApplications.FindByApplicationID(_license.ApplicationID);

            LicenseInfo frm = new LicenseInfo(local.AppID);
            frm.ShowDialog();
            linkLabelShowLicenseInfo.Enabled = false;
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

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonRelease_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to Release a license with ID " + _license.LicenseID.ToString(), "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                return;
            }
            _Application = new clsApplication();
            _Application = clsApplication.Find(_license.ApplicationID);

            _Person = new clsPerson();
            _Person = clsPerson.Find(_Application.AppPersonID);

            _Application = new clsApplication();
            _Application.AppPersonID = _Person.ID;
            _Application.AppDate = DateTime.Now;
            _Application.AppTypeID = 5;
            _Application.AppStatus = 3;
            _Application.LastStatusDate = DateTime.Now;
            _Application.PaidFees = _ApplicationType.AppFees;
            _Application.CreatedByUserID = clsGlobal.CurrentUser.UserID;
            if (_Application.Save())
            {
                _DetainLicense.ReleasedByUserID = clsGlobal.CurrentUser.UserID;
                _DetainLicense.ReleaseApplicationID = _Application.AppID;
                _DetainLicense.ReleaseDate = DateTime.Now;
                _DetainLicense.IsReleased = true;
                if (_DetainLicense.Save())
                {
                    
                    MessageBox.Show("License released successfully", "Released", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    labelReleaseAppIDResult.Text = _Application.AppID.ToString();

                }
                else
                {
                    MessageBox.Show("Error[01]");
                }
                
            }
            else
            {
                MessageBox.Show("Error[02]");
            }

            linkLabelShowLicenseInfo.Enabled = true;
        }

        private void ReleaseDetainedLicense_Load(object sender, EventArgs e)
        {

        }
    }
}
