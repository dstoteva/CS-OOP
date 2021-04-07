using NUnit.Framework;
using StorageMaster.Core;
using StorageMaster.Entities.Products;
using StorageMaster.Entities.Storage;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Tests
{
    public class StorageMasterTests
    {
        private StorageMaster.Core.StorageMaster storageMaster;
        [SetUp]
        public void Setup()
        {
            this.storageMaster = new StorageMaster.Core.StorageMaster();
        }

        [Test]
        [TestCase("Gpu", 0.3)]
        [TestCase("Ram", 9)]
        [TestCase("HardDrive", 2.4)]
        [TestCase("SolidStateDrive", 3.35)]
        public void AddProductMethodWorksCorrectly(string type, double price)
        {
            var productsPoolField = typeof(StorageMaster.Core.StorageMaster)
                .GetField("productsPool", BindingFlags.Instance | BindingFlags.NonPublic)
                .GetValue(this.storageMaster);

            var dict = productsPoolField as Dictionary<string, Stack<Product>>;
            this.storageMaster.AddProduct(type, price);
            string expectedOutput = $"Added {type} to pool";
            int expectedCount = 2;

            Assert.AreEqual(expectedOutput, this.storageMaster.AddProduct(type, price));
            Assert.AreEqual(expectedCount, dict[type].Count);
        }
        [Test]
        [TestCase("AutomatedWarehouse", "AutomatedWarehouseTest")]
        [TestCase("DistributionCenter", "DistributionCenterTest")]
        [TestCase("Warehouse", "WarehouseTest")]
        public void RegisterStorageMethodWorksCorrectly(string type, string name)
        {
            string expectedOutput = $"Registered {name}";

            Assert.AreEqual(expectedOutput, this.storageMaster.RegisterStorage(type, name));
        }
        [Test]
        [TestCase("AutomatedWarehouse", "AutomatedWarehouseTest", 0, "Truck")]
        [TestCase("DistributionCenter", "DistributionCenterTest", 1, "Van")]
        [TestCase("Warehouse", "WarehouseTest", 2, "Semi")]
        public void SelectVehicleMethodWorksCorrectly(string type, string storageName, int slot, string vehicleType)
        {
            this.storageMaster.RegisterStorage(type, storageName);

            string expectedOutput = $"Selected {vehicleType}";

            Assert.AreEqual(expectedOutput, this.storageMaster.SelectVehicle(storageName, slot));
        }
        [Test]
        [TestCase("AutomatedWarehouse", "AutomatedWarehouseTest", "Truck", 6)]
        [TestCase("DistributionCenter", "DistributionCenterTest", "Van", 3)]
        [TestCase("Warehouse", "WarehouseTest", "Semi", 11)]
        public void LoadVehicleMethodWorksCorrectly(string storageType, string storageName, string vehicle, int count)
        {
            List<string> products = new List<string>();
            //Adding products to the productPool and to the List
            for (int i = 0; i < count; i++)
            {
                this.storageMaster.AddProduct("HardDrive", 1.2);
                products.Add("HardDrive");
            }
            //Registering storage
            this.storageMaster.RegisterStorage(storageType, storageName);
            //Selecting currentVehicle
            this.storageMaster.SelectVehicle(storageName, 0);
            //expectedOutput for loading vehicle capacity + 1 products
            string expectedOutput = $"Loaded {count - 1}/{count} products into {vehicle}";

            Assert.AreEqual(expectedOutput, this.storageMaster.LoadVehicle(products));
        }
        [Test]
        [TestCase("AutomatedWarehouse", "AutomatedWarehouseTest")]
        [TestCase("DistributionCenter", "DistributionCenterTest")]
        [TestCase("Warehouse", "WarehouseTest")]
        public void LoadVehicleMethodThrowsExceptionForNotExistingProduct(string storageType, string storageName)
        {
            List<string> products = new List<string>();
            products.Add("HardDrive");
            this.storageMaster.AddProduct("Gpu", 1.2);
            this.storageMaster.RegisterStorage(storageType, storageName);
            this.storageMaster.SelectVehicle(storageName, 0);

            Assert.Throws<InvalidOperationException>(() => this.storageMaster.LoadVehicle(products), "Gpu is out of stock!");
        }
        [Test]
        [TestCase("AutomatedWarehouse", "AutomatedWarehouseTest", 0, 1, 5)]
        [TestCase("DistributionCenter", "DistributionCenterTest", 1, 2, 2)]
        [TestCase("Warehouse", "WarehouseTest", 2, 10, 10)]
        public void UnloadVehicleMethodWorksCorrecly(string storageType, string storageName, int slot, int expectedCount, int productsCount)
        {
            List<string> products = new List<string>();

            this.storageMaster.RegisterStorage(storageType, storageName);
            for (int i = 0; i < productsCount; i++)
            {
                this.storageMaster.AddProduct("HardDrive", 1.2);
                products.Add("HardDrive");
            }
            this.storageMaster.SelectVehicle(storageName, slot);
            this.storageMaster.LoadVehicle(products);

            string expectedOutput = $"Unloaded {expectedCount}/{productsCount} products at {storageName}";

            Assert.AreEqual(expectedOutput, this.storageMaster.UnloadVehicle(storageName, slot));
        }
        [Test]
        public void SendVehicleToMethodWorksCorrectly()
        {
            this.storageMaster.RegisterStorage("AutomatedWarehouse", "AutomatedWarehouseTest");
            this.storageMaster.RegisterStorage("DistributionCenter", "DistributionCenterTest");

            string expectedOutput = $"Sent Truck to DistributionCenterTest (slot 3)";

            Assert.AreEqual(expectedOutput, this.storageMaster.SendVehicleTo("AutomatedWarehouseTest", 0, "DistributionCenterTest"));
        }
        [Test]
        public void SendVehicleToMethodWorksThrowsExceptionForNotExistingStorage()
        {
            this.storageMaster.RegisterStorage("AutomatedWarehouse", "AutomatedWarehouseTest");

            Assert.Throws<InvalidOperationException>(() => this.storageMaster.SendVehicleTo("AutomatedWarehouseTest", 0, "DistributionCenterTest"));
            Assert.Throws<InvalidOperationException>(() => this.storageMaster.SendVehicleTo("DistributionCenterTest", 0, "AutomatedWarehouseTest"));

        }
        [Test]
        [TestCase("DistributionCenter", "DistributionCenterTest", 2, "Van")]
        public void GetStorageStatusMethodWorkCorrectly(string storageType, string storageName, int capacity, string vehicle)
        {
            this.storageMaster.RegisterStorage(storageType, storageName);

            List<string> products = new List<string>();
            products.Add("Gpu");
            this.storageMaster.AddProduct("Gpu", 4);
            products.Add("Ram");
            this.storageMaster.AddProduct("Ram", 0.3);
            products.Add("HardDrive");
            this.storageMaster.AddProduct("HardDrive", 9.9);
            this.storageMaster.SelectVehicle(storageName, 0);
            this.storageMaster.LoadVehicle(products);
            this.storageMaster.UnloadVehicle(storageName, 0);

            string expectedOutput = $"Stock (1.8/{capacity}): [Gpu (1), HardDrive (1), Ram (1)]" + Environment.NewLine +
                $"Garage: [{vehicle}|{vehicle}|{vehicle}|empty|empty]";

            Assert.AreEqual(expectedOutput, this.storageMaster.GetStorageStatus(storageName));
        }
    }
}