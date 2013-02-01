using System;
using System.Linq;
using DebuggingVsTesting.Interfaces;
using DebuggingVsTesting.Systems;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace DebuggingVsTesting.Tests
{
    [Binding]
    public class ProcessRunSteps
    {
        private int _cleanUpBound;
        private RunResult results;
        private int _maxRunCycles;
        private IConveyor _conveyor;
        private IRobot _robot;


        [Given(@"I have a control system ready to run (.*) cycles")]
        public void GivenIHaveAControlSystemReadyToRunCycles(int p0)
        {
            _maxRunCycles = p0;
        }

        [Given(@"I have cleanup after every (.*) cycles")]
        public void GivenIHaveCleanupAfterEveryCycles(int p0)
        {
            _cleanUpBound = p0;
        }

        [Given(@"I have a conveyor setup for (.*) foot per cycle")]
        public void GivenIHaveAConveyorSetupForFootPerCycle(int p0)
        {
            _conveyor = new Conveyor(p0);
        }

        [Given(@"I have a robot that produces (.*) widgets per build")]
        public void GivenIHaveARobotThatProducesWidgetsPerBuild(int p0)
        {
            _robot = new Robot(p0);
        }
        

        [When(@"I run these cycles")]
        public void WhenIRunTheseCycles()
        {
            var controlSystem = new ControlSystem(_conveyor, _robot, new VaccumPort());

           results = controlSystem.DoStuff(_maxRunCycles,_cleanUpBound);
        }
        
       
        [Then(@"the result should be a cleaup after these cycles: (.*), (.*)")]
        public void ThenTheResultShouldBeACleaupAfterTheseCycles(int p0, int p1)
        {
            Assert.AreEqual(2, results.Cleanups.Count());
            Assert.AreEqual(p0, results.Cleanups.First().CycleCleanedAfter);
            Assert.AreEqual(p1, results.Cleanups.Last().CycleCleanedAfter);
        }

        [Then(@"the result should have (.*) widgets")]
        public void ThenTheResultShouldHaveWidgets(int p0)
        {
            Assert.AreEqual(p0, results.Widgets.Count());
        }

        
        [Then(@"the result should have (.*) movements with a total (.*) feet moved")]
        public void ThenTheResultShouldHaveMovementsWithATotalFeetMoved(int p0, int p1)
        {
            Assert.AreEqual(p0,results.Movements.Count());
            Assert.AreEqual(p1,results.Movements.Sum(x=>x.FeetMoved));
        }


    }
}
