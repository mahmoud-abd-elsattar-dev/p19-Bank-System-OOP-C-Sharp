
using System.Runtime.CompilerServices;

namespace Shared
{
    public class User : Person
    {
        public int ID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int Permissions { get; set; }
        public int PersonID { get; set; }

        public User(string FirstName, string LastName, string Email, string Phone,
            string UserName, string Password, int Permissions) : base(FirstName, LastName, Email, Phone)
        {
            this.UserName = UserName;
            this.Password = Password;
            this.Permissions = Permissions;
        }

    }
}
