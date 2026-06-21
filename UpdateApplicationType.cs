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
    public partial class UpdateApplicationType : Form
    {
        int _AppTypeID = -1;
        clsApplicationType _AppType;
        public UpdateApplicationType(int AppTypeID)
        {
            InitializeComponent();

            _AppTypeID = AppTypeID;
            _AppType = clsApplicationType.Find(_AppTypeID);
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UpdateApplicationType_Load(object sender, EventArgs e)
        {
           
            if (_AppType != null)
            {
                labelIDResult.Text = _AppType.AppTypeID.ToString();
                textBoxTitle.Text = _AppType.AppTitel.ToString();
                textBoxFees.Text = _AppType.AppFees.ToString(); ;
            }
            else
            {
               
                MessageBox.Show("Error", "404", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            _AppType.AppTitel = textBoxTitle.Text;
            _AppType.AppFees = Convert.ToDecimal(textBoxFees.Text);
            if (_AppType.Save())
            {
                MessageBox.Show("Application Type Updated Successfully", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {

                MessageBox.Show("Faild to update applicatin type", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
