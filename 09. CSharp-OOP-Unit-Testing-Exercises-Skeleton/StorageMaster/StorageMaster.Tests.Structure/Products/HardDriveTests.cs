using NUnit.Framework;
using StorageMaster.Entities.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace StorageMaster.Tests.Structure.Products
{
    public class HardDriveTests
    {
        private Product hardDrive;
        [SetUp]
        public void Setup()
        {
            this.hardDrive = new HardDrive(3.45);
        }
        [Test]
        public void PricePropertySetsCorrectly()
        {
            double expectedPrice = 3.45;

            Assert.That(expectedPrice == this.hardDrive.Price);
        }
        [Test]
        public void PricePropertyThrowsException()
        {
            Assert.Throws<InvalidOperationException>(() => this.hardDrive = new HardDrive(-3.45));
        }
        [Test]
        public void RamConstructorSetsCorrectly()
        {
            Assert.That(this.hardDrive.Price == 3.45);
            Assert.That(this.hardDrive.Weight == 1);
        }
    }
}
