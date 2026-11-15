using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Xml;

namespace DVLD_Data_Access_Layer
{
    public class clsPersonData
    {
        public static bool GetPersonInfoByID(int ID, ref string NationalNum, ref string FirsName,
            ref string SecoundName, ref string ThirdName, ref string LastName, ref DateTime DateOfBirth,
            ref byte Gendor, ref string Address, ref string Phone, ref string Email,
            ref int NationalCountryID, ref string ImagePath)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "Select * From People where PersonID = @PersonID";
            
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID",ID);
            try 
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    isFound = true;
                    NationalNum = (string)reader["NationalNo"];
                    FirsName = (string)reader["FirstName"];
                    SecoundName = (string)reader["SecondName"];
                   
                    if (reader["ThirdName"] != DBNull.Value)
                    {
                        ThirdName = (string)reader["ThirdName"];
                    }
                    else
                    {
                        ThirdName = "";
                    }
                    LastName = (string)reader["LastName"];
                    DateOfBirth = (DateTime)reader["DateOfBirth"];
                    Gendor = (byte)reader["Gendor"];
                    Address = (string)reader["Address"];
                    Phone = (string)reader["Phone"];
                    
                    if (reader["Email"] != DBNull.Value)
                    {
                        Email = (string)reader["Email"];
                    }
                    else
                    {
                        Email = "";
                    }
                    NationalCountryID = (int)reader["NationalityCountryID"];

                    if (reader["ImagePath"] != DBNull.Value)
                    {
                        ImagePath = (string)reader["ImagePath"];
                    }
                    else
                    {
                        ImagePath = "";
                    }

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


        public static bool GetPersonInfoByNationalNo(string NationalNum, ref int ID, ref string FirsName,
            ref string SecoundName, ref string ThirdName, ref string LastName, ref DateTime DateOfBirth,
            ref byte Gendor, ref string Address, ref string Phone, ref string Email,
            ref int NationalCountryID, ref string ImagePath)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "select * from People where NationalNo = @NationalNo";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@NationalNo", NationalNum);

            try 
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;
                    ID = (int)reader["PersonID"];
                    FirsName = (string)reader["FirstName"];
                    SecoundName = (string)reader["SecondName"];
                    ThirdName = (string)reader["ThirdName"];
                    LastName = (string)reader["LastName"];
                    DateOfBirth = (DateTime)reader["DateOfBirth"];
                    Gendor = (byte)reader["Gendor"];
                    Address = (string)reader["Address"];
                    Phone = (string)reader["Phone"];
                    Email = (string)reader["Email"];
                    NationalCountryID = (int)reader["NationalityCountryID"];

                    if (reader["ImagePath"] != DBNull.Value)
                    {
                        ImagePath = (string)reader["ImagePath"];
                    }
                    else
                    {
                        ImagePath = "";
                    }

                }
                else
                {
                    isFound = false;
                }

                connection.Close();
            }
            catch (Exception ex) { clsEventLog.Log(ex); isFound = false; }
            finally { connection.Close(); }
            return isFound;
        }

        public static int AddNewPerson(string NationalNo, string FirstName,
             string SecondName,  string ThirdName,  string LastName,  DateTime DateOfBirth,
             byte Gendor,  string Address,  string Phone,  string Email,
             int NationalityCountryID,string ImagePath)
        {
            int PersonID = -1;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"insert into People (NationalNo,FirstName,SecondName,ThirdName,LastName,DateOfBirth,Gendor,Address,
                                                 Phone,Email,NationalityCountryID,ImagePath)  
                                                 VALUES (@NationalNo,@FirstName,@SecondName,@ThirdName,@LastName,@DateOfBirth,@Gendor,@Address,
                                                 @Phone,@Email,@NationalityCountryID,@ImagePath); 
                                                 SELECT SCOPE_IDENTITY();";
            SqlCommand command =  new SqlCommand(query, connection);
            
            command.Parameters.AddWithValue ("@NationalNo", NationalNo);
            command.Parameters.AddWithValue ("@FirstName", FirstName);
            command.Parameters.AddWithValue ("@SecondName", SecondName);
            command.Parameters.AddWithValue ("@ThirdName", ThirdName);
            command.Parameters.AddWithValue ("@LastName", LastName);
            command.Parameters.AddWithValue ("@DateOfBirth", DateOfBirth);
            command.Parameters.AddWithValue ("@Gendor", Gendor);
            command.Parameters.AddWithValue ("@Address", Address);
            command.Parameters.AddWithValue ("@Phone", Phone);
            command.Parameters.AddWithValue ("@Email", Email);
            command.Parameters.AddWithValue ("@NationalityCountryID", NationalityCountryID);
            if (ImagePath != "")
            {
                command.Parameters.AddWithValue("@ImagePath", ImagePath);
            }
            else
            {
                command.Parameters.AddWithValue("@ImagePath", System.DBNull.Value);
            }

            try 
            {
                connection.Open();

                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int  InsertedID))
                {
                    return PersonID = InsertedID;
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
            return PersonID;

        }

        public static bool UpdatedPerson(int ID,string NationalNo, string FirstName,
             string SecondName, string ThirdName, string LastName, DateTime DateOfBirth,
             byte Gendor, string Address, string Phone, string Email,
             int NationalityCountryID, string ImagePath)
        {
            int RowsEffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"Update People set 
                                               NationalNo = @NationalNo,
                                               FirstName = @FirstName,
                                               SecondName = @SecondName,
                                               ThirdName = @ThirdName,
                                               LastName = @LastName ,
                                               DateOfBirth = @DateOfBirth,
                                               Gendor = @Gendor,
                                               Address = @Address,
                                               Phone = @Phone,
                                               Email = @Email,
                                               NationalityCountryID = @NationalityCountryID,
                                               ImagePath = @ImagePath
                                               where PersonID = @PersonID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonID", ID);
            command.Parameters.AddWithValue("@NationalNo", NationalNo);
            command.Parameters.AddWithValue("@FirstName", FirstName);
            command.Parameters.AddWithValue("@SecondName", SecondName);
            command.Parameters.AddWithValue("@ThirdName", ThirdName);
            command.Parameters.AddWithValue("@LastName", LastName);
            command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            command.Parameters.AddWithValue("@Gendor", Gendor);
            command.Parameters.AddWithValue("@Address", Address);
            command.Parameters.AddWithValue("@Phone", Phone);
            command.Parameters.AddWithValue("@Email", Email);
            command.Parameters.AddWithValue("@NationalityCountryID", NationalityCountryID);
            if (ImagePath != "")
            {
                command.Parameters.AddWithValue("@ImagePath", ImagePath);
            }
            else
            {
                command.Parameters.AddWithValue("@ImagePath", System.DBNull.Value);
            }

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

        public static bool DeletePerson(int ID)
        {
            int RowEffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "delete People where PersonID = @PersonID";
            SqlCommand command = new SqlCommand(query,connection);
            command.Parameters.AddWithValue("@PersonID", ID);
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

        public static DataTable ListPersons()
        {
            DataTable DT = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"SELECT People.PersonID, People.NationalNo,
              People.FirstName, People.SecondName, People.ThirdName, People.LastName,
			  People.DateOfBirth, People.Gendor,  
				  CASE
                  WHEN People.Gendor = 0 THEN 'Male'

                  ELSE 'Female'

                  END as GendorCaption ,
			  People.Address, People.Phone, People.Email, 
              People.NationalityCountryID, Countries.CountryName, People.ImagePath
              FROM            People INNER JOIN
                         Countries ON People.NationalityCountryID = Countries.CountryID
                ORDER BY People.FirstName";
            SqlCommand command =new  SqlCommand(query, connection);
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

        public static bool IsPersonExist(int ID)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "select x=1 from People where PersonID = @PersonID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", ID);

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

        public static bool IsPersonExist(string NationalNo)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "select x=1 from People where NationalNo = @NationalNo";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@NationalNo", NationalNo);

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
