using Bank_Business_Layer;
using Shared;
using System;

namespace Bank_Console
{
    public class clsScreen
    {
        protected static void _DrawScreenHeader(string Title, string SubTitle = "")
        {
            Console.Clear();
            Console.WriteLine("\n");
            Console.WriteLine("============================================");
            Console.Write("\t" + Title);
            if (SubTitle != "")
                Console.WriteLine("\t" + SubTitle);
            else
                Console.Write("\n");
            Console.WriteLine("============================================");
            Console.Write($"User : {clsUsers.CurrentUser.UserName}");
            Console.WriteLine($"\tDate : {DateTime.Now.ToString()}");

        }

        public static bool CheckAccessRights(clsUsers.enPermissions Permission)
        {
            if(!clsUsers.CheckAccessPermissions(Permission))
            {
                Console.Clear();
                Console.WriteLine("============================================");
                Console.WriteLine($"Access Denied! Contact Your Admin.");
                Console.WriteLine("============================================");
                return false;
            }

            return true;
        }

    }
}
