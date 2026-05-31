using System;
using Bank_Business_Layer;


namespace Bank_Console
{
    internal class Program
    {

        static void Main(string[] args)
        {

            while (true)
            {
                if(!clsLoginScreen.ShowLoginScreen())
                {
                    break;
                }
            }




            Console.ReadKey();
        }
    }
}
