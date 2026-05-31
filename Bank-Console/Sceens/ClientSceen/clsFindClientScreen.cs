using Bank_Business_Layer;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Console
{
    internal class clsFindClientScreen : clsScreen
    {
        private static void _PrintClientInfo(Client client)
        {
            Console.WriteLine("\n========================================");
            Console.WriteLine("FirstName   : " + client.FirstName);
            Console.WriteLine("LastName    : " + client.LastName);
            Console.WriteLine("Email       : " + client.Email);
            Console.WriteLine("Phone       : " + client.Phone);
            Console.WriteLine("AccNumber   : " + client.AccNumber);
            Console.WriteLine("PinCode     : " + client.PinCode);
            Console.WriteLine("AccBalance  : " + client.AccBalance);
            Console.WriteLine("========================================");

        }

        private static void _FindClient()
        {
            Console.Write("\nPlease Enter AccNumber ? : ");
            string AccNumber = Console.ReadLine();

            Client Client1 = clsClients.Find(AccNumber);

            if (Client1 != null)
            {
               _PrintClientInfo(Client1);
            }
            else
                Console.WriteLine("\nClient with AccNumber [" + AccNumber + "] is Not Found");
        }

        public static void ShowFindClienScreen()
        {
            _DrawScreenHeader("Find Client Screen");
            _FindClient();
        }

    }
}
