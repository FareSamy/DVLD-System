using DVLD_Data_Access_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BusinessLayer
{
    public class clsPerson
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int ID { get; set; }
        public string NationalNum { get; set; }
        public string FirsName { get; set; }
        public string SecoundName { get; set; }
        public string ThirdName { get; set; }
        public string LastName { get; set; }
        public string FullName()
        {
            return FirsName + " " + SecoundName + " " + ThirdName + " " + LastName;
        }
        public DateTime DateOfBirth { get; set; }
        public byte Gendor { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int NationalCountryID { get; set; }
        public string ImagePath { get; set; }

        public clsPerson()
        {

            this.ID = -1;
            this.NationalNum = "";
            this.FirsName = "";
            this.SecoundName = "";
            this.ThirdName = "";
            this.LastName = "";
            this.DateOfBirth = DateTime.Now;
            this.Gendor = 0;
            this.Address = "";
            this.Phone = "";
            this.Email = "";
            this.NationalCountryID = -1;
            this.ImagePath = "";
            Mode = enMode.AddNew;
        }

        private clsPerson(int ID, string NationalNum, string FirsName,
             string SecoundName, string ThirdName, string LastName, DateTime DateOfBirth,
             byte Gendor, string Address, string Phone, string Email,
             int NationalCountryID, string ImagePath)
        {
           this.ID = ID;
           this.NationalNum = NationalNum;
           this.FirsName = FirsName;
            this.SecoundName = SecoundName;
            this.ThirdName = ThirdName;
            this.LastName = LastName;
            this.DateOfBirth = DateOfBirth;
            this.Gendor = Gendor;
            this.Address = Address;
            this.Phone = Phone;
            this.Email = Email;
            this.NationalCountryID = NationalCountryID;
            this.ImagePath = ImagePath;

            Mode = enMode.Update;

        
        }

       public static clsPerson Find(int ID)
        {
            string NationalNum = "";
            string FirsName = "";
            string SecoundName = "";
            string ThirdName = "";
            string LastName = "";
            DateTime DateOfBirth = DateTime.Now;
            byte Gendor = 0;
            string Address = "";
            string Phone = "";
            string Email = "";
            int NationalCountryID = -1;
            string ImagePath = "";

            if (clsPersonData.GetPersonInfoByID(ID, ref NationalNum, ref FirsName,
            ref SecoundName, ref ThirdName, ref LastName, ref DateOfBirth,
            ref Gendor, ref Address, ref Phone, ref Email,
            ref NationalCountryID, ref ImagePath))
            {
             return new clsPerson(ID, NationalNum, FirsName, SecoundName, ThirdName, LastName, DateOfBirth,
             Gendor, Address, Phone, Email, NationalCountryID, ImagePath);
            }
            else
             return null;
            
        }

        public static clsPerson Find(string NationalNum)
        {
            int ID = -1;
            string FirsName = "";
            string SecoundName = "";
            string ThirdName = "";
            string LastName = "";
            DateTime DateOfBirth = DateTime.Now;
            byte Gendor = 0;
            string Address = "";
            string Phone = "";
            string Email = "";
            int NationalCountryID = -1;
            string ImagePath = "";

            if (clsPersonData.GetPersonInfoByNationalNo(NationalNum, ref ID, ref FirsName,
            ref SecoundName, ref ThirdName, ref LastName, ref DateOfBirth,
            ref Gendor, ref Address, ref Phone, ref Email,
            ref NationalCountryID, ref ImagePath))
            {
                return new clsPerson(ID,NationalNum, FirsName, SecoundName, ThirdName, LastName, DateOfBirth,
                Gendor, Address, Phone, Email, NationalCountryID, ImagePath);
            }
            else
                return null;
        }

        private bool _AddNewPerson()
        {
            this.ID = clsPersonData.AddNewPerson(this.NationalNum, this.FirsName, this.SecoundName, this.ThirdName,
                                                 this.LastName, this.DateOfBirth, this.Gendor, this.Address, this.Phone, this.Email,
                                                 this.NationalCountryID, this.ImagePath);
            return (this.ID != -1);
        }

        private bool _UpdatePerson()
        {
            return clsPersonData.UpdatedPerson(this.ID, this.NationalNum, this.FirsName, this.SecoundName, this.ThirdName,this.LastName,
                                               this.DateOfBirth, this.Gendor, this.Address, this.Phone, this.Email, this.NationalCountryID,
                                               this.ImagePath);
        }

        public static bool DeltetePerson(int ID)
        {
            return clsPersonData.DeletePerson(ID);
        }

        public static DataTable ListPersons()
        {
            return clsPersonData.ListPersons();
        }

        public static bool IsPersonExist(string NationalNo)
        {
            return clsPersonData.IsPersonExist(NationalNo);
        }

        public static bool IsPersonExist(int ID)
        {
            return clsPersonData.IsPersonExist(ID);
        }
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewPerson())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case enMode.Update:
                 return _UpdatePerson();
                    
            }

                return false;

        }

    }
}
