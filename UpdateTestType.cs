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
    public partial class UpdateTestType : Form
    {

        int _TestTypeID = -1;
        clsTestType _TestType;
        public UpdateTestType(int TestID)
        {
            InitializeComponent();
            _TestTypeID = TestID;
            _TestType = clsTestType.Find(_TestTypeID);
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UpdateTestType_Load(object sender, EventArgs e)
        {

            if (_TestType != null)
            {
                labelIDResult.Text = _TestType.TestTypeID.ToString();
                textBoxTitle.Text = _TestType.TestTitel.ToString();
                textBoxDescraption.Text = _TestType.TestDescription;
                textBoxFees.Text = _TestType.TestFees.ToString(); ;
            }
            else
            {
                MessageBox.Show("Error", "404", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            _TestType.TestTitel = textBoxTitle.Text;
            _TestType.TestFees = Convert.ToDecimal(textBoxFees.Text);
            _TestType.TestDescription = textBoxDescraption.Text;
            if (_TestType.Save())
            {
                MessageBox.Show("Test Type Updated Successfully", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show(_TestType.TestTitel);
                //MessageBox.Show("Faild to update Test type", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
