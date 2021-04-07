using Chainblock.Contracts;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chainblock.Tests
{
    public class ChainBlockTests
    {
        private Chainblock chainblock;
        private Transaction transaction;
        [SetUp]
        public void SetUp()
        {
            this.chainblock = new Chainblock();
            this.transaction = new Transaction(5, TransactionStatus.Successfull, "Gosho", "Pesho", 23.54m);
        }
       // [Test]
       // public void ConstructorShouldInitializeCorrectly()
       // {
       //     Transaction actual = new Transaction(5, TransactionStatus.Successfull, "Gosho", "Pesho", 23.54m);
       //     this.transaction.Id = 5;
       //     this.transaction.Status = TransactionStatus.Successfull;
       //     this.transaction.From = "Gosho";
       //     this.transaction.To = "Pesho";
       //     this.transaction.Amount = 23.54m;
       //
       //     Assert.AreEqual(transaction, actual);
       // }
        [Test]
        public void AddShouldIncreaseCountWithOne()
        {
            chainblock.Add(this.transaction);

            Assert.AreEqual(1, this.chainblock.Count);
        }
        [Test]
        public void AddShouldNotIncreaseCountWhenNothingIsAdded()
        {
            Assert.AreEqual(0, this.chainblock.Count);
        }
        [Test]
        public void CountShouldStartFromZero()
        {
            Assert.AreEqual(0, this.chainblock.Count);
        }
        [Test]
        public void AddShouldThrowExceptionWhenNullIsAdded()
        {
            Assert.Throws<ArgumentNullException>(() => this.chainblock.Add(null));
            Assert.AreEqual(0, this.chainblock.Count);
        }
        [Test]
        public void AddShouldAddCorrectTransaction()
        {
            this.chainblock.Add(this.transaction);

            foreach (var trans in this.chainblock)
            {
                Assert.AreEqual(this.transaction, trans);
            }
        }
        [Test]
        public void ContainsByIdShouldReturnTrue()
        {
            this.chainblock.Add(this.transaction);

            bool result = this.chainblock.Contains(5);

            Assert.IsTrue(result);
        }
        [Test]
        public void ContainsByIdShouldReturnFalse()
        {
            this.chainblock.Add(this.transaction);

            bool result = this.chainblock.Contains(9);

            Assert.IsFalse(result);
        }
        [Test]
        public void ContainsByIdWithNegativeValueShouldThrowInvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(() => this.chainblock.Contains(-25));
        }
        [Test]
        public void ContainsByTransactionShouldReturnTrue()
        {
            this.chainblock.Add(this.transaction);

            bool result = this.chainblock.Contains(this.transaction);

            Assert.IsTrue(result);
        }
        [Test]
        public void ContainsByTransactionShouldReturnFalse()
        {
            bool result = this.chainblock.Contains(this.transaction);

            Assert.IsFalse(result);
        }
        [Test]
        public void ContainsByNullTransactionShouldThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => this.chainblock.Contains(null));
        }
        [Test]
        public void ChangeTransactionStatusShouldChangeStatusCorrectly()
        {
            this.chainblock.Add(this.transaction);

            var expected = TransactionStatus.Failed;

            this.chainblock.ChangeTransactionStatus(5, expected);

            Assert.AreEqual(expected, this.transaction.Status);
        }
        [Test]
        public void ChangeTransactionStatusShouldThrowArgumentExceptionWithInvalidId()
        {
            var expected = TransactionStatus.Failed;

            Assert.Throws<ArgumentException>(() => this.chainblock.ChangeTransactionStatus(5, expected));

        }
        [Test]
        public void RemoveTransactionByIdShouldRemoveCorrectTransaction()
        {
            Transaction firstTransaction = 
                new Transaction(1, TransactionStatus.Unauthorized, "Simo", "Dimo", 57.65m);
            Transaction secondTransaction =
                new Transaction(2, TransactionStatus.Unauthorized, "Simo", "Dimo", 57.65m);
            Transaction thirdTransaction =
                new Transaction(3, TransactionStatus.Unauthorized, "Simo", "Dimo", 57.65m);

            this.chainblock.Add(firstTransaction);
            this.chainblock.Add(secondTransaction);
            this.chainblock.Add(thirdTransaction);

            this.chainblock.RemoveTransactionById(2);
            this.chainblock.RemoveTransactionById(1);

            foreach (var trans in this.chainblock)
            {
                Assert.AreEqual(thirdTransaction, trans);
            }
        }
        [Test]
        public void RemoveTransactionByIdShouldThrowInvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(() => this.chainblock.RemoveTransactionById(-5));
        }
        [Test]
        public void GetByIdShouldGetTheRightTransaction()
        {
            ITransaction firstTransaction =
                new Transaction(1, TransactionStatus.Unauthorized, "Simo", "Dimo", 57.65m);
            ITransaction secondTransaction =
                new Transaction(2, TransactionStatus.Unauthorized, "Simo", "Dimo", 57.65m);
            ITransaction thirdTransaction =
                new Transaction(3, TransactionStatus.Unauthorized, "Simo", "Dimo", 57.65m);

            this.chainblock.Add(firstTransaction);
            this.chainblock.Add(secondTransaction);
            this.chainblock.Add(thirdTransaction);

            ITransaction expected = secondTransaction;

            ITransaction actual = this.chainblock.GetById(2);

            Assert.AreEqual(expected, actual);
        }
        [Test]
        [TestCase(0)]
        [TestCase(-5)]
        [TestCase(7)]
        public void GetByIdShouldThrowInvalidOperationException(int id)
        {
            ITransaction firstTransaction =
                new Transaction(1, TransactionStatus.Unauthorized, "Simo", "Dimo", 57.65m);
            ITransaction secondTransaction =
                new Transaction(2, TransactionStatus.Unauthorized, "Simo", "Dimo", 57.65m);
            ITransaction thirdTransaction =
                new Transaction(3, TransactionStatus.Unauthorized, "Simo", "Dimo", 57.65m);

            this.chainblock.Add(firstTransaction);
            this.chainblock.Add(secondTransaction);
            this.chainblock.Add(thirdTransaction);

            Assert.Throws<InvalidOperationException>(() => this.chainblock.GetById(id));
        }
        [Test]
        public void GetByTransactionStatusShouldReturnCorrectsTransactions()
        {
            ITransaction firstTransaction =
                new Transaction(1, TransactionStatus.Unauthorized, "Simo", "Dimo", 57.65m);
            ITransaction secondTransaction =
                new Transaction(2, TransactionStatus.Successfull, "Simo", "Dimo", 57.65m);
            ITransaction thirdTransaction =
                new Transaction(3, TransactionStatus.Unauthorized, "Simo", "Dimo", 59.65m);

            this.chainblock.Add(firstTransaction);
            this.chainblock.Add(secondTransaction);
            this.chainblock.Add(thirdTransaction);

            IEnumerable<ITransaction> actual 
                = this.chainblock.GetByTransactionStatus(TransactionStatus.Unauthorized);
            IEnumerable<ITransaction> expected = new List<ITransaction>()
            {
                thirdTransaction,
                firstTransaction
            };

            CollectionAssert.AreEqual(expected, actual);
        }
        [Test]
        public void GetByTransactionStatusShouldReturnInvalidOperationExceptionForEmpty()
        {
            ITransaction firstTransaction =
                new Transaction(1, TransactionStatus.Unauthorized, "Simo", "Dimo", 57.65m);
            ITransaction secondTransaction =
                new Transaction(2, TransactionStatus.Successfull, "Simo", "Dimo", 57.65m);
            ITransaction thirdTransaction =
                new Transaction(3, TransactionStatus.Unauthorized, "Simo", "Dimo", 59.65m);

            this.chainblock.Add(firstTransaction);
            this.chainblock.Add(secondTransaction);
            this.chainblock.Add(thirdTransaction);

            Assert.Throws<InvalidOperationException>
                (() => this.chainblock.GetByTransactionStatus(TransactionStatus.Failed));
        }
        [Test]
        public void GetAllSendersWithTransactionStatusShouldReturnCorrectSenders()
        {
            ITransaction firstTransaction =
                new Transaction(1, TransactionStatus.Unauthorized, "Simo", "Dimo", 57.65m);
            ITransaction secondTransaction =
                new Transaction(2, TransactionStatus.Unauthorized, "Simo", "Dimo", 57.65m);
            ITransaction thirdTransaction =
                new Transaction(3, TransactionStatus.Unauthorized, "Misho", "Dimo", 59.65m);

            this.chainblock.Add(firstTransaction);
            this.chainblock.Add(secondTransaction);
            this.chainblock.Add(thirdTransaction);

            IEnumerable<string> actual
                = this.chainblock.GetAllSendersWithTransactionStatus(TransactionStatus.Unauthorized);
            IEnumerable<string> expected = new List<string>()
            {
                firstTransaction.From,
                secondTransaction.From,
                thirdTransaction.From
            };
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void GetAllSendersWithTransactionStatusShouldThrow()
        {
         Assert.Throws<InvalidOperationException>(() =>
         this.chainblock.GetAllSendersWithTransactionStatus(TransactionStatus.Unauthorized));
        }
        [Test]
        public void GetAllReceiversWithTransactionStatusShouldReturnCorrectSenders()
        {
            ITransaction firstTransaction =
                new Transaction(1, TransactionStatus.Unauthorized, "Simo", "Dimo", 57.65m);
            ITransaction secondTransaction =
                new Transaction(2, TransactionStatus.Unauthorized, "Simo", "Ivo", 57.65m);
            ITransaction thirdTransaction =
                new Transaction(3, TransactionStatus.Unauthorized, "Misho", "Dimo", 59.65m);

            this.chainblock.Add(firstTransaction);
            this.chainblock.Add(secondTransaction);
            this.chainblock.Add(thirdTransaction);

            IEnumerable<string> actual
                = this.chainblock.GetAllReceiversWithTransactionStatus(TransactionStatus.Unauthorized);
            IEnumerable<string> expected = new List<string>()
            {
                firstTransaction.To,
                secondTransaction.To,
                thirdTransaction.To
            };
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void GetAllReceiversWithTransactionStatusShouldThrow()
        {
            Assert.Throws<InvalidOperationException>(() =>
            this.chainblock.GetAllReceiversWithTransactionStatus(TransactionStatus.Unauthorized));
        }
        [Test]
        public void GetAllOrderedByAmountDescendingThenByIdShouldReturnOrderedCollection()
        {
            ITransaction firstTransaction =
                new Transaction(1, TransactionStatus.Unauthorized, "Simo", "Dimo", 57.65m);
            ITransaction secondTransaction =
                new Transaction(2, TransactionStatus.Unauthorized, "Simo", "Ivo", 57.65m);
            ITransaction thirdTransaction =
                new Transaction(3, TransactionStatus.Unauthorized, "Misho", "Dimo", 59.65m);

            this.chainblock.Add(firstTransaction);
            this.chainblock.Add(secondTransaction);
            this.chainblock.Add(thirdTransaction);

            IEnumerable<ITransaction> expected = new List<ITransaction>()
            {
                thirdTransaction,
                firstTransaction,
                secondTransaction
            };
            IEnumerable<ITransaction> actual = this.chainblock.GetAllOrderedByAmountDescendingThenById();

            CollectionAssert.AreEqual(expected, actual);
        }
        [Test]
        public void GetAllOrderedByAmountDescendingThenByIdShouldThrow()
        {
            IEnumerable<ITransaction> expected = new List<ITransaction>() { };
            IEnumerable<ITransaction> actual = this.chainblock.GetAllOrderedByAmountDescendingThenById();

            CollectionAssert.AreEqual(expected, actual);
        }
        [Test]
        public void GetBySenderOrderedByAmountDescendingShouldReturnTransactionOrderedByAmount()
        {
            ITransaction firstTransaction =
               new Transaction(1, TransactionStatus.Unauthorized, "Simo", "Dimo", 57.65m);
            ITransaction secondTransaction =
                new Transaction(2, TransactionStatus.Unauthorized, "Simo", "Ivo", 60.65m);
            ITransaction thirdTransaction =
                new Transaction(3, TransactionStatus.Unauthorized, "Misho", "Dimo", 59.65m);

            this.chainblock.Add(firstTransaction);
            this.chainblock.Add(secondTransaction);
            this.chainblock.Add(thirdTransaction);

            IEnumerable<ITransaction> expected = new List<ITransaction>()
            {
                secondTransaction,
                firstTransaction
                
            };
            IEnumerable<ITransaction> actual = this.chainblock.GetBySenderOrderedByAmountDescending("Simo");

            CollectionAssert.AreEqual(expected, actual);
        }
        [Test]
        public void GetBySenderOrderedByAmountDescendingShouldThrow()
        {
            
            Assert.Throws<InvalidOperationException>
                (() => this.chainblock.GetBySenderOrderedByAmountDescending("Simo"));
        }
        [Test]
        public void GetByReceiverOrderedByAmountThenByIdShouldWorkCorrectly()
        {
            ITransaction firstTransaction =
               new Transaction(1, TransactionStatus.Unauthorized, "Simo", "Dimo", 57.65m);
            ITransaction secondTransaction =
                new Transaction(2, TransactionStatus.Unauthorized, "Simo", "Dimo", 57.65m);
            ITransaction thirdTransaction =
                new Transaction(3, TransactionStatus.Unauthorized, "Misho", "Dimo", 59.65m);

            this.chainblock.Add(firstTransaction);
            this.chainblock.Add(secondTransaction);
            this.chainblock.Add(thirdTransaction);

            IEnumerable<ITransaction> expected = new List<ITransaction>()
            {
                thirdTransaction,
                firstTransaction,
                secondTransaction
            };
            IEnumerable<ITransaction> actual 
                = this.chainblock.GetByReceiverOrderedByAmountThenById("Dimo");

            CollectionAssert.AreEqual(expected, actual);
        }
        [Test]
        public void GetByReceiverOrderedByAmountThenByIdShouldThrow()
        {
            Assert.Throws<InvalidOperationException>(() => this.chainblock.GetByReceiverOrderedByAmountThenById("Dimo"));
        }
    }
}
