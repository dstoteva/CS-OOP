using NUnit.Framework;
using StorageMaster.Entities.Products;
using StorageMaster.Entities.Storage;
using StorageMaster.Entities.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace StorageMaster.Tests.Structure.StorageTests
{
    public class DistributionCenterTests
    {
        protected Storage storage;
        [SetUp]
        public void Setup()
        {
            this.storage = new DistributionCenter("TestStorage");
        }
        [Test]
        public void AddVehicleMethodAddsCorrctly()
        {
            Vehicle semi = new Semi();
            var method = typeof(Storage).GetMethod("AddVehicle", BindingFlags.Instance | BindingFlags.NonPublic);
            int garageSlot = (int)method.Invoke(storage, new object[] { semi });

            Assert.That(garageSlot == 3);
            Assert.That(this.storage.GetVehicle(3) is Semi);
        }

        [Test]
        [TestCase(3)]
        [TestCase(5)]
        public void GetVehicleMethodThrowsExceptionsForInvalidOrEmptySlot(int slot)
        {
            Assert.Throws<InvalidOperationException>(() => this.storage.GetVehicle(slot));
        }

        [Test]
        public void SendVehicleToMethodWorksCorrectly()
        {
            Storage targetStorage = new DistributionCenter("TargetStorage");
            int expectedSlotIndex = 3;

            Assert.AreEqual(expectedSlotIndex, storage.SendVehicleTo(0, targetStorage));
        }
        [Test]
        public void SendVehicleToMethodThrowsExceptionForFullStorage()
        {
            Storage targetStorage = new DistributionCenter("TargetStorage");
            Vehicle van = new Van();
            var method = typeof(Storage).GetMethod("AddVehicle", BindingFlags.Instance | BindingFlags.NonPublic);
            method.Invoke(targetStorage, new object[] { van });
            method.Invoke(targetStorage, new object[] { van });


            Assert.Throws<InvalidOperationException>(() => storage.SendVehicleTo(0, targetStorage));
        }
        [Test]
        public void UnloadVehicleMethodWorksCorrectly()
        {
            SolidStateDrive solidStateDrive = new SolidStateDrive(3);
            this.storage.GetVehicle(1).LoadProduct(solidStateDrive);
            this.storage.GetVehicle(1).LoadProduct(solidStateDrive);

            int expectedCount = 2;

            Assert.AreEqual(expectedCount, this.storage.UnloadVehicle(1));
        }
        [Test]
        public void UnloadVehicleMethodThrowsExceptionForFullStorage()
        {
            HardDrive hardDrive = new HardDrive(1.4);
            this.storage.GetVehicle(0).LoadProduct(hardDrive);
            this.storage.GetVehicle(0).LoadProduct(hardDrive);

            //Unloading the van, IsFull == true
            this.storage.UnloadVehicle(0);

            this.storage.GetVehicle(0).LoadProduct(hardDrive);

            Assert.Throws<InvalidOperationException>(() => this.storage.UnloadVehicle(0));
        }
        [Test]
        public void IsFullMethodReturnsTrue()
        {
            HardDrive hardDrive = new HardDrive(1.4);
            this.storage.GetVehicle(1).LoadProduct(hardDrive);
            this.storage.GetVehicle(1).LoadProduct(hardDrive);

            this.storage.UnloadVehicle(1);

            Assert.IsTrue(this.storage.IsFull);
        }
        [Test]
        public void IsFullMethodReturnsFalse()
        {
            Assert.IsFalse(this.storage.IsFull);
        }
    }
}
