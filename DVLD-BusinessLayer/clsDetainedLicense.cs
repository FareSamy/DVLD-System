using DVLD_Data_Access_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BusinessLayer
{
    public class clsDetainedLicense
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;
        public int DetainID { get; set; }
        public int LicenseID { get; set; }
        public DateTime DetainDate { get; set; }
        public decimal FineFees { get; set; }
        public int CreatedByUserID { get; set; }
        public bool IsReleased { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public int? ReleasedByUserID { get; set; }
        public int? ReleaseApplicationID { get; set; }

        public clsDetainedLicense()
        {
            this.DetainID = -1;
            this.LicenseID = -1;
            this.DetainDate = DateTime.Now;
            this.FineFees = 0;
            this.CreatedByUserID = -1;
            this.IsReleased = false;
            this.ReleaseDate = null;
            this.ReleasedByUserID = null;
            this.ReleaseApplicationID = null;
            Mode = enMode.AddNew; 

        }
        private clsDetainedLicense(int DetainID , int LicenseID , DateTime DetainDate ,decimal FineFees ,int CreatedByUserID ,bool IsReleased ,DateTime? ReleaseDate, int? ReleasedByUserID,int? ReleaseApplicationID)
        {
            this.DetainID = DetainID;
            this.LicenseID = LicenseID;
            this.DetainDate = DetainDate;
            this.FineFees = FineFees;
            this.CreatedByUserID=CreatedByUserID;
            this.IsReleased = IsReleased;
            this.ReleaseDate =ReleaseDate;
            this.ReleasedByUserID = ReleasedByUserID;
            this.ReleaseApplicationID = ReleaseApplicationID;
            Mode = enMode.Update;

        }

        public static bool IsLicenseDetained(int LicenseID)
        {
            return clsDetainedLicenseData.IsLicenseDetained(LicenseID);
        }

        public static clsDetainedLicense Find(int LicenseID)
        {
            int DetainID = -1;
            DateTime DetainDate = DateTime.Now;
            decimal FineFees = 0;
            int CreatedByUserID = -1;
            bool IsReleased = false;
            DateTime? ReleaseDate = null;
            int? ReleasedByUserID = null;
            int? ReleaseApplicationID = null;


            if (clsDetainedLicenseData.GetDetainedLicencesByLicencesID(LicenseID,ref DetainID, ref DetainDate, ref FineFees, ref CreatedByUserID, ref IsReleased,
                                           ref ReleaseDate, ref ReleasedByUserID, ref ReleaseApplicationID))
            {
                return new clsDetainedLicense(DetainID, LicenseID, DetainDate, FineFees, CreatedByUserID,
                                            IsReleased, ReleaseDate, ReleasedByUserID, ReleaseApplicationID);
            }
            else
            { return null; }

        }

        private bool _DetainLicense()
        {
            this.DetainID = clsDetainedLicenseData.DetainLicense(this.LicenseID, this.DetainDate, this.FineFees, this.CreatedByUserID, this.IsReleased, this.ReleaseDate, this.ReleasedByUserID, this.ReleaseApplicationID);
            return (this.DetainID != -1);
        }
        private bool _ReleaseLicensce()
        {
            return clsDetainedLicenseData.RelaseLicense(this.DetainID,this.LicenseID, this.DetainDate, this.FineFees, this.CreatedByUserID, this.IsReleased, this.ReleaseDate, this.ReleasedByUserID, this.ReleaseApplicationID);
        }
        public static bool DeleteDetainLicense(int DetainID)
        {
            return clsDetainedLicenseData.DeleteDetainLicense(DetainID);
        }
        public static DataTable ListDetainedLicense()
        {
            return clsDetainedLicenseData.ListDetainLicense();
        }
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_DetainLicense())
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
                        return _ReleaseLicensce();
                    }
            }

            return false;

        }
    }
}
