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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DVLD_System
{
    public partial class FilterLicenseInfo : UserControl
    {
        public event Action<clsLicense> LicenseSelected;
        
        clsLicense _License;
        int _LicenseID;

        public FilterLicenseInfo()
        {
            InitializeComponent();
        }

        private void FilterLicenseInfo_Load(object sender, EventArgs e)
        {
            if (this.TopLevelControl is Form parentForm)
            {
                parentForm.AcceptButton = buttonSearch; 
            }
        }

 
        private void buttonSearch_Click(object sender, EventArgs e)
        {
            if (textBoxFilter.Text == "")
            {
                return;
            }
            _LicenseID = Convert.ToInt32(textBoxFilter.Text);
            _License = new clsLicense();
            _License = clsLicense.Find(_LicenseID);
            if (_License != null)
            {
                clsLocalDrivingLicenseApplications LDLA = new clsLocalDrivingLicenseApplications();
                LDLA = clsLocalDrivingLicenseApplications.FindByApplicationID(_License.ApplicationID);
                driverLicenseInfo1.LoadInfo( _License.ApplicationID);

                LicenseSelected?.Invoke(_License);
                
            }
            else
            {
                MessageBox.Show("No License with this ID please use vaild ID","Not Found",MessageBoxButtons.OK,MessageBoxIcon.Error);
               
            }
        }

      
        private void textBoxFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            
                if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                }
        }
       
    }
}
