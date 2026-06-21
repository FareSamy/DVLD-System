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
    public partial class ManageTestType : Form
    {
        public ManageTestType()
        {
            InitializeComponent();
            _RefresTestTypesList();
            labelRecordCount.Text = dataGridViewTest.RowCount.ToString();
        }

        private void _RefresTestTypesList()
        {
          
            dataGridViewTest.DataSource = clsTestType.ListAppType();


            dataGridViewTest.Columns["TestTypeID"].FillWeight = 15;
            dataGridViewTest.Columns["TestTypeID"].HeaderText = "ID";

            dataGridViewTest.Columns["TestTypeTitle"].FillWeight = 70;
            dataGridViewTest.Columns["TestTypeTitle"].HeaderText = "Title";

            dataGridViewTest.Columns["TestTypeDescription"].FillWeight = 250;
            dataGridViewTest.Columns["TestTypeDescription"].HeaderText = "Description";


            dataGridViewTest.Columns["TestTypeFees"].FillWeight = 30;
            dataGridViewTest.Columns["TestTypeFees"].HeaderText = "Fees";

        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void editApplicationTypeToolStripMenuItem_Click(object sender, EventArgs e)

        {
            int id = Convert.ToInt32(dataGridViewTest.CurrentRow.Cells["TestTypeID"].Value);
            UpdateTestType frm = new UpdateTestType(id);
            frm.ShowDialog();
            _RefresTestTypesList();
        }
    }

}
