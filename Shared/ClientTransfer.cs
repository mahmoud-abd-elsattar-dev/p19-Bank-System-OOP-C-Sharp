
using System;

namespace Shared
{
    public class ClientTransfer
    {
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public decimal TransferAmount { get; set; }
        public string FromAccNumber { get; set; }
        public string ToAccNumber { get; set; }

        public ClientTransfer(decimal Amount, string FromAccNumber, string ToAccNumber)
        {
            this.TransferAmount = Amount;
            this.FromAccNumber = FromAccNumber;
            this.ToAccNumber = ToAccNumber;
        }

    }

}
