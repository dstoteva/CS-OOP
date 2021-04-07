using Chainblock.Contracts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chainblock
{
    public class Chainblock : IChainblock
    {
        private List<ITransaction> transactions;

        public Chainblock()
        {
            this.transactions = new List<ITransaction>(); 
        }
        public int Count => this.transactions.Count;

        public void Add(ITransaction tx)
        {
            if (tx == null)
            {
                throw new ArgumentNullException();
            }
            this.transactions.Add(tx);
        }

        public void ChangeTransactionStatus(int id, TransactionStatus newStatus)
        {
            if (!this.transactions.Any(x => x.Id == id))
            {
                throw new ArgumentException();
            }
            ITransaction transaction = this.transactions.FirstOrDefault(x => x.Id == id);
            transaction.Status = newStatus;
        }

        public bool Contains(ITransaction tx)
        {
            if (tx == null)
            {
                throw new ArgumentNullException();
            }
            if (this.transactions.Any(x => x == tx))
            {
                return true;
            }
            return false;
        }

        public bool Contains(int id)
        {
            if (id <= 0)
            {
                throw new InvalidOperationException();
            }
            if (this.transactions.Any(x => x.Id == id))
            {
                return true;
            }
            return false;
        }

        public IEnumerable<ITransaction> GetAllInAmountRange(double lo, double hi)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ITransaction> GetAllOrderedByAmountDescendingThenById()
        {
            return this.transactions.OrderByDescending(x => x.Amount).ThenBy(x => x.Id);
        }

        public IEnumerable<string> GetAllReceiversWithTransactionStatus(TransactionStatus status)
        {
            List<string> receivers = this.transactions.Where(x => x.Status == status)
                .OrderBy(x => x.Amount).Select(x => x.To).ToList();

            if (receivers.Count == 0)
            {
                throw new InvalidOperationException();
            }
            return receivers;
        }

        public IEnumerable<string> GetAllSendersWithTransactionStatus(TransactionStatus status)
        {
            List<string> senders = this.transactions.Where(x => x.Status == status)
                .OrderBy(x => x.Amount).Select(x => x.From).ToList();

            if (senders.Count == 0)
            {
                throw new InvalidOperationException();
            }
            return senders;
        }

        public ITransaction GetById(int id)
        {
            if (!this.transactions.Any(x => x.Id == id))
            {
                throw new InvalidOperationException();
            }
            return this.transactions.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<ITransaction> GetByReceiverAndAmountRange(string receiver, double lo, double hi)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ITransaction> GetByReceiverOrderedByAmountThenById(string receiver)
        {
            List<ITransaction> result = this.transactions.Where(x => x.To == receiver)
                .OrderByDescending(x => x.Amount).ThenBy(x => x.Id).ToList();

            if (result.Count == 0)
            {
                throw new InvalidOperationException();
            }
            return result;
        }

        public IEnumerable<ITransaction> GetBySenderAndMinimumAmountDescending(string sender, double amount)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ITransaction> GetBySenderOrderedByAmountDescending(string sender)
        {
            List<ITransaction> result = this.transactions.Where(x => x.From == sender)
                .OrderByDescending(x => x.Amount).ToList();

            if (result.Count == 0)
            {
                throw new InvalidOperationException();
            }
            return result;
        }

        public IEnumerable<ITransaction> GetByTransactionStatus(TransactionStatus status)
        {
            List<ITransaction> result = this.transactions.Where(x => x.Status == status)
                .OrderByDescending(x => x.Amount).ToList();

            if (result.Count == 0)
            {
                throw new InvalidOperationException();
            }
            return result;
        }

        public IEnumerable<ITransaction> GetByTransactionStatusAndMaximumAmount(TransactionStatus status, double amount)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<ITransaction> GetEnumerator()
        {
            foreach (var item in this.transactions)
            {
                yield return item;
            }
        }

        public void RemoveTransactionById(int id)
        {
            if (!this.transactions.Any(x => x.Id == id))
            {
                throw new InvalidOperationException();
            }
            this.transactions.Remove(this.transactions.FirstOrDefault(x => x.Id == id));
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
