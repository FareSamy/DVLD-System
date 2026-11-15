using DVLD_Data_Access_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DVLD_BusinessLayer
{
    public class clsLocalDrivingLicenseApplications
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int LocalAppID { get; set; }
        public int AppID { get; set; }
        public int LicenseClassID { get; set; }

        public clsLocalDrivingLicenseApplications()
        
        {
            this.LocalAppID= -1;
            this.AppID = -1; 
            this.LicenseClassID = -1;
            Mode = enMode.AddNew;
        }
        public clsLocalDrivingLicenseApplications(int LocalAppID,int AppID, int LicensID)
        {
            this.LocalAppID = LocalAppID;
            this.AppID = AppID;
            this.LicenseClassID = LicensID;
            Mode = enMode.Update;
        }
        private bool _AddNewLocalLicensApplication()
        {
            this.LocalAppID = clsLocalDrivingLicenseApplicationsData.AddNewLocalApplication(this.AppID,this.LicenseClassID);
            return (this.LocalAppID != -1);
        }
        public static clsLocalDrivingLicenseApplications FindByApplicationID(int ApplicationID)
        {
            int LocalDrivingLicenseApplicationID = -1;
            int LicensID = -1;

            if (clsLocalDrivingLicenseApplicationsData.GeTLocalLicensAppInfoByAppID(ApplicationID, ref LocalDrivingLicenseApplicationID, ref LicensID))
            {
                return new clsLocalDrivingLicenseApplications(LocalDrivingLicenseApplicationID, ApplicationID, LicensID);
            }
            else
                return null;

        }
        public static clsLocalDrivingLicenseApplications FindByLocalDrivingLicenseApplicationID(int LocalDrivingLicenseApplicationsID)
        {
            int ApplicationID = -1;
            int LicensID = -1;
            if (clsLocalDrivingLicenseApplicationsData.GeTLocalLicensAppInfoByLocalAppID(LocalDrivingLicenseApplicationsID, ref ApplicationID, ref LicensID))
            {
                return new clsLocalDrivingLicenseApplications(LocalDrivingLicenseApplicationsID, ApplicationID, LicensID);
            }
            else
                return null;
        }
        public static bool IsDoesPersonHaveActiveApplication(int PersonID, int LicenseClassID)
        {
            return clsLocalDrivingLicenseApplicationsData.IsDoesPersonHaveActiveApplication(PersonID, LicenseClassID);
        }
        public static bool DeleteLocalLicensApp(int LocalLicensID)
        {
            return clsLocalDrivingLicenseApplicationsData.DeleteLocalLicenseApp(LocalLicensID);
        }
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewLocalLicensApplication())
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
