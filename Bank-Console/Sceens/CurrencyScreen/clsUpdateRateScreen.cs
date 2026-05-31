using Bank_Business_Layer;
using Shared;
using System;


namespace Bank_Console
{
    internal class clsUpdateRateScreen : clsScreen
    {
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

        private static decimal _ReadRate()
        {
            decimal NewRate;
            Console.WriteLine("\nUpdate Currency Rate : ");
            Console.Write("---------------------------");
            Console.WriteLine("\nEnter New Rate : ");
            NewRate = Convert.ToDecimal(Console.ReadLine());

            return NewRate;
        }
        private static void _UpdateCurrencyRate()
        {
            Currency currency = clsCurrencies.FindByCode(_ReadString("\nPlease Enter Currency Code ? : "));

            if (currency != null)
            {
                _PrintCurrencyInfo(currency);
                Console.Write("\nAre you sure you want to update the rate of this currency ? [Y]/[N] : ");
                char Answer = char.Parse(Console.ReadLine());
                
                if(Answer == 'Y' || Answer == 'y')
                {
                    decimal NewRate = _ReadRate();

                    if(clsCurrencies.UpdateRate(currency.Code, NewRate))
                    {
                        currency.ExchangeRateUSD = NewRate;
                        Console.Write("\n Currency Rate Updated Successfully.");
                        _PrintCurrencyInfo(currency);
                    }
                    else
                    {
                        Console.Write("\n Currency Rate Updated Faild.");
                    }
                }
            }
            else
                Console.WriteLine("\nCurrency Not Found!");
        }

        public static void ShowUpdateRateScreen()
        {
            _DrawScreenHeader("Update Rate Screen");
            _UpdateCurrencyRate();
        }

    }
}
