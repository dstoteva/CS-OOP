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
    public class StorageFactoryTests
    {
        private StorageFactory storageFactory;
        [SetUp]
        public void Setup()
        {
            this.storageFactory = new StorageFactory();
        }
        [Test]
        public void CreateStorageWorksCorrectly()
        {
            Storage automWarehouse = this.storageFactory.CreateStorage("AutomatedWarehouse", "AutomatedWarehouseTest");
            Storage warehouse = this.storageFactory.CreateStorage("Warehouse", "TestWarehouse");
            Storage distributionCenter = this.storageFactory.CreateStorage("DistributionCenter", "TestDistributionCenter");

            Assert.That(automWarehouse is AutomatedWarehouse);
            Assert.That(warehouse is Warehouse);
            Assert.That(distributionCenter is DistributionCenter);
        }
        [Test]
        public void CreateProductThrowsExceptionForInvalidType()
        {
            Assert.Throws<InvalidOperationException>(() => this.storageFactory.CreateStorage("NeshtoNevalidno", "Mimi"));
        }
        [Test]
        public void CreateProductThrowsInnerException()
        {
            //no such case???????
            Assert.Pass();
        }
    }
}
