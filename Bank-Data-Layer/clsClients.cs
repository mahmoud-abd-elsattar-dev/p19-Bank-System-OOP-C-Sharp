using System;
using Shared;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;


namespace Bank_Data_Layer
{
    public class clsClients
    {
        private static int _GetPersonID(string AccNumber)
        {
            int PersonID = -1;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Select Persons.ID From Persons join Clients on Clients.PersonID = Persons.ID Where Clients.AccNumber = @AccNumber";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@AccNumber", AccNumber);

            try
            {
                connection.Open();
                PersonID = (int)command.ExecuteScalar();

            }
            catch (Exception ex) { }
            finally { connection.Close(); }

            return PersonID;
        }
        public static List<string> GetAllAccountNumbers()
        {
            List<string> AcountNumbers = new List<string>();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Select AccNumber From Clients";

            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    AcountNumbers.Add((string)reader["AccNumber"]);
                }

                reader.Close();
            }
            catch (Exception ex) { }    
            finally { connection.Close(); }

            return AcountNumbers;
        }
        public static Client GetClintInfo(string AccNumber)
        {
            Client client1 = new Client("", "", "", "", "", "", 0);

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Select Clients.ID, AccNumber, Persons.FirstName, Persons.LastName, Persons.Email, Persons.Phone,
                                       PinCode, AccBalance From Clients inner join Persons On Clients.PersonID = Persons.ID
                                       Where AccNumber = @AccNumber";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@AccNumber", AccNumber);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if(reader.Read())
                {
                    client1.ID = (int)reader["ID"];
                    client1.FirstName = (string)reader["FirstName"];
                    client1.LastName = (string)reader["LastName"];
                    client1.Email = (string)reader["Email"];
                    client1.Phone = (string)reader["Phone"];
                    client1.AccNumber = (string)reader["AccNumber"];
                    client1.PinCode = (string)reader["PinCode"];
                    client1.AccBalance = (decimal)reader["AccBalance"];
                }
                else
                {
                    client1 = null;
                }
               
                reader.Close();
            }
            catch (Exception ex) { } 
            finally { connection.Close(); }

            return client1;
        }

        public static bool AddNewClient(Client client)
        {
            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            try
            {
                string query = @"Insert Into Persons (FirstName, LastName, Email, Phone)
                                      Values (@FirstName, @LastName, @Email, @Phone);
                                                            Select SCOPE_IDENTITY();";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@FirstName", client.FirstName);
                command.Parameters.AddWithValue("@LastName", client.LastName);
                command.Parameters.AddWithValue("@Email", client.Email);
                command.Parameters.AddWithValue("@Phone", client.Phone);

                connection.Open();
                object result = command.ExecuteScalar();

                int.TryParse(result.ToString(), out int InsertedPersonID);

                query = @"Insert Into Clients (AccNumber, PinCode, AccBalance, PersonID)
                                  Values (@AccNumber, @PinCode, @AccBalance, @PersonID)";


                command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@AccNumber", client.AccNumber);
                command.Parameters.AddWithValue("@PinCode", client.PinCode);
                command.Parameters.AddWithValue("@AccBalance", client.AccBalance);
                command.Parameters.AddWithValue("@PersonID", InsertedPersonID);
                rowsAffected = command.ExecuteNonQuery();
            }
            catch (Exception ex) { }
            finally { connection.Close(); }

            return (rowsAffected > 0);
        }

        public static bool UpdateClient(Client client)
        {
            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Update Persons Set FirstName = @FirstName, LastName = @LastName, Email = @Email, Phone = @Phone Where ID = @ID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ID", _GetPersonID(client.AccNumber));
            command.Parameters.AddWithValue("@FirstName", client.FirstName);
            command.Parameters.AddWithValue("@LastName", client.LastName);
            command.Parameters.AddWithValue("@Email", client.Email);
            command.Parameters.AddWithValue("@Phone", client.Phone);

            try
            {
                connection.Open();
                rowsAffected += command.ExecuteNonQuery();

                query = @"Update Clients Set PinCode = @PinCode, AccBalance = @AccBalance Where AccNumber = @AccNumber";

                command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@AccNumber", client.AccNumber);
                command.Parameters.AddWithValue("@PinCode", client.PinCode);
                command.Parameters.AddWithValue("@AccBalance", client.AccBalance);
                rowsAffected += command.ExecuteNonQuery();
            }
            catch (Exception ex) { } 
            finally { connection.Close(); }

            return (rowsAffected >= 2);
        }

        public static bool DeleteClient(string AccNumber)
        {
            int rowsAffected = 0;
            int PersonID = _GetPersonID(AccNumber);
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Delete From Clients Where AccNumber = @AccNumber";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@AccNumber", AccNumber); ;

           

            try
            {
                connection.Open();
                rowsAffected += command.ExecuteNonQuery();

                query = @"Delete From Persons Where ID = @ID";

                command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ID", PersonID);
                rowsAffected += command.ExecuteNonQuery();
            }
            catch (Exception ex) { }
            finally { connection.Close(); }

            return (rowsAffected >= 2);
        }

        public static DataTable GetClientsList()
        {
            DataTable dataTable = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Select AccNumber 'Acc Num', FirstName 'First Name',LastName 'Last Name',
                                        Email ,Phone,PinCode 'Pin',AccBalance 'Balance $' From Clients
                                               inner join Persons on Persons.ID=Clients.PersonID";

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

        public static bool IsExists(string AccNumber)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Select Found = 1 From Clients Where AccNumber = @AccNumber";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("AccNumber", AccNumber);

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



    }
}
