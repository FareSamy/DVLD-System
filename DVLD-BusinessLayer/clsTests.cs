using DVLD_Data_Access_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BusinessLayer
{
    public class clsTests
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;
        public int TestID { get; set; }
        public int TestAppointmentID { get; set; }
        public bool? TestResult { get; set; }
        public string Notes { get; set; }
        public int CreatedByUserID { get; set; }

        public clsTests()
        {
            
            this.TestID = -1;
            this.TestAppointmentID = -1;
            this.TestResult = null;
            this.Notes = "";
            this.CreatedByUserID = 1;
            Mode = enMode.AddNew;
        }
        public clsTests(int TestID, int TestAppointmentID, bool? TestResult, string Notes, int CreatedByUserID)
        {
            this.TestID = TestID;
            this.TestAppointmentID = TestAppointmentID;
            this.TestResult = TestResult;
            this.Notes = Notes;
            this.CreatedByUserID = CreatedByUserID;
            Mode = enMode.Update; 
        }

        public static clsTests FindByTestAppointmentID(int TestAppointmentID)
        {
            int TestID = -1;
            bool? TestResult = null;
            string Notes = "";
            int CreatedByUserID = 1;

            if (clsTestsData.GetTestByTestAppoimentsID(TestAppointmentID, ref TestID, ref TestResult, ref Notes, ref CreatedByUserID))
            {    
                return new clsTests(TestID, TestAppointmentID, TestResult, Notes, CreatedByUserID);
            }
            else
                return null;

        }
        public  static int CountPassedTest(int LDCAID)
        {
            
            int PassedTest;
            PassedTest = clsTestsData.CountPassedTests(LDCAID);
            return PassedTest;
        }
        public static bool IsPassedVisionTest(int LDLAID)
        {
            return  clsTestsData.IsPassedVisionTest(LDLAID);
        }
        public static bool IsPassedWrittenTest(int LDLAID)
        {
            return clsTestsData.IsPassedWrittenTest(LDLAID);
        }
        public static bool IsPassedStreetTest(int LDLAID)
        {
            return clsTestsData.IsPassedStreetTest(LDLAID);
        }
        public static bool IsFaildVisionTest(int LDLAID,int TestType)
        {
            return clsTestsData.IsFailedInTestType(LDLAID,TestType);
        }
        public static int HowManyFaild(int LDLAID, int TestType)
        {
            return clsTestsData.HowManyFailedInTest(LDLAID, TestType);
        }
        private bool _AddNewTest()
        {
            this.TestID = clsTestsData.AddNewTest(this.TestAppointmentID,this.TestResult,this.Notes,this.CreatedByUserID);
            return (this.TestID != -1);
        }
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewTest())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case enMode.Update:
                    {
                        return false;
                    }
            }

            return false;

        }
    }
}
