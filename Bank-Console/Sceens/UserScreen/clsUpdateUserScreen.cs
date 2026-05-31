using Bank_Business_Layer;
using Shared;
using System;


namespace Bank_Console
{
    internal class clsUpdateUserScreen : clsScreen
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

        private static User _ReadUserInfo(User user)
        {
            _PrintUserInfo(user);

            do
            {
                Console.Write("\nPlease Enter FirstName ? : ");
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

        private static void _UpdateUser()
        {
            string UserName = _ReadUserName();
            User User1 = clsUsers.Find(UserName);

            if (User1 != null)
            {
                if (clsUsers.UpdateUser(_ReadUserInfo(User1)))
                    Console.WriteLine("\nUser Updated Successfully.");
                else
                    Console.WriteLine("\nError: User Updated Faild.");
            }
            else
            {
                Console.WriteLine("\nUserName [" + UserName + "] Is Not Exists.");
            }
        }

        public static void ShowUpdateUserScreen()
        {
            _DrawScreenHeader("Update User Screen");
            _UpdateUser();
        }

    }
}
