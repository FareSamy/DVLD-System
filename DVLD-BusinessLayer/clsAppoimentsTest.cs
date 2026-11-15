using DVLD_Data_Access_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BusinessLayer
{
    public class clsAppoimentsTest
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int TestAppointmentID { get; set; }
        public int TestTypeID { get; set; }
        public int LocalDrivingLicenseApplicationID { get; set; }
        public DateTime AppointmentDate { get; set; }
        public  decimal PaidFees { get; set; }
        public int CreatedByUserID { get; set; }
        public bool IsLocked { get; set; }

        public clsAppoimentsTest()
        {
            this.TestAppointmentID = -1;
            this.TestTypeID = -1;
            this.LocalDrivingLicenseApplicationID = -1;
            this.CreatedByUserID = -1;
            this.PaidFees = 0;
            this.AppointmentDate = DateTime.Now;
            Mode = enMode.AddNew;
        }
        public clsAppoimentsTest(int testAppointmentID, int testTypeID, int localDrivingLicenseApplicationID, DateTime appointmentDate, decimal paidFees, int createdByUserID, bool isLocked)
        {
            TestAppointmentID = testAppointmentID;
            TestTypeID = testTypeID;
            LocalDrivingLicenseApplicationID = localDrivingLicenseApplicationID;
            AppointmentDate = appointmentDate;
            PaidFees = paidFees;
            CreatedByUserID = createdByUserID;
            IsLocked = isLocked;
            Mode = enMode.Update;
        }
        public static clsAppoimentsTest FindByTestApppimentsID(int TestAppointmentID)
        {
            int TestTypeID = -1;
            int LocalDrivingLicenseApplicationID = -1;
            DateTime AppointmentDate = DateTime.Now;
            decimal paidFees = 0;
            int CreatedByUserID = -1;
            bool IsLocked = false;
         

            if (clsTestAppoimentsData.GetTestAppoimentByTestAppointmentID(TestAppointmentID, ref TestTypeID, ref LocalDrivingLicenseApplicationID, ref AppointmentDate, ref paidFees, ref CreatedByUserID, ref IsLocked))
            {
                return new clsAppoimentsTest(TestAppointmentID, TestTypeID, LocalDrivingLicenseApplicationID, AppointmentDate, paidFees, CreatedByUserID, IsLocked);
            }
            else
                return null;

        }
        public static clsAppoimentsTest FindTestBYLDLAID(int LocalDrivingLicenseApplicationID)
        {
            int TestTypeID = -1;
            int TestAppointmentID = -1;
            DateTime AppointmentDate = DateTime.Now;
            decimal paidFees = 0;
            int CreatedByUserID = -1;
            bool IsLocked = false;


            if (clsTestAppoimentsData.GetTestAppoimentByLDLAID(LocalDrivingLicenseApplicationID, ref TestTypeID, ref TestAppointmentID, ref AppointmentDate, ref paidFees, ref CreatedByUserID, ref IsLocked))
            {
                return new clsAppoimentsTest(TestAppointmentID, TestTypeID, LocalDrivingLicenseApplicationID, AppointmentDate, paidFees, CreatedByUserID, IsLocked);
            }
            else
                return null;

        }
        public static DataTable listVisonTest(int LDLAID)
        {
            return clsTestAppoimentsData.ListVisionTest(LDLAID);
        }
        public static DataTable listWriteTest(int LDLAID)
        {
            return clsTestAppoimentsData.ListWriteTest(LDLAID);
        }
        public static DataTable listStreetTest(int LDLAID)
        {
            return clsTestAppoimentsData.ListStreetTest(LDLAID);
        }
        private bool _AddNewAppoimentTest()
        {
            this.TestAppointmentID = clsTestAppoimentsData.AddNewTestApppiment(this.TestTypeID,this.LocalDrivingLicenseApplicationID,this.AppointmentDate,this.PaidFees,this.CreatedByUserID,this.IsLocked);
            return (this.TestAppointmentID != -1);
        }
        private bool _UpdateAppoimentTest()
        {
            return clsTestAppoimentsData.UpdateTestApppiment(this.TestAppointmentID,this.TestTypeID,this.LocalDrivingLicenseApplicationID,this.AppointmentDate,this.PaidFees,this.CreatedByUserID,this.IsLocked);
        }
        public static bool IsHaveActiveVisionTest(int  LDLAID)
        {
            return clsTestAppoimentsData.IsHaveActiveVisionTest(LDLAID);
        }
        public static bool IsHaveActiveWrittenTest(int LDLAID)
        {
            return clsTestAppoimentsData.IsHaveActiveWrittenTest(LDLAID);
        }
        public static bool IsHaveActiveStreetTest(int LDLAID)
        {
            return clsTestAppoimentsData.IsHaveActiveStreetTest(LDLAID);
        }
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewAppoimentTest())
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
                        return _UpdateAppoimentTest();
                    }
            }

            return false;

        }

    }
}
