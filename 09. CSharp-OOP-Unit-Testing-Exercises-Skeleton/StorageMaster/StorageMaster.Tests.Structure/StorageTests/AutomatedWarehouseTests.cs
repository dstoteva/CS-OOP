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
    public class AutomatedWarehouseTests
    {
        protected Storage storage;
        [SetUp]
        public void Setup()
        {
            this.storage = new AutomatedWarehouse("TestStorage");
        }
        [Test]
        public void AddVehicleMethodAddsCorrctly()
        {
            Vehicle van = new Van();
            var method = typeof(Storage).GetMethod("AddVehicle", BindingFlags.Instance | BindingFlags.NonPublic);
            int garageSlot = (int)method.Invoke(storage, new object[] { van});

            Assert.That(garageSlot == 1);
            Assert.That(this.storage.GetVehicle(1) is Van);
        }
        [Test]
        [TestCase(1)]
        [TestCase(2)]
        public void GetVehicleMethodThrowsExceptionsForInvalidOrEmptySlot(int slot)
        {
            Assert.Throws<InvalidOperationException>(() => this.storage.GetVehicle(slot));
        }

        [Test]
        public void SendVehicleToMethodWorksCorrectly()
        {
            Storage targetStorage = new AutomatedWarehouse("TargetStorage");
            int expectedSlotIndex = 1;

            Assert.AreEqual(expectedSlotIndex, storage.SendVehicleTo(0, targetStorage));
        }
        [Test]
        public void SendVehicleToMethodThrowsExceptionForFullStorage()
        {
            Storage targetStorage = new AutomatedWarehouse("TargetStorage");
            Vehicle van = new Van();
            var method = typeof(Storage).GetMethod("AddVehicle", BindingFlags.Instance | BindingFlags.NonPublic);
            method.Invoke(targetStorage, new object[] { van });

            Assert.Throws<InvalidOperationException>(() => storage.SendVehicleTo(0, targetStorage));
        }

        
        [Test]
        //This method is exceptionally done with reflection because of reasons!
        //https://stackoverflow.com/questions/14349512/unit-test-fails-on-run-all-but-not-on-run-selected-tests-with-all-selected
        public void UnloadVehicleMethodWorksCorrectly()
        {
            SolidStateDrive solidStateDrive = new SolidStateDrive(3);
            Vehicle van = new Van();
            var method = typeof(Storage).GetMethod("AddVehicle", BindingFlags.Instance | BindingFlags.NonPublic);
            int garageSlot = (int)method.Invoke(storage, new object[] { van });
            this.storage.GetVehicle(1).LoadProduct(solidStateDrive);

            int expectedCount = 1;

            Assert.AreEqual(expectedCount, this.storage.UnloadVehicle(1));
        }
        [Test]
        public void UnloadVehicleMethodThrowsExceptionForFullStorage()
        {
            HardDrive hardDrive = new HardDrive(1.4);
            this.storage.GetVehicle(0).LoadProduct(hardDrive);

            //Unloading the truck, IsFull == true
            this.storage.UnloadVehicle(0);

            this.storage.GetVehicle(0).LoadProduct(hardDrive);

            Assert.Throws<InvalidOperationException>(() => this.storage.UnloadVehicle(0));
        }
        [Test]
        public void IsFullMethodReturnsTrue()
        {
            HardDrive hardDrive = new HardDrive(2);
            this.storage.GetVehicle(0).LoadProduct(hardDrive);

            this.storage.UnloadVehicle(0);

            Assert.IsTrue(this.storage.IsFull);
        }
        [Test]
        public void IsFullMethodReturnsFalse()
        {
            Assert.IsFalse(this.storage.IsFull);
        }
    }
}
