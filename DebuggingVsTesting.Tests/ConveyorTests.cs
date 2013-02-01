using DebuggingVsTesting.Systems;
using NUnit.Framework;

namespace DebuggingVsTesting.Tests
{
    [TestFixture]
    public class ConveyorTests
    {
        [Test]
        public void ShouldReturnAMovementDetailWithConfiguredFeetOfMovement()
        {
            //Arrange
            var target = new Conveyor(15);

            //Act
            var result = target.Run();

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(15, result.FeetMoved);
        }
    }
}