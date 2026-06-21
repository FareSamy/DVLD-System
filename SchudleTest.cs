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
using static System.Net.Mime.MediaTypeNames;

namespace DVLD_System
{

    public partial class SchudleTest : Form
    {
        clsApplication _Application;
        clsLocalDrivingLicenseApplications _LDLA;
        clsPerson _Person;
        clsUser _User;
        clsApplicationType _AppType;
        clsLicenseClasses _LicensClass;
        clsTestType _TestType;
        clsTests _Tests;
        public enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode ;

        int _DLAppId, _ApplicationID , _AppoimentsTestID =-1 , _TT ;
        

        public SchudleTest(int LDLID,int ApplicationID,int TestType)
        {
            _DLAppId = LDLID;
            _ApplicationID = ApplicationID;
            _TT = TestType;

          
            InitializeComponent();
            
        }
        public SchudleTest(int LDLID, int ApplicationID,int AppoimentsTestID, int TestType)
        {
            _DLAppId = LDLID;
            _ApplicationID = ApplicationID;
            _AppoimentsTestID  = AppoimentsTestID;
            _TT = TestType;

            if (_AppoimentsTestID == -1)
                _Mode = enMode.AddNew;
            else
                _Mode = enMode.Update;

            InitializeComponent();

        }
        private void _LoadData()
        {

            clsAppoimentsTest _AppoimentsTest = clsAppoimentsTest.FindTestBYLDLAID(_DLAppId);
            //clsAppoimentsTest _AppoimentsTest = clsAppoimentsTest.FindByTestApppimentsID(_AppoimentsTestID);
            if (_AppoimentsTest != null && _AppoimentsTest.TestTypeID == _TT)
            {
                _Tests = clsTests.FindByTestAppointmentID(_AppoimentsTest.TestAppointmentID);
            }
            if (clsTests.IsFaildVisionTest(_DLAppId,_TT))
            {
                
                int RetakeFees = 5;
                labelVisionTest.Text = "RETAKE TEST";
                _TestType = clsTestType.Find(_TT);
                labelRAppFeesResult.Text = RetakeFees.ToString();
                labelTotalFeesResult.Text = (RetakeFees + _TestType.TestFees).ToString("N0");
                labelRetestAppIDResult.Text = _AppoimentsTestID.ToString();
                groupBoxRetakeTestInfo.Enabled = true;
                

            }
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

            }
            else
            {
                _LDLA = clsLocalDrivingLicenseApplications.FindByLocalDrivingLicenseApplicationID(_DLAppId);
                if (_LDLA != null)
                {
                    labelDLAppIDResult.Text = _LDLA.LocalAppID.ToString();
                    _LicensClass = clsLicenseClasses.Find(_LDLA.LicenseClassID);
                    labeLicenesClassResult.Text = _LicensClass.ClassName.ToString();
                    label1TrialResult.Text = clsTests.HowManyFaild(_DLAppId,_TT).ToString();

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
        }

        private void SchudleTest_Load(object sender, EventArgs e)
        {
           
            _LoadData();
        }


        private void buttonSave_Click(object sender, EventArgs e)
        {
            clsAppoimentsTest appoimentsTest;

            if (_Mode == enMode.AddNew)
            {
                appoimentsTest = new clsAppoimentsTest();
            }
            else
            {
                appoimentsTest = clsAppoimentsTest.FindByTestApppimentsID(_AppoimentsTestID);
            }

            appoimentsTest.TestTypeID = _TT;
            appoimentsTest.LocalDrivingLicenseApplicationID = _LDLA.LocalAppID;
            appoimentsTest.AppointmentDate = dateTimePicker1.Value;
            appoimentsTest.PaidFees = _TestType.TestFees;
            appoimentsTest.CreatedByUserID = clsGlobal.CurrentUser.UserID;
            appoimentsTest.IsLocked = false;
            if (appoimentsTest.Save())
            {
                _AppoimentsTestID = appoimentsTest.TestAppointmentID;
                _Mode = enMode.Update;
                MessageBox.Show("Data Saved successfully", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                MessageBox.Show("Data NOT Saved successfully", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
          
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
       
    
}
