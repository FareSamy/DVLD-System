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
    public partial class LocalDrivingLicensApplication : Form
    {
        int _LDLAID, _AppID;
        public LocalDrivingLicensApplication()
        {
            InitializeComponent();
            _RefreshApplicationsList();
            labelRecordCount.Text = dataGridView1.RowCount.ToString();
        }
        private void _RefreshApplicationsList()
        {
            dataGridView1.DataSource = clsApplication.ListApplications();
            dataGridView1.Columns["Full Name"].FillWeight = 200;
            dataGridView1.Columns["L.D.LAppID"].FillWeight = 70;
            dataGridView1.Columns["Driving Class"].FillWeight = 200;
            dataGridView1.Columns["NationalNo"].FillWeight = 70;
            dataGridView1.Columns["ApplicationDate"].FillWeight = 100;
            dataGridView1.Columns["Passed Tests"].FillWeight = 100;
            dataGridView1.Columns["Status"].FillWeight = 70;
        }
        private void _FillComboBox()
        {

      
            comboBoxFilter.Items.Add("None");
            comboBoxFilter.Items.Add("Application ID");
            comboBoxFilter.Items.Add("National No");
            comboBoxFilter.Items.Add("Status");
            comboBoxFilter.SelectedIndex = 0;

            comboBoxStatus.Items.Add("All");
            comboBoxStatus.Items.Add("New");
            comboBoxStatus.Items.Add("Completed");
            comboBoxStatus.Items.Add("Cancelled");
            comboBoxStatus.SelectedIndex = 0;
        }
        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void LocalDrivingLicensApplication_Load(object sender, EventArgs e)
        {
            _FillComboBox();
            _RefreshApplicationsList();
          
        }
        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
         
            if (this.dataGridView1.Columns[e.ColumnIndex].Name == "Status" || e.ColumnIndex == 6)
            {
                if (e.Value != null)
                {
                    string status = e.Value.ToString();

               
                    switch (status)
                    {
                        case "Cancelled":
                            e.CellStyle.BackColor = Color.Red;
                            break;
                        case "Completed":
                            e.CellStyle.BackColor = Color.Green;
                            break;
                    }
                }
            }
        }
        private void _PassedTests()
        {
            int x = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            string z = Convert.ToString (dataGridView1.CurrentRow.Cells[6].Value).Trim();
            if (z == "Cancelled")
            {
                scheduleVisionTestToolStripMenuItem.Enabled = false;
                ScheduleWrittrnTestToolStripMenuItem.Enabled = false;
                scheduleStreetTestToolStripMenuItem.Enabled = false;
                return;
            }
            if (clsTests.IsPassedVisionTest(x))
            {
              
                if (clsTests.IsPassedWrittenTest(x))
                {
                    if (clsTests.IsPassedStreetTest(x))
                    {
                        scheduleVisionTestToolStripMenuItem.Enabled = false;
                        ScheduleWrittrnTestToolStripMenuItem.Enabled = false;
                        scheduleStreetTestToolStripMenuItem.Enabled = false;

                        

                    }
                    else
                    {
                        scheduleVisionTestToolStripMenuItem.Enabled = false;
                        ScheduleWrittrnTestToolStripMenuItem.Enabled = false;
                        scheduleStreetTestToolStripMenuItem.Enabled = true;

                       

                    }
                }
                else
                {
                    scheduleVisionTestToolStripMenuItem.Enabled = false;
                    ScheduleWrittrnTestToolStripMenuItem.Enabled = true;
                    scheduleStreetTestToolStripMenuItem.Enabled = false;


                }
            }
            else
            {
                scheduleVisionTestToolStripMenuItem.Enabled = true;
                ScheduleWrittrnTestToolStripMenuItem.Enabled = false;
                scheduleStreetTestToolStripMenuItem.Enabled = false;


            }
        }
        private void _IssueLicensecFirstTime()
        {
            clsLicense license = new clsLicense();
            clsLocalDrivingLicenseApplications LDLA = new clsLocalDrivingLicenseApplications();

            _LDLAID = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            
            LDLA = clsLocalDrivingLicenseApplications.FindByLocalDrivingLicenseApplicationID(_LDLAID);
            if (LDLA != null)
            {
              
                _AppID = LDLA.AppID;
                
                license = clsLicense.FindByApplicationID(_AppID);
                if (license != null)
                {
                    issueToolStripMenuItem.Enabled = false;
                }
                else
                {
                    if (clsTests.IsPassedStreetTest(_LDLAID))
                    {
                        issueToolStripMenuItem.Enabled = true;
                    }
                    else
                    {
                        issueToolStripMenuItem.Enabled = false;
                    }
                }
            }
            else
            {
                MessageBox.Show("SomthingWrong!!!");
            }
        }
        private void _CheckComplete()
        {
            string status = dataGridView1.CurrentRow.Cells["Status"].Value.ToString();

            if (status == "Completed")
            {
                editApplicationToolStripMenuItem.Enabled = false;
                delectApplicationToolStripMenuItem.Enabled = false;
                cancelApplicationToolStripMenuItem.Enabled = false;
                shecadToolStripMenuItem.Enabled = false;
                showLicenseToolStripMenuItem.Enabled = true;
            }
            else if (status == "Cancelled")
            {
                editApplicationToolStripMenuItem.Enabled = false;
                delectApplicationToolStripMenuItem.Enabled = false;
                cancelApplicationToolStripMenuItem.Enabled = false;
                shecadToolStripMenuItem.Enabled = false;
                showLicenseToolStripMenuItem.Enabled = false;
            }
            else
            {
               
                editApplicationToolStripMenuItem.Enabled = true;
                delectApplicationToolStripMenuItem.Enabled = true;
                cancelApplicationToolStripMenuItem.Enabled = true;
                shecadToolStripMenuItem.Enabled = true;
                showLicenseToolStripMenuItem.Enabled = false;
            }
        }
        private void comboBoxFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBoxFilter.Clear();
            if (comboBoxFilter.SelectedIndex == 0)
            {
                textBoxFilter.Visible = false;
                comboBoxStatus.Visible = false;
            }
            else if (comboBoxFilter.SelectedIndex == 3)
            {
                textBoxFilter.Visible = false;
                comboBoxStatus.Visible = true;
            }
            else
            {
                textBoxFilter.Visible = true;
                comboBoxStatus.Visible = false;
            }
        }
        private void textBoxFilter_TextChanged(object sender, EventArgs e)
        {

            string FilterColum = "";

            switch (comboBoxFilter.Text)
            {
                case "Application ID":
                    FilterColum = "L.D.LAppID";
                    break;
                case "National No":
                    FilterColum = "NationalNo";
                    break;
                case "Status":
                    FilterColum = "Status";
                    break;
                default:
                    FilterColum = "None";
                    break;
            }
            {
                if (textBoxFilter.Text.Trim() == "" || FilterColum == "None")
                {
                    ((DataTable)dataGridView1.DataSource).DefaultView.RowFilter = "";
                    labelRecordCount.Text = dataGridView1.Rows.Count.ToString();
                    return;
                }

                if (FilterColum == "L.D.LAppID")
                {
                    if (int.TryParse(textBoxFilter.Text.Trim(), out int result))
                    {
                        ((DataTable)dataGridView1.DataSource).DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColum, result);
                    }
                }

                else
                {
                    ((DataTable)dataGridView1.DataSource).DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColum, textBoxFilter.Text.Trim());
                }

                labelRecordCount.Text = (dataGridView1.Rows.Count ).ToString();

            }

        }
        private void comboBoxStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            string FilterValue = "";
        
            switch (comboBoxStatus.Text)
            {
                case "New": FilterValue = "New"; break;
                case "Completed": FilterValue = "Completed"; break;
                case "Cancelled": FilterValue = "Cancelled"; break;
                default: FilterValue = ""; break;
            }
            if (dataGridView1.DataSource == null) return;

            DataView dv = ((DataTable)dataGridView1.DataSource).DefaultView;

            if (FilterValue == "" || comboBoxStatus.Text == "All")
            {
                dv.RowFilter = "";
            }
            else
            {
             
                dv.RowFilter = string.Format("[Status] = '{0}'", FilterValue);
            }
            labelRecordCount.Text = dv.Count.ToString();
        }
        private void delectApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Are you sure to DELETE this [" + dataGridView1.CurrentRow.Cells[0].Value + "]",
               "Confirm Delete", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                if (clsLocalDrivingLicenseApplications.DeleteLocalLicensApp((int)dataGridView1.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("Person Deleted Successfully");
                    _RefreshApplicationsList();
                }
                else

                {
                    MessageBox.Show("Can not delete this application because its have an open conactions","Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void cancelApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Are you sure to Cancel this [" + dataGridView1.CurrentRow.Cells[0].Value + "]",
               "Confirm Cancel", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                int x = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                clsLocalDrivingLicenseApplications LocalApplication = clsLocalDrivingLicenseApplications.FindByLocalDrivingLicenseApplicationID(x);
                clsApplication application = clsApplication.Find(LocalApplication.AppID);
                if (application.AppStatus == 3)
                {
                    MessageBox.Show("Can not Cancel completed applications ", "Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else
                {
                    application.AppStatus = 2;
                    if (application.Save())
                    {
                        MessageBox.Show("Application Canceled successfully", "Canceled!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        _RefreshApplicationsList();
                    }
                    else
                    {
                        MessageBox.Show("Somthing wrong can not Cancel this application ", "Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }

                }
               
            }
        }
        private void buttonAddNewApplication_Click(object sender, EventArgs e)
        {
            NewLocalDrivingLicense frm = new NewLocalDrivingLicense();
            frm.ShowDialog();
            _RefreshApplicationsList();
        }
        private void scheduleVisionTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LDLAID = (int)dataGridView1.CurrentRow.Cells[0].Value;
            clsLocalDrivingLicenseApplications local = clsLocalDrivingLicenseApplications.FindByLocalDrivingLicenseApplicationID(LDLAID);

            VisionTest frm = new VisionTest(LDLAID,local.AppID);
            frm.ShowDialog();
            _RefreshApplicationsList();
        }
        private void shecadToolStripMenuItem_DropDownOpened(object sender, EventArgs e)
        {
            _PassedTests();
        }
        private void ScheduleWrittrnTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LDLAID = (int)dataGridView1.CurrentRow.Cells[0].Value;
            clsLocalDrivingLicenseApplications local = clsLocalDrivingLicenseApplications.FindByLocalDrivingLicenseApplicationID(LDLAID);

            WrittenTest frm = new WrittenTest(LDLAID, local.AppID);
            frm.ShowDialog();
            _RefreshApplicationsList();

        }
        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                _CheckComplete();
                _IssueLicensecFirstTime();
            }
        }
        private void scheduleStreetTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LDLAID = (int)dataGridView1.CurrentRow.Cells[0].Value;
            clsLocalDrivingLicenseApplications local = clsLocalDrivingLicenseApplications.FindByLocalDrivingLicenseApplicationID(LDLAID);

            StreetTest frm = new StreetTest(LDLAID, local.AppID);
            frm.ShowDialog();
            _RefreshApplicationsList();
        }
        private void showLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LDLAID = (int)dataGridView1.CurrentRow.Cells[0].Value;
            clsLocalDrivingLicenseApplications local = clsLocalDrivingLicenseApplications.FindByLocalDrivingLicenseApplicationID(LDLAID);
            
            LicenseInfo frm = new LicenseInfo(local.AppID);
            frm.ShowDialog();
            
        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string NationalNo = (string)dataGridView1.CurrentRow.Cells[2].Value;
            LicenseHistory frm = new LicenseHistory(NationalNo);
            frm.ShowDialog();
        }

        private void issueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            IssueLicsenceForTheFirstTime frm = new IssueLicsenceForTheFirstTime(_LDLAID,_AppID);
            frm.ShowDialog();
            _RefreshApplicationsList();
        }
    }
}
