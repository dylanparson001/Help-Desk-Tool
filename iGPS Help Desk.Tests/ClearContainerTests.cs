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
        public async Task GetDnusTest_FindsDNUsWhenExists_UpperCase()
        {
            // Arrange
            var mockContainerList = new List<IGPS_DEPOT_LOCATION>
            {
                new IGPS_DEPOT_LOCATION("12345", "READY", "MIXED", "DNU", "DTEST00001", 540),
                new IGPS_DEPOT_LOCATION("12346", "READY", "MIXED", "nodnu", "DTEST00001", 540),
                new IGPS_DEPOT_LOCATION("12347", "READY", "MIXED", "DnU", "DTEST00001", 540),
                new IGPS_DEPOT_LOCATION("12348", "READY", "MIXED", "dNuuu", "DTEST00001", 540),
            };

            // Act
            var dnuResultList = _controller.CheckDnusFromList(mockContainerList.Select(x => x.Description).ToList());
            
            // Assert
            Assert.That(dnuResultList.Count, Is.EqualTo(4));
            Assert.That(dnuResultList.Where(x => !x.ToUpper().Contains("DNU")), Is.Empty);
        }
        [Test]
        public async Task GetDNUsTest_HasOneDnuReturned()
        {
            // Arrange
            var mockContainerList = new List<IGPS_DEPOT_LOCATION>
            {
                new IGPS_DEPOT_LOCATION("12345", "READY", "MIXED", "dnu", "DTEST00001", 540),
                new IGPS_DEPOT_LOCATION("12346", "READY", "MIXED", "no", "DTEST00001", 540),
                new IGPS_DEPOT_LOCATION("12347", "READY", "MIXED", "", "DTEST00001", 540),
                new IGPS_DEPOT_LOCATION("12348", "READY", "MIXED", "", "DTEST00001", 540),
            };

            // Act
            var dnuResultList = _controller.CheckDnusFromList(mockContainerList.Select(x => x.Description).ToList());
            
            // Assert
            Assert.That(dnuResultList.Count, Is.EqualTo(1));
        }
    }
}
