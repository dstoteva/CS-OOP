using NUnit.Framework;
using StorageMaster.Entities.Factories;
using StorageMaster.Entities.Products;
using StorageMaster.Entities.Storage;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace StorageMaster.Tests.Structure.Factories
{
    public class ProductFactoryTests
    {
        private ProductFactory productFactory;
        [SetUp]
        public void Setup()
        {
            this.productFactory = new ProductFactory();
        }
        [Test]
        public void CreateProductWorksCorrectly()
        {
            Product gpu = this.productFactory.CreateProduct("Gpu", 2);
            Product hardDrive = this.productFactory.CreateProduct("HardDrive", 3);
            Product ram = this.productFactory.CreateProduct("Ram", 4.9);
            Product solidStateDrive = this.productFactory.CreateProduct("SolidStateDrive", 1.2);

            Assert.That(gpu is Gpu);
            Assert.That(hardDrive is HardDrive);
            Assert.That(ram is Ram);
            Assert.That(solidStateDrive is SolidStateDrive);
        }
        [Test]
        public void CreateProductThrowsExceptionForInvalidType()
        {
            Assert.Throws<InvalidOperationException>(() => this.productFactory.CreateProduct("NeshtoNevalidno", 2));
        }
        [Test]
        public void CreateProductThrowsInnerException()
        {
            //no such case???????
            Assert.Pass();
        }
    }
}
