using System;

namespace Bank_Console
{
    public class clsUtil
    {
        public static string ReadString(string Message)
        {
            string Text = "";
            do
            {
                Console.WriteLine(Message);
                Text = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(Message));

            return Text;
        }
        public static short ReadMenueOptions(string Message, short From, short To)
        {
            short Choice = 0;

            do
            {
                Console.Write(Message);
                Choice = short.Parse(Console.ReadLine());
            } while (Choice < From || Choice > To);

            return Choice;
        }

    }
}
