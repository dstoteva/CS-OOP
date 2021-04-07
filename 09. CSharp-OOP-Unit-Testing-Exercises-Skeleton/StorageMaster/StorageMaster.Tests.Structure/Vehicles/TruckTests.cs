using NUnit.Framework;
using StorageMaster.Entities.Products;
using StorageMaster.Entities.Vehicles;
using System;
using System.Linq;

namespace Tests
{
    public class TruckTests
    {
        private Vehicle truck;
        [SetUp]
        public void Setup()
        {
            this.truck = new Truck();
        }

        [Test]
        public void VehicleLoadProductMethodShouldLoadCorrectly()
        {
            Product product = new Ram(2.57);

            this.truck.LoadProduct(product);

            int expectedCount = 1;
            Product insertedProduc = this.truck.Trunk.Last();

            Assert.That(expectedCount == this.truck.Trunk.Count);
            Assert.That(product == insertedProduc);
        }
        [Test]
        public void VehicleLoadMethodShouldThrowException()
        {
            Product product = new HardDrive(2.57);
            for (int i = 0; i < 5; i++)
            {
                this.truck.LoadProduct(product);
            }
            int expectedCount = 5;

            Assert.That(expectedCount == this.truck.Trunk.Count);
            Assert.Throws<InvalidOperationException>(() => this.truck.LoadProduct(product));
        }
        [Test]
        public void VehicleUnloadMethodShouldThrowException()
        {
            Assert.Throws<InvalidOperationException>(() => this.truck.Unload());
        }
        [Test]
        public void VehicleUnloadMethodShouldWorkCorrectly()
        {
            Product product = new Ram(2.57);
            Product lastProduct = new HardDrive(3.25);
            for (int i = 0; i < 5; i++)
            {
                this.truck.LoadProduct(product);
            }
            this.truck.LoadProduct(lastProduct);

            Product resultProduct = this.truck.Unload();
            int expectedCount = 5;

            Assert.That(expectedCount == this.truck.Trunk.Count);
            Assert.That(lastProduct == resultProduct);
        }
        [Test]
        public void IsEmptyReturnsTrue()
        {
            var result = this.truck.IsEmpty;

            Assert.IsTrue(result);
        }
        [Test]
        public void IsEmptyReturnsFalse()
        {
            Product product = new Ram(2.57);
            this.truck.LoadProduct(product);

            var result = this.truck.IsEmpty;

            Assert.IsFalse(result);
        }
        [Test]
        public void IsFullReturnsTrue()
        {
            Product product = new HardDrive(3);

            for (int i = 0; i < 5; i++)
            {
                this.truck.LoadProduct(product);
            }

            var result = this.truck.IsFull;

            Assert.IsTrue(result);
        }
        [Test]
        public void IsFullReturnsFalse()
        {
            Product product = new Ram(2.57);
            this.truck.LoadProduct(product);

            var result = this.truck.IsFull;

            Assert.IsFalse(result);
        }
        [Test]
        public void CapacityIsSetCorrecly()
        {
            Assert.That(5 == this.truck.Capacity);
        }
        [Test]
        public void TrunkPropertyReturnsCorrectData()
        {
            Assert.That(0 == this.truck.Trunk.Count);
        }
    }
}