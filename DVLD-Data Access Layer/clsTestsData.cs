using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Data_Access_Layer
{
    public class clsTestsData
    {
        public static bool GetTestByTestAppoimentsID(int TestAppointmentID, ref int TestID, ref bool? TestResult, ref string Notes, ref int CreatedByUserID)
        {
            {
                bool isFound = false;
                SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
                string query = @" select top 1 * from tests where TestAppointmentID = @TestAppointmentID
                                ORDER BY TestID DESC";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        isFound = true;
                        TestID = (int)reader["TestID"];

                        if (reader["TestResult"] == DBNull.Value)
                            TestResult = null;
                        else
                            TestResult = (bool)reader["TestResult"];

                        if (reader["Notes"] == DBNull.Value)
                            Notes = "";
                        else
                            Notes = (string)reader["Notes"];

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
        public static int CountPassedTests(int LDLAppID)
        {
            int PassedTests = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"
                               SELECT 
                               COUNT(T.TestID)
                               FROM 
                               TestAppointments TA
                               INNER JOIN 
                               Tests T ON TA.TestAppointmentID = T.TestAppointmentID
                               WHERE 
                               T.TestResult = 1 
                               AND TA.LocalDrivingLicenseApplicationID =@LocalDrivingLicenseApplicationID
                                ";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LDLAppID);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();
                if (result != null && result != DBNull.Value)
                {
                    PassedTests = Convert.ToInt32(result);
                }

            }
            catch (Exception ex)
            {
                clsEventLog.Log(ex);
            }
            finally
            {
                connection.Close();
            }
            return PassedTests;
        }
        public static bool IsPassedVisionTest(int LDLAppID)
        {
            bool PassedTests = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"
                               SELECT 
                               COUNT(T.TestID)
                               FROM 
                               TestAppointments TA
                               INNER JOIN 
                               Tests T ON TA.TestAppointmentID = T.TestAppointmentID
                               WHERE 
                               T.TestResult = 1 
                               AND TA.LocalDrivingLicenseApplicationID =@LocalDrivingLicenseApplicationID and TestTypeID =1
                                ";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LDLAppID);
            try
            {

                connection.Open();
                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int count))
                {

                    PassedTests = (count > 0);
                }
            }
            catch (Exception ex)
            {
                clsEventLog.Log(ex);
            }
            finally
            {
                connection.Close();
            }
            return PassedTests;
        }
        public static bool IsPassedWrittenTest(int LDLAppID)
            {
                bool PassedTests = false;

                SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
                string query = @"
                                   SELECT 
                                   COUNT(T.TestID)
                                   FROM 
                                   TestAppointments TA
                                   INNER JOIN 
                                   Tests T ON TA.TestAppointmentID = T.TestAppointmentID
                                   WHERE 
                                   T.TestResult = 1 
                                   AND TA.LocalDrivingLicenseApplicationID =@LocalDrivingLicenseApplicationID and TestTypeID =2
                                    ";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LDLAppID);
                try
                {

                    connection.Open();
                    object result = command.ExecuteScalar();

                    if (result != null && int.TryParse(result.ToString(), out int count))
                    {

                        PassedTests = (count > 0);
                    }

                }
                catch (Exception ex)
                {
                   clsEventLog.Log(ex);
                }
                finally
                {
                    connection.Close();
                }
                return PassedTests;
            }
        public static bool IsPassedStreetTest(int LDLAppID)
        {
            bool PassedTests = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"
                               SELECT 
                               COUNT(T.TestID)
                               FROM 
                               TestAppointments TA
                               INNER JOIN 
                               Tests T ON TA.TestAppointmentID = T.TestAppointmentID
                               WHERE 
                               T.TestResult = 1 
                               AND TA.LocalDrivingLicenseApplicationID =@LocalDrivingLicenseApplicationID and TestTypeID =3
                                ";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LDLAppID);
            try
            {

                connection.Open();
                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int count))
                {

                    PassedTests = (count > 0);
                }
            }
            catch (Exception ex)
            {
                clsEventLog.Log(ex);
            }
            finally
            {
                connection.Close();
            }
            return PassedTests;
        }
        public static int AddNewTest(int TestAppointmentID, bool? TestResult, string Notes,
                                           int CreatedByUserID)
        { 
            int TestID = -1;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"INSERT INTO Tests ([TestAppointmentID],[TestResult],[Notes],[CreatedByUserID]) 
                             VALUES
                             (@TestAppointmentID,@TestResult,@Notes,
                             @CreatedByUserID)
                             SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
            command.Parameters.AddWithValue("@TestResult", TestResult);
            command.Parameters.AddWithValue("@Notes", Notes);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);


            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int InsertedID))
                {
                    TestID = InsertedID;
                }
            }
            catch (Exception ex) { clsEventLog.Log(ex); }
            finally { connection.Close(); }

            return TestID;
        }
        public static bool IsFailedInTestType(int LDLAppID, int TestTypeID)
        {

            bool ISFailed = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"
                   select * from TestAppointments where LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID 
                     and TestTypeID = @TestTypeID and IsLocked = 1
                                ";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LDLAppID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            try
            {

                connection.Open();
                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int count))
                {

                    ISFailed = (count > 0);
                }
            }
            catch (Exception ex)
            {
                clsEventLog.Log(ex);
            }
            finally
            {
                connection.Close();
            }
            return ISFailed;
        }

        public static int HowManyFailedInTest(int LDLAppID, int TestTypeID)
        {
            int failCount = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"
                               SELECT 
                               COUNT(T.TestID)
                               FROM 
                               TestAppointments TA
                               INNER JOIN 
                               Tests T ON TA.TestAppointmentID = T.TestAppointmentID
                               WHERE 
                               T.TestResult = 0
                               AND TA.LocalDrivingLicenseApplicationID =@LocalDrivingLicenseApplicationID and TestTypeID =@TestTypeID
                                ";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LDLAppID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            try
            {

                connection.Open();
               
                 failCount = (int)command.ExecuteScalar();
            }
            catch (Exception ex)
            {
                clsEventLog.Log(ex);
            }
            finally
            {
                connection.Close();
            }
            return failCount;

        }
    }

}
