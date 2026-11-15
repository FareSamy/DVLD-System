using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Xml;
using System.Net;
using System.Security.Policy;

namespace DVLD_Data_Access_Layer
{
    public class clsUserData
    {
        public static bool GetUserByInfoByID(int ID, ref int PersonID, ref string UserName, ref string Password,ref bool IsActive)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "Select * From Users where UserID = @UserID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@UserID",ID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    isFound = true;
                    PersonID = (int)reader["PersonID"];
                    UserName = (string)reader["UserName"];
                    Password = (string)reader["Password"];
                    IsActive= (bool)reader["IsActive"];
       

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

        public static bool GetUserInfoByUserName(string UserName, ref int PersonID,ref int UserID, ref string Password, ref bool IsActive)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "Select * From Users where UserName = @UserName COLLATE Latin1_General_CS_AS";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@UserName", UserName);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    isFound = true;
                    UserID = (int)reader["UserID"];
                    PersonID = (int)reader["PersonID"];
                    UserName = (string)reader["UserName"];
                    Password = (string)reader["Password"];
                    IsActive = (bool)reader["IsActive"];


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

        public static bool GetUserByInfoByPersonID(int PersonID, ref int UserID, ref string UserName, ref string Password, ref bool IsActive)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "Select * From Users where PersonID = @PersonID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    isFound = true;
                    UserID = (int)reader["UserID"];
                    UserName = (string)reader["UserName"];
                    Password = (string)reader["Password"];
                    IsActive = (bool)reader["IsActive"];


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

        public static int AddNewUser(int PersonID, string UserName, string Password, bool IsActive)

        {
            int UserID = -1;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"insert into Users (PersonID,UserName,Password,IsActive)  
                                                 VALUES (@PersonID,@UserName,@Password,@IsActive); 
                                                 SELECT SCOPE_IDENTITY();";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@UserName", UserName);
            command.Parameters.AddWithValue("@Password", Password);
            command.Parameters.AddWithValue("@IsActive", IsActive);
           

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(),out int InsertedID))
                {
                    return UserID = InsertedID;
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
            return UserID;

        }

        public static bool UpdateUser(int ID, int PersonID, string UserName, string Password, bool IsActive)
        {
            int RowsEffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"Update Users set 
                                               UserName = @UserName,
                                               Password = @Password,
                                               IsActive = @IsActive
                                               where  UserID = @UserID";
                                               

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@UserID", ID);
            command.Parameters.AddWithValue("@UserName", UserName);
            command.Parameters.AddWithValue("@Password", Password);
            command.Parameters.AddWithValue("@IsActive", IsActive);
           

            try
            {
                connection.Open();
                RowsEffected = command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                clsEventLog.Log(ex);
                return false;
            }
            finally
            {
                connection.Close();
            }
            return (RowsEffected > 0);
        }

        public static bool DeleteUser(int ID)
        {
            int RowEffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "delete Users where UserID = @UserID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@UserID", ID);
            try
            {
                connection.Open();
                RowEffected = command.ExecuteNonQuery();


            }
            catch (Exception ex)
            {
                clsEventLog.Log(ex);
                return false;
            }
            finally
            {
                connection.Close();
            }
            return (RowEffected > 0);

        }

        public static DataTable ListUsers()
        {
            DataTable DT = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"SELECT Users.UserID,Users.PersonID,(People.FirstName + ' ' + People.SecondName + ' ' 
                            + People.ThirdName + ' ' + People.LastName) AS FullName,Users.UserName,Users.IsActive
                           FROM Users INNER JOIN People ON Users.PersonID = People.PersonID";
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

        public static bool IsUsersExist(int ID)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "select x=1 from Users where UserID = @UserID";
            SqlCommand command = new SqlCommand(query,connection);
            command.Parameters.AddWithValue("@UserID", ID);

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

        public static bool IsUserNameExist(string UserName)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "select x=1 from Users where UserName = @UserName";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@UserName", UserName);

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
