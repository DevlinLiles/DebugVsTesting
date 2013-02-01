using System;
using DebuggingVsTesting.Systems;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace DebuggingVsTesting.Tests
{
    [TestFixture]
    public class VaccumPortTests
    {
        public event EventHandler PortOpen;
        public event EventHandler PortClose;

        protected virtual void OnPortClose()
        {
            var handler = PortClose;
            if (handler != null) handler(this, EventArgs.Empty);
        }

        protected virtual void OnPortOpen()
        {
            var handler = PortOpen;
            if (handler != null) handler(this, EventArgs.Empty);
        }

        [Test]
        public void ShouldOpenPortOnEvent()
        {
            //arrange
            var target = new VaccumPort();
            PortOpen += target.OnCleanUp;
            //act
            OnPortOpen();

            //Assert
            Assert.IsTrue(target.Open);
        }

        [Test]
        public void ShouldClosePortOnEven()
        {
            //Arrange
            var target = new VaccumPort();
            PortOpen += target.OnCleanUp;
            OnPortOpen();
            Assert.IsTrue(target.Open);
            PortClose += target.OnCleanUpComplete;

            //Act
            OnPortClose();

            //Assert
            Assert.IsFalse(target.Open);
        }
    }
}
