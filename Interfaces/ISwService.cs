using Modellic.Enums;
using SolidWorks.Interop.sldworks;
using System;
using System.Threading.Tasks;

namespace Modellic.Interfaces
{
    public interface ISwService : IDisposable
    {
        event EventHandler ConnectionStatusChanged;

        ISldWorks SwApp { get; }
        SwConnectionStatus ConnectionStatus { get; }

        bool IsDisconnected { get; }
        bool IsDisconnecting { get; }
        bool IsConnecting { get; }
        bool IsConnected { get; }

        Task ConnectAsync();
        Task DisconnectAsync();
    }
}
