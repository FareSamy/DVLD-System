using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Data_Access_Layer
{
    public class clsLocalDrivingLicenseApplicationsData
    {
        public static int AddNewLocalApplication(int AppID,int LicenseClassID)
        {
            int ApplicationID = -1;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"INSERT INTO LocalDrivingLicenseApplications([ApplicationID],[LicenseClassID])
                             VALUES
                             (@ApplicationID,@LicenseClassID)
                             SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicationID", AppID);
            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
          
            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int InsertedID))
                {
                    ApplicationID = InsertedID;
                }
            }
            catch (Exception ex) { clsEventLog.Log(ex); }
            finally { connection.Close(); }

            return ApplicationID;


        }
        public static bool IsLocalLicenseAppIsExsist(int LocalLicensAppID)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "select x=1 from LocalDrivingLicenseApplications where LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalLicensAppID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    isFound = true;
                }
                reader.Close();
            }
            catch (Exception ex) { clsEventLog.Log(ex); return false; }
            finally { connection.Close(); }
            return isFound;
        }
        public static bool GeTLocalLicensAppInfoByAppID(int ApplicationID, ref int LocalDrivingLicenseApplicationID, ref int LicensID)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "Select * From LocalDrivingLicenseApplications where ApplicationID = @ApplicationID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    isFound = true;
                    LocalDrivingLicenseApplicationID = (int)reader["LocalDrivingLicenseApplicationID"];
                    LicensID = (int)reader["LicenseClassID"];
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
        public static bool IsDoesPersonHaveActiveApplication(int PersonID, int LicensClassID)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"SELECT Found=1 
                         FROM LocalDrivingLicenseApplications 
                         INNER JOIN Applications ON LocalDrivingLicenseApplications.ApplicationID = Applications.ApplicationID
                         WHERE Applications.ApplicantPersonID = @PersonID 
                         AND LocalDrivingLicenseApplications.LicenseClassID = @LicenseClassID
                         AND Applications.ApplicationStatus IN (1,3)";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@PersonID", PersonID);
                command.Parameters.AddWithValue("@LicenseClassID", LicensClassID);

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();

                    if (result != null)
                    {
                        isFound = true;
                    }
                }
                catch (Exception ex)
                {
                    clsEventLog.Log(ex);
                    isFound = false;
                }
            }
            return isFound;
        }
        public static bool GeTLocalLicensAppInfoByLocalAppID(int LocalDrivingLicenseApplicationID , ref int ApplicationID, ref int LicensID)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "Select * From LocalDrivingLicenseApplications where LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    isFound = true;
                    ApplicationID = (int)reader["ApplicationID"];
                    LicensID = (int)reader["LicenseClassID"];
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
        public static bool DeleteLocalLicenseApp(int LocalLicensID)
        {
            int RowEffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "delete LocalDrivingLicenseApplications where LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalLicensID);
            try
            {
                connection.Open();
                RowEffected = command.ExecuteNonQuery();


            }
            catch (Exception ex)
            {
                clsEventLog.Log(ex);
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
            finally
            {
                connection.Close();
            }
            return (RowEffected > 0);

        }

    }
}
