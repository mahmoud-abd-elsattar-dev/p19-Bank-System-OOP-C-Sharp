using Bank_Business_Layer;
using Shared;
using System;


namespace Bank_Console
{
    internal class clsUpdateClientScreen : clsScreen
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

        private static string _ReadAccNumber()
        {
            string AccNumber = "";

            do
            {
                Console.Write("\nPlease Enter AccNumber ? : ");
                AccNumber = Console.ReadLine();

            } while (string.IsNullOrWhiteSpace(AccNumber));

            return AccNumber;
        }

        private static Client _UpdateClientInfo(Client client1)
        {

            do
            {
                Console.Write("\nPlease Enter FirstName ? : ");
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

        private static void _UpdateClient()
        {
            string AccNumber = _ReadAccNumber();
            Client client1 = clsClients.Find(AccNumber);

            if (client1 != null)
            {
                _PrintClientInfo(client1);

                if (clsClients.UpdateClient(_UpdateClientInfo(client1)))
                    Console.WriteLine("\nClient Updated Successfully.");
                else
                    Console.WriteLine("\nClient Updated Faild.");
            }
            else
            {
                Console.WriteLine("\nAccNumber [" + AccNumber + "] Is Not Exists.");
            }

        }

        public static void ShowUpdateClientScreen()
        {
            _DrawScreenHeader("Update Client Screen");
            _UpdateClient();
        }


    }
}
