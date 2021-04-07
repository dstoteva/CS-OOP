using NUnit.Framework;
using StorageMaster.Entities.Products;
using StorageMaster.Entities.Vehicles;
using System;
using System.Linq;

namespace Tests
{
    public class VanTests
    {
        private Vehicle van;
        [SetUp]
        public void Setup()
        {
            this.van = new Van();
        }

        [Test]
        public void VehicleLoadProductMethodShouldLoadCorrectly()
        {
            Product product = new Ram(2.57);

            this.van.LoadProduct(product);

            int expectedCount = 1;
            Product insertedProduc = this.van.Trunk.Last();

            Assert.That(expectedCount == this.van.Trunk.Count);
            Assert.That(product == insertedProduc);
        }
        [Test]
        public void VehicleLoadMethodShouldThrowException()
        {
            Product product = new Ram(2.57);
            for (int i = 0; i < 20; i++)
            {
                this.van.LoadProduct(product);
            }
            int expectedCount = 20;

            Assert.That(expectedCount == this.van.Trunk.Count);
            Assert.Throws<InvalidOperationException>(() => this.van.LoadProduct(product));
        }
        [Test]
        public void VehicleUnloadMethodShouldThrowException()
        {
            Assert.Throws<InvalidOperationException>(() => this.van.Unload());
        }
        [Test]
        public void VehicleUnloadMethodShouldWorkCorrectly()
        {
            Product product = new Ram(2.57);
            Product lastProduct = new HardDrive(3.25);
            for (int i = 0; i < 5; i++)
            {
                this.van.LoadProduct(product);
            }
            this.van.LoadProduct(lastProduct);

            Product resultProduct = this.van.Unload();
            int expectedCount = 5;

            Assert.That(expectedCount == this.van.Trunk.Count);
            Assert.That(lastProduct == resultProduct);
        }
        [Test]
        public void IsEmptyReturnsTrue()
        {
            var result = this.van.IsEmpty;

            Assert.IsTrue(result);
        }
        [Test]
        public void IsEmptyReturnsFalse()
        {
            Product product = new Ram(2.57);
            this.van.LoadProduct(product);

            var result = this.van.IsEmpty;

            Assert.IsFalse(result);
        }
        [Test]
        public void IsFullReturnsTrue()
        {
            Product product = new HardDrive(3);
            this.van.LoadProduct(product);
            this.van.LoadProduct(product);

            var result = this.van.IsFull;

            Assert.IsTrue(result);
        }
        [Test]
        public void IsFullReturnsFalse()
        {
            Product product = new Ram(2.57);
            this.van.LoadProduct(product);

            var result = this.van.IsFull;

            Assert.IsFalse(result);
        }
        [Test]
        public void CapacityIsSetCorrecly()
        {
            Assert.That(2 == this.van.Capacity);
        }
        [Test]
        public void TrunkPropertyReturnsCorrectData()
        {
            Assert.That(0 == this.van.Trunk.Count);
        }
    }
}