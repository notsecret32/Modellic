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

        #endregion

        #region Private Readonly Members

        /// <summary>
        /// Объект заглушка для удаления данных в lock.
        /// </summary>
        private readonly object _disposingLock = new object();
      
        #endregion

        #region Public Properties

        /// <summary>
        /// Текущее приложение.
        /// </summary>
        public SwApplication SwApp => _swApp;

        /// <summary>
        /// Флаг, указывающий подключено ли приложение к SolidWorks.
        /// </summary>
        public bool IsConnected => _swApp != null && !_swApp._isDisposing;

        #endregion

        #region Public Static Properties

        /// <summary>
        /// Статический объект указывающий на единственный экземпляр менеджера приложений
        /// </summary>
        public static SwApplicationManager Instance { get; } = new SwApplicationManager();

        #endregion

        #region Constructors

        /// <summary>
        /// Запрещаем создавать новые менеджеры.
        /// </summary>
        private SwApplicationManager()
        {
            Logger.LogInformation("SwApplicationManager создан");
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
            if (IsConnected)
            {
                Logger.LogInformation("SolidWorks уже подключен");

                return true;
            }

            try
            {
                return await Task.Run(() =>
                {
                    try
                    {
                        // Получаем объект приложения SolidWorks
                        var swApp = GetOrCreateSwApp();

                        // Настраиваем его
                        swApp.Visible = true;
                        swApp.FrameState = (int)swWindowState_e.swWindowMaximized;

                        // Получаем текущий язык
                        var currentLanguage = SwSupportedLanguageParser.Parse(swApp.GetCurrentLanguage());

                        // Обновляем язык в локализаторе
                        LocalizationManager.Language = currentLanguage;

                        Logger.LogInformation(
                            $"Параметры SOLIDWORKS:" +
                            $"\n- Номер версии: {swApp.RevisionNumber()}" +
                            $"\n- Язык={currentLanguage}" +
                            $"\n- WindowState={(swWindowState_e)swApp.FrameState}" +
                            $"\n- Тип лицензии: {(swLicenseType_e)swApp.GetCurrentLicenseType()}" +
                            $"\n- Путь до файла: {swApp.GetExecutablePath()}"
                        );

                        lock (_disposingLock)
                        {
                            if (_isDisposed) return false;
                            this._swApp = new SwApplication(swApp);
                        }

                        return true;
                    }
                    catch (Exception ex)
                    {
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
            if (!IsConnected) return;

            lock (_disposingLock)
            {
                try
                {
                    if (closeApp) _swApp.UnsafeObject?.ExitApp();
                }
                catch (COMException) { }

                _swApp?.Dispose();
                _swApp = null;
            }
        }

        #endregion

        #region Private Methods

        private SldWorks GetOrCreateSwApp()
        {
            try
            {
                Logger.LogInformation("Пробуем получить приложение SolidWorks");

                return (SldWorks)Marshal.GetActiveObject(SOLIDWORKS_PROG_ID);
            }
            catch (COMException)
            {
                Logger.LogInformation("SolidWorks не открыт, открываем его");

                return (SldWorks)Activator.CreateInstance(Type.GetTypeFromProgID(SOLIDWORKS_PROG_ID));
            }
        }

        #endregion

        #region Disposing

        public void Dispose()
        {
            if (_isDisposed) return;

            Disconnect(false);
            _isDisposed = true;
            GC.SuppressFinalize(this);
        }

        ~SwApplicationManager() => Dispose();

        #endregion
    }
}