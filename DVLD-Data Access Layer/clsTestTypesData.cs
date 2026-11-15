using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Data_Access_Layer
{
    public class clsTestTypesData
    {
        public static bool GetTestTypeInfoByTypeID(int TestTypeID, ref string TestTitle,ref string TestDescription, ref decimal TestFees)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "select * from TestTypes where TestTypeID = @TestTypeID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TestTypeID",TestTypeID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    IsFound = true;
                    TestTitle = (string)reader["TestTypeTitle"];
                    TestDescription = (string)reader["TestTypeDescription"];
                    TestFees = (decimal)reader["TestTypeFees"];
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

        public static DataTable ListTestType()
        {
            DataTable DT = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "select * from TestTypes";
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

        public static bool UpdateTestType(int ID, string Titel,string Description, decimal Fees)
        {
            int RowsEffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"Update TestTypes set 
                           TestTypeTitle = @TestTypeTitle,
                           TestTypeDescription = @TestTypeDescription,
                           TestTypeFees = @TestTypeFees
                           where TestTypeID = @TestTypeID;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TestTypeID", ID);
            command.Parameters.AddWithValue("@TestTypeTitle", Titel);
            command.Parameters.AddWithValue("@TestTypeDescription", Description);
            command.Parameters.AddWithValue("@TestTypeFees", Fees);
            try
            {
                connection.Open();
                RowsEffected = command.ExecuteNonQuery();

            }
            catch (Exception ex) { clsEventLog.Log(ex); return false; }
            finally { connection.Close(); }

            return (RowsEffected > 0);
        }

        public static int AddNewTestType(string Titel, string Description, decimal Fees)

        {
            int TestTypeID = -1;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"insert into TestTypes (TestTypeTitle,TestTypeDescription,TestTypeFees)
                                                          VALUES 
                                                          (@TestTypeTitle,@TestTypeDescription,@TestTypeFees)
                                                          SELECT SCOPE_IDENTITY();";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@TestTypeTitle", Titel);
            command.Parameters.AddWithValue("@TestTypeDescription", Description);
            command.Parameters.AddWithValue("@TestTypeFees", Fees);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int InsertedID))
                {
                    return TestTypeID = InsertedID;
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
            return TestTypeID;

        }

    }
}

