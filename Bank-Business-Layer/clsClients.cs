using System;
using Shared;
using System.Data;
using Bank_Data_Layer;
using System.Collections.Generic;

namespace Bank_Business_Layer
{
    public class clsClients
    {
        public static Client GetEmptyClient()
        {
            return new Client("", "", "", "", "", "", 0);
        }
        public static Client Find(string AccNumber) => Bank_Data_Layer.clsClients.GetClintInfo(AccNumber);

        public static bool AddNewClient(Client client) => Bank_Data_Layer.clsClients.AddNewClient(client);

        public static bool UpdateClient(Client client) => Bank_Data_Layer.clsClients.UpdateClient(client);

        public static bool DeleteClient(string AccNumber) => Bank_Data_Layer.clsClients.DeleteClient(AccNumber);

        public static DataTable GetClientsList() => Bank_Data_Layer.clsClients.GetClientsList();

        public static bool IsExists(string AccNumber) => Bank_Data_Layer.clsClients.IsExists(AccNumber);





    }
}
