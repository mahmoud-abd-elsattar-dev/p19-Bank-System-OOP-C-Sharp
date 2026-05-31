using Bank_Business_Layer;
using Shared;
using System;

namespace Bank_Console
{
    public class clsManageUsersscreen : clsScreen
    {
        private enum enManageUsersOption
        {
            ListUsers = 1, AddNewUser = 2, UpdateUser = 3,
            DeleteUser = 4, FindUser = 5, UsersLog = 6, MainMenue = 7
        }
        private static void _GoBackToManageUsersMenue()
        {
            Console.Write("\nPress any key to go back to manage users menue...");
            Console.ReadKey();
            ShowManageUsersMenueScreen();
        }
        private static void _ShowUsersList()
        {
            clsUserListScreen.ShowUsersListScreen();
        }
        private static void _AddNewUser()
        {
            clsAddNewUserScreen.ShowAddNewUserScreen();
        }
        private static void _UpdateUser()
        {
           clsUpdateUserScreen.ShowUpdateUserScreen();
        }
        private static void _DeleteUser()
        {
           clsDeleteUserScreen.ShowDeleteUserScreen();
        }
        private static void _FindUser()
        {
            clsFindUserScreen.ShowFindUserScreen();
        }
        private static void _UsersLog()
        {
            clsUserslogScreen.ShowUsersLogScreen();
        }

        private static void PerformManageUsersMenueOptions(enManageUsersOption Option)
        {
            switch (Option)
            {
                case enManageUsersOption.ListUsers:
                    _ShowUsersList();
                    _GoBackToManageUsersMenue();
                    break;

                case enManageUsersOption.AddNewUser:
                    _AddNewUser();
                    _GoBackToManageUsersMenue();
                    break;

                case enManageUsersOption.UpdateUser:
                    _UpdateUser();
                    _GoBackToManageUsersMenue();
                    break;

                case enManageUsersOption.DeleteUser:
                    _DeleteUser();
                    _GoBackToManageUsersMenue();
                    break;

                case enManageUsersOption.FindUser:
                    _FindUser();
                    _GoBackToManageUsersMenue();
                    break;

                case enManageUsersOption.UsersLog:
                    _UsersLog();
                    _GoBackToManageUsersMenue();
                    break;

                case enManageUsersOption.MainMenue:
                    break;

            }
        }

        public static void ShowManageUsersMenueScreen()
        {
            if (!CheckAccessRights(clsUsers.enPermissions.pManageUsers))
            {
                return;
            }

            _DrawScreenHeader("Show Manage Users Screen");
            Console.WriteLine("============================================");
            Console.WriteLine("[1] Show User List.");
            Console.WriteLine("[2] Add New User.");
            Console.WriteLine("[3] Update User.");
            Console.WriteLine("[4] Delete User.");
            Console.WriteLine("[5] Find User.");
            Console.WriteLine("[6] Users Log.");
            Console.WriteLine("[7] Main Menue.");
            Console.WriteLine("============================================");
            PerformManageUsersMenueOptions((enManageUsersOption)clsUtil.ReadMenueOptions("Please Enter Number Between [1 to 7] : ", 1, 7));

        }

    }
}
