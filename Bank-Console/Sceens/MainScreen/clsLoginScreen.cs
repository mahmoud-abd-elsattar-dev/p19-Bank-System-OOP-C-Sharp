using Bank_Business_Layer;
using System;
using Shared;



namespace Bank_Console
{
    internal class clsLoginScreen : clsScreen
    {

        private static bool _Login()
        {
            string UserName, Password;
            bool FaildLogon = false;
            short TrailsLogin = 3;

            do
            {
                if (FaildLogon)
                {
                    TrailsLogin--;
                    Console.WriteLine("\nInvaild UserName/Password!");
                    Console.WriteLine($"You have {TrailsLogin} Trails to Login.");

                    if (TrailsLogin == 0)
                    {
                        Console.WriteLine("\nYou are Locked After 3 Faild Trails.");
                        return false;
                    }
                }

                Console.Write("\nPlease Enter UserName ? : ");
                UserName = Console.ReadLine();

                Console.Write("Please Enter Password ? : ");
                Password = Console.ReadLine();

                clsUsers.CurrentUser = clsUsers.Find(UserName, Password);

                FaildLogon = (clsUsers.CurrentUser == null);

            } while (FaildLogon);

            clsUsers.LoginUsersLog();
            clsMainMenueScreen.ShowMainMenueScreen();
            return true;
        }

        public static bool ShowLoginScreen()
        {
            _DrawScreenHeader("\tLogin Screen");
            return _Login();
        }

    }
}
