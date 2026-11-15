using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using static System.Net.Mime.MediaTypeNames;

namespace DVLD_Data_Access_Layer
{
    public class clsApplicationsData
    {

        public static bool GetApplicationByID(int ID, ref int AppPersonID, ref DateTime AppDate, ref int AppTypeID, ref byte AppStatus,
                                              ref DateTime LastStatusDate, ref decimal PaidFees, ref int CreatedByUserID)
        {
            {
                bool isFound = false;
                SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
                string query = "Select * From Applications where ApplicationID = @ApplicationID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ApplicationID", ID);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        isFound = true;
                        AppPersonID = (int)reader["ApplicantPersonID"];
                        AppDate = (DateTime)reader["ApplicationDate"];
                        AppTypeID = (int)reader["ApplicationTypeID"];
                        AppStatus = (byte)reader["ApplicationStatus"];
                        LastStatusDate = (DateTime)reader["LastStatusDate"];
                        PaidFees = (decimal)reader["PaidFees"];
                        CreatedByUserID = (int)reader["CreatedByUserID"];


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
        }

        public static DataTable GetApplicationInfoByPersonID(int ID)
        {
            DataTable DT = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "Select * From Applications where ApplicantPersonID = @ApplicantPersonID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("ApplicantPersonID", ID);
            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    DT.Load(reader);
                }

                reader.Close();
            }
            catch (Exception ex) { clsEventLog.Log(ex); }
            finally { connection.Close(); }
            return DT;
        }

        public static DataTable ListApplications()
        {
            DataTable DT = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"SELECT
                           LDL.LocalDrivingLicenseApplicationID AS [L.D.LAppID], 
                           LC.ClassName AS [Driving Class],
                           P.NationalNo,
                           (P.FirstName + ' ' + P.SecondName + ' ' + ISNULL(' ' + P.ThirdName, '') + ' ' + P.LastName) AS [Full Name],
                           App.ApplicationDate,
                           COUNT(CASE WHEN T.TestResult = 1 THEN 1 END) AS [Passed Tests],
                           CASE 
                           WHEN App.ApplicationStatus = 1 THEN 'New'
                           WHEN App.ApplicationStatus = 2 THEN 'Cancelled' 
                           WHEN App.ApplicationStatus = 3 THEN 'Completed'       
                           END AS Status
                           FROM LocalDrivingLicenseApplications LDL
                           INNER JOIN Applications App ON LDL.ApplicationID = App.ApplicationID 
                           INNER JOIN LicenseClasses LC ON LDL.LicenseClassID = LC.LicenseClassID 
                           INNER JOIN People P ON App.ApplicantPersonID = P.PersonID 
                           LEFT JOIN TestAppointments TA ON LDL.LocalDrivingLicenseApplicationID = TA.LocalDrivingLicenseApplicationID 
                           LEFT JOIN Tests T ON TA.TestAppointmentID = T.TestAppointmentID
                           GROUP BY 
                           LDL.LocalDrivingLicenseApplicationID,
                           LC.ClassName,
                           P.NationalNo,
                           P.FirstName, P.SecondName, P.ThirdName, P.LastName,
                           App.ApplicationDate,
                           App.ApplicationStatus
                           ORDER BY LDL.LocalDrivingLicenseApplicationID DESC;";
            SqlCommand command = new SqlCommand(query, connection);
           
            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    DT.Load(reader);
                }

                reader.Close();
            }
            catch (Exception ex) { clsEventLog.Log(ex); }
            finally { connection.Close(); }
            return DT;
        }

        public static int AddNewApplication(int AppPersonID, DateTime ApplicationDate, int AppTypeID,
                                             byte AppStatu, DateTime LastStatuDate, decimal PaidFees, int CreatedByUserID)
        {
            int ApplicationID = -1;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"INSERT INTO Applications([ApplicantPersonID],[ApplicationDate],[ApplicationTypeID],[ApplicationStatus]
                             ,[LastStatusDate],[PaidFees],[CreatedByUserID]) 
                             VALUES
                             (@ApplicantPersonID,@ApplicationDate,@ApplicationTypeID,
                             @ApplicationStatus,@LastStatusDate,@PaidFees,@CreatedByUserID)
                             SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicantPersonID", AppPersonID);
            command.Parameters.AddWithValue("@ApplicationDate", ApplicationDate);
            command.Parameters.AddWithValue("@ApplicationTypeID", AppTypeID);
            command.Parameters.AddWithValue("@ApplicationStatus", AppStatu);
            command.Parameters.AddWithValue("@LastStatusDate", LastStatuDate);
            command.Parameters.AddWithValue("@PaidFees", PaidFees);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

            try 
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int InsertedID))
                {
                    ApplicationID = InsertedID;
                }
            }
            catch(Exception ex) { clsEventLog.Log(ex); }
            finally { connection.Close(); }

            return ApplicationID;


        }

        public static bool UpdateApplication(int AppID, int AppPersonID, DateTime AppDate, int AppTypeID,
                                             byte AppStatu, DateTime LastStatuDate, decimal PaidFees, int CreatedByUserID)
        {
            int EffectedRows = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"UPDATE Applications
                          SET  ApplicantPersonID = @ApplicantPersonID,
                               ApplicationDate  = @ApplicationDate, 
                               ApplicationTypeID = @ApplicationTypeID,
                               ApplicationStatus = @ApplicationStatus,
                               LastStatusDate = @LastStatusDate,
                               PaidFees = @PaidFees,
                               CreatedByUserID = @CreatedByUserID
                               WHERE ApplicationID = @ApplicationID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicationID", AppID);
            command.Parameters.AddWithValue("@ApplicantPersonID", AppPersonID);
            command.Parameters.AddWithValue("@ApplicationDate", AppDate);
            command.Parameters.AddWithValue("@ApplicationTypeID", AppTypeID);
            command.Parameters.AddWithValue("@ApplicationStatus", AppStatu);
            command.Parameters.AddWithValue("@LastStatusDate", LastStatuDate);
            command.Parameters.AddWithValue("@PaidFees", PaidFees);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            try 
            {
                connection.Open();
                EffectedRows = command.ExecuteNonQuery();
            }
            catch (Exception ex) { clsEventLog.Log(ex); }
            finally { connection.Close(); }
            return (EffectedRows > 0);

        }

        public static bool DeleteApplication(int AppID)
        {
            int RowEffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string qurey ="delete  Applications where ApplicationID = @ApplicationID";
            SqlCommand command = new SqlCommand(qurey, connection);
            command.Parameters.AddWithValue("@ApplicationID", AppID);
            try
            {
                connection.Open();

                RowEffected = command.ExecuteNonQuery();
            }
            catch (Exception ex) { clsEventLog.Log(ex); return false; }
            finally { connection.Close(); }
            return (RowEffected > 0);
        }

        public static bool ApplicationIsExsistByPersonID(int ApplicantPersonID)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "select x=1 from Applications where ApplicantPersonID = @ApplicantPersonID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicantPersonID", ApplicantPersonID);

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
    }
}
