using DVLD_BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace DVLD_System
{
    public partial class PeopleMangement : Form
    {
   
        public PeopleMangement()
        {
            InitializeComponent();
            _RefreshPeopleList();
          
            labelRecordCount.Text = dataGridViewPeopleList.RowCount.ToString();

        }

        private void _RefreshPeopleList()
        {
            dataGridViewPeopleList.DataSource = clsPerson.ListPersons();
            
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
                textBoxFilter.Visible = Enabled;
            }
        }
        private void _FillComboBox()
        {
            comboBoxFilter.Items.Add("None");
            comboBoxFilter.Items.Add("Person ID");
            comboBoxFilter.Items.Add("National ID");
            comboBoxFilter.Items.Add("First Name");
            comboBoxFilter.Items.Add("Last Name");
            comboBoxFilter.SelectedIndex = 0;
        }
        private void buttonAddNewPerson_Click(object sender, EventArgs e)
        {
            Add_EditPersonInfo frm = new Add_EditPersonInfo(-1);
            frm .ShowDialog();
            _RefreshPeopleList();
        }
        private void PeopleMangement_Load(object sender, EventArgs e)
        {
            _FillComboBox();
            _RefreshPeopleList();
        }
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure to DELETE this [" + dataGridViewPeopleList.CurrentRow.Cells[0].Value + "]",
                "Confirm Delete", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                if (clsPerson.DeltetePerson((int)dataGridViewPeopleList.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("Person Deleted Successfully");
                    _RefreshPeopleList();
                }
                else

                {
                    MessageBox.Show("Person NOT Deleted ,Error!!");
                }
            }
        }
        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Add_EditPersonInfo frm = new Add_EditPersonInfo((int)dataGridViewPeopleList.CurrentRow.Cells[0].Value);
            frm .ShowDialog();
            _RefreshPeopleList();
        }
        private void sendEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Will Availbel Soon");
           
        }
        private void makeCallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Will Availbel Soon");

        }
        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void showInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dataGridViewPeopleList.CurrentRow.Cells["PersonID"].Value);
            ShowPersonDetails frm = new ShowPersonDetails(id);
            frm.ShowDialog();
           
        }
        private void textBoxFilter_TextChanged(object sender, EventArgs e)
        {
            string FilterColum = "";

            switch (comboBoxFilter.Text)
            {
                case "Person ID":
                    FilterColum = "PersonID";
                    break;
                case "National ID":
                    FilterColum = "NationalNo";
                    break;
                case "First Name":
                    FilterColum = "FirstName";
                    break;
                case "Last Name":
                    FilterColum = "LastName";
                    break;
                default:
                    FilterColum = "None";
                    break;
            }
            {
                if (textBoxFilter.Text.Trim() == "" || FilterColum == "None")
                {
                    ((DataTable)dataGridViewPeopleList.DataSource).DefaultView.RowFilter = "";
                    labelRecordCount.Text = dataGridViewPeopleList.Rows.Count.ToString();
                    return;
                }

                if (FilterColum == "PersonID")
                {
                    if (int.TryParse(textBoxFilter.Text.Trim(), out int result))
                    {
                        ((DataTable)dataGridViewPeopleList.DataSource).DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColum, result);
                    }
                }
                else
                {
                    ((DataTable)dataGridViewPeopleList.DataSource).DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColum, textBoxFilter.Text.Trim());
                }

                labelRecordCount.Text = dataGridViewPeopleList.RowCount.ToString();


            }
        }
        private void textBoxFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (comboBoxFilter.SelectedIndex == 1)
            {
                if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
            else if (comboBoxFilter.SelectedIndex == 3 || comboBoxFilter.SelectedIndex == 4)
            {
                if (char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
          
        }
    }
}
