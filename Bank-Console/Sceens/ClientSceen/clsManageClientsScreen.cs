using Bank_Business_Layer;
using System;


namespace Bank_Console
{
    internal class clsManageClientsScreen : clsScreen
    {
        private enum enManageClientsOptions
        {
            ListClients = 1, AddNewClient = 2, UpdateClient = 3,
            DeleteClient = 4, FindClient = 5, MainMenue = 6,
        }
        private static void _GoBackToManageClientsMenue()
        {
            Console.Write("\nPress any key to go back to manage clients menue...");
            Console.ReadKey();
            ShowManageClientsScreen();
        }
        private static void _ShowClientList()
        {
            clsClientListScreen.ShowListClientsScreen();
        }
        private static void _AddNewClient()
        {
            clsAddNewClientScreen.ShowAddNewClientScreen();
        }
        private static void _UpdateClient()
        {
            clsUpdateClientScreen.ShowUpdateClientScreen();
        }
        private static void _DeleteClient()
        {
            clsDeleteClientScreen.ShowDeleteClientScreen();
        }
        private static void _FindClient()
        {
            clsFindClientScreen.ShowFindClienScreen();
        }
        private static void PerformManageClientsOptions(enManageClientsOptions Option)
        {
            switch (Option)
            {
                case enManageClientsOptions.ListClients:
                    _ShowClientList();
                    _GoBackToManageClientsMenue();
                    break;

                case enManageClientsOptions.AddNewClient:
                    _AddNewClient();
                    _GoBackToManageClientsMenue();
                    break;

                case enManageClientsOptions.UpdateClient:
                    _UpdateClient();
                    _GoBackToManageClientsMenue();
                    break;

                case enManageClientsOptions.DeleteClient:
                    _DeleteClient();
                    _GoBackToManageClientsMenue();
                    break;

                case enManageClientsOptions.FindClient:
                    _FindClient();
                    _GoBackToManageClientsMenue();
                    break;

                case enManageClientsOptions.MainMenue:
                    break;

            }
        }
        public static void ShowManageClientsScreen()
        {
            if (!CheckAccessRights(clsUsers.enPermissions.pManageClients))
            {
                return;
            }

            _DrawScreenHeader("Show Manage Clients Screen");
            Console.WriteLine("============================================");
            Console.WriteLine("[1] Show Client List.");
            Console.WriteLine("[2] Add New Client.");
            Console.WriteLine("[3] Update Client.");
            Console.WriteLine("[4] Delete Client.");
            Console.WriteLine("[5] Find Client.");
            Console.WriteLine("[6] Main Menue.");
            Console.WriteLine("============================================");
            PerformManageClientsOptions((enManageClientsOptions)clsUtil.ReadMenueOptions("Please Enter Number Between [1 to 6] : ", 1, 6));

        }




    }
}
