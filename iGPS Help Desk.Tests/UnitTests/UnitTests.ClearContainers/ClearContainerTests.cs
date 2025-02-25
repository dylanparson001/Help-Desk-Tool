using iGPS_Help_Desk.Controllers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using iGPS_Help_Desk.Models;
using iGPS_Help_Desk.Interfaces;
using NSubstitute;
using Serilog;
using NSubstitute.Core.Arguments;
using iGPS_Help_Desk.Logger;

namespace iGPS_Help_Desk.Tests.UnitTests.ClearContainers
{
    public class ClearContainerTests
    {
        private ClearContainerController _controller;

        #region repos

        private IIgpsDepotGlnRepository _mockDepoGlnRespository;
        private IIgpsDepotLocationRepository _mockDepotLocationRepository;

        #endregion

        #region logger

        private ILogger _mockLogger;
        private ILoggerFactory _mockLoggerFactory;

        #endregion

        #region private variables
        private List<string> _listOfGlns;

        private List<IGPS_DEPOT_GLN> _existingGrais;

        private List<IGPS_DEPOT_LOCATION> _existingContainers;

        #endregion

        #region setup
        [SetUp]
        public void SetUp()
        {
            _mockDepoGlnRespository = Substitute.For<IIgpsDepotGlnRepository>();
            _mockDepotLocationRepository = Substitute.For<IIgpsDepotLocationRepository>();


            _mockLogger = Substitute.For<ILogger>();
            _mockLoggerFactory = Substitute.For<ILoggerFactory>();

            _listOfGlns = new List<string>
            {
                "1234",
                "12345",
                "123456",
                "1234567"
            };

            _existingGrais = new List<IGPS_DEPOT_GLN>()
            {
                new IGPS_DEPOT_GLN("1234", "432", DateTime.Now),
                new IGPS_DEPOT_GLN("1234", "5432", DateTime.Now),
                new IGPS_DEPOT_GLN("Test", "6543", DateTime.Now),
                new IGPS_DEPOT_GLN("Test1", "7657", DateTime.Now),
            };

            _existingContainers = new List<IGPS_DEPOT_LOCATION>
            {
                new IGPS_DEPOT_LOCATION("1234", "READY", "MIXED", "Test", "DTEST00001", 540),
                new IGPS_DEPOT_LOCATION("Test", "READY", "MIXED", "Test", "DTEST00001", 540),
                new IGPS_DEPOT_LOCATION("Test1", "READY", "MIXED", "Test", "DTEST00001", 540),
            };

        }
        #endregion

        #region tests

        [Test]
        public async Task ClearContainerTest_ValidList_DeletesBoth()
        {
            // Arrange
            // Mock methods
            // Returns a count of all GRAIs in table
            _mockDepoGlnRespository.GetCountOfTable().Returns(3);

            // Returns a list of Grais from IGPS_DEPOT_GLN
            _mockDepoGlnRespository.ReadContainersFromList(Arg.Any<string>())
                .Returns(_existingGrais);

            // Returns existing container list

            _mockDepotLocationRepository.ReadContainersFromList(Arg.Any<List<string>>())
                .Returns(_existingContainers);


            _controller = new ClearContainerController(_mockDepoGlnRespository, _mockDepotLocationRepository, _mockLoggerFactory);
            // Act
            await _controller.ClearContainers(_listOfGlns);

            // Assert
            // Delete GRAIs should run once when lists are valid
            //_mockDepoGlnRespository.Verify(repo => repo.DeleteGlnsFromList(It.IsAny<string>()), Times.Once);
            _mockDepoGlnRespository.Received(1).DeleteGlnsFromList(Arg.Any<string>());

            //_mockDepotLocationRepository.Verify(repo => repo.DeleteContainersFromList(It.IsAny<string>()), Times.Exactly(1));
            _mockDepotLocationRepository.Received(1).DeleteContainersFromList(Arg.Any<string>());
        }

        [Test]
        public async Task ClearContainer_EmptyList_NoDeletesHappen()
        {
            // Arrange
            var listOfGlns = new List<string>();

            _controller = new ClearContainerController(_mockDepoGlnRespository, _mockDepotLocationRepository, _mockLoggerFactory);


            //Act
            _controller.ClearContainers(listOfGlns);

            //Assert
            _mockDepoGlnRespository.Received(0).DeleteGlnsFromList(Arg.Any<string>());
            _mockDepotLocationRepository.Received(0).DeleteContainersFromList(Arg.Any<string>());
        }

        [Test]
        public async Task GetDnusTest_FindsDNUsWhenExists()
        {
            // Arrange
            _existingGrais = new List<IGPS_DEPOT_GLN>()
                    {
                        new IGPS_DEPOT_GLN("8948244214", "123", DateTime.Now),
                        new IGPS_DEPOT_GLN("89482442142", "1234", DateTime.Now),
                        new IGPS_DEPOT_GLN("89482442143", "1245", DateTime.Now),
                    };

            _existingContainers = new List<IGPS_DEPOT_LOCATION>()
                    {
                        new IGPS_DEPOT_LOCATION("123", "READY", "MIXED", "DNU", "DTEST00001", 540),
                        new IGPS_DEPOT_LOCATION("123", "READY", "MIXED", "DNU", "DTEST00001", 540),
                        new IGPS_DEPOT_LOCATION("123", "READY", "MIXED", "DNU", "DTEST00001", 540)

                    };
            var existingDNUs = new List<string>()
                    {
                        "12DNU",
                        "DNU321",
                        "dnu"
                    };

            // mock repos to send valid lists
            _mockDepoGlnRespository.ReadContainersFromList(Arg.Any<string>()).Returns(_existingGrais);
            _mockDepotLocationRepository.ReadContainersFromList(Arg.Any<List<string>>()).Returns(_existingContainers);
            _mockDepotLocationRepository.ReadDnus().Returns(existingDNUs);

            _controller = new ClearContainerController(_mockDepoGlnRespository, _mockDepotLocationRepository, _mockLoggerFactory);

            var dnuTestResult = await _controller.GetDnus();

            Assert.That(dnuTestResult.Item1, Has.Count.EqualTo(3));
        }


        [Test]
        public async Task ClearContainerTest_GhostGraisWillBeDeletedIfThereIsNoContainerFoundInTable()
        {
            // Arrange
            var list = new List<string>()
            {
                "test",
                "test",
                "test"
            };

            _mockDepoGlnRespository.ReadContainersFromList(Arg.Any<string>()).Returns(_existingGrais);
            _mockDepotLocationRepository.ReadContainersFromList(Arg.Any<List<string>>()).Returns(new List<IGPS_DEPOT_LOCATION>());

            _controller = new ClearContainerController(_mockDepoGlnRespository, _mockDepotLocationRepository, _mockLoggerFactory);

            // Act
            _controller.ClearContainers(list);


            // Assert
            // Grais should be deleted, clear containers should not run
            _mockDepoGlnRespository.Received(1).DeleteGlnsFromList(Arg.Any<string>());
            _mockDepotLocationRepository.Received(0).DeleteContainersFromList(Arg.Any<string>());
        }

        [Test]
        public async Task Logging_LoggerShouldBeRunWhenContainersAreCleared()
        {
            // Arrange
            _mockDepoGlnRespository.GetCountOfTable().Returns(3);

            _mockDepoGlnRespository.ReadContainersFromList(Arg.Any<string>())
                .Returns(_existingGrais);

            _mockDepotLocationRepository.ReadContainersFromList(Arg.Any<List<string>>())
                .Returns(_existingContainers);

            // Set logger factory to return the test logger
            _mockLoggerFactory.CreateContextualLogger(Arg.Any<string>())
                .Returns(_mockLogger);

            _controller = new ClearContainerController(_mockDepoGlnRespository, _mockDepotLocationRepository, _mockLoggerFactory);
            
            // Act
            _controller.ClearContainers(_listOfGlns);

            // Assert
            _mockLogger.Received(1).Information(Arg.Is<string>(msg => msg.Contains("Grai(s) have been cleared and deleted")));
        }


        #endregion
    }
}