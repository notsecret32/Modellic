using Microsoft.Extensions.Logging;
using Modellic.App.Enums;
using Modellic.App.Errors;
using Modellic.App.Exceptions;
using Modellic.App.SolidWorks.Localization;
using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swconst;
using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using static Modellic.App.Logging.LoggerService;

namespace Modellic.App.SolidWorks.Application
{
    /// <summary>
    /// Менеджер по управлению приложением SolidWorks. Предоставляет центролизированное управление активным приложением SolidWorks.
    /// </summary>
    public class SwApplicationManager : IDisposable
    {
        #region Constants

        /// <summary>
        /// ID приложения SolidWorks в реестре Windows.
        /// </summary>
        const string SOLIDWORKS_PROG_ID = "SldWorks.Application";

        #endregion

        #region Private Members

        /// <summary>
        /// Текущее приложение SolidWorks.
        /// </summary>
        private SwApplication _swApp;

        /// <summary>
        /// Флаг, указывающий очищены ли данные текущего объекта.
        /// </summary>
        private bool _isDisposed = false;

        /// <summary>
        /// Объект заглушка для удаления данных в lock.
        /// </summary>
        private readonly object _disposingLock = new object();

        #endregion

        #region Public Properties

        /// <summary>
        /// Статический объект указывающий на единственный экземпляр менеджера приложений
        /// </summary>
        public static SwApplicationManager Instance { get; } = new SwApplicationManager();

        /// <summary>
        /// Текущее приложение.
        /// </summary>
        public SwApplication Application => _swApp;

        /// <summary>
        /// Флаг, указывающий подключено ли приложение к SolidWorks.
        /// </summary>
        public bool IsConnected => _swApp != null && !_swApp.Disposing;

        #endregion

        #region Constructors

        /// <summary>
        /// Запрещаем создавать новые менеджеры.
        /// </summary>
        private SwApplicationManager()
        {
            Logger.LogInformation("Запущен конструктор SwApplicationManager");
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Метод для подключения к приложению SolidWorks. Если SolidWorks не открыт, то приложение откроет его.
        /// </summary>
        /// <returns>True - если удалось подключиться.</returns>
        /// <exception cref="SolidWorksException">При любой непредвиденной ошибке.</exception>
        public async Task<bool> ConnectAsync()
        {
            Logger.LogInformation("Проверяем статус подключения к SolidWorks");

            if (IsConnected)
            {
                Logger.LogInformation("Приложение уже подключено к SolidWorks, выходим");
                return true;
            }

            Logger.LogInformation("Приложение не подключено к SolidWorks, пробуем подключиться");

            try
            {
                return await Task.Run(() =>
                {
                    try
                    {
                        SldWorks app;
                        try
                        {
                            Logger.LogInformation("Пробуем получить запущенный SolidWorks");

                            app = (SldWorks)Marshal.GetActiveObject(SOLIDWORKS_PROG_ID);
                        }
                        catch (COMException)
                        {
                            Logger.LogInformation("SolidWorks не запущен, открываем его");

                            app = (SldWorks)Activator.CreateInstance(Type.GetTypeFromProgID(SOLIDWORKS_PROG_ID));
                        }

                        app.Visible = true;
                        app.FrameState = (int)swWindowState_e.swWindowMaximized;

                        // Устанавливаем язык
                        SwSupportedLanguage currentLanguage = SwSupportedLanguageParser.Parse(app.GetCurrentLanguage());
                        LocalizationManager.Language = currentLanguage;
                        Logger.LogInformation($"Язык: {currentLanguage}");


                        lock (_disposingLock)
                        {
                            if (_isDisposed) return false;
                            _swApp = new SwApplication(app);
                        }

                        return true;
                    }
                    catch (Exception ex)
                    {
                        Logger.LogError("Не удалось создать либо подключиться к SolidWorks");

                        throw new SolidWorksException(
                            SwObjectErrorManager.CreateError(
                                "Не удалось создать либо подключиться к SolidWorks.",
                                SwObjectErrorCode.ConnectionFailed
                            ),
                            ex
                        );
                    }
                });
            }
            catch (Exception ex)
            {
                Logger.LogError("Ошибка при подключении к SolidWorks.");

                throw new SolidWorksException(
                    SwObjectErrorManager.CreateError(
                        "Ошибка при подключении к SolidWorks.",
                        SwObjectErrorCode.ConnectionFailed
                    ),
                    ex
                );
            }
        }

        /// <summary>
        /// Метод для отключения от SolidWorks.
        /// </summary>
        /// <param name="closeApp">Если True - закрыть приложение SolidWorks.</param>
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