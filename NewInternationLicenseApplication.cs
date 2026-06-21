using DVLD_BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_System
{
    public partial class NewInternationLicenseApplication : Form
    {
        clsLicense _license;
        clsInternationalLicense _internationalLicense;
        clsPerson _Person;
        clsDriver _Driver;
        clsApplicationType _applicationType;
        
        public NewInternationLicenseApplication()
        {
            InitializeComponent();
            filterLicenseInfo1.LicenseSelected += LicenseSelected;
        }
        private void LicenseSelected(clsLicense license)
        {
            _license = license;
           
            if (_license != null)
            {
                if (_license.LicenseClass == 3 && _license.IsActive == true && _license.ExpirationDate > DateTime.Now)
                {
                    _internationalLicense = new clsInternationalLicense();
                    _internationalLicense = clsInternationalLicense.FindByDriverID(_license.DriverID);
                    if (_internationalLicense != null)
                    {
                        MessageBox.Show("Cannot Issue a International License because you have one with ID " + _internationalLicense.InternationalLicenseID.ToString(), "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        linkLabelShowLicenseInfo.Enabled = true;
                        return;
                    }
                    groupBoxApplicationInfo.Enabled = true;

                    labelApplicationDateResult.Text = DateTime.Now.ToShortDateString();

                    labelissueDateResult.Text = DateTime.Now.ToShortDateString();

                    _applicationType = new clsApplicationType();
                    _applicationType = clsApplicationType.Find(6);
                    labelFeesResult.Text = _applicationType.AppFees.ToString("N0") ;

                    labelLocalLicenseIDResult.Text = _license.LicenseID.ToString();

                    labelExpirationDateResult.Text = DateTime.Now.AddYears(1).ToShortDateString();

                    labelCreatedByResult.Text = clsGlobal.CurrentUser.UserName;
                    
                    buttonIssue.Enabled = true;
                   
                }
                else
                {

                    linkLabelShowLicenseInfo.Enabled = false;
                    groupBoxApplicationInfo.Enabled = false;

                    labelApplicationDateResult.Text = "[???]";

                    labelissueDateResult.Text = "[???]";

                    labelFeesResult.Text = "[???]";

                    labelLocalLicenseIDResult.Text = "[???]";

                    labelExpirationDateResult.Text = "[???]";

                    labelCreatedByResult.Text = "[???]";
                    MessageBox.Show("Cannot Issue a International License because The required conditions are not met", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    buttonIssue.Enabled = false;

                }
            }
        }
        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void NewInternationLicenseApplication_Load(object sender, EventArgs e)
        {
            
           
        }

        private void buttonIssue_Click(object sender, EventArgs e)
        {

                DialogResult result  = MessageBox.Show("Are you sure you want to issue an international license to Driver ID " + _license.DriverID.ToString(), "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No)
                {
                    return; 
                }
                _internationalLicense = new clsInternationalLicense();

                _internationalLicense.ApplicationID = _license.ApplicationID;
                _internationalLicense.DriverID = _license.DriverID;
                _internationalLicense.IssuedUsingLocalLicenseID = _license.LicenseID;
                _internationalLicense.IssueDate = DateTime.Now;
                _internationalLicense.ExpirationDate = DateTime.Now.AddYears(1);
                _internationalLicense.IsActive = true;
                _internationalLicense.CreatedByUserID = clsGlobal.CurrentUser.UserID;
                if (_internationalLicense.Save())
                {
                    MessageBox.Show("international license issued successfully with ID = " + _internationalLicense.InternationalLicenseID.ToString(), "Lisence Issued", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    linkLabelShowLicenseInfo.Enabled = true;
                    labelILApplicationIDResult.Text = _internationalLicense.InternationalLicenseID.ToString();
                    ILLicenseIDResult.Text = _internationalLicense.InternationalLicenseID.ToString();
                    buttonIssue.Enabled = false;
                }
                else
                {
                    MessageBox.Show("somthing wrong!!");
                }
        }

        private void linkLabelShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            InternationalDriverInfo frm = new InternationalDriverInfo(_internationalLicense.InternationalLicenseID);
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
    }
}
