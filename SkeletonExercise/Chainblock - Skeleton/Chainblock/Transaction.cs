using Chainblock.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chainblock
{
    public class Transaction : ITransaction
    {
        public Transaction(int id, TransactionStatus status, string from, string to, decimal amount)
        {
            this.Id = id;
            this.Status = status;
            this.From = from;
            this.To = to;
            this.Amount = amount;
        }

        public int Id { get; set; }
        public TransactionStatus Status { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public decimal Amount { get; set; }

        public int CompareTo(ITransaction other)
        {
            throw new NotImplementedException();
        }
    }
}
