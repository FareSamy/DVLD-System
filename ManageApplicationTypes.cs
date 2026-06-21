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
    public partial class ManageApplicationTypes : Form
    {
        public ManageApplicationTypes()
        {
            InitializeComponent();
            _RefreshApplicationTypesList();
            labelRecordCount.Text = dataGridViewAppTypes.RowCount.ToString();
        }

        private void _RefreshApplicationTypesList()
        {
            dataGridViewAppTypes.DataSource = clsApplicationType.ListAppType();

            dataGridViewAppTypes.Columns["ApplicationTypeID"].FillWeight = 30;
            dataGridViewAppTypes.Columns["ApplicationTypeID"].HeaderText = "ID";

            dataGridViewAppTypes.Columns["ApplicationTypeTitle"].FillWeight = 200;
            dataGridViewAppTypes.Columns["ApplicationTypeTitle"].HeaderText = "Title";

            dataGridViewAppTypes.Columns["ApplicationFees"].FillWeight = 40;
            dataGridViewAppTypes.Columns["ApplicationFees"].HeaderText = "Fees";

        }

        private void ManageApplicationTypes_Load(object sender, EventArgs e)
        {
            _RefreshApplicationTypesList();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void editApplicationTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dataGridViewAppTypes.CurrentRow.Cells["ApplicationTypeID"].Value);
            UpdateApplicationType frm = new UpdateApplicationType(id);
            frm.ShowDialog();
            _RefreshApplicationTypesList();
        }
    }
}
