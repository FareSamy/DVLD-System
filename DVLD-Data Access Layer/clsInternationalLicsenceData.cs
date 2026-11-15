using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Data_Access_Layer
{
    public class clsInternationalLicsenceData
    {
        public static bool GetInternationalLicencesByLicencesID(int InternationalLicenseID, ref int ApplicationID, ref int DriverID, ref int IssuedUsingLocalLicenseID, ref DateTime IssueDate,
                                          ref DateTime ExpirationDate,  ref bool IsActive, ref int CreatedByUserID)
        {
            {
                bool isFound = false;
                SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
                string query = "select * from InternationalLicenses where InternationalLicenseID = @InternationalLicenseID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@InternationalLicenseID", InternationalLicenseID);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        isFound = true;

                        ApplicationID = (int)reader["ApplicationID"];
                        DriverID = (int)reader["DriverID"];
                        IssuedUsingLocalLicenseID = (int)reader["IssuedUsingLocalLicenseID"];
                        IssueDate = (DateTime)reader["IssueDate"];
                        ExpirationDate = (DateTime)reader["ExpirationDate"];
                        IsActive = (bool)reader["IsActive"];
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

        public static bool GetInternationalLicencesByApplicationID(int ApplicationID, ref int InternationalLicenseID, ref int DriverID, ref int IssuedUsingLocalLicenseID, ref DateTime IssueDate,
                                         ref DateTime ExpirationDate, ref bool IsActive, ref int CreatedByUserID)
        {
            {
                bool isFound = false;
                SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
                string query = "select * from InternationalLicenses where ApplicationID = @ApplicationID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        isFound = true;

                        InternationalLicenseID = (int)reader["InternationalLicenseID"];
                        DriverID = (int)reader["DriverID"];
                        IssuedUsingLocalLicenseID = (int)reader["IssuedUsingLocalLicenseID"];
                        IssueDate = (DateTime)reader["IssueDate"];
                        ExpirationDate = (DateTime)reader["ExpirationDate"];
                        IsActive = (bool)reader["IsActive"];
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


        public static bool GetInternationalLicencesByDriverID(int DriverID, ref int ApplicationID, ref int InternationalLicenseID, ref int IssuedUsingLocalLicenseID, ref DateTime IssueDate,
                                         ref DateTime ExpirationDate, ref bool IsActive, ref int CreatedByUserID)
        {
            {
                bool isFound = false;
                SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
                string query = "select * from InternationalLicenses where DriverID = @DriverID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@DriverID", DriverID);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        isFound = true;

                        InternationalLicenseID = (int)reader["InternationalLicenseID"];
                        ApplicationID = (int)reader["ApplicationID"];
                        IssuedUsingLocalLicenseID = (int)reader["IssuedUsingLocalLicenseID"];
                        IssueDate = (DateTime)reader["IssueDate"];
                        ExpirationDate = (DateTime)reader["ExpirationDate"];
                        IsActive = (bool)reader["IsActive"];
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

        public static DataTable ListInternationalDriverLicences(int DriverID)
        {
            DataTable DT = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"
                             SELECT * from InternationalLicenses where DriverID = @DriverID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@DriverID", DriverID);
            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                DT.Load(reader);
               


                reader.Close();
            }
            catch (Exception ex) { clsEventLog.Log(ex); }
            finally { connection.Close(); }
            return DT;
        }
        public static DataTable ListInternationalDriverLicences()
        {
            DataTable DT = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"
                             SELECT * from InternationalLicenses";

            SqlCommand command = new SqlCommand(query, connection);
            
            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                DT.Load(reader);



                reader.Close();
            }
            catch (Exception ex) { clsEventLog.Log(ex); }
            finally { connection.Close(); }
            return DT;
        }
        public static int AddNewinternationalLicences( int ApplicationID,  int DriverID,  int IssuedUsingLocalLicenseID,  DateTime IssueDate,
                                           DateTime ExpirationDate,  bool IsActive,  int CreatedByUserID)
        {
            int InternationalLicenseID = -1;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"INSERT INTO [InternationalLicenses]([ApplicationID],[DriverID],[IssuedUsingLocalLicenseID],[IssueDate]
                             ,[ExpirationDate],[IsActive],[CreatedByUserID]) 
                             VALUES
                             (@ApplicationID,@DriverID,@IssuedUsingLocalLicenseID,
                             @IssueDate,@ExpirationDate,@IsActive,@CreatedByUserID)
                             SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@DriverID", DriverID);
            command.Parameters.AddWithValue("@IssuedUsingLocalLicenseID", IssuedUsingLocalLicenseID);
            command.Parameters.AddWithValue("@IssueDate", IssueDate);
            command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);
            command.Parameters.AddWithValue("@IsActive", IsActive);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int InsertedID))
                {
                    InternationalLicenseID = InsertedID;
                }
            }
            catch (Exception ex) { clsEventLog.Log(ex); }
            finally { connection.Close(); }

            return InternationalLicenseID;

        }

        public static bool UpdateInternationalLicences(int InternationalLicenseID, int ApplicationID, int DriverID, int IssuedUsingLocalLicenseID, DateTime IssueDate,
                                           DateTime ExpirationDate, bool IsActive, int CreatedByUserID)
        {
            int EffectedRows = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"UPDATE InternationalLicense
                          SET  ApplicationID = @ApplicationID,
                               DriverID  = @DriverID, 
                               IssuedUsingLocalLicenseID = @IssuedUsingLocalLicenseID,
                               IssueDate = @IssueDate,
                               ExpirationDate = @ExpirationDate,
                               IsActive = @IsActive,
                               CreatedByUserID = @CreatedByUserID
                               WHERE InternationalLicenseID = @InternationalLicenseID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@InternationalLicenseID", InternationalLicenseID);
            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@DriverID", DriverID);
            command.Parameters.AddWithValue("@IssuedUsingLocalLicenseID", IssuedUsingLocalLicenseID);
            command.Parameters.AddWithValue("@IssueDate", IssueDate);
            command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);
            command.Parameters.AddWithValue("@IsActive", IsActive);
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
    }
}
