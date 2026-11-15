using DVLD_Data_Access_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BusinessLayer
{
    public class clsUser
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int UserID { get; set; }
        public int PersonID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }



        public clsUser()
        {
            this.UserID = -1;
            this.PersonID = -1;
            this.UserName = "";
            this.Password = "";
            Mode = enMode.AddNew;
        }
        private clsUser( int UserID, int PersonID, string UserName, string Password, bool isActive)
        {
            
            this.UserID = UserID;
            this.PersonID = PersonID;
            this.UserName = UserName;
            this.Password = Password;
            this.IsActive = isActive;
            Mode = enMode.Update;
        }

        public static clsUser Find(int ID)
        {
            int PersonID = -1;
            string UserName = "";
            string Password = "";
            bool isActive = false;

            if (clsUserData.GetUserByInfoByID(ID, ref PersonID, ref UserName, ref Password, ref isActive))
            {
                return new clsUser(ID, PersonID, UserName, Password, isActive);
            }
            else
                return null;


        }
        public static clsUser Find(string UserName)
        {
            int UserID = -1;
            int PersonID = -1;
            string Password = "";
            bool isActive = false;

            if (clsUserData.GetUserInfoByUserName(UserName,ref PersonID, ref UserID, ref Password, ref isActive))
            {
                return new clsUser(UserID, PersonID, UserName, Password, isActive);
            }
            else
                return null;


        }

        public static clsUser FindByPersonID(int PersonID)
        {
            int UserID = -1;
            string UserName = "";
            string Password = "";
            bool isActive = false;

            if (clsUserData.GetUserByInfoByPersonID(PersonID, ref UserID, ref UserName, ref Password, ref isActive))
            {
                return new clsUser(UserID, PersonID, UserName, Password, isActive);
            }
            else
                return null;


        }
        private bool _AddNewUser()
        {
            this.UserID = clsUserData.AddNewUser(this.PersonID,this.UserName,this.Password,this.IsActive);
            return (this.UserID != -1);
        }
        private bool _UpdateUser()
        {
            return clsUserData.UpdateUser(this.UserID, this.PersonID, this.UserName, this.Password, this.IsActive);
        }
        public static bool DeleteUser(int ID)
        {
            return clsUserData.DeleteUser(ID);
        }
        public static DataTable ListUsers()
        {
            return clsUserData.ListUsers();
        }
        public static bool IsUserExist(int ID)
        {
            return clsUserData.IsUsersExist(ID);
        }
        public static bool IsUserNameExist(string UserName)
        {
            return clsUserData.IsUserNameExist(UserName);
        }
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewUser())
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
                        return _UpdateUser();
                    }
            }

            return false;

        }

    }
}
