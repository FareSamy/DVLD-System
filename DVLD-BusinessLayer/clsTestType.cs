using DVLD_Data_Access_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace DVLD_BusinessLayer
{
    public class clsTestType
    {

        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int TestTypeID { get; set; }
        public string TestTitel { get; set; }
        public string TestDescription{ get; set; }
        public decimal TestFees { get; set; }

        public clsTestType()
        {
            this.TestTypeID = -1;
            this.TestTitel = "";
            this.TestDescription = "";
            this.TestFees = 0;
            Mode = enMode.AddNew;
        }
        private clsTestType(int TestTypeID, string TestTitel,string TestDescription, decimal TestFees)
        {

            this.TestTypeID = TestTypeID;
            this.TestTitel = TestTitel;
            this.TestDescription = TestDescription;
            this.TestFees = TestFees;
            Mode = enMode.Update;
        }

        public static clsTestType Find(int TestTypeID)
        {
            string TestTitel = "";
            string TestDescription = "";
            decimal TestFees = 0;
            if (clsTestTypesData.GetTestTypeInfoByTypeID(TestTypeID, ref TestTitel,ref TestDescription, ref TestFees))
            {
                return new clsTestType(TestTypeID,TestTitel,TestDescription, TestFees);
            }
            else
                return null;
        }

        public static DataTable ListAppType()
        {
            return clsTestTypesData.ListTestType();
        }

        private bool _UpdateTestType()
        {
            return clsTestTypesData.UpdateTestType(this.TestTypeID, this.TestTitel, this.TestDescription,this.TestFees);
        }
        private bool _AddNewTestType()
        {
            this.TestTypeID = clsTestTypesData.AddNewTestType(this.TestTitel, this.TestDescription,this.TestFees);
            return (this.TestTypeID != -1);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewTestType())
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
                        return _UpdateTestType();
                    }
            }
            return false;
        }
    }
}

