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
    public partial class InternationalDrivingLicensApplication : Form
    {
        int _LDLAID, _AppID;
        public InternationalDrivingLicensApplication()
        {
            InitializeComponent();
            _RefreshApplicationsList();
            labelRecordCount.Text = dataGridView1.RowCount.ToString();
        }
        private void _RefreshApplicationsList()
        {
            dataGridView1.DataSource = clsInternationalLicense.ListInternationalDriverLicences();
            dataGridView1.Columns["InternationalLicenseID"].FillWeight = 120;
            dataGridView1.Columns["ApplicationID"].FillWeight = 70;
            dataGridView1.Columns["DriverID"].FillWeight = 50;
            dataGridView1.Columns["IssuedUsingLocalLicenseID"].HeaderText = "Local License ID";
            dataGridView1.Columns["IssuedUsingLocalLicenseID"].FillWeight = 90;
            //dataGridView1.Columns["IssueDate"].DefaultCellStyle.Format = "dd/MM/yyyy";
            //dataGridView1.Columns["ExpirationDate"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dataGridView1.Columns["ExpirationDate"].FillWeight = 100;
            dataGridView1.Columns["IssueDate"].FillWeight = 100;
            dataGridView1.Columns["IsActive"].FillWeight = 50;
            dataGridView1.Columns["CreatedByUserID"].Visible = false;

        }
        private void _FillComboBox()
        {
            comboBoxFilter.Items.Add("None");
            comboBoxFilter.Items.Add("International License ID");
            comboBoxFilter.Items.Add("Local License ID");
            comboBoxFilter.Items.Add("Application ID");
            comboBoxFilter.Items.Add("Status");
            comboBoxFilter.SelectedIndex = 0;

            comboBoxStatus.Items.Add("All");
            comboBoxStatus.Items.Add("Active");
            comboBoxStatus.Items.Add("Deactive");
          
            comboBoxStatus.SelectedIndex = 0;
        }
        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void InternationalDrivingLicensApplication_Load(object sender, EventArgs e)
        {
            _FillComboBox();
            _RefreshApplicationsList();
        }
        private void comboBoxFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBoxFilter.Clear();
            if (comboBoxFilter.SelectedIndex == 0)
            {
                textBoxFilter.Visible = false;
                comboBoxStatus.Visible = false;
            }
            else if (comboBoxFilter.SelectedIndex == 4)
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
                case "International License ID":
                    FilterColum = "InternationalLicenseID";
                    break;
                case "Local License ID":
                    FilterColum = "IssuedUsingLocalLicenseID";
                    break;
                case "Application ID":
                    FilterColum = "ApplicationID";
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

                if (FilterColum == "InternationalLicenseID")
                {
                    if (int.TryParse(textBoxFilter.Text.Trim(), out int result))
                    {
                        ((DataTable)dataGridView1.DataSource).DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColum, result);
                    }
                }
                else if (FilterColum == "IssuedUsingLocalLicenseID")
                {
                    if (int.TryParse(textBoxFilter.Text.Trim(), out int result))
                    {
                        ((DataTable)dataGridView1.DataSource).DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColum, result);
                    }
                }
                else if (FilterColum == "ApplicationID")
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
        private void buttonAddNewApplication_Click(object sender, EventArgs e)
        {
            NewInternationLicenseApplication frm = new NewInternationLicenseApplication();
            frm.ShowDialog();
        }
        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int DriverID = (int)dataGridView1.CurrentRow.Cells[2].Value;
            clsDriver Driver = new clsDriver();
            Driver = clsDriver.FindByDriverID(DriverID);
            clsPerson Person = new clsPerson();
            Person = clsPerson.Find(Driver.PersonID);

            LicenseHistory frm = new LicenseHistory(Person.NationalNum);
            frm.ShowDialog();
        }
        private void showLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int ApplicationID = (int)dataGridView1.CurrentRow.Cells[1].Value;
            clsLocalDrivingLicenseApplications local = clsLocalDrivingLicenseApplications.FindByApplicationID(ApplicationID);

            LicenseInfo frm = new LicenseInfo( local.AppID);
            frm.ShowDialog();
        }
        private void ShowPersonDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int DriverID = (int)dataGridView1.CurrentRow.Cells[2].Value;
            clsDriver Driver = new clsDriver();
            Driver = clsDriver.FindByDriverID(DriverID);
            clsPerson Person = new clsPerson();
            Person = clsPerson.Find(Driver.PersonID);

            ShowPersonDetails frm = new ShowPersonDetails(Person.ID);
            frm.ShowDialog();
            
        }
        private void comboBoxStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool? FilterValue;

            switch (comboBoxStatus.Text)
            {
               
                case "Active": FilterValue =  true; break;
                case "Deactive": FilterValue = false; break;
                default: FilterValue = null; break;
            }
            if (dataGridView1.DataSource == null) return;

            DataView dv = ((DataTable)dataGridView1.DataSource).DefaultView;

            if (FilterValue == null || comboBoxStatus.Text == "All")
            {
                dv.RowFilter = "";
            }
            else
            {

              
                dv.RowFilter = "[IsActive] = " + (FilterValue.Value ? "true" : "false");
            }
            labelRecordCount.Text = dv.Count.ToString();
        }
    }
}
