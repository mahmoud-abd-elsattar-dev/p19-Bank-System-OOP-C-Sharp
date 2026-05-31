using Bank_Business_Layer;
using Shared;
using System;

namespace Bank_Console
{
    internal class clsAddNewClientScreen : clsScreen
    {
        private static void _PrintClientInfo(Client client)
        {
            Console.WriteLine("\nClient Info : ");
            Console.WriteLine("========================================");
            Console.WriteLine("FirstName   : " + client.FirstName);
            Console.WriteLine("LastName    : " + client.LastName);
            Console.WriteLine("Email       : " + client.Email);
            Console.WriteLine("Phone       : " + client.Phone);
            Console.WriteLine("AccNumber   : " + client.AccNumber);
            Console.WriteLine("PinCode     : " + client.PinCode);
            Console.WriteLine("AccBalance  : " + client.AccBalance);
            Console.WriteLine("========================================");

        }

        private static Client _ReadClientInfo()
        {
            Client client1 = new Client("", "", "", "", "", "", 0);


            do
            {
                client1.AccNumber = clsUtil.ReadString("Please Enter AccNumber ? : ");

            } while(string.IsNullOrWhiteSpace(client1.AccNumber));

            while (clsClients.IsExists(client1.AccNumber))
            {
                client1.AccNumber = clsUtil.ReadString("AccountNumber [" + client1.AccNumber + "] Is Areadly Exists, Chocie another one.");
            }

            do
            {
                Console.Write("Please Enter FirstName ? : ");
                client1.FirstName = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(client1.FirstName));

            do
            {
                Console.Write("Please Enter LastName ? : ");
                client1.LastName = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(client1.LastName));

            do
            {
                Console.Write("Please Enter Email ? : ");
                client1.Email = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(client1.Email));

            do
            {
                Console.Write("Please Enter Phone ? : ");
                client1.Phone = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(client1.Phone));

            do
            {
                Console.Write("Please Enter PinCode ? : ");
                client1.PinCode = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(client1.PinCode));

            do
            {
                Console.Write("Please Enter AccBalance ? : ");
                client1.AccBalance = decimal.Parse(Console.ReadLine());
            } while (client1.AccBalance <= 0);

            return client1;
        }

        private static void _AddNewClient()
        {
            Client client = _ReadClientInfo();

            if (clsClients.AddNewClient(client))
            {
                Console.WriteLine("\nClient Added Successfully.");
                _PrintClientInfo(client);
            }
            else
                Console.WriteLine("\nClient Added Faild.");

        }

        public static void ShowAddNewClientScreen()
        {
            _DrawScreenHeader("Add New Client Screen");
            _AddNewClient();
        }

    }
}
