using Bank_Business_Layer;
using System;
using System.Data;


namespace Bank_Console
{
    internal class clsTotalBalancesScreen : clsScreen
    {

        private static void _ShowTotalBalances()
        {
            decimal TotalBalance = 0;
            DataTable dataTable = clsTransactions.GetTotalBalances();

            _DrawScreenHeader("Balances List (" + dataTable.Rows.Count + ") Client(s)");

            Console.WriteLine("======================================================================================");

            Console.WriteLine($"| {"Account Number",-20} | {"Client Name",-40} | {"Balance $",-20}");

            Console.WriteLine("======================================================================================");

            foreach (DataRow row in dataTable.Rows)
            {
                Console.WriteLine($"| {row["AccNumber"],-20} | {row["Client Name"],-40} | {row["AccBalance"],-20}");
                TotalBalance += (decimal)row["AccBalance"];
            }
            Console.WriteLine("======================================================================================");
            Console.WriteLine($"\t\t\tTotal Balances = " + TotalBalance);

        }

        public static void ShowTotalBalancesScreen()
        {
            _ShowTotalBalances();
        }

    }
}
