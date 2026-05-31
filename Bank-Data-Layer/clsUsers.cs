using Shared;
using System;
using System.Data;
using System.Data.SqlClient;


namespace Bank_Data_Layer
{
    public class clsUsers
    {
        private static int _GetPersonID(string UserName)
        {
            int PersonID = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Select Persons.ID From Persons Inner Join Users On persons.ID = Users.PersonID Where UserName = @UserName";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@UserName", UserName);

            try
            {
                connection.Open();
                PersonID = (int)command.ExecuteScalar();
                
            }
            catch (Exception ex) { }
            finally { connection.Close(); }

            return PersonID;
        }
        private static int _GetUserID(string UserName)
        {
            int UserID = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Select ID From Users Where UserName = @UserName";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@UserName", UserName);

            try
            {
                connection.Open();
                UserID = (int)command.ExecuteScalar();

            }
            catch (Exception ex) { }
            finally { connection.Close(); }

            return UserID;
        }

        public static User GetUserInfo(string UserName, string Password = "")
        {
            User user = new User("", "", "", "", "", "", 0);
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            SqlCommand command;
            string query;

            if (!string.IsNullOrWhiteSpace(Password))
            {
                query = @"Select FirstName, LastName, Email, Phone, UserName, Password, Permissions From Users
                Join Persons On Users.PersonID = Persons.ID Where UserName = @UserName and Password = @Password";
                command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Username", UserName);
                command.Parameters.AddWithValue("@Password", Password);
            }
            else
            {
                query = @"Select FirstName, LastName, Email, Phone, UserName, Password, Permissions From Users
                Join Persons On Users.PersonID = Persons.ID Where UserName = @UserName";
                command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Username", UserName);
            }

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    user.FirstName = (string)reader["FirstName"];
                    user.LastName = (string)reader["LastName"];
                    user.Email = (string)reader["Email"];
                    user.Phone = (string)reader["Phone"];
                    user.UserName = (string)reader["UserName"];
                    user.Password = (string)reader["Password"];
                    user.Permissions = (int)reader["Permissions"];
                }
                else
                {
                    user = null;
                }

                reader.Close();
            }
            catch (Exception ex) { }
            finally { connection.Close(); }

            return user;
        }

        public static bool AddNewUser(User user)
        {
            int PersonID = 0;
            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Insert Into Persons(FirstName, LastName, Email, Phone)
                                    Values (@FirstName, @LastName, @Email, @Phone);
                                                        Select SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@FirstName", user.FirstName);
            command.Parameters.AddWithValue("@LastName", user.LastName);
            command.Parameters.AddWithValue("@Email", user.Email);
            command.Parameters.AddWithValue("@Phone", user.Phone);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                int.TryParse(result.ToString(), out int InsertedPersonID);

                query = @"Insert Into Users (UserName, Password, Permissions, PersonID)
                               Values (@UserName, @Password, @Permissions, @PersonID);";

                command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@UserName", user.UserName);
                command.Parameters.AddWithValue("@Password", user.Password);
                command.Parameters.AddWithValue("@Permissions", user.Permissions);
                command.Parameters.AddWithValue("@PersonID", InsertedPersonID);
                rowsAffected = command.ExecuteNonQuery();
            }
            catch (Exception ex) { }
            finally { connection.Close(); }
                 
            return (rowsAffected  > 0);
        }

        public static bool UpdateUser(User user)
        {
            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Update Persons Set FirstName = @FirstName, LastName = @LastName, Email = @Email, Phone = @Phone Where ID = @ID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@FirstName", user.FirstName);
            command.Parameters.AddWithValue("@LastName", user.LastName);
            command.Parameters.AddWithValue("@Email", user.Email);
            command.Parameters.AddWithValue("@Phone", user.Phone);
            command.Parameters.AddWithValue("@ID", _GetPersonID(user.UserName));


            try
            {
                connection.Open();
                rowsAffected += command.ExecuteNonQuery();

                query = @"Update Users Set Password = @Password, Permissions = @Permissions Where UserName = @UserName";

                command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@UserName", user.UserName);
                command.Parameters.AddWithValue("@Password", user.Password);
                command.Parameters.AddWithValue("@Permissions", user.Permissions);
                rowsAffected += command.ExecuteNonQuery();
            }
            catch (Exception ex) { }
            finally { connection.Close(); }

            return (rowsAffected >= 2);
        }
        public static bool DeleteUser(string UserName)
        {
            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Delete Users Where UserName = @UserName;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@UserName", UserName);

            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();

            }
            catch (Exception ex) { }
            finally { connection.Close(); }

            return (rowsAffected > 0);
        }

        public static bool IsExists(string UserName)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Select Found = 1 From Users Where UserName = @UserName;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@UserName", UserName);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                IsFound = (reader.HasRows);
                reader.Close();
            }
            catch (Exception ex) { } 
            finally { connection.Close(); }

            return IsFound;
        }

        public static void UsersLog(string UserName)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Insert Into UserLog (UserID) Values (@UserID);";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@UserID", _GetUserID(UserName));

            try
            {
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex) { }
            finally { connection.Close(); }
        }

        public static DataTable GetAllUsersLog()
        {
            DataTable dataTable = new DataTable();
            SqlConnection connection = new SqlConnection( clsDataAccessSettings.ConnectionString);

            string query = @"Select UserName, Date, (FirstName+' '+LastName) 'Name', Email, Phone, Password, Permissions From Users
                                                                            Join Persons On Persons.ID = Users.PersonID
                                                                            join UserLog On UserLog.UserID = Users.ID";

            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if(reader.HasRows)
                {
                    dataTable.Load(reader);
                }

                reader.Close();
            }
            catch (Exception ex) { }
            finally { connection.Close(); }

            return dataTable;                                                                
        }
        public static DataTable GetUsersList()
        {
            DataTable dataTable = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Select UserName 'UserName', FirstName 'First Name',LastName 'Last Name',
                                        Email ,Phone,Password 'Password',Permissions 'Permissions' From Users
                                               inner join Persons on Persons.ID=Users.PersonID";

            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    dataTable.Load(reader);
                }

                reader.Close();
            }
            catch (Exception ex) { }
            finally { connection.Close(); }

            return dataTable;
        }

    }
}
