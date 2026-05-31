using Bank_Business_Layer;
using Shared;
using System;


namespace Bank_Console
{
    internal class clsWithdrawScreen : clsScreen
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
            Answer = char.Parse(Console.ReadLine());

            return Answer;
        }

        private static void _Withdraw()
        {
            string AccNumber = _ReadAccNumber();
            Client client = clsClients.Find(AccNumber);
            _PrintClientInfo(client);
            decimal Amount = _ReadAmount();

            while(Amount > client.AccBalance)
            {
                Console.WriteLine("Amount Exceeds The Balance, you can withdraw up to : " + client.AccBalance);
                Amount = _ReadAmount();
            }

            char Answer = _Answer();

            if (Answer == 'Y' || Answer == 'y')
            {
                if (clsTransactions.Withdraw(AccNumber, Amount))
                {
                    Console.WriteLine("Done Successfully. New Balance Is : " + (client.AccBalance - Amount));
                }
                else
                {
                    Console.WriteLine("Errpr: Withdraw Faild");
                }
            }

        }

        public static void ShowWithdrawScreen()
        {
            _DrawScreenHeader("Withdraw Screen");
            _Withdraw();
        }

    }
}
