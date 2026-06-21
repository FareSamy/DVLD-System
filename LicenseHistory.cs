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
    public partial class LicenseHistory : Form
    {
        string _NationalNo;
        clsPerson _Person;
        public LicenseHistory(string NationalNo)
        {
            _NationalNo = NationalNo;
            InitializeComponent();
        }

        private void LicenseHistory_Load(object sender, EventArgs e)
        {
            _Person = new clsPerson();
            _Person = clsPerson.Find(_NationalNo);
            pepoelInfoControl1.ShowCloseButton = false;
            pepoelInfoControl1.LoadPerson(_Person.ID);
            driverLicense1.LoadInfo(_NationalNo);

        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
