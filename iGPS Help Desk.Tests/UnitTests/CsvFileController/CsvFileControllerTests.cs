using iGPS_Help_Desk.Controllers;
using iGPS_Help_Desk.Interfaces;
using iGPS_Help_Desk.Logger;
using NSubstitute;
using NUnit.Framework;
using Serilog;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iGPS_Help_Desk.Tests.UnitTests.UnitTests.CsvFileControllerTests
{
    public class CsvFileControllerTests
    {
        private CsvFileController _csvFileController;
        private ClearContainerController _clearContainerController;

        #region logger
        private ILogger _mockLogger;
        private ILoggerFactory _mockLoggerFactory;

        #endregion

        private IIgpsDepotGlnRepository _mockDepotGlnRepository;
        private IIgpsDepotLocationRepository _mockDepotLocationRepository;
        
        [SetUp]
        public void SetupCsvFileController()
        {
            _mockDepotGlnRepository = Substitute.For<IIgpsDepotGlnRepository>();

            //_mockDepotLocationRepository = new Mock<IIgpsDepotLocationRepository>();
            _mockDepotLocationRepository = Substitute.For<IIgpsDepotLocationRepository>();
            _mockLoggerFactory = Substitute.For<LoggerFactory>();

            _clearContainerController = new ClearContainerController(_mockDepotGlnRepository, _mockDepotLocationRepository, _mockLoggerFactory);

            _csvFileController = new CsvFileController(_mockDepotGlnRepository, _mockDepotLocationRepository, _clearContainerController, _mockLoggerFactory);
        }

        public async Task TestGettingFolderPath_EmptyPath_ThrowsException()
        {
            // Arrange
            _csvFileController.ClearContainerPath = "";
            string count = "";
            var ttGraisToClear = new List<string>();
            int rand = 1;

            // Act & Assert
            var result = Assert.Throws<Exception>(() => CsvFileController.GetCurrentFolderPath());
            Assert.That(result.Message, Is.EqualTo("File path is empty please set in settings")); 
        }
    }
}
