using Bank_Business_Layer;
using Shared;
using System;
using System.Collections.Generic;
using System.Data;
using System.Runtime.Remoting.Lifetime;

namespace Bank_Console
{
    internal class clsMainMenueScreen : clsScreen
    {
        private enum enMainMenueOptions
        {
            ManageClients = 1, ManageUsers = 2, ManageTransactions = 3, CurrencyExchange = 4, Logout = 5
        }
        private static void _GoBackToMainMenue()
        {
            Console.Write("\nPress any key to go back to main menue...");
            Console.ReadKey();
            ShowMainMenueScreen();
        }
        private static void _ManageClients()
        {
            clsManageClientsScreen.ShowManageClientsScreen();
        }
        private static void _ManageUsers()
        {
            clsManageUsersscreen.ShowManageUsersMenueScreen();
        }
        private static void _ManageTransactions()
        {
            clsTransactionsScreen.ShowTransactionsMenueScreen();
        }
        private static void _CurrencyExchange()
        {
            clsCurrencyExchangeScreen.ShowCurrencyExchangeMenueScreen();
        }
        private static void _Logout()
        {
            Console.Clear();
            clsUsers.CurrentUser = new User("", "", "", "", "", "", 0);
        }
        private static void PerformMainMenueOptions(enMainMenueOptions Option)
        {
            switch(Option)
            {
                case enMainMenueOptions.ManageClients:
                    _ManageClients();
                    _GoBackToMainMenue();
                    break;

                case enMainMenueOptions.ManageUsers:
                    _ManageUsers();
                    _GoBackToMainMenue();
                    break;

                case enMainMenueOptions.ManageTransactions:
                    _ManageTransactions();
                    _GoBackToMainMenue();
                    break;

                case enMainMenueOptions.CurrencyExchange:
                    _CurrencyExchange();
                    _GoBackToMainMenue();
                    break;

                case enMainMenueOptions.Logout:
                    _Logout();
                    break;
            }
        }
        public static void ShowMainMenueScreen()
        {
            _DrawScreenHeader("Show Main Menue Screen");
            Console.WriteLine("============================================");
            Console.WriteLine("[1] Manage Clients.");
            Console.WriteLine("[2] Manage Users.");
            Console.WriteLine("[3] Manage Transactions.");
            Console.WriteLine("[4] Currency Exchange.");
            Console.WriteLine("[5] Logout.");
            Console.WriteLine("============================================");
            PerformMainMenueOptions((enMainMenueOptions)clsUtil.ReadMenueOptions("Please Enter Number Between [1 to 5] : ", 1, 5));

        }

    }
}
