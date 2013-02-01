using System.Collections.Generic;
using DebuggingVsTesting.Interfaces;
using DebuggingVsTesting.Systems;
using NUnit.Framework;
using Rhino.Mocks;
using System.Linq;

namespace DebuggingVsTesting.Tests
{
    [TestFixture]
    public class ControlSystemTests
    {
        [Test]
        public void ShouldMoveConveyorOnDoStuff()
        {
            //Arrange
            var mockConveyor = MockRepository.GenerateStrictMock<IConveyor>();
            var mockRobot = MockRepository.GenerateStub<IRobot>();

            mockRobot.Stub(x => x.Build()).Return(new List<Widget>());

            var mockVacuumPort = MockRepository.GenerateStub<IVacuumPort>();

            mockConveyor.Expect(x => x.Run()).Repeat.Once();

            var target = new ControlSystem(mockConveyor, mockRobot, mockVacuumPort);

            //Act
            var result = target.DoStuff(1, 100);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Movements.Count());
            mockConveyor.VerifyAllExpectations();
        }

        [Test]
        public void ShouldBuildWidgetsOnDoStuff()
        {
            //Arrange
            var mockConveyor = MockRepository.GenerateStub<IConveyor>();
            var mockRobot = MockRepository.GenerateStrictMock<IRobot>();
            var mockVacuumPort = MockRepository.GenerateStub<IVacuumPort>();

            mockRobot.Expect(x => x.Build()).Return(new List<Widget>()
                {
                    new Widget(),
                    new Widget()
                }).Repeat.Twice();

            var target = new ControlSystem(mockConveyor, mockRobot, mockVacuumPort);

            //Act
            var result = target.DoStuff(2, 100);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(4, result.Widgets.Count());
            mockRobot.VerifyAllExpectations();
        }

        [Test]
        public void ShouldCleanupAtTheSpecifiedCycle()
        {
            //Arrange
            var mockConveyor = MockRepository.GenerateStub<IConveyor>();
            var mockRobot = MockRepository.GenerateStub<IRobot>();
            var mockVacuumPort = MockRepository.GenerateStub<IVacuumPort>();
            mockRobot.Stub(x => x.Build()).Return(new List<Widget>());

            var target = new ControlSystem(mockConveyor, mockRobot, mockVacuumPort);

            //Act
            var result = target.DoStuff(2, 1);

            //Assert
            Assert.AreEqual(2, result.Cleanups.Count());
            Assert.AreEqual(1,result.Cleanups.First().CycleCleanedAfter);
            Assert.AreEqual(2, result.Cleanups.Last().CycleCleanedAfter);
        }
    }
}