using System;

namespace DebuggingVsTesting.Interfaces
{
    public interface IVacuumPort
    {
        void OnCleanUp(object sender, EventArgs args);
        bool Open { get; set; }
        void OnCleanUpComplete(object sender, EventArgs args);
    }
}