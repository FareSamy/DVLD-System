using DVLD_Data_Access_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BusinessLayer
{
    public class clsApplication
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int AppID {  get; set; }
        public int AppPersonID { get; set; }
        public DateTime AppDate { get; set; }
        public int AppTypeID { get; set; }
        public byte AppStatus { get; set; }
        public DateTime LastStatusDate { set; get; }
        public decimal PaidFees {  get; set; }
        public int CreatedByUserID {  get; set; }

        public clsApplication()
        {
            this.AppID = -1;
            this.AppPersonID = -1;
            this.AppDate = DateTime.Now;
            this.AppTypeID = -1;
            this.AppStatus = 0;
            this.LastStatusDate = DateTime.Now;
            this.PaidFees = 0;
            this.CreatedByUserID = -1;
            Mode = enMode.AddNew;
        }

        private clsApplication(int appID, int appPersonID, DateTime appDate, int appTypeID, byte appStatus, DateTime lastStatusDate, decimal paidFees, int createdByUserID)
        {
            AppID = appID;
            AppPersonID = appPersonID;
            AppDate = appDate;
            AppTypeID = appTypeID;
            AppStatus = appStatus;
            LastStatusDate = lastStatusDate;
            PaidFees = paidFees;
            CreatedByUserID = createdByUserID;
            Mode = enMode.Update;
        }

        public static clsApplication Find(int ID)
        {
            int AppPersonID = -1;
            DateTime appDate = DateTime.Now;
            int appTypeID = -1;
            byte appStatus = 0;
            DateTime LastStauts = DateTime.Now;
            decimal paidFees = 0;
            int createdByUserID = -1;

            if (clsApplicationsData.GetApplicationByID(ID, ref AppPersonID, ref appDate, ref appTypeID, ref appStatus, ref LastStauts, ref paidFees, ref createdByUserID))
            {
                return new  clsApplication(ID, AppPersonID, appDate, appTypeID, appStatus, LastStauts, paidFees, createdByUserID);
            }
            else
                return null;

        }
        public static DataTable GetApplicationInfoByPersonID(int ID)
        {
            return clsApplicationsData.GetApplicationInfoByPersonID(ID);
        }
        private bool _AddNewApplication()
        {
            this.AppID = clsApplicationsData.AddNewApplication(this.AppPersonID, this.AppDate, this.AppTypeID,
                        this.AppStatus, this.LastStatusDate, this.PaidFees, this.CreatedByUserID);
            return (this.AppID != -1);
        }
        private bool _UpdateApplication()
        {
            return clsApplicationsData.UpdateApplication(this.AppID, this.AppPersonID, this.AppDate, this.AppTypeID
                                , this.AppStatus, this.LastStatusDate, this.PaidFees, this.CreatedByUserID);
        }
        public static DataTable ListApplications()
        {
            return clsApplicationsData.ListApplications();
        }
        public static bool IsApplicationExist(int PersonID)
        {
            return clsApplicationsData.ApplicationIsExsistByPersonID(PersonID);
        }
        public static bool DeleteApplication(int AppID)
        {
            return clsApplicationsData.DeleteApplication(AppID);
        }
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewApplication())
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
                        return _UpdateApplication();
                    }
            }

            return false;

        }
    }
}
