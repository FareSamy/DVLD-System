using DVLD_Data_Access_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BusinessLayer
{
    public class clsApplicationType
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int AppTypeID { get; set; }
        public string AppTitel { get; set; }
        public decimal AppFees { get; set; }

        public clsApplicationType()
        {
            this.AppTypeID = -1;
            this.AppFees = 0;
            this.AppTitel = "";
            Mode = enMode.AddNew;
        }
        private clsApplicationType(int AppTypeID, string AppTitel, decimal AppFees)
        {

            this.AppTypeID = AppTypeID;
            this.AppFees = AppFees;
            this.AppTitel = AppTitel;
            Mode = enMode.Update;
        }

        public static clsApplicationType Find(int AppTypeID)
        {
            string AppTitel = "";
            decimal AppFees = 0;
            if (clsApplicationTypeData.GetAppTyperInfoByTypeID(AppTypeID, ref AppTitel, ref AppFees))
            {
                return new clsApplicationType(AppTypeID, AppTitel, AppFees);
            }
            else
                return null;
        }

        public static DataTable ListAppType()
        {
            return clsApplicationTypeData.ListAppType();
        }

        private bool _UpdateAppType()
        {
            return clsApplicationTypeData.UpdateAppType(this.AppTypeID, this.AppTitel, this.AppFees);
        }
        private bool _AddNewAppType()
        {
            this.AppTypeID = clsApplicationTypeData.AddNewAppType(this.AppTitel, this.AppFees);
            return (this.AppTypeID != -1);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewAppType())
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
                        return _UpdateAppType();
                    }
            }
            return false;
        }
    }
}
