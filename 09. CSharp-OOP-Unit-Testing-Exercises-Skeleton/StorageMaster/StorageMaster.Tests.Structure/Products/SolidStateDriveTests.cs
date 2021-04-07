using NUnit.Framework;
using StorageMaster.Entities.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace StorageMaster.Tests.Structure.Products
{
    public class SolidStateDriveTests
    {
        private Product solidStateDrive;
        [SetUp]
        public void Setup()
        {
            this.solidStateDrive = new SolidStateDrive(3.45);
        }
        [Test]
        public void PricePropertySetsCorrectly()
        {
            double expectedPrice = 3.45;

            Assert.That(expectedPrice == this.solidStateDrive.Price);
        }
        [Test]
        public void PricePropertyThrowsException()
        {
            Assert.Throws<InvalidOperationException>(() => this.solidStateDrive = new SolidStateDrive(-3.45));
        }
        [Test]
        public void RamConstructorSetsCorrectly()
        {
            Assert.That(this.solidStateDrive.Price == 3.45);
            Assert.That(this.solidStateDrive.Weight == 0.2);
        }
    }
}
