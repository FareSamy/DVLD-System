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
using System.Xml.Linq;

namespace DVLD_System
{
    public partial class ReplacmentForLostOrdamagedLicense : Form
    {
        clsLicense _license;
        clsLicense _Newlicense;
        clsLicenseClasses _LicenseClasses;
        clsDriver _Driver;
        clsPerson _Person;
        clsApplication _Application;
        clsApplicationType _ApplicationType;
        public ReplacmentForLostOrdamagedLicense()
        {
            InitializeComponent();
            filterLicenseInfo1.LicenseSelected += LicenseSelected;
        }
        private void LicenseSelected(clsLicense license)
        {
            _license = license;
            if (_license != null)
            {
                if (_license.ExpirationDate < DateTime.Now)
                {
                    MessageBox.Show("The selected license is expired; it expired on  " + _license.ExpirationDate.ToShortDateString(), "Cannot Replacment Please Renew it", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    linkLabelShowLicenseInfo.Enabled = true;
                    groupBoxAppInfoForLicenseReplacment.Enabled = false;
                    buttonIssue.Enabled = false;
                    ResetINFO();
                }
                else if (!_license.IsActive)
                {
                    MessageBox.Show("The selected license is Not active and you cant Replacment it ", "Cannot Replacment", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    groupBoxAppInfoForLicenseReplacment.Enabled = false;
                    buttonIssue.Enabled = false;
                    ResetINFO();
                }
                else
                {
                   groupBoxAppInfoForLicenseReplacment.Enabled = true;
                   //applicationNewLicenseInfo1.LoadInfo(_license.LicenseID);
                   AppInfoForLisenceReplacmentLOADIFO();
                   buttonIssue.Enabled = true;
                }
            }
        }
        private void AppInfoForLisenceReplacmentLOADIFO()
        {
            labelApplicationDateResult.Text = DateTime.Now.ToShortDateString();

            if (radioButtonDamadegLicense.Checked)
            {
                _ApplicationType = new clsApplicationType();
                _ApplicationType = clsApplicationType.Find(4);
            }
            else if (radioButtonLostLicense.Checked)
            {
                _ApplicationType = new clsApplicationType();
                _ApplicationType = clsApplicationType.Find(3);
            }
            labelAppliationFeesResult.Text = _ApplicationType.AppFees.ToString("N0");
            labelOldLicensidResult.Text = _license.LicenseID.ToString();
            labelCreatedByResult.Text = clsGlobal.CurrentUser.UserName;
        }
        private void ResetINFO()
        {
            labelApplicationDateResult.Text = "[???]";
            labelAppliationFeesResult.Text = "[???]";
            labelOldLicensidResult.Text = "[???]";
            labelCreatedByResult.Text = "[???]";
        }
            private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void linkLabelShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (_license == null)
            {
                return;
            }
            clsLocalDrivingLicenseApplications local = clsLocalDrivingLicenseApplications.FindByApplicationID(_license.ApplicationID);

            LicenseInfo frm = new LicenseInfo( local.AppID);
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

        private void buttonIssue_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to Replacment an license to Driver ID " + _license.DriverID.ToString(), "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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
                _Newlicense.Notes = _license.Notes;
                _Newlicense.PaidFees = _LicenseClasses.ClassFees;
                _Newlicense.IsActive = true;
               
                if (radioButtonDamadegLicense.Checked)
                {
                    _Newlicense.IssueReason = 3;
                }
                else if (radioButtonLostLicense.Checked)
                {
                    _Newlicense.IssueReason = 4;
                }
                _Newlicense.CreatedByUserID = clsGlobal.CurrentUser.UserID;
                if (_Newlicense.Save())
                {
                    MessageBox.Show("Replacment License Issued Successuffly with license ID " + _Newlicense.LicenseID.ToString(), "License Issued", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    labelRLApplicationIDResult.Text = _Application.AppID.ToString();
                    labeReplacmentlLicensIDResult.Text = _Newlicense.LicenseID.ToString();
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

        private void radioButtonDamadegLicense_CheckedChanged(object sender, EventArgs e)
        {
            labelMainTitel.Text = "REPLACMENT FOR DAMAGED LICENSE";
            if (groupBoxAppInfoForLicenseReplacment.Enabled == false)
            {
                return;
            }
            _ApplicationType = new clsApplicationType();
            _ApplicationType = clsApplicationType.Find(4);
            labelAppliationFeesResult.Text = _ApplicationType.AppFees.ToString("N0");
        }

        private void radioButtonLostLicense_CheckedChanged(object sender, EventArgs e)
        {
            labelMainTitel.Text = "REPLACMENT FOR LOST LICENSE";
            if (groupBoxAppInfoForLicenseReplacment.Enabled == false)
            {
                return;
            }
                       _ApplicationType = new clsApplicationType();
            _ApplicationType = clsApplicationType.Find(3);
            labelAppliationFeesResult.Text = _ApplicationType.AppFees.ToString("N0");
        }
    }
}
