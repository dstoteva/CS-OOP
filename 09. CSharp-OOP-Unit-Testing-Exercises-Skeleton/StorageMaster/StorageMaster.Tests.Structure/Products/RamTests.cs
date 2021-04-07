using NUnit.Framework;
using StorageMaster.Entities.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace StorageMaster.Tests.Structure.Products
{
    public class RamTests
    {
        private Product ram;
        [SetUp]
        public void Setup()
        {
            this.ram = new Ram(3.45);
        }
        [Test]
        public void PricePropertySetsCorrectly()
        {
            double expectedPrice = 3.45;

            Assert.That(expectedPrice == this.ram.Price);
        }
        [Test]
        public void PricePropertyThrowsException()
        {
            Assert.Throws<InvalidOperationException>(() => this.ram = new Ram(-3.45));
        }
        [Test]
        public void RamConstructorSetsCorrectly()
        {
            Assert.That(this.ram.Price == 3.45);
            Assert.That(this.ram.Weight == 0.1);
        }
    }
}
