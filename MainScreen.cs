using DVLD_BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_System
{
    public partial class MainScreen : Form
    {
        public clsUser CurrentUser = new clsUser();
        public MainScreen()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }
        private void _RefreshPersonList()
        {
                
        }
        private void buttonApplication_Click(object sender, EventArgs e)
        {
            contextMenuApplication.Show(buttonApplication, new Point(0, buttonApplication.Height));
            contextMenuApplication.AutoSize = true;
        }
        private void buttonDrivers_Click(object sender, EventArgs e)
        {
            Drivers frm = new Drivers();
            frm.ShowDialog();
            

        }
        private void buttonUsers_Click(object sender, EventArgs e)
        {
            UsersScreen frm = new UsersScreen();
            frm.ShowDialog();

        }
        private void buttonAccSetting_Click(object sender, EventArgs e)
        {
            contextMenuAccountSetting.Show(buttonAccSetting, new Point(0, buttonAccSetting.Height));
            contextMenuAccountSetting.AutoSize = true;
            
        }
        private void buttonPeople_Click(object sender, EventArgs e)
        {
            PeopleMangement frm = new PeopleMangement();
            frm.ShowDialog();
        }
        private void singOutToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Application.Restart();
            
        }
        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangePassword frm = new ChangePassword();
            frm.ShowDialog();
        }

        private void cuToolStripMenuItem_Click(object sender, EventArgs e)
        {

            
            ShowPersonDetails frm = new ShowPersonDetails(clsGlobal.CurrentUser.PersonID);
            frm.ShowDialog();
            

        }

        private void manageAppToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageApplicationTypes frm = new ManageApplicationTypes();
            frm.ShowDialog();
        }

        private void manageTestTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageTestType frm = new ManageTestType();
            frm.ShowDialog();
        }

        private void manageApllicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void localLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewLocalDrivingLicense frm = new NewLocalDrivingLicense();
            frm.ShowDialog();
        }

        private void localDrivingLicensApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LocalDrivingLicensApplication frm = new LocalDrivingLicensApplication();
            frm.ShowDialog();
        }

        private void detainToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
        }

        private void internationalLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewInternationLicenseApplication frm = new NewInternationLicenseApplication();
            frm.ShowDialog();
        }

        private void localDrivingLicensApplicationToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            InternationalDrivingLicensApplication frm = new InternationalDrivingLicensApplication();
            frm.ShowDialog();
        }

        private void renweDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RenewLocalDrivingLicense frm = new RenewLocalDrivingLicense();
            frm.ShowDialog();
        }

        private void replacmentForLostOrDamagedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReplacmentForLostOrdamagedLicense frm = new ReplacmentForLostOrdamagedLicense();
            frm.ShowDialog();
        }

        private void detsinLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DetainLicense frm = new DetainLicense();
            frm.ShowDialog();
        }

        private void relaseDetainedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReleaseDetainedLicense frm = new ReleaseDetainedLicense();
            frm.ShowDialog();
        }

        private void manageDetainLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListDetainedLicense frm = new ListDetainedLicense();
            frm.ShowDialog();
        }

        private void retakeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LocalDrivingLicensApplication frm = new LocalDrivingLicensApplication();
            frm.ShowDialog();
        }
    }
}
