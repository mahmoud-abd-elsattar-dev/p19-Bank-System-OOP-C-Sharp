
namespace Shared
{
    public class Client : Person
    {
        public int ID { get; set; }
        public string AccNumber { get; set; }
        public string PinCode { get; set; }
        public decimal AccBalance { get; set; }
        public int PersonID { get; set; }

        public Client(string AccNumber, string FirstName, string LastName, string Email, string Phone,
            string PinCode, decimal AccBalance)
            : base(FirstName, LastName, Email, Phone)
        {
            this.AccNumber = AccNumber;
            this.PinCode = PinCode;
            this.AccBalance = AccBalance;
        }
        

    }
}
