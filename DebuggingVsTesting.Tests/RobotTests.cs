using System.Linq;
using DebuggingVsTesting.Systems;
using NUnit.Framework;

namespace DebuggingVsTesting.Tests
{
    [TestFixture]
    public class RobotTests
    {
        [Test]
        public void ShouldReturnConfiguredWidgetsPerCall()
        {
            //Arrange
            var target = new Robot(3);

            //Act
            var result = target.Build();

            //Assert
            Assert.AreEqual(3, result.Count());
        }
    }
}