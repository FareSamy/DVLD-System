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
    public partial class TakeTest : Form
    {
        clsApplication _Application;
        clsLocalDrivingLicenseApplications _LDLA;
        clsPerson _Person;
        clsUser _User;
        clsApplicationType _AppType;
        clsLicenseClasses _LicensClass;
        clsTestType _TestType;
        clsAppoimentsTest _AppoimentsTest;

        int _DLAppId, _ApplicationID, _AppoimentsTestID = -1,_TT;
        public TakeTest(int LDLID, int ApplicationID)
        {
            _DLAppId = LDLID;
            _ApplicationID = ApplicationID;
            InitializeComponent();
        }
        public TakeTest(int LDLID, int ApplicationID, int AppoimentsTestID,int TT)
        {
            _DLAppId = LDLID;
            _ApplicationID = ApplicationID;
            _AppoimentsTestID = AppoimentsTestID;
            _TT = TT;

            InitializeComponent();

        }

        private void TakeTest_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            clsTests Test = new clsTests();
            Test.TestAppointmentID = _AppoimentsTestID;
            Test.Notes = textBoxNotes.Text;
            Test.CreatedByUserID = clsGlobal.CurrentUser.UserID;
            Test.TestID = _TT;
            if (radioButtonPass.Checked)
            {
                Test.TestResult = true;
            }
            else if (radioButtonFail.Checked)
            {
                Test.TestResult = false;
            }
            else
            {
                MessageBox.Show("Please Select Test Result !!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            MessageBox.Show("Are you sure you want to save ? after that you cannot change the pass/fail results after you save?.", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (Test.Save())
            {
                _AppoimentsTest.IsLocked = true;
                _AppoimentsTest.Save();
                MessageBox.Show("Data saved successfully", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                MessageBox.Show("somthing is wrong !!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void _LoadData()
        {
            if (_TT == 2)
            {
                groupBoxVisionTest.Text = "Written Test";
                pictureBoxTest.BackgroundImage = Properties.Resources.written_test;
            }
            else if (_TT == 3)
            {
                groupBoxVisionTest.Text = "Street Test";
                pictureBoxTest.BackgroundImage = Properties.Resources.driving_test;

            }
            if (_DLAppId <= 0)
            {
                labelDLAppIDResult.Text = "[???]";
                labeLicenesClassResult.Text = "[???]";
                return;
            }
            else
            {
                _LDLA = clsLocalDrivingLicenseApplications.FindByLocalDrivingLicenseApplicationID(_DLAppId);
                if (_LDLA != null)
                {
                    labelDLAppIDResult.Text = _LDLA.LocalAppID.ToString();
                    _LicensClass = clsLicenseClasses.Find(_LDLA.LicenseClassID);
                    labeLicenesClassResult.Text = _LicensClass.ClassName.ToString();

                }
                else
                {
                    labelDLAppIDResult.Text = "[???]";
                    labeLicenesClassResult.Text = "[???]";
                }
            }
            if (_ApplicationID <= 0)
            {
                labelFeesResult.Text = "[???]";
                labelNameResult.Text = "[???]";
            }
            else
            {
                _Application = clsApplication.Find(_ApplicationID);
                if (_Application != null)
                {
                    _TestType = clsTestType.Find(_TT);
                    labelFeesResult.Text = _TestType.TestFees.ToString("N0");

                    _Person = clsPerson.Find(_Application.AppPersonID);
                    labelNameResult.Text = _Person.FullName();
                }
                else
                {
                    labelFeesResult.Text = "[???]";
                    labelNameResult.Text = "[???]";
                }
            }
            if (_AppoimentsTestID <= 0)
            {
                labelDateResult.Text = "[???]";
            }
            else
            {
                _AppoimentsTest = clsAppoimentsTest.FindByTestApppimentsID(_AppoimentsTestID);
                if (_AppoimentsTest != null)
                {
                    labelDateResult.Text = _AppoimentsTest.AppointmentDate.ToShortDateString();
                }
                else
                {
                    labelDateResult.Text = "[???]";

                }
            }
        }
        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
