using SolidWorks.Interop.sldworks;
using System;

namespace Modellic.Interfaces
{
    public interface ISwService : IDisposable
    {
        ISldWorks SwApp { get; }

        bool IsConnected { get; }

        bool Connect();

        void Disconnect();
    }
}
