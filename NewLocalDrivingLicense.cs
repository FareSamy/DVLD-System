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
    public partial class NewLocalDrivingLicense : Form
    {
        public NewLocalDrivingLicense()
        {
            InitializeComponent();
        }
        clsPerson Person;
        bool _AllowTap2 = false;
        int _PersonID;

        private void buttonSave_Click(object sender, EventArgs e)
        {

        }
        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void buttonNext_Click(object sender, EventArgs e)
        {
            Person = filterPepoleControl1.SearchedPerson();

            if (clsPerson.Find(Person.ID) != null)
            {
                _PersonID = Person.ID;

                _AllowTap2 = true;
                tabControl1.SelectedIndex = 1;
            }
            else
            {
                MessageBox.Show("No person selected please select person and try again", "Select a person", MessageBoxButtons.OK, MessageBoxIcon.Information);
               
            }

        }
        private void _FillComboBox()
        {
            DataTable DTLicenseClasses = clsLicenseClasses.ListClasses();
            comboBoxLicensClass.DataSource = DTLicenseClasses;
            comboBoxLicensClass.DisplayMember = "ClassName";
            comboBoxLicensClass.ValueMember = "LicenseClassID";

        }
        private void NewLocalDrivingLicense_Load(object sender, EventArgs e)
        {
            _FillComboBox();
        }
        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {

            if (e.TabPageIndex == 1 && !_AllowTap2)
            {
                e.Cancel = true;
                MessageBox.Show("Please select a person and click Next first.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if (e.TabPageIndex == 0)
            {
                _AllowTap2 = false;
                labelAppDateResult.Text = DateTime.Now.ToString();
            }
        }
        private void tabPage2_Click(object sender, EventArgs e)
        {
          
        }
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (tabControl1.SelectedIndex == 1)
            {
                labelAppDateResult.Text = DateTime.Now.ToString("dd/MM/yyyy");
                labelCreatedByResult.Text = clsGlobal.CurrentUser.UserName;
                labelAppFeesResult.Text = "15";
              
            }
        }

        private void buttonSave_Click_1(object sender, EventArgs e)
        {
            clsApplication application = new clsApplication();
            application.AppStatus = 1;
            application.AppDate= DateTime.Now;
            application.PaidFees = 15;
            application.AppPersonID = _PersonID;
            application.CreatedByUserID = clsGlobal.CurrentUser.UserID;
            application.AppTypeID = 1;

             
             
            int SelectedLicenseClassID = (int)comboBoxLicensClass.SelectedValue;
            if (clsLocalDrivingLicenseApplications.IsDoesPersonHaveActiveApplication(_PersonID, SelectedLicenseClassID))
            {
                MessageBox.Show("Choose onther license class the selected person already have an active application for the selected class", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (application.Save())
            {
                clsLocalDrivingLicenseApplications localDrivingLicenseApplications = new clsLocalDrivingLicenseApplications();
                localDrivingLicenseApplications.AppID = application.AppID;
                localDrivingLicenseApplications.LicenseClassID = SelectedLicenseClassID;
                if (localDrivingLicenseApplications.Save())
                {
                    MessageBox.Show("Data Saved Successflly", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error saving Local Driving License Part");
                }
            }
            else
            {
                MessageBox.Show("Something went wrong with Application Save", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}
