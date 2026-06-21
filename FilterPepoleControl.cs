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
    public partial class FilterPepoleControl : UserControl
    {
        public FilterPepoleControl()
        {
            InitializeComponent();
            _FillComboBox();
        }
        clsPerson SearchPerson = new clsPerson();
        string _NationalNo = "";
        string _UserName = "";
        int _PersonID = -1;
        private void FilterPepoleControl_Load(object sender, EventArgs e)
        {
            _FillComboBox();
            this.ActiveControl = textBoxFilter;
        }
        private void _FillComboBox()
        {
            comboBoxFilter.Items.Add("National ID");
            comboBoxFilter.Items.Add("Person ID");
            comboBoxFilter.Items.Add("UserName");
            comboBoxFilter.SelectedIndex = 0;
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
        }
        private void buttonSearch_Click_1(object sender, EventArgs e)
        {
            if (comboBoxFilter.SelectedIndex == 0)
            {
                _NationalNo = textBoxFilter.Text;
                clsPerson Person = clsPerson.Find(_NationalNo);

                if (Person != null)
                {
                    SearchPerson = Person;
                    pepoelInfoControl1.LoadPerson(Person.ID);
                }
                else
                {
                    MessageBox.Show("No person founded please try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxFilter.Text = "";
                    pepoelInfoControl1.LoadPerson(0);
                }
            }
            else if (comboBoxFilter.SelectedIndex == 1)
            {
               
                if (int.TryParse(textBoxFilter.Text, out int personID))
                    _PersonID = personID;
                clsPerson Person = clsPerson.Find(_PersonID);
                if (Person != null)
                {
                    SearchPerson = Person;
                    pepoelInfoControl1.LoadPerson(Person.ID);
                }
                else
                {
                    MessageBox.Show("No person founded please try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxFilter.Text = "";
                    pepoelInfoControl1.LoadPerson(0);
                }

            }
            else if (comboBoxFilter.SelectedIndex == 2)
            {
                _UserName = textBoxFilter.Text;

                clsUser User = clsUser.Find(_UserName);
                if (User != null)
                {
                    pepoelInfoControl1.LoadPerson(User.PersonID);

                }
                else
                {
                    MessageBox.Show("Not Found !!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxFilter.Text = "";
                    pepoelInfoControl1.LoadPerson(0);
                }
            }
        }
        private void textBoxFilter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buttonSearch_Click_1(sender, e);
                e.SuppressKeyPress = true;
            }
        }
        public clsPerson SearchedPerson()
        {
            return SearchPerson;
        }
    }
}
