using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Data_Access_Layer
{
    public class clsLicenseClassesData
    {
        public static bool GetClassInfoByID(int ID, ref string ClassName, ref  string ClassDescraption, ref byte MinimumAllowedAge, ref byte DefaultValidityLength , ref decimal Classfees)
        {

            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "Select * From LicenseClasses where LicenseClassID = @LicenseClassID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LicenseClassID", ID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    isFound = true;
                    ClassName = (string)reader["ClassName"];
                    ClassDescraption = (string)reader["ClassDescription"];
                    MinimumAllowedAge = (byte)reader["MinimumAllowedAge"];
                    DefaultValidityLength = (byte)reader["DefaultValidityLength"];
                    Classfees = (decimal)reader["ClassFees"];

                }
                else
                {
                    isFound = false;
                }
                reader.Close();

            }
            catch (Exception ex)
            {
                clsEventLog.Log(ex);
                isFound = false;
            }
            finally
            {
                connection.Close();
            }


            return isFound;
        }

        public static DataTable ListClasses()
        {

            DataTable DT = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "select * from LicenseClasses";
            SqlCommand command = new SqlCommand(query, connection);
            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows) { DT.Load(reader); }

                reader.Close();
            }
            catch (Exception ex) { clsEventLog.Log(ex); }
            finally { connection.Close(); }
            return DT;
        }
    }
}
