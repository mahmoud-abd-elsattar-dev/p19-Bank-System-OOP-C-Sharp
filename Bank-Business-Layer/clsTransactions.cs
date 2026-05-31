using System;
using System.Data;

namespace Bank_Business_Layer
{
    public class clsTransactions
    {
        public static bool Deposite(string AccNumber, decimal Amount)
        {
            return Bank_Data_Layer.clsTransactions.Deposite(AccNumber, Amount);
        }
        public static bool Withdraw(string AccNumber, decimal Amount)
        {
            return Deposite(AccNumber, Amount * -1);
        }
        public static bool Transfer(decimal TransferAmount, string FromAccNumber, string ToAccNumber)
        {
            if (Withdraw(FromAccNumber, TransferAmount) && Deposite(ToAccNumber, TransferAmount));
            {
                Bank_Data_Layer.clsTransactions.TransferLog(TransferAmount, FromAccNumber, ToAccNumber);
                return true;
            }

            return false;
        }
        public static DataTable GetTotalBalances()
        {
            return Bank_Data_Layer.clsTransactions.GetTotalBalances();
        }
        public static DataTable GetTransferLog()
        {
             return Bank_Data_Layer.clsTransactions.GetTransferLog();
        }
        public static decimal TotalBalances()
        {
            return Bank_Data_Layer.clsTransactions.TotalBalances();
        }



    }
}
