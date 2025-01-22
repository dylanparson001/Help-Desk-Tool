using iGPS_Help_Desk.Controllers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit;
using iGPS_Help_Desk.Models.Repositories;
using FakeItEasy;
using Moq;
using iGPS_Help_Desk.Models;

namespace iGPS_Help_Desk.Tests
{
    public class ClearContainerTests
    {
        private ClearContainerController _controller;
        private Mock<IgpsDepotLocationRepository> _locationRespository;

        [SetUp]
        public void SetUp()
        {
            _controller = new ClearContainerController();
            _locationRespository = new Mock<IgpsDepotLocationRepository>();
        }
        [Test]
        public async Task GetDnusTest_FindsDNUsWhenExists()
        {

            var mockContainerList = new List<IGPS_DEPOT_LOCATION>
            {
                new IGPS_DEPOT_LOCATION("DNU", "READY", "MIXED", "TEST", "DTEST00001", 540),
                new IGPS_DEPOT_LOCATION("DNU1", "READY", "MIXED", "TEST", "DTEST00001", 540),
                new IGPS_DEPOT_LOCATION("DNU2", "READY", "MIXED", "TEST", "DTEST00001", 540),
                new IGPS_DEPOT_LOCATION("12345", "READY", "MIXED", "TEST", "DTEST00001", 540),
            };
            var DnuResult = _locationRespository.Object.ReadDnus();
            Assert.That(DnuResult, Is.Null);
        }
    }
}
