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
    public partial class InternationalDriverInfo : Form
    {
        int _InternationalLicenseID;
        public InternationalDriverInfo(int InternationalLicenseID)
        {
            _InternationalLicenseID = InternationalLicenseID;
            InitializeComponent();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void InternationalDriverInfo_Load(object sender, EventArgs e)
        {
            internationalDriverLicenseInfo1.LoadInfo(_InternationalLicenseID);
        }
    }
}
