using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace DVLD_Data_Access_Layer
{
    public class clsApplicationTypeData
    {
        public static bool GetAppTyperInfoByTypeID(int AppTypeID, ref string AppTitle, ref decimal AppFees)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "select * from ApplicationTypes where ApplicationTypeID = @ApplicationTypeID ";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicationTypeID", AppTypeID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    IsFound = true;
                    AppTitle = (string)reader["ApplicationTypeTitle"];
                    AppFees = (decimal)reader["ApplicationFees"];
                }
                else
                {
                    IsFound = false;
                }
                                    

            }
            catch (Exception ex) { clsEventLog.Log(ex); return false; }
            finally { connection.Close(); }
            return IsFound;
        }

        public static DataTable ListAppType()
        {
            DataTable DT = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "select * from ApplicationTypes";
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

        public static bool UpdateAppType(int ID, string Titel, decimal Fees)
        {
            int RowsEffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"Update ApplicationTypes set 
                           ApplicationTypeTitle = @ApplicationTypeTitle,
                           ApplicationFees = @ApplicationFees
                           where ApplicationTypeID = @ApplicationTypeID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicationTypeID", ID);
            command.Parameters.AddWithValue("@ApplicationTypeTitle", Titel);
            command.Parameters.AddWithValue("@ApplicationFees", Fees);
            try 
            {
                connection.Open();
                RowsEffected = command.ExecuteNonQuery();

            }
            catch (Exception ex) { clsEventLog.Log(ex); return false; }
            finally { connection.Close(); }

            return (RowsEffected > 0);
        }

        public static int AddNewAppType( string Titel, decimal Fees)

        {
            int AppTypeID = -1;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"insert into ApplicationTypes (ApplicationTypeTitle,ApplicationFees)
                                                          VALUES 
                                                          (@ApplicationTypeTitle,@ApplicationFees)
                                                          SELECT SCOPE_IDENTITY();";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicationTypeTitle", Titel);
            command.Parameters.AddWithValue("@ApplicationFees", Fees);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int InsertedID))
                {
                    return AppTypeID = InsertedID;
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
            return AppTypeID;

        }

    }
}
