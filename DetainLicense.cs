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
    public partial class DetainLicense : Form
    {
        clsLicense _license, _Newlicense;
        clsApplication _Application;
        clsPerson _Person;
        clsDriver _Driver;
        clsApplicationType _ApplicationType;
        clsLicenseClasses _LicenseClasses;
        clsDetainedLicense _DetainLicense;
        public DetainLicense()
        {
            InitializeComponent();
            filterLicenseInfo1.LicenseSelected += LicenseSelected;
        }
        private void LicenseSelected(clsLicense license)
        {
            _license = license;
            if (_license != null)
            {
                if (clsDetainedLicense.IsLicenseDetained(_license.LicenseID))
                {
                    Reset();
                    MessageBox.Show("The selected license is already detained ", "Detained License", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    linkLabelShowLicenseInfo.Enabled = true;
                    return;
                }
                else
                {
                    groupBoxDetainInfo.Enabled = true;
                    buttonDetain.Enabled = true;
                }
            }
            else
            {
                return;
            }
            labelDetainResult.Text = DateTime.Now.ToShortDateString();
            labelLicensIDResult.Text = _license.LicenseID.ToString();
            labelCreatedByResult.Text = clsGlobal.CurrentUser.UserName;

        }
        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Reset()
        {
            labelDetainResult.Text = "[???]";
            labelLicensIDResult.Text = "[???]";
            labelCreatedByResult.Text = "[???]";
            textBoxFineFees.Text = "";
            groupBoxDetainInfo.Enabled = false;
            buttonDetain.Enabled = false;

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

        private void buttonDetain_Click(object sender, EventArgs e)
        {
            if ( textBoxFineFees.Text == "" || int.Parse(textBoxFineFees.Text) <= 0 )
            {
                MessageBox.Show("Please Enter Fine Fees to continue", "No Value", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;

            }
            DialogResult result = MessageBox.Show("Are you sure you want to Detain a license with ID " + _license.LicenseID.ToString(), "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                return;
            }
         
            _DetainLicense = new clsDetainedLicense();
            _DetainLicense.LicenseID = _license.LicenseID;
            _DetainLicense.DetainDate = DateTime.Now;
            _DetainLicense.FineFees = int.Parse(textBoxFineFees.Text);
            _DetainLicense.CreatedByUserID = clsGlobal.CurrentUser.UserID;
            _DetainLicense.IsReleased = false;
            _DetainLicense.ReleaseDate = null;
            _DetainLicense.ReleasedByUserID = null;
            _DetainLicense.ReleaseApplicationID = null;
            if (_DetainLicense.Save())
            {
                MessageBox.Show("License Detained successfully", "Detained", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Wrong");
            }
            linkLabelShowLicenseInfo.Enabled = true;
        }

        private void DetainLicense_Load(object sender, EventArgs e)
        {

        }

        private void textBoxFineFees_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
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
