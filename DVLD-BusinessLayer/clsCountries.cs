using DVLD_Data_Access_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BusinessLayer
{
    public class clsCountries
    {
        public int ID { set; get; }
        public string CountrieName { set; get; }


        public clsCountries() 
        {
            this.ID = -1;
            this.CountrieName = "";
        }
        private clsCountries(int ID, string CountrieName)
        {
            this.ID = ID;
            this.CountrieName = CountrieName;
        }

        public static clsCountries Find(int ID)
        {
            string CountrieName = "";
            if (clsCountriesData.GetCountriesByInfoByID(ID, ref CountrieName))
            {
                return new clsCountries(ID, CountrieName);
            }
            else
                return null;

        }

        public static DataTable ListCountries()
        {
            return clsCountriesData.ListCountries();
        }

        public static bool IsCountryExist(int ID)
        {
            return clsCountriesData.IsCountryExist(ID);
        }








    }

    
}
