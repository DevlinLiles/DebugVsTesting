using System.Collections.Generic;

namespace DebuggingVsTesting
{
    public class RunResult
    {
        private List<CleanupDetail> _cleanups;
        private List<ConveyorMovementDetail> _movements;
        private List<Widget> _widgets;

        public RunResult()
        {
            _cleanups = new List<CleanupDetail>();
            _movements = new List<ConveyorMovementDetail>();
            _widgets = new List<Widget>();
        }
        public IEnumerable<CleanupDetail> Cleanups
        {
            get { return _cleanups; }
        }

        public IEnumerable<ConveyorMovementDetail> Movements
        {
            get { return _movements; }
        }

        public IEnumerable<Widget> Widgets  
        {
            get { return _widgets; }
        }

        public void Add(ConveyorMovementDetail movement)
        {
            _movements.Add(movement);
        }

        public void Add(CleanupDetail cleanup)
        {
            _cleanups.Add(cleanup);
        }

        public void Add(IEnumerable<Widget> widgets)
        {
            _widgets.AddRange(widgets);
        }
    }
}