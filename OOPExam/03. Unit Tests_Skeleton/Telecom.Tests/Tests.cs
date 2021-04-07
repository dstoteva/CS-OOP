namespace Telecom.Tests
{
    using NUnit.Framework;
    using System;

    public class Tests
    {
        private Phone testPhone;
        [SetUp]
        public void Setup()
        {
            this.testPhone = new Phone("2003", "Sony");
        }
        [Test]
        [TestCase("")]
        [TestCase(null)]

        public void MakePropertyThrowsArgumentExceptionForInvalidValue(string make)
        {
            Assert.Throws<ArgumentException>(() => new Phone(make, "Sony"));
        }
        [Test]
        [TestCase("")]
        [TestCase(null)]

        public void ModelPropertyThrowsArgumentExceptionForInvalidValue(string model)
        {
            Assert.Throws<ArgumentException>(() => new Phone("2003", model));
        }
        [Test]
        public void ConstructorSetsCorrectly()
        {
            string expectedMake = "2003";
            string expectedModel = "Sony";

            Assert.AreEqual(expectedMake, this.testPhone.Make);
            Assert.AreEqual(expectedModel, this.testPhone.Model);
        }
        [Test]
        public void CountPropertyGetsCorrectCount()
        {
            for (int i = 0; i < 5; i++)
            {
                this.testPhone.AddContact($"{i}", "08474759505" + $"{i}");
            }

            int expectedCount = 5;
            Assert.AreEqual(expectedCount, this.testPhone.Count);
        }
        [Test]
        public void AddContactThrowsInvalidOperationExceptionForExistingContact()
        {
            this.testPhone.AddContact("Mimi", "5678");
            Assert.Throws<InvalidOperationException>(() => this.testPhone.AddContact("Mimi", "5678"));
        }
        [Test]
        public void CallThrowsInvalidOperationExceptionForNotExistingContact()
        {
            Assert.Throws<InvalidOperationException>(() => this.testPhone.Call("Desi"));
        }
        [Test]
        public void CallWorksCorrectly()
        {
            this.testPhone.AddContact("Mimi", "5678");
            string expectedOutput = "Calling Mimi - 5678...";

            Assert.AreEqual(expectedOutput, this.testPhone.Call("Mimi"));
        }
    }
}