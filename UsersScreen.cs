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
    public partial class UsersScreen : Form
    {
        public UsersScreen()
        {
            InitializeComponent();
            _RefreshUsersList();
            
            labelRecordCount.Text = dataGridViewUsers.RowCount.ToString();

        }
        private void _RefreshUsersList()
        {
            dataGridViewUsers.DataSource = clsUser.ListUsers();
            dataGridViewUsers.Columns["FullName"].FillWeight = 180;
            dataGridViewUsers.Columns["UserID"].FillWeight = 50;
            dataGridViewUsers.Columns["UserName"].FillWeight = 80;
            dataGridViewUsers.Columns["PersonID"].FillWeight = 50;
            dataGridViewUsers.Columns["IsActive"].FillWeight = 50;

        }
        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void _FillComboBox()
        {
            comboBoxFilter.Items.Add("None");
            comboBoxFilter.Items.Add("User ID");
            comboBoxFilter.Items.Add("Person ID");
            comboBoxFilter.Items.Add("UserName");
            comboBoxFilter.Items.Add("Is Active");
            comboBoxFilter.SelectedIndex = 0;

            comboBoxIsActive.Items.Add("All");
            comboBoxIsActive.Items.Add("Yes");
            comboBoxIsActive.Items.Add("No");
            comboBoxIsActive.SelectedIndex = 0;
        }
        private void UsersScreen_Load(object sender, EventArgs e)
        {
            _FillComboBox();
            _RefreshUsersList();
        }
        private void comboBoxFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBoxFilter.Clear();
            if (comboBoxFilter.SelectedIndex == 0)
            {
                textBoxFilter.Visible = false;
                comboBoxIsActive.Visible = false;
            }
            else if (comboBoxFilter.SelectedIndex == 4)
            {
                textBoxFilter.Visible = false;
                comboBoxIsActive.Visible = true;
            }
            else
            {
                textBoxFilter.Visible = true;
                comboBoxIsActive.Visible = false;
            }
        }
        private void textBoxFilter_TextChanged(object sender, EventArgs e)
        {

            string FilterColum = "";

            switch (comboBoxFilter.Text)
            {
                case "Person ID":
                    FilterColum = "PersonID";
                    break;
                case "User ID":
                    FilterColum = "UserID";
                    break;
                case "UserName":
                    FilterColum = "UserName";
                    break;
                case "Is Active":
                    FilterColum = "IsActive";
                    break;
                default:
                    FilterColum = "None";
                    break;
            }
            {
                if (textBoxFilter.Text.Trim() == "" || FilterColum == "None")
                {
                    ((DataTable)dataGridViewUsers.DataSource).DefaultView.RowFilter = "";
                    labelRecordCount.Text = dataGridViewUsers.Rows.Count.ToString();
                    return;
                }

                if (FilterColum == "PersonID" || FilterColum == "UserID")
                {
                    if (int.TryParse(textBoxFilter.Text.Trim(), out int result))
                    {
                        ((DataTable)dataGridViewUsers.DataSource).DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColum, result);
                    }
                }
            
                else
                {
                    ((DataTable)dataGridViewUsers.DataSource).DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColum, textBoxFilter.Text.Trim());
                }

                labelRecordCount.Text = (dataGridViewUsers.Rows.Count ).ToString();

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
            else if (comboBoxFilter.SelectedIndex == 4 )
            {
                if (char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }

        }
        private void comboBoxIsActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            string FilterValue = "";

            switch (comboBoxIsActive.Text)
            {
                case "Yes": FilterValue = "1"; break;
                case "No" : FilterValue = "0"; break;
                default: FilterValue = ""; break; 
            }
            if (FilterValue == "")
                ((DataTable)dataGridViewUsers.DataSource).DefaultView.RowFilter = "";
            else
                ((DataTable)dataGridViewUsers.DataSource).DefaultView.RowFilter = string.Format("[IsActive] = {0}", FilterValue);

            int count = dataGridViewUsers.RowCount;
            labelRecordCount.Text = dataGridViewUsers.RowCount.ToString();
        }
        private void buttonAddNewUser_Click(object sender, EventArgs e)
        {
            AddNewUser frm = new AddNewUser(); 
            frm.ShowDialog();
            _RefreshUsersList();
        }
        private void deleteUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure to DELETE this [" + dataGridViewUsers.CurrentRow.Cells[0].Value + "]",
               "Confirm Delete", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                if (clsUser.DeleteUser((int)dataGridViewUsers.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("Person Deleted Successfully");
                    _RefreshUsersList();
                }
                else

                {
                    MessageBox.Show("User NOT Deleted ,Error!!");
                }
            }
        }
        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dataGridViewUsers.CurrentRow.Cells["PersonID"].Value);
            ShowPersonDetails frm = new ShowPersonDetails(id);
            frm.ShowDialog();
        }
        private void sendToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This feature not available yet","Error404",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This feature not available yet", "Error404", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dataGridViewUsers.CurrentRow.Cells["UserID"].Value);
            ChangePassword frm = new ChangePassword(id);
            frm.ShowDialog();
        }
        private void editUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dataGridViewUsers.CurrentRow.Cells["UserID"].Value);
            UpdateUser frm = new UpdateUser(id);
            frm.ShowDialog();
            _RefreshUsersList();
        }
    }
    
}
