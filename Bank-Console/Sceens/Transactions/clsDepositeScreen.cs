using Bank_Business_Layer;
using Shared;
using System;


namespace Bank_Console
{
    public class clsDepositeScreen : clsScreen
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



            while (!clsClients.IsExists(AccNumber))
            {
                Console.WriteLine("\nClient with [" + AccNumber + "] does not Exist.");
                Console.WriteLine("\nPlease Enter AccNumber ? : ");
                AccNumber = Console.ReadLine();
            }

            return AccNumber;
        }

        private static decimal _ReadAmount()
        {
            decimal Amount = 0;
            do
            {
                Console.Write("Please Enter Amount ? : ");
                Amount = decimal.Parse(Console.ReadLine());
            } while (Amount <= 0);

            return Amount;
        }

        private static char _Answer()
        {
            char Answer = ' ';
            Console.WriteLine("\nAre you sure you want to perform this transaction ? [Y]/[N] ? : ");
            Answer=char.Parse(Console.ReadLine());

            return Answer;
        }

        private static void _Deposte()
        {
            string AccNumber = _ReadAccNumber();
            Client client = clsClients.Find(AccNumber);
            _PrintClientInfo(client);
            decimal Amount = _ReadAmount();
            char Answer = _Answer();

            if (Answer == 'Y' || Answer == 'y')
            {
                if (clsTransactions.Deposite(AccNumber, Amount))
                {
                    Console.WriteLine("Done Successfully. New Balance Is : " + (client.AccBalance + Amount));
                }
                else
                {
                    Console.WriteLine("Errpr: Deposite Faild");
                }
            }

        }

        public static void ShowDepositeScreen()
        {
            _DrawScreenHeader("Deposite Screen");
            _Deposte();
        }

    }
}
