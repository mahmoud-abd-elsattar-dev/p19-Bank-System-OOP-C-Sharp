using System;
using System.Data;
using Bank_Data_Layer;
using Shared;



namespace Bank_Business_Layer
{
    public class clsUsers
    {
        public enum enPermissions { pManageClients = 1, pManageUsers = 2, pManageTransactions = 4, pCurrencyExchange = 8, pAll = -1 }

        public static User CurrentUser = GetEmptyUser();
        public static User GetEmptyUser()
        {
            return new User("", "", "", "", "", "", 0);
        }
        public static bool CheckAccessPermissions(enPermissions Permission)
        {
            if(CurrentUser.Permissions == (int)enPermissions.pAll)
                return true;

            return ((CurrentUser.Permissions & (int)Permission) == (int)Permission);
        }
        public static void LoginUsersLog()
        {
            Bank_Data_Layer.clsUsers.UsersLog(clsUsers.CurrentUser.UserName);
        }

        public static User Find(string UserName, string Password)
        {
            return Bank_Data_Layer.clsUsers.GetUserInfo(UserName, Password);
        }
        
        public static User Find(string UserName)
        {
            return Bank_Data_Layer.clsUsers.GetUserInfo(UserName);
        }

        public static bool IsExists(string UserName)
        {
            return Bank_Data_Layer.clsUsers.IsExists(UserName);
        }
        public static bool AddNewUser(User user)
        {
            return Bank_Data_Layer.clsUsers.AddNewUser(user);
        }

        public static bool UpdateUser(User user)
        {
            return Bank_Data_Layer.clsUsers.UpdateUser(user);
        }
        public static bool DeleteUser(string UserName)
        {
            return Bank_Data_Layer.clsUsers.DeleteUser(UserName);
        }
        public static DataTable GetUsersList()
        {
            return Bank_Data_Layer.clsUsers.GetUsersList();
        }

        public static DataTable GetAllUsersLog()
        {
            return Bank_Data_Layer.clsUsers.GetAllUsersLog();
        }





    }
}
