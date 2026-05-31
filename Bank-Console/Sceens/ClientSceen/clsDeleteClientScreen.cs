using Bank_Business_Layer;
using Shared;
using System;


namespace Bank_Console
{
    internal class clsDeleteClientScreen : clsScreen
    {

        private static void _DeleteClient()
        {
            string AccNumber = "";

            do
            {
                Console.Write("Please Enter AccNumber ? : ");
                AccNumber = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(AccNumber));


            if (clsClients.IsExists(AccNumber))
            {
                if (clsClients.DeleteClient(AccNumber))
                    Console.WriteLine("\nClient Deleted Successfully.");
                else
                    Console.WriteLine("\nClient Deleted Faild.");
            }
            else
                Console.WriteLine("Client with AccNumber [" + AccNumber + "] is Not Found");
        }

        public static void ShowDeleteClientScreen()
        {
            _DrawScreenHeader("Delete Client Screen");
            _DeleteClient();
        }

    }
}
