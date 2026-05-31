using Bank_Business_Layer;
using Shared;
using System;


namespace Bank_Console
{
    internal class clsCurrencyCalculatorScreen : clsScreen
    {
        private static string _ReadString(string Message)
        {
            string Choice = "";

            Console.Write(Message);
            Choice = Console.ReadLine();

            return Choice;
        }
        private static decimal _ReadAmount()
        {
            decimal Amount = 0;
            Console.WriteLine("\nEnter Amount to Exchange : ");
            Amount = Convert.ToDecimal(Console.ReadLine());

            return Amount;
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
        private static void _Calculation()
        {

            string CurrencyCodeFrom = _ReadString("\nPlease Enter Currency1 Code : ");

            while (!clsCurrencies.IsExists(CurrencyCodeFrom))
            {
                CurrencyCodeFrom = _ReadString("\nCurrency1 Code Is Not Exsits, Enter aonther One : ");
            }

            Currency currencyFrom = clsCurrencies.FindByCode(CurrencyCodeFrom);

            string CurrencyCodeTo = _ReadString("\nPlease Enter Currency2 Code : ");

            while (!clsCurrencies.IsExists(CurrencyCodeTo))
            {
                CurrencyCodeTo = _ReadString("\nCurrency2 Code Is Not Exsits, Enter aonther One : ");
            }

            Currency currencyTo = clsCurrencies.FindByCode(CurrencyCodeTo);

            decimal Amount = _ReadAmount();


            if (CurrencyCodeTo == "USD" || CurrencyCodeTo == "usd")
            {
                Console.WriteLine("\nConvert From : ");
                _PrintCurrencyInfo(currencyFrom);
                Console.WriteLine($"{Amount} {currencyFrom.Code} = {Amount / currencyFrom.ExchangeRateUSD} {currencyTo.Code}");
            }
            else
            {
                Console.WriteLine("\nConvert To : ");
                _PrintCurrencyInfo(currencyFrom);
                Console.WriteLine($"{Amount} {currencyFrom.Code} = {Amount / currencyFrom.ExchangeRateUSD} USD");

                Console.WriteLine("\nConvert From USD To: ");
                Console.WriteLine("\nConvert To : ");
                _PrintCurrencyInfo(currencyTo);
                Console.WriteLine($"{Amount} {currencyFrom.Code} = {((Amount / currencyFrom.ExchangeRateUSD) * currencyTo.ExchangeRateUSD)} {currencyTo.Code}");

            }

        }
        public static void ShowCurrencyCalculatorScreen()
        {
            char Answer = ' ';

            do
            {
                _DrawScreenHeader("Currency Calculator Screen");
                _Calculation();

                Console.Write("\nDo you prtform aonther calculations ? [Y]/[N] : ");
                Answer = char.Parse(Console.ReadLine());

            } while (Answer == 'Y' || Answer == 'y');
        }

    }
}
