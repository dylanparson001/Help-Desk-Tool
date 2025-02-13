using iGPS_Help_Desk.Controllers;
using iGPS_Help_Desk.Interfaces;
using iGPS_Help_Desk.Logger;
using iGPS_Help_Desk.Models;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using NUnit.Framework;
using Serilog;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iGPS_Help_Desk.Tests.UnitTests.UnitTests.Rollback
{
    public class RollbackControllerTests
    {
        #region repos

        private IIgpsDepotGlnRepository _mockDepoGlnRespository;
        private IIgpsDepotLocationRepository _mockDepotLocationRepository;
        private IOrderRequestNewHeaderRepository _mockOrderRequestNewHeaderRepository;
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
            _mockOrderRequestNewHeaderRepository = Substitute.For<IOrderRequestNewHeaderRepository>();

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
        [TestCase("", "894844012342")]
        [TestCase("158982898", "")]
        public async Task IfOrderIdOrGlnIsEmptyOrNullRollbackWillNotProcess(string orderID, string gln)
        {
            // Arrange
            var rollbackController = new RollbackController(_mockOrderRequestNewHeaderRepository, _mockLoggerFactory);

            // Act
            await rollbackController.Rollback(orderID, gln, true);

            // Assert

            await _mockOrderRequestNewHeaderRepository.Received(0).Rollback(Arg.Any<string>(), Arg.Any<string>());
        }

        [Test]
        public async Task IfInsertQueryFailsThrowsExceptionRollbackWillNotCancel()
        {
            string orderId = "test";
            string gln = "test1";
            bool firstAttempt = true;
            // Arrange
            _mockOrderRequestNewHeaderRepository.RollbackInsertGrais(orderId, gln).Throws<Exception>();
            var rollbackController = new RollbackController(_mockOrderRequestNewHeaderRepository, _mockLoggerFactory);


            // Act and Assert
            Assert.ThrowsAsync<Exception>(async () => await rollbackController.Rollback(orderId, gln, firstAttempt));
            await _mockOrderRequestNewHeaderRepository.Received(0).RollbackDeleteGraisFromOrderId(orderId);
            await _mockOrderRequestNewHeaderRepository.Received(0).RollbackUpdateProcessingStatus(orderId);
        }

        [Test]
        public async Task IfRollbackIsSuccessfulLogsTwiceBeforeAndAfter()
        {
            // Arrange
            string orderId = "test";
            string gln = "test1";
            bool firstAttempt = true;

            _mockOrderRequestNewHeaderRepository.RollbackInsertGrais(orderId, gln).Returns(true);
            _mockOrderRequestNewHeaderRepository.RollbackUpdateProcessingStatus(orderId).Returns(true);
            _mockOrderRequestNewHeaderRepository.RollbackDeleteGraisFromOrderId(orderId).Returns(true);
            _mockLoggerFactory.CreateContextualLogger(Arg.Any<string>()).Returns(_mockLogger);

            var rollbackController = new RollbackController(_mockOrderRequestNewHeaderRepository, _mockLoggerFactory);

            // Act
            await rollbackController.Rollback(orderId, gln, firstAttempt);


            // Assert
            _mockLogger.Received(2).Information(Arg.Any<string>());
            _mockLogger.Received(1).Information(Arg.Is<string>(args => args.Contains("has started...")));
            _mockLogger.Received(1).Information(Arg.Is<string>(args => args.Contains("has been completed.")));
        }
        [Test]
        public async Task IfRollbackIsUnSuccessfulLogsOnceBefore()
        {
            // Arrange
            string orderId = "test";
            string gln = "test1";
            bool firstAttempt = true;

            _mockOrderRequestNewHeaderRepository.RollbackInsertGrais(orderId, gln).Returns(false);
            _mockOrderRequestNewHeaderRepository.RollbackUpdateProcessingStatus(orderId).Returns(false);
            _mockOrderRequestNewHeaderRepository.RollbackDeleteGraisFromOrderId(orderId).Returns(false);
            _mockLoggerFactory.CreateContextualLogger(Arg.Any<string>()).Returns(_mockLogger);

            var rollbackController = new RollbackController(_mockOrderRequestNewHeaderRepository, _mockLoggerFactory);

            // Act
            await rollbackController.Rollback(orderId, gln, firstAttempt);


            // Assert
            _mockLogger.Received(1).Information(Arg.Any<string>());
            _mockLogger.Received(1).Information(Arg.Is<string>(args => args.Contains("has started...")));
        }
        #endregion
    }
}