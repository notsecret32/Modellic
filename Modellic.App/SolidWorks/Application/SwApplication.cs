using Microsoft.Extensions.Logging;
using Modellic.App.Enums;
using Modellic.App.SolidWorks.Core;
using Modellic.App.SolidWorks.Documents;
using SolidWorks.Interop.sldworks;
using System;
using static Modellic.App.Logging.LoggerService;

namespace Modellic.App.SolidWorks.Application
{
    /// <summary>
    /// Представляет собой приложение SolidWorks.
    /// </summary>
    public class SwApplication : SwSharedObject<SldWorks>
    {
        #region Protected Members

        /// <summary>
        /// Активный документ.
        /// </summary>
        protected SwModelDoc _activeDocument;

        #endregion

        #region Private Members

        /// <summary>
        /// Объект заглушка для удаления данных объекта в lock.
        /// </summary>
        private readonly object _disposingLock = new object();

        #endregion

        #region Public Properties

        /// <summary>
        /// Активный документ. Может быть null если нет открытого документа.
        /// </summary>
        public SwModelDoc ActiveDocument => _activeDocument;

        public bool Disposing { get; private set; }

        #endregion

        #region Public Events

        /// <summary>
        /// Вызывается при создании нового документа любого типа.
        /// </summary>
        public event Action<SwModelDoc, SwDocumentType, string> DocumentCreated = (newDocument, documentType, tempateName) => {};

        /// <summary>
        /// Вызывается при смене активного документа.
        /// </summary>
        public event Action<SwModelDoc> ActiveDocumentChanged = newActiveDoc => { };

        #endregion

        #region Constructors

        /// <summary>
        /// Создает приложение SolidWorks и хранит информацию о нем.
        /// </summary>
        /// <param name="solidWorks">Объект приложения SolidWorks.</param>
        public SwApplication(SldWorks solidWorks) : base(solidWorks)
        {
            Logger.LogInformation($"Создаем экземпляр класса SwApplication (PID: {solidWorks.GetProcessID()})");

            // Подписываемся на события
            SubscribeToEvents();
        }

        #endregion

        #region Application Event Methods

        /// <summary>
        /// Метод для подписки на события приложения SolidWorks.
        /// </summary>
        protected void SubscribeToEvents()
        {
            Logger.LogInformation("Подписываемся на события");

            BaseObject.FileNewNotify2 += OnNewFileCreated;
            BaseObject.ActiveDocChangeNotify += OnActiveDocChanged;
        }

        /// <summary>
        /// Метод для отписки от событий приложения SolidWorks.
        /// </summary>
        protected void UnsubscribeFromEvents()
        {
            Logger.LogInformation("Отписываемся от событий");

            BaseObject.FileNewNotify2 -= OnNewFileCreated;
            BaseObject.ActiveDocChangeNotify -= OnActiveDocChanged;
        }

        #endregion

        #region Event Handlers

        protected int OnActiveDocChanged()
        {
            ModelDoc2 newActiveDoc = BaseObject.ActiveDoc;
            SwModelDoc newSwDoc = null;

            if (newActiveDoc != null)
            {
                newSwDoc = new SwModelDoc(newActiveDoc);
            }

            // Освобождаем предыдущий документ
            var oldDoc = _activeDocument;
            _activeDocument = newSwDoc;
            oldDoc?.Dispose();

            Logger.LogInformation($"Активный документ был изменен на \"{newSwDoc?.Name ?? "null"}\"");

            ActiveDocumentChanged(_activeDocument);

            return 0;
        }

        protected int OnNewFileCreated(object newDoc, int documentType, string templateName)
        {
            SwModelDoc document = new SwModelDoc((ModelDoc2)newDoc);

            SwDocumentType swDocumentType = (SwDocumentType)documentType;

            Logger.LogInformation($"Создан новый файл \"{document.Name}\" типа [{swDocumentType}]");

            DocumentCreated(document, swDocumentType, templateName);

            return 0;
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
                Disposing = true;

                // Отписываемся от событий
                UnsubscribeFromEvents();

                // Очищаем текущий документ
                ActiveDocument?.Dispose();

                // ПОМЕТКА: Не очищать приложение, SolidWorks делает это сам
                //base.Dispose();
            }
        }

        #endregion
    }
}
