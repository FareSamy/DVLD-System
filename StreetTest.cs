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
    public partial class StreetTest : Form
    {
        int _LDLID, _ApplicationID;
        public StreetTest(int LDLID, int ApplicationID)
        {
            _LDLID = LDLID;
            _ApplicationID = ApplicationID;

            InitializeComponent();
            _RefreshUsersList();

            labelRecordCount.Text = dataGridViewAppoiments.RowCount.ToString();
        }
        private void _RefreshUsersList()
        {
            dataGridViewAppoiments.DataSource = clsAppoimentsTest.listStreetTest(_LDLID);
        }
        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsAppoimentsTest appoimentsTest1 = clsAppoimentsTest.FindByTestApppimentsID(Convert.ToInt32(dataGridViewAppoiments.CurrentRow.Cells[0].Value));
            if (appoimentsTest1 != null)
            {
                if (appoimentsTest1.IsLocked == true)
                {
                    MessageBox.Show("Cannot Edit schedule a test appointment becasue its locked!!", "Locked Appoiments", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                else
                {
                    int x = Convert.ToInt32(dataGridViewAppoiments.CurrentRow.Cells[0].Value);
                    clsAppoimentsTest appoimentsTest = clsAppoimentsTest.FindByTestApppimentsID(x);
                    if (appoimentsTest != null)
                    {
                        if (appoimentsTest.IsLocked == false)
                        {
                            SchudleTest frm = new SchudleTest(_LDLID, _ApplicationID, x,3);
                            frm.ShowDialog();
                            _RefreshUsersList();
                        }
                        else
                        {
                            MessageBox.Show("Canot Edit this Appoiments because its locked!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }
                    }
                    else
                    {
                        MessageBox.Show("null");
                    }

                }
            }

        }
        private void buttonAddDate_Click(object sender, EventArgs e)
        {
            if (clsAppoimentsTest.IsHaveActiveStreetTest(_LDLID))
            {
                MessageBox.Show("Cannot schedule a test appointment while you have an active test appointment", "Already have appoiments", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            else
            {
                clsAppoimentsTest appoimentsTest = clsAppoimentsTest.FindTestBYLDLAID(_LDLID);
                int x = appoimentsTest.TestAppointmentID;

                SchudleTest frm = new SchudleTest(_LDLID, _ApplicationID, -1, 3);
                frm.ShowDialog();
                _RefreshUsersList();
            }
        }
        private void takeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {

            clsAppoimentsTest appoimentsTest1 = clsAppoimentsTest.FindByTestApppimentsID(Convert.ToInt32(dataGridViewAppoiments.CurrentRow.Cells[0].Value));
            if (appoimentsTest1 != null)
            {
                if (appoimentsTest1.IsLocked == true)
                {
                    MessageBox.Show("Cannot Take a test appointment becasue its locked!!", "Locked Appoiments", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                else
                {
                    int x = Convert.ToInt32(dataGridViewAppoiments.CurrentRow.Cells[0].Value);
                    TakeTest frm = new TakeTest(_LDLID, _ApplicationID, x, 3);
                    frm.ShowDialog();
                    _RefreshUsersList();
                }
            }
        }
        private void StreetTest_Load(object sender, EventArgs e)
        {
            licensApplicationInfo1.LoadInfo(_LDLID, _ApplicationID);
        }
    }
}
