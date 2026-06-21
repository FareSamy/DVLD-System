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
    public partial class Drivers : Form
    {
        public Drivers()
        {
        
            InitializeComponent();
            _RefreshUsersList();
            labelRecordCount.Text = dataGridViewDrivers.RowCount.ToString();

        }
        private void _RefreshUsersList()
        {
            dataGridViewDrivers.DataSource = clsDriver.ListUsers();
            dataGridViewDrivers.Columns["PersonID"].FillWeight = 65;
            dataGridViewDrivers.Columns["DriverID"].FillWeight = 65;
            dataGridViewDrivers.Columns["NationalNo"].FillWeight = 65;
            dataGridViewDrivers.Columns["Date"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dataGridViewDrivers.Columns["Date"].FillWeight =80;
            dataGridViewDrivers.Columns["FullName"].FillWeight = 200;
            dataGridViewDrivers.Columns["ActiveLicenses"].FillWeight = 100;
            dataGridViewDrivers.Columns["ActiveLicenses"].HeaderText = "Active Licenses";

        }
        private void _FillComboBox()
        {
            comboBoxFilter.Items.Add("None");
            comboBoxFilter.Items.Add("Driver ID");
            comboBoxFilter.Items.Add("Person ID");
            comboBoxFilter.Items.Add("National No");
            comboBoxFilter.SelectedIndex = 0;
            
        }
        private void Drivers_Load(object sender, EventArgs e)
        {
            _FillComboBox();
            _RefreshUsersList();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBoxFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBoxFilter.Clear();
            if (comboBoxFilter.SelectedIndex == 0)
            {
                textBoxFilter.Visible = false;
               
            }
            else
            {
                textBoxFilter.Visible = true;
               
            }
        }

        private void textBoxFilter_TextChanged(object sender, EventArgs e)
        {


            string FilterColum = "";



            switch (comboBoxFilter.Text)

            {

                case "Driver ID":

                    FilterColum = "DriverID";

                    break;

                case "Person ID":

                    FilterColum = "PersonID";

                    break;

                case "National No":

                    FilterColum = "NationalNo";

                    break;

                default:

                    FilterColum = "None";

                    break;

            }

            {

                if (textBoxFilter.Text.Trim() == "" || FilterColum == "None")

                {

                    ((DataTable)dataGridViewDrivers.DataSource).DefaultView.RowFilter = "";

                    labelRecordCount.Text = dataGridViewDrivers.Rows.Count.ToString();

                    return;

                }



                if (FilterColum == "PersonID" || FilterColum == "DriverID")

                {

                    if (int.TryParse(textBoxFilter.Text.Trim(), out int result))

                    {

                        ((DataTable)dataGridViewDrivers.DataSource).DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColum, result);

                    }

                }



                else

                {

                    ((DataTable)dataGridViewDrivers.DataSource).DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColum, textBoxFilter.Text.Trim());

                }



                labelRecordCount.Text = (dataGridViewDrivers.Rows.Count ).ToString();
            }
        }

        private void textBoxFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (comboBoxFilter.SelectedIndex == 1 || comboBoxFilter.SelectedIndex == 2)
            {
                if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
            else if (comboBoxFilter.SelectedIndex == 4)
            {
                if (char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
        }
    }
}
