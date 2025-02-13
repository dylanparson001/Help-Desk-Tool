using iGPS_Help_Desk.Controllers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace iGPS_Help_Desk.Tests.UnitTests.UnitTests.BaseControllerMethods
{
    public class HelperTests
    {
        public BaseController _baseController { get; set; }
        [SetUp]
        public void Setup()
        {
            _baseController = new BaseController();
        }

        /// <summary>
        /// Tests that the string will be correctly formatted
        /// </summary>
        [Test]
        public void TestConcatStringMethod_NormalValidStrings()
        {
            // Arrange
            List<string> list = new List<string>()
            {
                "Test",
                "Test1",
                "Test2",
            };

            // Act
            var resultString = _baseController.ConcatStringFromList(list);

            // Assert 
            Assert.That(resultString, Is.EqualTo("'Test','Test1','Test2'"));
        }
        [Test]
        public void TestConcatStringMethod_EmptyStringsAreValid()
        {
            // Arrange
            List<string> list = new List<string>()
            {
                " ",
                "",
                "",
            };

            // Act
            var resultString = _baseController.ConcatStringFromList(list);

            // Assert 
            Assert.That(resultString, Is.EqualTo("' ','',''"));
        }

        [Test]
        public void TestConcatStringMethod_EmptyListReturnsEmptyString()
        {
            // Arrange
            List<string> emptyList = new List<string>();

            // Act & Assert
            var result = _baseController.ConcatStringFromList(emptyList);

            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.EqualTo(""));
        }
    }
}
