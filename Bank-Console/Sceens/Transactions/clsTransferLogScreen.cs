using Bank_Business_Layer;
using System;
using System.Data;


namespace Bank_Console
{
    internal class clsTransferLogScreen : clsScreen
    {

        private static void _TransferLog()
        {
            DataTable dataTable = clsTransactions.GetTransferLog();

            _DrawScreenHeader("TransferLog List (" + dataTable.Rows.Count + ") Log(s)");

            Console.WriteLine("======================================================================================");

            Console.WriteLine($"| {"FromAccNumber",-15} | {"ToAccNumber",-15} | {"Amount",-15} | {"Date",-40}");

            Console.WriteLine("======================================================================================");

            foreach (DataRow row in dataTable.Rows)
            {
                Console.WriteLine($"| {row["FromAccNumber"],-15} | {row["ToAccNumber"],-15} | {row["Amount"],-15} | {row["Date"],-40}");
            }
            Console.WriteLine("======================================================================================");

        }

        public static void ShowTransferLogScreen()
        {
            _TransferLog();
        }


    }
}
