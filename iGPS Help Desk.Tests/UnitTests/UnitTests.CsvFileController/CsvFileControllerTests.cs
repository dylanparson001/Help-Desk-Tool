using iGPS_Help_Desk.Controllers;
using iGPS_Help_Desk.Interfaces;
using iGPS_Help_Desk.Repositories;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iGPS_Help_Desk.Tests.UnitTests.UnitTests.CsvFileControllerTests
{
    public class CsvFileControllerTests
    {
        private CsvFileController _csvFileController;
        private ClearContainerController _clearContainerController;
        private Mock<IIgpsDepotGlnRepository> _mockDepotGlnRepository;
        private Mock<IIgpsDepotLocationRepository> _mockDepotLocationRepository;
        
        [SetUp]
        public void SetupCsvFileController()
        {
            _mockDepotGlnRepository = new Mock<IIgpsDepotGlnRepository>();
            _mockDepotLocationRepository = new Mock<IIgpsDepotLocationRepository>();
            _clearContainerController = new ClearContainerController(_mockDepotGlnRepository.Object, _mockDepotLocationRepository.Object);

            _csvFileController = new CsvFileController(_mockDepotGlnRepository.Object, _mockDepotLocationRepository.Object, _clearContainerController);
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
