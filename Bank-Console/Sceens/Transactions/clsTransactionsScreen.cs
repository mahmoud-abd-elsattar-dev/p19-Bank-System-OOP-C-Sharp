using Bank_Business_Layer;
using Shared;
using System;

namespace Bank_Console
{
    internal class clsTransactionsScreen : clsScreen
    {
        private enum enTransactionsOptions { Deposite = 1, Withdraw = 2, TotalBalances = 3, Transfer = 4, TransferLog = 5, MainMenue = 6}
        private static void _GoBackToTransactionsMenue()
        {
            Console.Write("\nPress any key to go back to transactions menue...");
            Console.ReadKey();
            ShowTransactionsMenueScreen();
        }
        private static void _ShowDepositeScreen()
        {
            clsDepositeScreen.ShowDepositeScreen();
        }
        private static void _ShowWithdrawScreen()
        {
            clsWithdrawScreen.ShowWithdrawScreen();
        }
        private static void _ShowTotalBalancesScreen()
        {
            clsTotalBalancesScreen.ShowTotalBalancesScreen();
        }
        private static void _ShowTransferScreen()
        {
            clsTransferScreen.ShowTransferScreen();
        }

        private static void _ShowTransferLogScreen()
        {
            clsTransferLogScreen.ShowTransferLogScreen();
        }

        private static void PerformTransactionsOptions(enTransactionsOptions Option)
        {
            switch (Option)
            {
                case enTransactionsOptions.Deposite:
                    _ShowDepositeScreen();
                    _GoBackToTransactionsMenue();
                    break;

                case enTransactionsOptions.Withdraw:
                    _ShowWithdrawScreen();
                    _GoBackToTransactionsMenue();
                    break;

                case enTransactionsOptions.TotalBalances:
                    _ShowTotalBalancesScreen();
                    _GoBackToTransactionsMenue();
                    break;

                case enTransactionsOptions.Transfer:
                    _ShowTransferScreen();
                    _GoBackToTransactionsMenue();
                    break;

                case enTransactionsOptions.TransferLog:
                    _ShowTransferLogScreen();
                    _GoBackToTransactionsMenue();
                    break;

                case enTransactionsOptions.MainMenue:
                    break;

            }
        }

        public static void ShowTransactionsMenueScreen()
        {
            if (!CheckAccessRights(clsUsers.enPermissions.pManageTransactions))
            {
                return;
            }

            _DrawScreenHeader("Transactions Menue Screen");
            Console.WriteLine("============================================");
            Console.WriteLine("[1] Deposite.");
            Console.WriteLine("[2] Withdraw.");
            Console.WriteLine("[3] Total Balances.");
            Console.WriteLine("[4] Transfer.");
            Console.WriteLine("[5] Transfer Log.");
            Console.WriteLine("[6] Main Menue.");
            Console.WriteLine("============================================");
            PerformTransactionsOptions((enTransactionsOptions)clsUtil.ReadMenueOptions("Please Enter Number Between [1 to 6] : ", 1, 6));

        }

    }
}
