using Bank_Business_Layer;
using Shared;
using System;
using System.Data;

namespace Bank_Console
{
    public class clsClientListScreen : clsScreen
    {
        private static void _ShowListClients()
        {
            DataTable dataTable = clsClients.GetClientsList();

            
            _DrawScreenHeader("Show Clients Screen (" + dataTable.Rows.Count + ") Client(s) ");
            
            Console.WriteLine("==================================================================================================================");

            Console.WriteLine($"|{"First Name",-15} |{"Last Name",-15} |{"Email",-25} |{"Phone",-15} |{"Acc Num",-10} |{"Pin",-10} |{"Balance $",-10}|");

            Console.WriteLine("==================================================================================================================");

            foreach (DataRow row in dataTable.Rows)
            {
                Console.WriteLine($"|{row["First Name"],-15} |{row["Last Name"],-15} |{row["Email"],-25} |{row["Phone"],-15} |{row["Acc Num"],-10} |{row["Pin"],-10} |{row["Balance $"],-10}|");
            }
            Console.WriteLine("==================================================================================================================");

        }

        public static void ShowListClientsScreen()
        {
            _ShowListClients(); 
        }



    }
}
