using Bank_Business_Layer;
using Shared;
using System;


namespace Bank_Console
{
    internal class clsAddNewUserScreen : clsScreen
    {
        private static int _ReadUserPermissions()
        {
            int Permissions = 0;
            char Answer = 'N';

            Console.Write("\nDo you want to give full access ? [Y]/[N] ? : ");
            Answer = char.Parse(Console.ReadLine());

            if (Answer == 'Y' || Answer == 'y')
            {
                return -1;
            }

            Console.Write("\nDo you want to give access to : \n");

            Console.Write("\nManage Clients ? [Y]/[N] ? : ");
            Answer = char.Parse(Console.ReadLine());

            if (Answer == 'Y' || Answer == 'y')
            {
                Permissions += (int)clsUsers.enPermissions.pManageClients;
            }

            Console.Write("\nManage Users ? [Y]/[N] ? : ");
            Answer = char.Parse(Console.ReadLine());

            if (Answer == 'Y' || Answer == 'y')
            {
                Permissions += (int)clsUsers.enPermissions.pManageUsers;
            }

            Console.Write("\nManage Transactions ? [Y]/[N] ? : ");
            Answer = char.Parse(Console.ReadLine());

            if (Answer == 'Y' || Answer == 'y')
            {
                Permissions += (int)clsUsers.enPermissions.pManageTransactions;
            }

            Console.Write("\nCurrency Exchange ? [Y]/[N] ? : ");
            Answer = char.Parse(Console.ReadLine());

            if (Answer == 'Y' || Answer == 'y')
            {
                Permissions += (int)clsUsers.enPermissions.pCurrencyExchange;
            }

            return Permissions;
        }
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

        private static User _ReadUserInfo()
        {
            User user = new User("", "", "", "", "", "", 0);


            do
            {
                Console.Write("\nPlease Enter UserName ? : ");
                user.UserName = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(user.UserName));

            while (clsUsers.IsExists(user.UserName))
            {
                Console.WriteLine("\nUserName [" + user.UserName + "] Is Areadly Exists, Chocie another one.");
                Console.Write("\nPlease Enter UserName ? : ");
                user.UserName = Console.ReadLine();
            }

            do
            {
                Console.Write("Please Enter FirstName ? : ");
                user.FirstName = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(user.FirstName));

            do
            {
                Console.Write("Please Enter LastName ? : ");
                user.LastName = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(user.LastName));

            do
            {
                Console.Write("Please Enter Email ? : ");
                user.Email = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(user.Email));

            do
            {
                Console.Write("Please Enter Phone ? : ");
                user.Phone = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(user.Phone));

            do
            {
                Console.Write("Please Enter Password ? : ");
                user.Password = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(user.Password));

            user.Permissions = _ReadUserPermissions();

            return user;
        }

        private static void _AddNewUser()
        {
            User user = _ReadUserInfo();

            if(clsUsers.AddNewUser(user))
            {
                Console.WriteLine("\nUser Added Successfully.");
                _PrintUserInfo(user);
            }
            else
            {
                Console.WriteLine("\nError: User Added Faild.");
            }
        }

        public static void ShowAddNewUserScreen()
        {
            _DrawScreenHeader("Add New User Screen");
            _AddNewUser();
        }

    }
}
