using Bank_Business_Layer;
using System;
using System.Data;


namespace Bank_Console
{
    public class clsListCurrenciesScreen : clsScreen
    {
        private static void _CurrenciesList()
        {
            DataTable dataTable = clsCurrencies.GetListCurrencies();

            _DrawScreenHeader("Currencies List (" + dataTable.Rows.Count + ") Currency(ies)");

            Console.WriteLine("============================================================================================");

            Console.WriteLine($"| {"Country",-30} | {"Code",-10} | {"Name",-30} | {"Rate (1$)",-10}|");

            Console.WriteLine("============================================================================================");

            foreach (DataRow row in dataTable.Rows)
            {
                Console.WriteLine($"| {row["CountryName"],-30} | {row["Code"],-10} | {row["Name"],-30} | {row["ExchangeRateUSD"],-10}|");
            }
            Console.WriteLine("============================================================================================");

        }


        public static void ShowListCurrenciesScreen()
        {
            _CurrenciesList();
        }

    }
}
