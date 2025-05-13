using Modellic.Enums;
using SolidWorks.Interop.sldworks;
using System;
using System.Threading.Tasks;

namespace Modellic.Interfaces
{
    /// <summary>
    /// Интерфейс, описывающий сервис по работе с Solidworks.
    /// </summary>
    public interface ISwService : IDisposable
    {
        ISldWorks SwApp { get; }

        SwConnectionStatus ConnectionStatus { get; }

        bool IsDisconnected { get; }

        bool IsDisconnecting { get; }

        bool IsConnecting { get; }

        bool IsConnected { get; }

        event EventHandler ConnectionStatusChanged;
     
        Task ConnectAsync();

        Task DisconnectAsync();
    }
}
