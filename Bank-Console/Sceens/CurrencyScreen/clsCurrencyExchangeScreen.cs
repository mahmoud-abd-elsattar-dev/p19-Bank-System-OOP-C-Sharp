using Bank_Business_Layer;
using System;


namespace Bank_Console
{
    internal class clsCurrencyExchangeScreen : clsScreen
    {
        private enum enCurrencyExchange { ListCurrencies = 1, FindCurrency = 2, UpdateRate = 3, CurrencyCalculator = 4, MainMenue = 5 }
        private static void _GoBackToCurrencyExchangeMenue()
        {
            Console.Write("\nPress any key to go back to currency exchange menue...");
            Console.ReadKey();
            ShowCurrencyExchangeMenueScreen();
        }
        private static void _ListCurrenciesScreen()
        {
           clsListCurrenciesScreen.ShowListCurrenciesScreen();
        }
        private static void _FindCurrencyScreen()
        {
            clsFindCurrencyScreen.ShowFindCurrencyScreen();
        }
        private static void _UpdateRateScreen()
        {
            clsUpdateRateScreen.ShowUpdateRateScreen();
        }
        private static void _CurrencyCalculatorScreen()
        {
            clsCurrencyCalculatorScreen.ShowCurrencyCalculatorScreen(); 
        }
      
        private static void PerformCurrencyExchangeOptions(enCurrencyExchange Option)
        {
            switch (Option)
            {
                case enCurrencyExchange.ListCurrencies:
                    _ListCurrenciesScreen();
                    _GoBackToCurrencyExchangeMenue();
                    break;

                case enCurrencyExchange.FindCurrency:
                    _FindCurrencyScreen();
                    _GoBackToCurrencyExchangeMenue();
                    break;

                case enCurrencyExchange.UpdateRate:
                    _UpdateRateScreen();
                    _GoBackToCurrencyExchangeMenue();
                    break;

                case enCurrencyExchange.CurrencyCalculator:
                    _CurrencyCalculatorScreen();
                    _GoBackToCurrencyExchangeMenue();
                    break;

                case enCurrencyExchange.MainMenue:
                    break;

            }
        }

        public static void ShowCurrencyExchangeMenueScreen()
        {
            if (!CheckAccessRights(clsUsers.enPermissions.pCurrencyExchange))
            {
                return;
            }

            _DrawScreenHeader("Currency Exchange Screen");
            Console.WriteLine("============================================");
            Console.WriteLine("[1] List Currencies.");
            Console.WriteLine("[2] Find Currency.");
            Console.WriteLine("[3] Update Rate.");
            Console.WriteLine("[4] Currency Calculator.");
            Console.WriteLine("[5] Main Menue.");
            Console.WriteLine("============================================");
            PerformCurrencyExchangeOptions((enCurrencyExchange)clsUtil.ReadMenueOptions("Please Enter Number Between [1 to 5] : ", 1, 5));

        }

      
    }
}
