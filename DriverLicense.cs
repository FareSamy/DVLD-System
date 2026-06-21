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
    public partial class DriverLicense : UserControl
    {
        string _NationalNo;
        clsPerson _Person;
        clsDriver _Driver;
        clsApplication _Application;
        clsLicense _License;
        clsInternationalLicense _InternationalLicense;
        public DriverLicense()
        {
            InitializeComponent();
        }
        public void LoadInfo(string  NationalNo)
        {
            _NationalNo = NationalNo;
            _LoadData();
        }
        private void _LoadData()
        {
            _Person = new clsPerson();
            _Person = clsPerson.Find(_NationalNo);
            if (_Person != null)
            {
                _Driver = new clsDriver();
                _Driver = clsDriver.FindByPersonID(_Person.ID);
                if (_Driver != null)
                {
                    // Local license
                    dataGridViewLocalLicenseHistory.DataSource = clsLicense.ListDriverLicences(_Driver.DriverID);
                    
                    dataGridViewLocalLicenseHistory.Columns["ApplicationID"].HeaderText = "AppID";
                    dataGridViewLocalLicenseHistory.Columns["LicenseClassName"].HeaderText = "Class Name";
                    dataGridViewLocalLicenseHistory.Columns["IsActive"].HeaderText = "Active";
                    dataGridViewLocalLicenseHistory.Columns["LicenseID"].Width = 110;
                    dataGridViewLocalLicenseHistory.Columns["ApplicationID"].Width = 85;
                    dataGridViewLocalLicenseHistory.Columns["LicenseClassName"].Width = 320;
                    dataGridViewLocalLicenseHistory.Columns["IsActive"].Width = 80;
                    dataGridViewLocalLicenseHistory.Columns["IssueDate"].Width = 150;
                    dataGridViewLocalLicenseHistory.Columns["ExpirationDate"].Width = 150;
                    dataGridViewLocalLicenseHistory.Columns["IssueDate"].DefaultCellStyle.Format = "dd/MM/yyyy";
                    dataGridViewLocalLicenseHistory.Columns["ExpirationDate"].DefaultCellStyle.Format = "dd/MM/yyyy";

                    // International license

                    dataGridViewInternationalLicenseHistory.DataSource = clsInternationalLicense.ListInternationalDriverLicences(_Driver.DriverID);


                
                    if (!dataGridViewInternationalLicenseHistory.IsHandleCreated)
                    {
                        var forceHandle = dataGridViewInternationalLicenseHistory.Handle;
                    }

                        dataGridViewInternationalLicenseHistory.Columns["ApplicationID"].HeaderText = "AppID";
                        dataGridViewInternationalLicenseHistory.Columns["InternationalLicenseID"].HeaderText = "License ID";

                        dataGridViewInternationalLicenseHistory.Columns["IsActive"].HeaderText = "Active";
                        dataGridViewInternationalLicenseHistory.Columns["InternationalLicenseID"].Width = 110;
                        dataGridViewInternationalLicenseHistory.Columns["ApplicationID"].Width = 85;
                        dataGridViewInternationalLicenseHistory.Columns["IsActive"].Width = 80;
                        dataGridViewInternationalLicenseHistory.Columns["IssueDate"].Width = 150;
                        dataGridViewInternationalLicenseHistory.Columns["ExpirationDate"].Width = 150;
                        dataGridViewInternationalLicenseHistory.Columns["IssueDate"].DefaultCellStyle.Format = "dd/MM/yyyy";
                        dataGridViewInternationalLicenseHistory.Columns["ExpirationDate"].DefaultCellStyle.Format = "dd/MM/yyyy";
                        dataGridViewInternationalLicenseHistory.Columns["CreatedByUserID"].Visible = false;


                    labelRecordCountLocal.Text = dataGridViewLocalLicenseHistory.RowCount.ToString();
                    labelRecordCountInternational.Text = dataGridViewInternationalLicenseHistory.RowCount.ToString();

                }
            }
        }

        private void showLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LocalLicensID = (int)dataGridViewLocalLicenseHistory.CurrentRow.Cells[0].Value;
        
            
                _License = new clsLicense();
                _License = clsLicense.Find(LocalLicensID);
                _Application = new clsApplication();
                _Application = clsApplication.Find(_License.ApplicationID);
                clsLocalDrivingLicenseApplications local = clsLocalDrivingLicenseApplications.FindByApplicationID(_License.ApplicationID);

                LicenseInfo frm = new LicenseInfo( _Application.AppID);
                frm.ShowDialog();
            
            
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int InternationalLicensID = (int)dataGridViewInternationalLicenseHistory.CurrentRow.Cells[0].Value;
            InternationalDriverInfo frm = new InternationalDriverInfo(InternationalLicensID);
            frm.ShowDialog();
        }
    }
}
