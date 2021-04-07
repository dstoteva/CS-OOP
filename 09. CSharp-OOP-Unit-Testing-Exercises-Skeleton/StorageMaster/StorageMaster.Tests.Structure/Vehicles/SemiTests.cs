using NUnit.Framework;
using StorageMaster.Entities.Products;
using StorageMaster.Entities.Vehicles;
using System;
using System.Linq;

namespace Tests
{
    public class SemiTests
    {
        private Vehicle semi;
        [SetUp]
        public void Setup()
        {
            this.semi = new Semi();
        }

        [Test]
        public void VehicleLoadProductMethodShouldLoadCorrectly()
        {
            Product product = new Ram(2.57);

            this.semi.LoadProduct(product);

            int expectedCount = 1;
            Product insertedProduc = this.semi.Trunk.Last();

            Assert.That(expectedCount == this.semi.Trunk.Count);
            Assert.That(product == insertedProduc);
        }
        [Test]
        public void VehicleLoadMethodShouldThrowException()
        {
            Product product = new HardDrive(2.57);
            for (int i = 0; i < 10; i++)
            {
                this.semi.LoadProduct(product);
            }
            int expectedCount = 10;

            Assert.That(expectedCount == this.semi.Trunk.Count);
            Assert.Throws<InvalidOperationException>(() => this.semi.LoadProduct(product));
        }
        [Test]
        public void VehicleUnloadMethodShouldThrowException()
        {
            Assert.Throws<InvalidOperationException>(() => this.semi.Unload());
        }
        [Test]
        public void VehicleUnloadMethodShouldWorkCorrectly()
        {
            Product product = new Ram(2.57);
            Product lastProduct = new HardDrive(3.25);
            for (int i = 0; i < 5; i++)
            {
                this.semi.LoadProduct(product);
            }
            this.semi.LoadProduct(lastProduct);

            Product resultProduct = this.semi.Unload();
            int expectedCount = 5;

            Assert.That(expectedCount == this.semi.Trunk.Count);
            Assert.That(lastProduct == resultProduct);
        }
        [Test]
        public void IsEmptyReturnsTrue()
        {
            var result = this.semi.IsEmpty;

            Assert.IsTrue(result);
        }
        [Test]
        public void IsEmptyReturnsFalse()
        {
            Product product = new Ram(2.57);
            this.semi.LoadProduct(product);

            var result = this.semi.IsEmpty;

            Assert.IsFalse(result);
        }
        [Test]
        public void IsFullReturnsTrue()
        {
            Product product = new HardDrive(3);

            for (int i = 0; i < 10; i++)
            {
                this.semi.LoadProduct(product);
            }

            var result = this.semi.IsFull;

            Assert.IsTrue(result);
        }
        [Test]
        public void IsFullReturnsFalse()
        {
            Product product = new Ram(2.57);
            this.semi.LoadProduct(product);

            var result = this.semi.IsFull;

            Assert.IsFalse(result);
        }
        [Test]
        public void CapacityIsSetCorrecly()
        {
            Assert.That(10 == this.semi.Capacity);
        }
        [Test]
        public void TrunkPropertyReturnsCorrectData()
        {
            Assert.That(0 == this.semi.Trunk.Count);
        }
    }
}