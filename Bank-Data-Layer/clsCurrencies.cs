using Shared;
using System;
using System.Data;
using System.Data.SqlClient;


namespace Bank_Data_Layer
{
    public class clsCurrencies
    {
        public static DataTable GetListCurrencies()
        {
            DataTable dataTable = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Select CountryName, Code, Currencies.Name, ExchangeRateUSD From Currencies Join Countries On Currencies.ID = Countries.CurrencyID";

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

        public static Currency FindByCode(string Code)
        {
            Currency currency = new Currency();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Select CountryName, Code, Currencies.Name, ExchangeRateUSD From Currencies Join Countries On Currencies.ID = Countries.CurrencyID Where Code = @Code";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@Code", Code);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    currency.CountryName = (string)reader["CountryName"];
                    currency.Code = (string)reader["Code"];
                    currency.Name = (string)reader["Name"];
                    currency.ExchangeRateUSD = (decimal)reader["ExchangeRateUSD"];
                }
                else
                {
                    currency = null;
                }

                reader.Close();
            }
            catch (Exception ex) { }
            finally { connection.Close(); }

            return currency;
        }

        public static Currency FindByCountry(string Country)
        {
            Currency currency = new Currency();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Select CountryName, Code, Currencies.Name, ExchangeRateUSD From Currencies Join Countries On Currencies.ID = Countries.CurrencyID Where CountryName = @CountryName";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@CountryName", Country);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    currency.CountryName = (string)reader["CountryName"];
                    currency.Code = (string)reader["Code"];
                    currency.Name = (string)reader["Name"];
                    currency.ExchangeRateUSD = (decimal)reader["ExchangeRateUSD"];
                }
                else
                {
                    currency = null;
                }

                reader.Close();
            }
            catch (Exception ex) { }
            finally { connection.Close(); }

            return currency;
        }

        public static bool IsExists(string Code)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Select Found = 1 From Currencies Where Code = @Code";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@Code", Code);

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

        public  static bool UpdateRate(string Code, decimal NewRate)
        {
            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Update Currencies Set ExchangeRateUSD = @ExchangeRateUSD Where Code = @Code";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@Code", Code);
            command.Parameters.AddWithValue("@ExchangeRateUSD", NewRate);

            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();
            }
            catch (Exception ex) { }
            finally { connection.Close(); }

            return (rowsAffected > 0);
        }

    }
}
