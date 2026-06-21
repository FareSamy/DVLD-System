using DVLD_BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_System
{
    public partial class ListDetainedLicense : Form
    {
        clsApplication _Application;
        clsLocalDrivingLicenseApplications _LDLA;
        clsLicense _License;
        clsPerson _Person;
        public ListDetainedLicense()
        {
            InitializeComponent();
            _RefreshDetainedLicenseList();
            labelRecordCount.Text = dataGridView1.RowCount.ToString();
        }
        private void _RefreshDetainedLicenseList()
        
        {
            dataGridView1.DataSource = clsDetainedLicense.ListDetainedLicense ();
            dataGridView1.Columns["DetainID"].FillWeight = 55;
            dataGridView1.Columns["LicenseID"].FillWeight = 58;
            dataGridView1.Columns["DetainDate"].FillWeight = 65;
            dataGridView1.Columns["DetainDate"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dataGridView1.Columns["IsReleased"].HeaderText = "Released";
            dataGridView1.Columns["IsReleased"].FillWeight = 50;
            dataGridView1.Columns["FineFees"].HeaderText = "Fine Fees";
            dataGridView1.Columns["FineFees"].FillWeight = 65;
            dataGridView1.Columns["ReleaseDate"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dataGridView1.Columns["ReleaseDate"].FillWeight = 65;
            dataGridView1.Columns["ReleaseApplicationID"].HeaderText = "R.App.ID";
            dataGridView1.Columns["ReleaseApplicationID"].FillWeight = 50;
            dataGridView1.Columns["FullName"].FillWeight = 200;
            dataGridView1.Columns["NationalNo"].FillWeight = 60;
        }
        private void _FillComboBox()
        {


            comboBoxFilter.Items.Add("None");
            comboBoxFilter.Items.Add("Detain ID");
            comboBoxFilter.Items.Add("National No");
            comboBoxFilter.Items.Add("Full Name");
            comboBoxFilter.Items.Add("Release Application ID");
            comboBoxFilter.Items.Add("Is Released");
            comboBoxFilter.SelectedIndex = 0;

            comboBoxStatus.Items.Add("All");
            comboBoxStatus.Items.Add("Released");
            comboBoxStatus.Items.Add("Detained");
            comboBoxStatus.SelectedIndex = 0;
        }
        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonDetain_Click(object sender, EventArgs e)
        {
            DetainLicense frm = new DetainLicense();
            frm.ShowDialog();
            _RefreshDetainedLicenseList();
        }

        private void buttonRelease_Click(object sender, EventArgs e)
        {
            ReleaseDetainedLicense frm = new ReleaseDetainedLicense();
            frm.ShowDialog();
            _RefreshDetainedLicenseList();
        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string NationalNo = (string)dataGridView1.CurrentRow.Cells[8].Value;
            LicenseHistory frm = new LicenseHistory(NationalNo);
            frm.ShowDialog();
        }
        
        private void showLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LicenseID = (int)dataGridView1.CurrentRow.Cells[1].Value;
            _License = new clsLicense();
            _License = clsLicense.Find(LicenseID);
            _Application = new clsApplication();
            _Application = clsApplication.Find(_License.ApplicationID);

            LicenseInfo frm = new LicenseInfo( _Application.AppID);
            frm.ShowDialog();
        }

        private void issueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string NationalNo = (string)dataGridView1.CurrentRow.Cells[8].Value;
            _Person = new clsPerson();
            _Person = clsPerson.Find(NationalNo);
            ShowPersonDetails frm = new ShowPersonDetails(_Person.ID);
            frm.ShowDialog();
        }

        private void ListDetainedLicense_Load(object sender, EventArgs e)
        {
            _FillComboBox();
        }

        private void comboBoxFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBoxFilter.Clear();
            if (comboBoxFilter.SelectedIndex == 0)
            {
                textBoxFilter.Visible = false;
                comboBoxStatus.Visible = false;
            }
            else if (comboBoxFilter.SelectedIndex == 5)
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
            string FilterColumn = "";

            switch (comboBoxFilter.Text)
            {
                case "Detain ID":
                    FilterColumn = "DetainID";
                    break;
                case "National No":
                    FilterColumn = "NationalNo";
                    break;
                case "Full Name":
                    FilterColumn = "FullName";
                    break;
                case "Release Application ID":
                    FilterColumn = "ReleaseApplicationID";
                    break;
                case "Is Released":
                    FilterColumn = "IsReleased";
                    break;
                default:
                    FilterColumn = "None";
                    break;
            }

            if (textBoxFilter.Text.Trim() == "" || FilterColumn == "None")
            {
                ((DataTable)dataGridView1.DataSource).DefaultView.RowFilter = "";
                labelRecordCount.Text = dataGridView1.Rows.Count.ToString();
                return;
            }

            if (FilterColumn == "DetainID" || FilterColumn == "ReleaseApplicationID")
            {
                if (int.TryParse(textBoxFilter.Text.Trim(), out int result))
                {
                    ((DataTable)dataGridView1.DataSource).DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, result);
                }
                else
                {
                    ((DataTable)dataGridView1.DataSource).DefaultView.RowFilter = "1=0"; 
                }
            }
            else if (FilterColumn == "IsReleased")
            {
                string value = textBoxFilter.Text.Trim().ToLower();

                if (value == "yes" || value == "1" || value == "true")
                {
                    ((DataTable)dataGridView1.DataSource).DefaultView.RowFilter = "[IsReleased] = 1";
                }
                else if (value == "no" || value == "0" || value == "false")
                {
                    ((DataTable)dataGridView1.DataSource).DefaultView.RowFilter = "[IsReleased] = 0";
                }
                else
                {
                    ((DataTable)dataGridView1.DataSource).DefaultView.RowFilter = "1=0";
                }
            }
           
            else
            {
                ((DataTable)dataGridView1.DataSource).DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, textBoxFilter.Text.Trim());
            }

            labelRecordCount.Text = dataGridView1.Rows.Count.ToString();


        }

        private void comboBoxStatus_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (dataGridView1.DataSource == null) return;

            DataView dv = ((DataTable)dataGridView1.DataSource).DefaultView;

           
            switch (comboBoxStatus.Text)
            {
                case "Released":
                    dv.RowFilter = "[IsReleased] = 1"; 
                    break;

                case "Detained":
                    dv.RowFilter = "[IsReleased] = 0"; 
                    break;

                default: 
                    dv.RowFilter = "";
                    break;
            }

            
            labelRecordCount.Text = dv.Count.ToString();
        }

      
    }
}
