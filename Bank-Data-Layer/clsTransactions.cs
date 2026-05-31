using System;
using System.Data;
using System.Data.SqlClient;


namespace Bank_Data_Layer
{
    public class clsTransactions
    {
        public static bool Deposite(string AccNumber,decimal Amount)
        {
            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Update Clients Set AccBalance += @Amount Where AccNumber = @AccNumber";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@AccNumber", AccNumber);
            command.Parameters.AddWithValue("@Amount", Amount);

            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();

            }
            catch (Exception ex) { }
            finally { connection.Close(); }

            return (rowsAffected > 0);
        }

        public static DataTable GetTotalBalances()
        {
            DataTable dataTable = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Select AccNumber, (FirstName + ' ' + LastName) 'Client Name', AccBalance From Clients Inner Join Persons on Persons.ID = Clients.PersonID";

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

        public static decimal TotalBalances()
        {
            decimal TotalBalances = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Select Sum(AccBalance) From Clients";

            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                TotalBalances = (decimal)command.ExecuteScalar();
            }
            catch (Exception ex) { }
            finally { connection.Close(); }

            return TotalBalances;
        }

        public static void TransferLog(decimal TransferAmount, string FromAccNumber, string ToAccNumber)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Insert Into ClientTransfer (Amount, FromAccNumber, ToAccNumber)
                                            Values (@Amount, @FromAccNumber, @ToAccNumber)";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@FromAccNumber", FromAccNumber);
            command.Parameters.AddWithValue("@ToAccNumber", ToAccNumber);
            command.Parameters.AddWithValue("@Amount", TransferAmount);

            try
            {
                connection.Open();
                command.ExecuteNonQuery();

            }
            catch (Exception ex) { }
            finally { connection.Close(); }

        }

        public static DataTable GetTransferLog()
        {
            DataTable dataTable = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Select *From ClientTransfer";

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


    }
}
