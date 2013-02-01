using System.Collections.Generic;

namespace DebuggingVsTesting.Interfaces
{
    /// <summary>
    /// That's right, IRobot, you know like the.... well never mind
    /// </summary>
    public interface IRobot
    {
        IEnumerable<Widget> Build();
    }
}