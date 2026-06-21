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
    public partial class ApplicationNewLicenseInfo : UserControl
    {
        int _LicenseID;
        clsApplicationType _ApplicationTypes;
        clsApplication _Application;
        clsLicense _License;
        public event Action<string> Notes;
        public ApplicationNewLicenseInfo()
        {
            InitializeComponent();
        }

        public void LoadInfo(int LicenseID)
        {
            _LicenseID = LicenseID;
            _License = new clsLicense();
            _License = clsLicense.Find(_LicenseID);
            if (_License != null)
            {
                labelApplicationDateResult.Text = DateTime.Now.ToShortDateString();
                labelIssueDateResult.Text = DateTime.Now.ToShortDateString();

                _Application = new clsApplication();
                _Application = clsApplication.Find(_License.ApplicationID);

                _ApplicationTypes = new clsApplicationType();
                _ApplicationTypes = clsApplicationType.Find(2);
                labelAppliationFeesResult.Text = _ApplicationTypes.AppFees.ToString("N0");
                labelLicenseFeesResult.Text = _License.PaidFees.ToString("N0");
                //textBoxNotesResult.Text = _License.Notes;
                Notes?.Invoke(textBoxNotesResult.Text);
                labelOldLicensid.Text = _License.LicenseID.ToString();
                labelExpairationDateResult.Text = DateTime.Now.AddYears(10).ToShortDateString();
                labelCreatedByResult.Text = clsGlobal.CurrentUser.UserName;
                labelTotalFeesresult.Text = (_ApplicationTypes.AppFees + _License.PaidFees).ToString("N0");


            }
            else
            {
                MessageBox.Show("Somthing wrong!!");
            }
            
        }
        private void ApplicationNewLicenseInfo_Load(object sender, EventArgs e)
        {

        }
    }
}
