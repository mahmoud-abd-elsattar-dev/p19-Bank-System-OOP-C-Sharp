using Bank_Business_Layer;
using Shared;
using System;
using System.Runtime.Remoting.Messaging;


namespace Bank_Console
{
    internal class clsFindCurrencyScreen : clsScreen
    {
        private static short _ReadCodeOrCountry()
        {
            short Number = 0;
            do
            {
                Console.Write("\nFind By: [1] Code or [2] Country ? : ");
                Number = short.Parse(Console.ReadLine());
            } while (Number < 1 || Number > 2);

            return Number;
        }
        private static string _ReadString(string Message)
        {
            string Choice = "";

            Console.Write(Message);
            Choice = Console.ReadLine();

            return Choice;
        }

        private static void _PrintCurrencyInfo(Currency currency)
        {
            Console.WriteLine("\nCurrency Info : ");
            Console.WriteLine("=========================================");
            Console.WriteLine("Country   : " + currency.CountryName);
            Console.WriteLine("Code      : " + currency.Code);
            Console.WriteLine("Name      : " + currency.Name);
            Console.WriteLine("Rate (1$) : " + currency.ExchangeRateUSD);
            Console.WriteLine("=========================================");
        }

        private static void _FindCurrency()
        {
            string Choice = "";
            Currency currency;

            if (_ReadCodeOrCountry() == 1)
            {
                Choice = _ReadString("\nPlease Enter Currency Code ? : ");
                currency = clsCurrencies.FindByCode(Choice);

                if (currency != null)
                    _PrintCurrencyInfo(currency);
                else
                    Console.WriteLine("\nCurrency Not Found!");
            }
            else
            {
                Choice = _ReadString("\nPlease Enter Country Name ? : ");
                currency = clsCurrencies.FindByCountry(Choice);

                if (currency != null)
                    _PrintCurrencyInfo(currency);
                else
                    Console.WriteLine("\nCurrency Not Found!");

            }
        }

        public static void ShowFindCurrencyScreen()
        {
            _DrawScreenHeader("Find Currency Screen");
            _FindCurrency();
        }

    }
}
