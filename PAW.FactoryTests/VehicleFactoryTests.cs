using Microsoft.VisualStudio.TestTools.UnitTesting;
using PAW.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAW.Factory.Tests
{
    [TestClass()]
    public class VehicleFactoryTests
    {
        [TestMethod()]
        public void CreateToyotaTest()
        {
            var vehicle = VehicleFactory.Create("toyota");
            Assert.IsNotNull(vehicle);
            Assert.IsTrue(vehicle.Model == "Generic");
        }

        [TestMethod()]
        public void CreateFordTest()
        {
            var vehicle = VehicleFactory.Create("ford");
            Assert.IsNotNull(vehicle);
            Assert.IsTrue(vehicle.Model == "Generic");
        }

        [TestMethod()]
        public void CreateHondaTest()
        {
            var vehicle = VehicleFactory.Create("honda");
            Assert.IsNotNull(vehicle);
            Assert.IsTrue(vehicle.Model == "Generic");
        }
    }
}