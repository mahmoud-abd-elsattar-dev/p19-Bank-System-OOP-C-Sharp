using Shared;
using System;
using System.Data;

namespace Bank_Business_Layer
{
    public class clsCurrencies
    {
        public static DataTable GetListCurrencies()
        {
            return Bank_Data_Layer.clsCurrencies.GetListCurrencies();
        }

        public static Currency FindByCode(string Code)
        {
            return Bank_Data_Layer.clsCurrencies.FindByCode(Code);
        }

        public static Currency FindByCountry(string Country)
        {
            return Bank_Data_Layer.clsCurrencies.FindByCountry(Country);
        }

        public static bool IsExists(string Code)
        {
            return Bank_Data_Layer.clsCurrencies.IsExists(Code);
        }
        public static bool UpdateRate(string Code, decimal NewRate)
        {
            return Bank_Data_Layer.clsCurrencies.UpdateRate(Code, NewRate);
        }




    }
}
