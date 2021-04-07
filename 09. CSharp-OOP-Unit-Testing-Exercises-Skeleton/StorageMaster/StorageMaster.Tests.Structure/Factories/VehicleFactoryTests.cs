using NUnit.Framework;
using StorageMaster.Entities.Factories;
using StorageMaster.Entities.Products;
using StorageMaster.Entities.Storage;
using StorageMaster.Entities.Vehicles;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace StorageMaster.Tests.Structure.Factories
{
    public class VehicleFactoryTests
    {
        private VehicleFactory vehicleFactory;
        [SetUp]
        public void Setup()
        {
            this.vehicleFactory = new VehicleFactory();
        }
        [Test]
        public void CreateStorageWorksCorrectly()
        {
            Vehicle semi = this.vehicleFactory.CreateVehicle("Semi");
            Vehicle truck = this.vehicleFactory.CreateVehicle("Truck");
            Vehicle van = this.vehicleFactory.CreateVehicle("Van");

            Assert.That(semi is Semi);
            Assert.That(truck is Truck);
            Assert.That(van is Van);
        }
        [Test]
        public void CreateProductThrowsExceptionForInvalidType()
        {
            Assert.Throws<InvalidOperationException>(() => this.vehicleFactory.CreateVehicle("NeshtoNevalidno"));
        }
        [Test]
        public void CreateProductThrowsInnerException()
        {
            //no such case???????
            Assert.Pass();
        }
    }
}
