using Modellic.Enums;
using Modellic.Interfaces;
using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swconst;
using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace Modellic.Services
{
    /// <summary>
    /// Сервис по работе с Solidworks. В его задачи входит подключение к Solidworks, предоставление данных о Solidworks и т.д.
    /// </summary>
    public class SwService : ISwService
    {
        #region Constants

        /// <summary>
        /// Id программы Solidworks, по которому происходит поиск запущенных процессов.
        /// Данный вариант работает только на Windows.
        /// </summary>
        private const string SW_PROG_ID = "SldWorks.Application";

        #endregion

        #region Private Members

        /// <summary>
        /// Объект, указывающий на приложение Solidworks.
        /// </summary>
        private ISldWorks _swApp;
        
        /// <summary>
        /// Стутус подключения к приложению Solidworks.
        /// </summary>
        private SwConnectionStatus _swConnectionStatus;

        #endregion

        #region Private Static Members

        /// <summary>
        /// Статический объект, указывающий сам на себя. Нужен для получения доступа к полям и методам через статический вызов.
        /// </summary>
        private static SwService _instance;

        #endregion

        #region Properties

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

        #endregion

        #region Static Properties

        /// <summary>
        /// Объект, указывающий сам на себя.
        /// </summary>
        public static SwService Instance => _instance;
        
        #endregion

        #region Events

        /// <summary>
        /// Происходит, когда меняется статус подключения.
        /// </summary>
        public event EventHandler ConnectionStatusChanged;

        #endregion

        #region Constructors

        public SwService()
        {
            _instance = this; 
        }

        #endregion

        #region Public Methods

        public void Dispose()
        {
            DisconnectAsync().GetAwaiter().GetResult();
            _instance = null;
            GC.SuppressFinalize(this);
        }

        #endregion

        #region Public Async Methods

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

        #endregion

        #region Public Static Methods

        public static SwService GetInstance()
        {
            if (Instance == null)
            {
                throw new NullReferenceException("Попытка получить Instance сервиса SwService, который равен null.");
            }

            return Instance;
        }

        #endregion

        #region Overrided Methods

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

        #endregion
    }
}
