using Modellic.Enums;
using Modellic.Interfaces;
using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swconst;
using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace Modellic.Services
{
    public class SwService : ISwService
    {
        private ISldWorks _swApp;
        private SwConnectionStatus _swConnectionStatus;
        private const string SW_PROG_ID = "SldWorks.Application";

        public event EventHandler ConnectionStatusChanged;

        public ISldWorks SwApp => _swApp;
        public SwConnectionStatus ConnectionStatus
        {
            get => _swConnectionStatus;
            private set
            {
                if (_swConnectionStatus != value)
                {
                    _swConnectionStatus = value;
                    ConnectionStatusChanged?.Invoke(this, EventArgs.Empty);
                }
            }
        }

        public bool IsDisconnected => _swConnectionStatus == SwConnectionStatus.Disconnected;
        public bool IsDisconnecting => _swConnectionStatus == SwConnectionStatus.Disconnecting;
        public bool IsConnecting => _swConnectionStatus == SwConnectionStatus.Connecting;
        public bool IsConnected => _swConnectionStatus == SwConnectionStatus.Connected;

        public async Task ConnectAsync()
        {
            if (_swApp != null && IsConnected)
                return;

            ConnectionStatus = SwConnectionStatus.Connecting;

            try
            {
                await Task.Run(() =>
                {
                    try
                    {
                        _swApp = (ISldWorks)Marshal.GetActiveObject(SW_PROG_ID);
                    }
                    catch (COMException)
                    {
                        _swApp = (ISldWorks)Activator.CreateInstance(Type.GetTypeFromProgID(SW_PROG_ID));
                    }

                    _swApp.Visible = true;
                    _swApp.FrameState = (int)swWindowState_e.swWindowMaximized;

                    ConnectionStatus = SwConnectionStatus.Connected;
                });
            }
            catch (Exception ex)
            {
                ConnectionStatus = SwConnectionStatus.Disconnected;
                throw new Exception($"Ошибка подключения к SolidWorks:\n{ex}");
            }
        }

        public async Task DisconnectAsync()
        {
            if (_swApp == null)
                return;

            ConnectionStatus = SwConnectionStatus.Disconnecting;

            await Task.Run(() =>
            {
                try
                {
                    Marshal.ReleaseComObject(_swApp);
                    _swApp = null;
                }
                finally
                {
                    ConnectionStatus = SwConnectionStatus.Disconnected;
                }
            });
        }

        public void Dispose()
        {
            DisconnectAsync().GetAwaiter().GetResult();
            GC.SuppressFinalize(this);
        }

        public override string ToString()
        {
            return _swConnectionStatus switch
            {
                SwConnectionStatus.Disconnected => "Не подключено",
                SwConnectionStatus.Connecting => "Подключение...",
                SwConnectionStatus.Connected => "Подключено",
                SwConnectionStatus.Disconnecting => "Отключение...",
                _ => "Неизвестное состояние"
            };
        }
    }
}
