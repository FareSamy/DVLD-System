using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Data_Access_Layer
{
    public class clsDetainedLicenseData
    {
        public static bool IsLicenseDetained(int LicenseID)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "select x=1 from DetainedLicenses where LicenseID = @LicenseID and IsReleased =0";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LicenseID", LicenseID);

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

        public static DataTable ListDetainLicense()
        {
            DataTable DT = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"
                              SELECT 
                                DL.DetainID, 
                                DL.LicenseID, 
                                DL.DetainDate, 
                                DL.FineFees, 
                                DL.IsReleased, 
                                DL.ReleaseDate, 
                                DL.ReleaseApplicationID,
                               
                                (P.FirstName + ' ' + ISNULL(P.SecondName, '') + ' ' + ISNULL(P.ThirdName, '') + ' ' + P.LastName) AS FullName,
                               
                                P.NationalNo
                               FROM DetainedLicenses DL
                               INNER JOIN Licenses L ON DL.LicenseID = L.LicenseID
                               INNER JOIN Drivers D ON L.DriverID = D.DriverID
                              INNER JOIN People P ON D.PersonID = P.PersonID;";
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
        public static bool GetDetainedLicencesByLicencesID(int LicenseID, ref int DetainID, ref DateTime DetainDate, ref decimal FineFees, ref int CreatedByUserID,
                                          ref bool IsReleased, ref DateTime? ReleaseDate, ref int? ReleasedByUserID, ref int? ReleaseApplicationID)
        {
            {
                bool isFound = false;
                SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
                string query = "select * from DetainedLicenses where LicenseID = @LicenseID and IsReleased =0";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@LicenseID", LicenseID);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        isFound = true;

                        DetainID = (int)reader["DetainID"];
                        DetainDate = (DateTime)reader["DetainDate"];
                        FineFees = (decimal)reader["FineFees"];
                        CreatedByUserID = (int)reader["CreatedByUserID"];
                        IsReleased = (bool)reader["IsReleased"];
                        ReleaseDate = reader["ReleaseDate"] != DBNull.Value ? (DateTime?)reader["ReleaseDate"] : null;
                        ReleasedByUserID = reader["ReleasedByUserID"] != DBNull.Value ? (int?)reader["ReleasedByUserID"] : null;
                        ReleaseApplicationID = reader["ReleaseApplicationID"] != DBNull.Value ? (int?)reader["ReleaseApplicationID"] : null;
                       
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
        public static int DetainLicense(int LicenseID, DateTime DetainDate, decimal FineFees, int CreatedByUserID,
                                       bool IsReleased, DateTime? ReleaseDate, int? ReleasedByUserID, int? ReleaseApplicationID)
        {
            int DetainID = -1;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"INSERT INTO [DetainedLicenses]
                               ([LicenseID]
                              ,[DetainDate]
                              ,[FineFees]
                              ,[CreatedByUserID]
                              ,[IsReleased]
                              ,[ReleaseDate]
                              ,[ReleasedByUserID]
                              ,[ReleaseApplicationID]) 
                             VALUES
                             (@LicenseID,@DetainDate,
                             @FineFees,@CreatedByUserID,@IsReleased,@ReleaseDate,@ReleasedByUserID,@ReleaseApplicationID )
                             SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LicenseID", LicenseID);
            command.Parameters.AddWithValue("@DetainDate", DetainDate);
            command.Parameters.AddWithValue("@FineFees", FineFees);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            command.Parameters.AddWithValue("@IsReleased", IsReleased);
            command.Parameters.AddWithValue("@ReleaseDate", (ReleaseDate == null || ReleaseDate == DateTime.MinValue) ? DBNull.Value : (object)ReleaseDate);
            command.Parameters.AddWithValue("@ReleasedByUserID", (ReleasedByUserID == null || ReleasedByUserID == -1) ? DBNull.Value : (object)ReleasedByUserID);
            command.Parameters.AddWithValue("@ReleaseApplicationID", (ReleaseApplicationID == null || ReleaseApplicationID == -1) ? DBNull.Value : (object)ReleaseApplicationID);
        

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int InsertedID))
                {
                    DetainID = InsertedID;
                }
            }
            catch (Exception ex) { clsEventLog.Log(ex); }
            finally { connection.Close(); }

            return DetainID;
        }


        public static bool RelaseLicense(int DetainID,int LicenseID, DateTime DetainDate, decimal FineFees, int CreatedByUserID,
                                       bool IsReleased, DateTime? ReleaseDate, int? ReleasedByUserID, int? ReleaseApplicationID)
        {
            int EffectedRows = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"UPDATE DetainedLicenses
                          SET  LicenseID = @LicenseID,
                               DetainDate  = @DetainDate, 
                               FineFees = @FineFees,
                               CreatedByUserID = @CreatedByUserID,
                               IsReleased = @IsReleased,
                               ReleaseDate = @ReleaseDate,
                               ReleasedByUserID = @ReleasedByUserID,
                               ReleaseApplicationID = @ReleaseApplicationID
                               WHERE DetainID = @DetainID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@DetainID", DetainID);
            command.Parameters.AddWithValue("@LicenseID", LicenseID);
            command.Parameters.AddWithValue("@DetainDate", DetainDate);
            command.Parameters.AddWithValue("@FineFees", FineFees);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            command.Parameters.AddWithValue("@IsReleased", IsReleased);
            command.Parameters.AddWithValue("@ReleaseDate", (ReleaseDate == null || ReleaseDate == DateTime.MinValue) ? DBNull.Value : (object)ReleaseDate);
            command.Parameters.AddWithValue("@ReleasedByUserID", (ReleasedByUserID == null || ReleasedByUserID == -1) ? DBNull.Value : (object)ReleasedByUserID);
            command.Parameters.AddWithValue("@ReleaseApplicationID", (ReleaseApplicationID == null || ReleaseApplicationID == -1) ? DBNull.Value : (object)ReleaseApplicationID);

            try
            {
                connection.Open();
                EffectedRows = command.ExecuteNonQuery();
            }
            catch (Exception ex) { clsEventLog.Log(ex); }
            finally { connection.Close(); }
            return (EffectedRows > 0);
        }


        public static bool DeleteDetainLicense(int DetainID)
        {
            int RowEffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string qurey = "delete  DetainedLicenses where DetainID = @DetainID";
            SqlCommand command = new SqlCommand(qurey, connection);
            command.Parameters.AddWithValue("@DetainID", DetainID);
            try
            {
                connection.Open();

                RowEffected = command.ExecuteNonQuery();
            }
            catch (Exception ex) { clsEventLog.Log(ex); return false; }
            finally { connection.Close(); }
            return (RowEffected > 0);
        }







    }
}
