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
    public partial class LicenseInfo : Form
    {
        int _DLAppId, _ApplicationID;

      
        public LicenseInfo( int ApplicationID)
        {
           // _DLAppId = DLAppId;
            _ApplicationID = ApplicationID;
            InitializeComponent();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LicenseInfo_Load(object sender, EventArgs e)
        {
            driverLicenseInfo1.LoadInfo( _ApplicationID);
        }

    }
}
