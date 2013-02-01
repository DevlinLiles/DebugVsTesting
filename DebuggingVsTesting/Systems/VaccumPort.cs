using System;
using DebuggingVsTesting.Interfaces;

namespace DebuggingVsTesting.Systems
{
    public class VaccumPort : IVacuumPort
    {
        public void OnCleanUp(object sender, EventArgs args)
        {
            this.Open = true;
        }

        public bool Open { get; set; }

        public void OnCleanUpComplete(object sender, EventArgs args)
        {
            this.Open = false;
        }
    }
}
