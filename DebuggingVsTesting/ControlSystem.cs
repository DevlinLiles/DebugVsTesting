using System;
using DebuggingVsTesting.Interfaces;
using DebuggingVsTesting.Systems;

namespace DebuggingVsTesting
{
    public class ControlSystem
    {
        private readonly IConveyor _conveyor;
        private readonly IRobot _robot;
        private readonly IVacuumPort _vacuumPort;

        public ControlSystem(IConveyor conveyor, IRobot robot, IVacuumPort vacuumPort)
        {
            _conveyor = conveyor;
            _robot = robot;
            _vacuumPort = vacuumPort;
            CleanupStart += _vacuumPort.OnCleanUp;
            CleanupComplete += _vacuumPort.OnCleanUpComplete;
        }

        private event EventHandler<EventArgs> CleanupComplete;

        protected virtual void EndCleanup()
        {
            var handler = CleanupComplete;
            if (handler != null) handler(this, EventArgs.Empty);
        }

        private event EventHandler<EventArgs> CleanupStart;

        protected virtual void StartCleanup()
        {
            var handler = CleanupStart;
            if (handler != null) handler(this, EventArgs.Empty);
        }

        public RunResult DoStuff(int cyclesToRun, int cyclesBeforeCleanup)
        {
            var runResults = new RunResult();
            for (int totalCycles = 1; totalCycles <= cyclesToRun; totalCycles++)
            {
                if ((totalCycles % cyclesBeforeCleanup) == 0)
                {
                    StartCleanup();
                    runResults.Add(new CleanupDetail() { CycleCleanedAfter = totalCycles });
                    EndCleanup();
                }

                runResults.Add(_conveyor.Run());
                runResults.Add(_robot.Build());

            }

            return runResults;
        }
    }
}