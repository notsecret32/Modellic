using Microsoft.Extensions.Logging;
using Modellic.App.Enums;
using Modellic.App.SolidWorks.Core;
using Modellic.App.SolidWorks.Documents;
using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swconst;
using System;
using System.Threading.Tasks;
using static Modellic.App.Logging.LoggerService;

namespace Modellic.App.SolidWorks.Application
{
    /// <summary>
    /// Представляет собой приложение SolidWorks.
    /// </summary>
    public class SwApplication : SwSharedObject<SldWorks>
    {
        #region Private Members

        /// <summary>
        /// Флаг, указывающий на то, что идет процесс освобождения ресурсов.
        /// </summary>
        public bool _isDisposing = false;
        
        /// <summary>
        /// Активный документ.
        /// </summary>
        private SwModelDoc _activeDocument;

        #endregion

        #region Private Readonly Members

        /// <summary>
        /// Объект заглушка для удаления данных объекта в lock.
        /// </summary>
        private readonly object _disposingLock = new object();

        #endregion

        #region Public Properties

        /// <summary>
        /// Активный документ. Может быть null если нет открытого документа.
        /// </summary>
        public SwModelDoc ActiveDocument
        {
            get { return _activeDocument; }
            private set
            {
                if (_activeDocument != value)
                {
                    _activeDocument = value;
                    ActiveDocumentChanged?.Invoke(_activeDocument);
                }
            }
        }

        #endregion

        #region Public Events

        public event Action<SwModelDoc> ActiveDocumentChanged;

        #endregion

        #region Constructors

        /// <summary>
        /// Создает приложение SolidWorks и хранит информацию о нем.
        /// </summary>
        /// <param name="sldWorks">Объект приложения SolidWorks.</param>
        public SwApplication(SldWorks sldWorks) : base(sldWorks)
        {
            Logger.LogInformation($"Создаем SwApplication (PID: {sldWorks.GetProcessID()})");

            if (sldWorks.IActiveDoc2 != null)
            {
                Logger.LogInformation($"SolidWorks имеет активный документ \"{sldWorks.IActiveDoc2.GetTitle()}\"");

                ActiveDocument = new SwModelDoc(sldWorks.IActiveDoc2);
            }
        }

        #endregion

        #region Public Methods 

        public async Task<(SwModelDoc Document, swFileLoadError_e Error, swFileLoadWarning_e Warning)> OpenDocumentAsync(string fileName, SwDocumentType documentType)
        {
            return await Task.Run(() =>
            {
                int tempErrors = 0;
                int tempWarnings = 0;

                var openedDocument = BaseObject.OpenDoc6(
                    fileName,
                    (int)documentType,
                    (int)swOpenDocOptions_e.swOpenDocOptions_Silent,
                    "",
                    ref tempErrors,
                    ref tempWarnings
                );

                return (
                    Document: openedDocument != null ? new SwModelDoc(openedDocument) : null,
                    Error: (swFileLoadError_e)tempErrors,
                    Warning: (swFileLoadWarning_e)tempWarnings
                );
            });
        }

        #endregion

        #region Dispose

        /// <summary>
        /// Правильно очищает данные объекта.
        /// </summary>
        public override void Dispose()
        {
            Logger.LogInformation($"Запущено удаление (PID: {BaseObject.GetProcessID()})");

            lock (_disposingLock)
            {
                // Устанавливаем флаг, что идет процесс очистки
                _isDisposing = true;

                // Очищаем текущий документ
                ActiveDocument?.Dispose();

                // ПОМЕТКА: Не очищать приложение, SolidWorks делает это сам
                //base.Dispose();
            }
        }

        #endregion
    }
}
