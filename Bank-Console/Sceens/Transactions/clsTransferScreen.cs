using Bank_Business_Layer;
using Shared;
using System;
//using System.Runtime.Remoting.Lifetime;

namespace Bank_Console
{
    internal class clsTransferScreen : clsScreen
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

        private static string _ReadAccNumber(string Message)
        {
            string AccNumber = "";

            do
            {
                Console.WriteLine(Message);
                AccNumber = Console.ReadLine();

            } while (string.IsNullOrWhiteSpace(AccNumber));



            while (!clsClients.IsExists(AccNumber))
            {
                Console.WriteLine("\nClient with [" + AccNumber + "] does not Exist.");
                Console.WriteLine(Message);
                AccNumber = Console.ReadLine();
            }

            return AccNumber;
        }

        private static decimal _ReadAmount()
        {
            decimal Amount = 0;
            do
            {
                Console.Write("\nPlease Enter Transfer Amount ? : ");
                Amount = decimal.Parse(Console.ReadLine());
            } while (Amount <= 0);

            return Amount;
        }

        private static char _Answer()
        {
            char Answer = ' ';
            Console.WriteLine("\nAre you sure you want to perform this transaction ? [Y]/[N] ? : ");
            Answer = char.Parse(Console.ReadLine());

            return Answer;
        }

        private static void _Transfer()
        {
            string FromAccNumber = _ReadAccNumber("\nPlease Enter From AccNumber ? : ");
            Client FromClient = clsClients.Find(FromAccNumber);
            _PrintClientInfo(FromClient);

            string ToAccNumber = _ReadAccNumber("\nPlease Enter To AccNumber ? : ");
            Client ToClient = clsClients.Find(ToAccNumber);
            _PrintClientInfo(ToClient);

            decimal TransferAmount = _ReadAmount();

            while (TransferAmount > FromClient.AccBalance)
            {
                Console.WriteLine("\nAmount Exceeds The Balance, you can transfer up to : " + FromClient.AccBalance);
                TransferAmount = _ReadAmount();
            }

            char Answer = _Answer();

            if (Answer == 'Y' || Answer == 'y')
            {
                if (clsTransactions.Transfer(TransferAmount, FromAccNumber, ToAccNumber))
                {
                    Console.WriteLine("Done Successfully.");
                    Console.WriteLine("Client From New Balance Is : " + (FromClient.AccBalance - TransferAmount));
                    Console.WriteLine("Client To New Balance Is : " + (ToClient.AccBalance + TransferAmount));
                }
                else
                {
                    Console.WriteLine("Errpr: Deposite Faild");
                }
            }

        }

        public static void ShowTransferScreen()
        {
            _DrawScreenHeader("Transfer Screen");
            _Transfer();
        }




    }
}
