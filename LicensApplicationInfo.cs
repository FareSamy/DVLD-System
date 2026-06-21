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
    public partial class LicensApplicationInfo : UserControl
    {
        int _DLAppId, _ApplicationID;
        clsApplication _Application;
        clsLocalDrivingLicenseApplications _LDLA;
        clsPerson _Person;
        clsUser _User;
        clsApplicationType _AppType;
        clsLicenseClasses _LicensClass;
        
        public LicensApplicationInfo()
        {
            InitializeComponent();
        }
     
        public void LoadInfo(int DLAppId , int ApplicationID)
        {
            _DLAppId = DLAppId;
            _ApplicationID = ApplicationID;
            _LoadData();
        }

        private void linkLabelViewPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ShowPersonDetails frm = new ShowPersonDetails(_Person.ID);
            frm.ShowDialog();
        }

        private void LicensApplicationInfo_Load(object sender, EventArgs e)
        {

        }

        private void _LoadData()
        {
            if (_DLAppId <= 0)
            {
                labelDLAppIDResult.Text = "[???]";
                labelAppliedForLicenesResult.Text = "[???]";
                labelPassedTestResult.Text = "[???]";
                return;
            }
            else
            {
                _LDLA = clsLocalDrivingLicenseApplications.FindByLocalDrivingLicenseApplicationID(_DLAppId);
                if (_DLAppId != null)
                {
                    labelDLAppIDResult.Text = _LDLA.LocalAppID.ToString();
                   _LicensClass = clsLicenseClasses.Find(_LDLA.LicenseClassID);
                    labelAppliedForLicenesResult.Text = _LicensClass.ClassName.ToString() ;

                    labelPassedTestResult.Text =clsTests.CountPassedTest(_DLAppId).ToString() + "/3";
                }
            }
            if (_ApplicationID <= 0)
            {
                labelIDResult.Text = "[???]";
                labelStatusResult.Text = "[???]";
                labelFeesResult.Text = "[???]";
                labelTypeResult.Text = "[???]";
                labelApplicantResult.Text = "[???]";
                labelDateResult.Text = "[???]";
                labelDateStatusResult.Text = "[???]";
                labelCreatedByResult.Text = "[???]";
                return;
            }
            else
            {
                _Application = clsApplication.Find(_ApplicationID);
                if (_Application != null)
                {
                    labelIDResult.Text = _Application.AppID.ToString();
                    if (_Application.AppStatus == 1)
                    {
                        labelStatusResult.Text = "New";
                    }
                    else if (_Application.AppStatus == 2)
                    {
                        labelStatusResult.Text = "Canceled";
                    }
                    else if (_Application.AppStatus == 3)
                    {
                        labelStatusResult.Text = "Completed";
                    }
                    _AppType = clsApplicationType.Find(_Application.AppTypeID);
                    labelFeesResult.Text = _AppType.AppFees.ToString("N0");

                    labelTypeResult.Text = _AppType.AppTitel;
                    
                    _Person = clsPerson.Find(_Application.AppPersonID);
                    labelApplicantResult.Text = _Person.FullName();

                    labelDateResult.Text = _Application.AppDate.ToString();
                    labelDateStatusResult.Text = _Application.LastStatusDate.ToString();

                    _User = clsUser.Find(_Application.CreatedByUserID);
                    labelCreatedByResult.Text = _User.UserName;
                }
            }
        }
    }
}
