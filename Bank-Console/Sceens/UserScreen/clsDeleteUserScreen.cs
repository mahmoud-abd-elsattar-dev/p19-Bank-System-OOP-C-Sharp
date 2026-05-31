using Bank_Business_Layer;
using Shared;
using System;


namespace Bank_Console
{
    internal class clsDeleteUserScreen : clsScreen
    {
        private static string _ReadUserName()
        {
            string UserName = "";

            do
            {
                Console.Write("\nPlease Enter UserName ? : ");
                UserName = Console.ReadLine();

            } while (string.IsNullOrWhiteSpace(UserName));

            return UserName;
        }

        private static void _DeleteUser()
        {
            string UserName = _ReadUserName();

            if (clsUsers.IsExists(UserName))
            {
                if (clsUsers.DeleteUser(UserName))
                    Console.WriteLine("\nUser Deleted Successfully.");
                else
                    Console.WriteLine("\nUser Deleted Faild.");
            }
            else
            {
                Console.WriteLine($"User With UserName [{UserName}] Is Not Exsits.");
            }
        }

        public static void ShowDeleteUserScreen()
        {
            _DrawScreenHeader("Delete User Screen");
            _DeleteUser();
        }

    }
}
