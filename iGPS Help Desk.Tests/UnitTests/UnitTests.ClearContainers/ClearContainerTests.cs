using iGPS_Help_Desk.Controllers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Moq;
using iGPS_Help_Desk.Models;
using iGPS_Help_Desk.Interfaces;

namespace iGPS_Help_Desk.Tests.UnitTests.ClearContainers
{
    public class ClearContainerTests
    {
        private ClearContainerController _controller;
        private Mock<IIgpsDepotGlnRepository> _mockDepoGlntRespository;
        private Mock<IIgpsDepotLocationRepository> _mockDepotLocationRepository;
        [SetUp]
        public void SetUp()
        {
            _mockDepoGlntRespository = new Mock<IIgpsDepotGlnRepository>();
            _mockDepotLocationRepository = new Mock<IIgpsDepotLocationRepository>();
            _controller = new ClearContainerController(_mockDepoGlntRespository.Object, _mockDepotLocationRepository.Object);
        }

        /// <summary>
        /// Checks that the methods to delete grais do in fact run if all lists are valid (Not null)
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task ClearContainerTest_ValidList_DeletesBoth()
        {
            // Arrange
            var listOfGlns = new List<string>
            {
                "1234",
                "12345",
                "123456",
                "1234567"
            };

            // Fake existing grais
            var existingGrais = new List<IGPS_DEPOT_GLN>()
                {
                        new IGPS_DEPOT_GLN("1234", "432", DateTime.Now),
                        new IGPS_DEPOT_GLN("1234", "5432", DateTime.Now),
                        new IGPS_DEPOT_GLN("Test", "6543", DateTime.Now),
                        new IGPS_DEPOT_GLN("Test1", "7657", DateTime.Now),
                };

            // Fake Existing Containers 
            var existingContainers = new List<IGPS_DEPOT_LOCATION>
            {
                        new IGPS_DEPOT_LOCATION("1234", "READY", "MIXED", "Test", "DTEST00001", 540),
                        new IGPS_DEPOT_LOCATION("Test", "READY", "MIXED", "Test", "DTEST00001", 540),
                        new IGPS_DEPOT_LOCATION("Test1", "READY", "MIXED", "Test", "DTEST00001", 540),

            };

            // Mock methods
            // Returns a count of all GRAIs in table
            _mockDepoGlntRespository.Setup(x =>
                x.GetCountOfTable())
                .ReturnsAsync(It.IsAny<int>()
                );

            // Returns a list of Grais from IGPS_DEPOT_GLN
            _mockDepoGlntRespository.Setup(x =>
            x.ReadContainersFromList(It.IsAny<string>()))
                .ReturnsAsync(() =>
                new List<IGPS_DEPOT_GLN>()
                {
                        new IGPS_DEPOT_GLN("1234", "432", DateTime.Now),
                        new IGPS_DEPOT_GLN("Test", "6543", DateTime.Now),
                        new IGPS_DEPOT_GLN("Test1", "7657", DateTime.Now),
                }
                );

            // Returns exisitn container list
            _mockDepotLocationRepository.Setup(x =>
            x.ReadContainersFromList(It.IsAny<List<string>>()))
                .ReturnsAsync(() =>
                existingContainers
                );



            _controller = new ClearContainerController(_mockDepoGlntRespository.Object, _mockDepotLocationRepository.Object);
            // Act
            _controller.ClearContainers(listOfGlns);

            // Assert
            // Delete GRAIs should run once when lists are valid
            _mockDepoGlntRespository.Verify(repo => repo.DeleteGlnsFromList(It.IsAny<string>()), Times.Once);
            _mockDepotLocationRepository.Verify(repo => repo.DeleteContainersFromList(It.IsAny<string>()), Times.Exactly(1));

        }

        /// <summary>
        /// Sends and empty list to controller, controller checks for empty list and takes no action
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task ClearContainer_EmptyList_NoDeletesHappen()
        {
            // Arrange
            // Null List
            var listOfGlns = new List<string>();

            //Act
            _controller.ClearContainers(listOfGlns);

            //Assert
            _mockDepoGlntRespository.Verify(repo => repo.DeleteGlnsFromList(It.IsAny<string>()), Times.Never);
            _mockDepotLocationRepository.Verify(repo => repo.DeleteContainersFromList(It.IsAny<string>()), Times.Never);
        }

        /// <summary>
        /// Test for controller where repos return 3 DNU containers
        /// </summary>
        /// <returns></returns>

        [Test]
        public async Task GetDnusTest_FindsDNUsWhenExists()
        {
            // Arrange

            // mock repos to send valid lists
            _mockDepoGlntRespository.Setup(x =>
                x.ReadContainersFromList(It.IsAny<string>()))
                .ReturnsAsync(() =>
                    new List<IGPS_DEPOT_GLN>()
                    {
                        new IGPS_DEPOT_GLN("DNU", "123", DateTime.Now),
                        new IGPS_DEPOT_GLN("DNU", "1234", DateTime.Now),
                        new IGPS_DEPOT_GLN("DNU", "1245", DateTime.Now),
                    });

            _mockDepotLocationRepository.Setup(x =>
                x.ReadContainersFromList(It.IsAny<List<string>>()))
                .ReturnsAsync(() =>
                    new List<IGPS_DEPOT_LOCATION>()
                    {
                        new IGPS_DEPOT_LOCATION("123", "READY", "MIXED", "DNU", "DTEST00001", 540),
                        new IGPS_DEPOT_LOCATION("123", "READY", "MIXED", "DNU", "DTEST00001", 540),
                        new IGPS_DEPOT_LOCATION("123", "READY", "MIXED", "DNU", "DTEST00001", 540)

                    }
                );
            _mockDepotLocationRepository.Setup(x =>
                x.ReadDnus())
                .ReturnsAsync(() =>
                    new List<string>()
                    {
                        "DNU",
                        "DNU",
                        "DNU"
                    }
                );

            _controller = new ClearContainerController(_mockDepoGlntRespository.Object, _mockDepotLocationRepository.Object);

            var dnuTestResult = await _controller.GetDnus();

            Assert.That(dnuTestResult.Item1, Has.Count.EqualTo(3));
        }

        /// <summary>
        /// Test for filtering method finding DNUs from a potential list that may not have them, realistically shouldnt happen 
        /// </summary>
        /// <returns></returns>
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
        [Test]
        public async Task GetDNUsTest_NoDNUsInListSent_ExceptionThrownNoDNUsFound()
        {
            // Arrange
            var mockContainerList = new List<IGPS_DEPOT_LOCATION>
            {
                new IGPS_DEPOT_LOCATION("12345", "READY", "MIXED", "Test", "DTEST00001", 540),
                new IGPS_DEPOT_LOCATION("12346", "READY", "MIXED", "Tes2", "DTEST00001", 540),
                new IGPS_DEPOT_LOCATION("12347", "READY", "MIXED", "Test1", "DTEST00001", 540),
                new IGPS_DEPOT_LOCATION("12348", "READY", "MIXED", "Test4", "DTEST00001", 540),
            };

            // Act & Assert
            var exception = Assert.Throws<Exception>(() =>
                {
                    _controller.CheckDnusFromList(mockContainerList.Select(x => x.Description).ToList());
                }
            );

            Assert.That(exception.Message, Is.EqualTo("No DNUs Found"));

        }
    }
}