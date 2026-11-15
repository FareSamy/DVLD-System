using DVLD_Data_Access_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BusinessLayer
{
    public class clsInternationalLicense
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;
        public int InternationalLicenseID { get; set; }
        public int ApplicationID { get; set; }
        public int DriverID { get; set; }
        public int IssuedUsingLocalLicenseID { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public bool IsActive { get; set; }
        public int CreatedByUserID { get; set; }

        public clsInternationalLicense()
        {
            this.InternationalLicenseID = -1;
            this.ApplicationID = -1;
            this.DriverID = -1;
            this.IssuedUsingLocalLicenseID = -1;
            this.IssueDate = DateTime.Now;
            this.ExpirationDate = DateTime.Now;
            this.IsActive = false;
            this.CreatedByUserID = -1;
            Mode = enMode.AddNew;
        }
        private clsInternationalLicense(int InternationalLicenseID,int ApplicationID, int DriverID,int IssuedUsingLocalLicenseID
                                        ,DateTime IssueDate , DateTime ExpirationDate , bool IsActive ,int CreatedByUserID)
        {
            this.InternationalLicenseID = InternationalLicenseID;
            this.ApplicationID = ApplicationID;
            this.DriverID = DriverID;
            this.IssuedUsingLocalLicenseID = IssuedUsingLocalLicenseID;
            this.IssueDate = IssueDate;
            this.ExpirationDate = ExpirationDate;
            this.IsActive = IsActive;
            this.CreatedByUserID = CreatedByUserID;
            Mode = enMode.Update;

        }

        public static clsInternationalLicense Find(int InternationalLicenseID)
        {
           
            int ApplicationID = -1;
            int DriverID = -1;
            int IssuedUsingLocalLicenseID = -1;
            DateTime IssueDate = DateTime.Now;
            DateTime ExpirationDate = DateTime.Now;
            bool IsActive = false;
            int CreatedByUserID = -1;
            if (clsInternationalLicsenceData.GetInternationalLicencesByLicencesID(InternationalLicenseID, ref ApplicationID, ref DriverID, ref IssuedUsingLocalLicenseID, ref IssueDate, ref ExpirationDate, ref IsActive, ref CreatedByUserID))
            {
                return new clsInternationalLicense(InternationalLicenseID, ApplicationID, DriverID, IssuedUsingLocalLicenseID, IssueDate, ExpirationDate, IsActive, CreatedByUserID);
            }
            else
            { return null; }

        }

        public static clsInternationalLicense FindByApplicationID(int ApplicationID)
        {
            int InternationalLicenseID = -1;
            int DriverID = -1;
            int IssuedUsingLocalLicenseID = -1;
            DateTime IssueDate = DateTime.Now;
            DateTime ExpirationDate = DateTime.Now;
            bool IsActive = false;
            int CreatedByUserID = -1;
            if (clsInternationalLicsenceData.GetInternationalLicencesByApplicationID(ApplicationID, ref InternationalLicenseID, ref DriverID, ref IssuedUsingLocalLicenseID, ref IssueDate, ref ExpirationDate, ref IsActive, ref CreatedByUserID))
            {
                return new clsInternationalLicense(InternationalLicenseID, ApplicationID, DriverID, IssuedUsingLocalLicenseID, IssueDate, ExpirationDate, IsActive, CreatedByUserID);
            }
            else
            { return null; }
        }

        public static clsInternationalLicense FindByDriverID(int DriverID)
        {
            int InternationalLicenseID = -1;
            int ApplicationID = -1;
            int IssuedUsingLocalLicenseID = -1;
            DateTime IssueDate = DateTime.Now;
            DateTime ExpirationDate = DateTime.Now;
            bool IsActive = false;
            int CreatedByUserID = -1;
            if (clsInternationalLicsenceData.GetInternationalLicencesByDriverID(DriverID, ref ApplicationID,ref InternationalLicenseID, ref IssuedUsingLocalLicenseID, ref IssueDate, ref ExpirationDate, ref IsActive, ref CreatedByUserID))
            {
                return new clsInternationalLicense(InternationalLicenseID, ApplicationID, DriverID, IssuedUsingLocalLicenseID, IssueDate, ExpirationDate, IsActive, CreatedByUserID);
            }
            else
            { return null; }
        }

        public static DataTable ListInternationalDriverLicences(int DriverID)
        {
            return clsInternationalLicsenceData.ListInternationalDriverLicences(DriverID);
        }
        public static DataTable ListInternationalDriverLicences()
        {
            return clsInternationalLicsenceData.ListInternationalDriverLicences();
        }
        private bool _AddNewInternationalLicensce()
        {
            this.InternationalLicenseID = clsInternationalLicsenceData.AddNewinternationalLicences(this.ApplicationID, this.DriverID,this.IssuedUsingLocalLicenseID, this.IssueDate, this.ExpirationDate,  this.IsActive, this.CreatedByUserID);
            return (this.InternationalLicenseID != -1);
        }
        private bool _UpdateInternationalLicensce()
        {
            return clsInternationalLicsenceData.UpdateInternationalLicences(this.InternationalLicenseID, this.ApplicationID, this.DriverID, this.InternationalLicenseID, this.IssueDate, this.ExpirationDate, this.IsActive, this.CreatedByUserID);
        }
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewInternationalLicensce())
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
                        return _UpdateInternationalLicensce();
                    }
            }

            return false;

        }

    }
}
