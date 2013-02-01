using System.Collections.Generic;
using DebuggingVsTesting.Interfaces;

namespace DebuggingVsTesting.Systems
{
    public class Robot : IRobot
    {
        private readonly int _widgetsPerCycle;

        public Robot(int widgetsPerCycle)
        {
            _widgetsPerCycle = widgetsPerCycle;
        }

        public IEnumerable<Widget> Build()
        {
            var widgets = new List<Widget>();
            for (int i = 0; i < _widgetsPerCycle; i++)
            {
                widgets.Add(new Widget());
            }
            return widgets;
        }
    }
}