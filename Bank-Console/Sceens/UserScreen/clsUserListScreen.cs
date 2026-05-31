using Bank_Business_Layer;
using System;
using System.Data;


namespace Bank_Console
{
    internal class clsUserListScreen : clsScreen
    {
        private static void _ShowUsersList()
        {
            DataTable dataTable = clsUsers.GetUsersList();


            _DrawScreenHeader("Show Users Screen (" + dataTable.Rows.Count + ") User(s) ");

            Console.WriteLine("==================================================================================================================");

            Console.WriteLine($"|{"First Name",-15} |{"Last Name",-15} |{"Email",-25} |{"Phone",-15} |{"UserName",-10} |{"Password",-10} |{"Permisions",-10}|");

            Console.WriteLine("==================================================================================================================");

            foreach (DataRow row in dataTable.Rows)
            {
                Console.WriteLine($"|{row["First Name"],-15} |{row["Last Name"],-15} |{row["Email"],-25} |{row["Phone"],-15} |{row["UserName"],-10} |{row["Password"],-10} |{row["Permissions"],-10}|");
            }
            Console.WriteLine("==================================================================================================================");

        }

        public static void ShowUsersListScreen()
        {
            _ShowUsersList();
        }



    }
}
