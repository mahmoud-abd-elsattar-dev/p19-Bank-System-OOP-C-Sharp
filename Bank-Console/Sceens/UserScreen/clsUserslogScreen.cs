using Bank_Business_Layer;
using System;
using System.Data;


namespace Bank_Console
{
    internal class clsUserslogScreen : clsScreen
    {
        private static void _ListUsersLog()
        {
            DataTable dataTable = clsUsers.GetAllUsersLog();


            _DrawScreenHeader("Show Users Log Screen (" + dataTable.Rows.Count + ") Log(s) ");

            Console.WriteLine("=======================================================================================================================");

            Console.WriteLine($"|{"UserName",-10} |{"Date",-21}|{"Name",-20} |{"Email",-20} |{"Phone",-15} |{"Password",-10} |{"Permisions",-10}|");

            Console.WriteLine("=======================================================================================================================");

            foreach (DataRow row in dataTable.Rows)
            {
                Console.WriteLine($"|{row["UserName"],-10} |{row["Date"],-21}|{row["Name"],-20} |{row["Email"],-20} |{row["Phone"],-15} |{row["Password"],-10} |{row["Permissions"],-10}|");
            }
            Console.WriteLine("=======================================================================================================================");

        }


        public static void ShowUsersLogScreen()
        {
            _ListUsersLog();
        }

    }
}
