using Modellic.App.Enums;
using Modellic.App.Errors;
using Modellic.App.Exceptions;
using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swconst;
using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace Modellic.App.SolidWorks.Application
{
    public class SwApplicationManager : IDisposable
    {
        #region Constants

        const string SOLIDWORKS_PROG_ID = "SldWorks.Application";

        #endregion

        #region Private Members

        private SwApplication _swApp;

        private bool _isDisposed = false;

        private readonly object _disposingLock = new object();

        #endregion

        #region Public Properties

        public static SwApplicationManager Instance { get; } = new SwApplicationManager();

        public SwApplication Application => _swApp;

        public bool IsConnected => _swApp != null && !_swApp.Disposing;

        #endregion

        #region Public Methods

        public async Task<bool> ConnectAsync()
        {
            if (IsConnected)
                return true;

            try
            {
                return await Task.Run(() =>
                {
                    try
                    {
                        ISldWorks app;
                        try
                        {
                            app = (ISldWorks)Marshal.GetActiveObject(SOLIDWORKS_PROG_ID);
                        }
                        catch (COMException)
                        {
                            app = (ISldWorks)Activator.CreateInstance(Type.GetTypeFromProgID(SOLIDWORKS_PROG_ID));
                        }

                        app.Visible = true;
                        app.FrameState = (int)swWindowState_e.swWindowMaximized;

                        lock (_disposingLock)
                        {
                            if (_isDisposed) return false;
                            _swApp = new SwApplication(app);
                        }

                        return true;
                    }
                    catch (Exception ex)
                    {
                        throw new SolidWorksException(
                            SwObjectErrorManager.CreateError(
                                "Не удалось создать либо подключиться к SolidWorks.",
                                SwObjectErrorType.SolidWorksApplication,
                                SwObjectErrorCode.SolidWorksApplicationFailedToConnect
                            ),
                            ex
                        );
                    }
                });
            }
            catch (Exception ex)
            {
                throw new SolidWorksException(
                    SwObjectErrorManager.CreateError(
                        "Ошибка при асинхронном подключении к SolidWorks.",
                        SwObjectErrorType.SolidWorksApplication,
                        SwObjectErrorCode.SolidWorksApplicationFailedToConnect
                    ),
                    ex
                );
            }
        }

        public void Disconnect(bool closeApp = false)
        {
            if (!IsConnected)
                return;

            lock (_disposingLock)
            {
                if (closeApp && _swApp.UnsafeObject != null)
                {
                    try
                    {
                        _swApp.UnsafeObject.ExitApp();
                    }
                    catch (COMException)
                    {
                        // Игнорируем ошибки при закрытии
                    }
                }

                _swApp.Dispose();
                _swApp = null;
            }
        }

        #endregion

        #region Disposing

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_isDisposed)
                return;

            if (disposing)
            {
                Disconnect(false);
            }

            _isDisposed = true;
        }

        ~SwApplicationManager()
        {
            Dispose(false);
        }

        #endregion
    }
}