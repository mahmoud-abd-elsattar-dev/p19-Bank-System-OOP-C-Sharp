using Bank_Business_Layer;
using Shared;
using System;


namespace Bank_Console
{
    internal class clsFindUserScreen : clsScreen
    {
        private static void _PrintUserInfo(User user)
        {
            Console.WriteLine("\nUser Info : ");
            Console.WriteLine("========================================");
            Console.WriteLine("FirstName   : " + user.FirstName);
            Console.WriteLine("LastName    : " + user.LastName);
            Console.WriteLine("Email       : " + user.Email);
            Console.WriteLine("Phone       : " + user.Phone);
            Console.WriteLine("UserName    : " + user.UserName);
            Console.WriteLine("Password    : " + user.Password);
            Console.WriteLine("Permissions : " + user.Permissions);
            Console.WriteLine("========================================");

        }

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

        private static void _FindUser()
        {
            string UserName = _ReadUserName();
            User user = clsUsers.Find(UserName);

            if (user != null)
            {
                _PrintUserInfo(user);
            }
            else
            {
                Console.WriteLine("\nUserName [" + UserName + "] Is Not Found.");
            }
        }
        public static void ShowFindUserScreen()
        {
            _DrawScreenHeader("Find User Screen");
            _FindUser();
        }
    }
}
