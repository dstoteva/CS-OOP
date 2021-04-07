using NUnit.Framework;
using StorageMaster.Entities.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace StorageMaster.Tests.Structure.Products
{
    public class GpuTests
    {
        private Product gpu;
        [SetUp]
        public void Setup()
        {
            this.gpu = new Gpu(3.45);
        }
        [Test]
        public void PricePropertySetsCorrectly()
        {
            double expectedPrice = 3.45;

            Assert.That(expectedPrice == this.gpu.Price);
        }
        [Test]
        public void PricePropertyThrowsException()
        {
            Assert.Throws<InvalidOperationException>(() => this.gpu = new Gpu(-3.45));
        }
        [Test]
        public void RamConstructorSetsCorrectly()
        {
            Assert.That(this.gpu.Price == 3.45);
            Assert.That(this.gpu.Weight == 0.7);
        }
    }
}
