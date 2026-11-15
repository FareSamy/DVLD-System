using DVLD_Data_Access_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BusinessLayer
{
    public class clsLicenseClasses
    {
        public int ID { set; get; }
        public string ClassName { set; get; }
        public string ClassDescraption{ set; get; }
        public byte MinimumAllowedAge{ set; get; }
        public byte DefaultValidityLength{ set; get; }
        public decimal ClassFees { set; get; }

        public clsLicenseClasses()
        {
            this.ID = -1;
            this.ClassName = "";
            this.ClassDescraption = "";
            this.MinimumAllowedAge= 0;
            this.DefaultValidityLength = 0;
            this.ClassFees = 0;
        }
        private clsLicenseClasses(int ID, string ClassName, string ClassDescraption, byte MinimumAllowedAge, byte DefaultValidityLength, decimal ClassFees)
        {
            this.ID = ID;
            this.ClassName = ClassName;
            this.ClassDescraption = ClassDescraption;
            this.MinimumAllowedAge = MinimumAllowedAge;
            this.DefaultValidityLength = DefaultValidityLength;
            this.ClassFees = ClassFees;
        }
        public static clsLicenseClasses Find(int ID)
        {
            string ClassName = "";
            string ClassDescraption = "";
            byte MinimumAllowedAge = 0;
            byte DefaultValidityLength = 0;
            decimal ClassFees = 0;
            if (clsLicenseClassesData.GetClassInfoByID(ID,ref ClassName,ref ClassDescraption,ref MinimumAllowedAge,ref DefaultValidityLength ,ref ClassFees))
            {
                return new clsLicenseClasses(ID, ClassName,ClassDescraption,MinimumAllowedAge,DefaultValidityLength,ClassFees);
            }
            else
                return null;

        }

        public static DataTable ListClasses()
        {
            return clsLicenseClassesData.ListClasses();
        }
    }
}
