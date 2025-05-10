using Modellic.Interfaces;
using System;

namespace Modellic.Events
{
    public class CurrentStepChangedEventArgs : EventArgs
    {
        public IFixtureService Service { get; }

        public CurrentStepChangedEventArgs(IFixtureService service)
        {
            Service = service;
        }
    }
}
