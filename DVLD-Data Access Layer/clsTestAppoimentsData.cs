using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Data_Access_Layer
{
    public class clsTestAppoimentsData
    {

        public static DataTable ListVisionTest(int LDLAID)
        {

            DataTable DT = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"
                             select TestAppointmentID as ""Appoiments ID"" ,
                             AppointmentDate as ""Appoiments Date"",
	                         PaidFees as ""Paid Fees"",
	                         IsLocked as ""Is Locked""
                             from TestAppointments where LocalDrivingLicenseApplicationID =@LocalDrivingLicenseApplicationID 
                             and TestTypeID =1";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LDLAID);
            
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
        public static DataTable ListWriteTest(int LDLAID)
        {

            DataTable DT = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"select TestAppointmentID as ""Appoiments ID"" ,
                             AppointmentDate as ""Appoiments Date"",
	                         PaidFees as ""Paid Fees"",
	                         IsLocked as ""Is Locked""
                             from TestAppointments where LocalDrivingLicenseApplicationID =@LocalDrivingLicenseApplicationID 
                             and TestTypeID =2";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LDLAID);

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
        public static DataTable ListStreetTest(int LDLAID)
        {

            DataTable DT = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"select TestAppointmentID as ""Appoiments ID"" ,
                             AppointmentDate as ""Appoiments Date"",
	                         PaidFees as ""Paid Fees"",
	                         IsLocked as ""Is Locked""
                             from TestAppointments where LocalDrivingLicenseApplicationID =@LocalDrivingLicenseApplicationID 
                             and TestTypeID =3";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LDLAID);

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
        public static bool IsHaveActiveVisionTest(int LDLAID)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "select x =1 from TestAppointments where LocalDrivingLicenseApplicationID =@LocalDrivingLicenseApplicationID and TestTypeID =1 and IsLocked =0;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LDLAID);

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
        public static bool IsHaveActiveWrittenTest(int LDLAID)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "select x =1 from TestAppointments where LocalDrivingLicenseApplicationID =@LocalDrivingLicenseApplicationID and TestTypeID =2 and IsLocked =0;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LDLAID);

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
        public static bool IsHaveActiveStreetTest(int LDLAID)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "select x =1 from TestAppointments where LocalDrivingLicenseApplicationID =@LocalDrivingLicenseApplicationID and TestTypeID =3 and IsLocked =0;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LDLAID);

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
        public static int AddNewTestApppiment(int TestTypeID, int LocalDrivingLicenseApplicationID, DateTime AppointmentDate,
                                           decimal PaidFees, int CreatedByUserID,bool IsLocked)
        {
            int TestAppointmentID = -1;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"INSERT INTO TestAppointments([TestTypeID]
                             ,[LocalDrivingLicenseApplicationID]
                             ,[AppointmentDate]
                             ,[PaidFees]
                             ,[CreatedByUserID]
                             ,[IsLocked]) 
                             VALUES
                             (@TestTypeID,@LocalDrivingLicenseApplicationID,@AppointmentDate,
                             @PaidFees,@CreatedByUserID,@IsLocked)
                             SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@AppointmentDate", AppointmentDate);
            command.Parameters.AddWithValue("@PaidFees", PaidFees);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            command.Parameters.AddWithValue("@IsLocked", IsLocked);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int InsertedID))
                {
                    TestAppointmentID = InsertedID;
                }
            }
            catch (Exception ex) { clsEventLog.Log(ex); }
            finally { connection.Close(); }

            return TestAppointmentID;

        }
        public static bool UpdateTestApppiment(int TestAppointmentID, int TestTypeID, int LocalDrivingLicenseApplicationID, DateTime AppointmentDate,
                                          decimal PaidFees, int CreatedByUserID, bool IsLocked)
        {
            int EffectedRows = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"UPDATE TestAppointments
                               SET
                               TestTypeID = @TestTypeID,
                               LocalDrivingLicenseApplicationID  = @LocalDrivingLicenseApplicationID, 
                               AppointmentDate = @AppointmentDate,
                               PaidFees = @PaidFees,
                               CreatedByUserID = @CreatedByUserID,
                               IsLocked = @IsLocked
                               WHERE TestAppointmentID = @TestAppointmentID;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@AppointmentDate", AppointmentDate);
            command.Parameters.AddWithValue("@PaidFees", PaidFees);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            command.Parameters.AddWithValue("@IsLocked", IsLocked);
            command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);

            try
            {

                connection.Open();
                EffectedRows = command.ExecuteNonQuery();
            }
            catch (Exception ex) { clsEventLog.Log(ex); }
            finally { connection.Close(); }

            return (EffectedRows > 0);

        }
        public static bool GetTestAppoimentByTestAppointmentID(int TestAppointmentID, ref int TestTypeID,ref int LocalDrivingLicenseApplicationID, ref DateTime AppointmentDate,
                                        ref  decimal PaidFees,ref int CreatedByUserID,ref bool IsLocked)
        {
            {
                bool isFound = false;
                SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
                string query = "Select * From TestAppointments where TestAppointmentID = @TestAppointmentID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        isFound = true;
                        TestTypeID = (int)reader["TestTypeID"];
                        LocalDrivingLicenseApplicationID = (int)reader["LocalDrivingLicenseApplicationID"];
                        AppointmentDate = (DateTime)reader["AppointmentDate"];
                        PaidFees = (decimal)reader["PaidFees"];
                        CreatedByUserID = (int)reader["CreatedByUserID"];
                        IsLocked = (bool)reader["IsLocked"];

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

        public static bool GetTestAppoimentByLDLAID(int LocalDrivingLicenseApplicationID, ref int TestTypeID, ref int TestAppointmentID, ref DateTime AppointmentDate,
                                       ref decimal PaidFees, ref int CreatedByUserID, ref bool IsLocked)
        {
            {
                bool isFound = false;
                SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
                string query = @"SELECT * FROM TestAppointments 
                 WHERE LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID ";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
               
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        isFound = true;
                        TestTypeID = (int)reader["TestTypeID"];
                        TestAppointmentID = (int)reader["TestAppointmentID"];
                        AppointmentDate = (DateTime)reader["AppointmentDate"];
                        PaidFees = (decimal)reader["PaidFees"];
                        CreatedByUserID = (int)reader["CreatedByUserID"];
                        IsLocked = (bool)reader["IsLocked"];

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


    }
}
