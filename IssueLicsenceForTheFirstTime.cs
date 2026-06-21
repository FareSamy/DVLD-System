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
    public partial class IssueLicsenceForTheFirstTime : Form
    {
        int _LDLAID , _AppID;
        public IssueLicsenceForTheFirstTime(int LDLAID,int AppID)
        {
            _LDLAID = LDLAID;
            _AppID = AppID;
            InitializeComponent();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close  ();
        }

        private void buttonIssue_Click(object sender, EventArgs e)
        {
            clsApplication application = new clsApplication();
            application = clsApplication.Find(_AppID);
            if (application != null)
            {
                int PersonID = application.AppPersonID;
                clsLicense license = new clsLicense();

                clsPerson person = new clsPerson();
                person = clsPerson.Find(PersonID);

                clsLocalDrivingLicenseApplications LDLA = new clsLocalDrivingLicenseApplications();
                LDLA = clsLocalDrivingLicenseApplications.FindByLocalDrivingLicenseApplicationID(_LDLAID);

                clsLicenseClasses licenseClasses = new clsLicenseClasses();
                licenseClasses = clsLicenseClasses.Find(LDLA.LicenseClassID);

                clsDriver driver = new clsDriver();
                driver = clsDriver.FindByPersonID(PersonID);

                if (driver == null)
                {
                    driver = new clsDriver();

                    driver.PersonID = PersonID;
                    driver.CreatedDate = DateTime.Now;
                    driver.CreatedByUserID = clsGlobal.CurrentUser.UserID;
                    if (!driver.Save())
                    {
                        MessageBox.Show("SomthingWrong!!!");
                        return;
                    }

                }
               
                license = new clsLicense();

                license.ApplicationID = _AppID;
                license.DriverID = driver.DriverID;
                license.LicenseClass = LDLA.LicenseClassID;
                license.IssueDate = DateTime.Now;
                license.ExpirationDate = DateTime.Now.AddYears(licenseClasses.DefaultValidityLength);
                license.Notes = textBoxNotes.Text;
                license.PaidFees = licenseClasses.ClassFees;
                license.IsActive = true;
                license.IssueReason = 1;
                license.CreatedByUserID = clsGlobal.CurrentUser.UserID;
                if (license.Save())
                {
                    application.AppStatus = 3;
                    application.Save();
                    MessageBox.Show("License Issued Succesfully with License ID" + license.LicenseID.ToString(), "Succeeded", MessageBoxButtons.OK, MessageBoxIcon.Information);
                 
                }
                else
                {
                    MessageBox.Show("SomthingWrong!!!");
                }
            }
            else
            {
                MessageBox.Show("SomthingWrong!!!");
            }

        }

        private void IssueLicsenceForTheFirstTime_Load(object sender, EventArgs e)
        {
            licensApplicationInfo1.LoadInfo(_LDLAID,_AppID);
        }
    }
}
