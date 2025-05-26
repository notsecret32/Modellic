using Microsoft.Extensions.Logging;
using Modellic.App.Enums;
using Modellic.App.SolidWorks.Core;
using Modellic.App.SolidWorks.Managers;
using SolidWorks.Interop.sldworks;
using System;
using static Modellic.App.Logging.LoggerService;

namespace Modellic.App.SolidWorks.Documents
{
    /// <summary>
    /// Представляет собой любой тип файла в SolidWorks (Модель, Сборка, Чертеж).
    /// </summary>
    public class SwModelDoc : SwSharedObject<ModelDoc2>
    {
        #region Public Manager Properties

        /// <summary>
        /// Предоставляет доступ к модели документа.
        /// </summary>
        public SwExtension Extension { get; protected set; }

        /// <summary>
        /// Предоставляет доступ к менеджеру выбранных элементов.
        /// </summary>
        public SwSelectionManager SelectionManager { get; protected set; }

        /// <summary>
        /// Предоставляет доступ к менеджеру создания эскизов.
        /// </summary>
        public SwSketchManager SketchManager { get; protected set; }

        /// <summary>
        /// Предоствляет доступ к дереву проектирования.
        /// </summary>
        public SwFeatureManager FeatureManager { get; protected set; }

        #endregion

        #region Public Properties

        /// <summary>
        /// Имя документа.
        /// </summary>
        public string Name => BaseObject.GetTitle();

        /// <summary>
        /// Абсолютный путь к файлу этого документа, если он был сохранен.
        /// </summary>
        public string FilePath { get; protected set; }

        /// <summary>
        /// Указывает, был ли этот файл сохранен (то есть существует ли он на диске).
        /// Если нет, то это новый документ, который в настоящее время находится только в памяти и не будет содержать пути к файлу.
        /// </summary>
        public bool HasBeenSaved => !string.IsNullOrEmpty(FilePath);

        /// <summary>
        /// Указывает, нуждается ли этот файл в сохранении (содержит изменения в файле).
        /// </summary>
        public bool NeedsSaving => BaseObject.GetSaveFlag();

        /// <summary>
        /// Тип документа, такого как деталь, сборка или чертеж.
        /// </summary>
        public SwDocumentType DocumentType { get; protected set; }

        /// <summary>
        /// True, если этот документ детали.
        /// </summary>
        public bool IsPart => DocumentType == SwDocumentType.Part;

        /// <summary>
        /// True, если этот документ сборки.
        /// </summary>
        public bool IsAssembly => DocumentType == SwDocumentType.Assembly;

        #endregion

        #region Public Events

        /// <summary>
        /// Вызывается, когда документ был сохранен.
        /// </summary>
        public event Action DocumentSaved = () => { };

        /// <summary>
        /// Вызывается, когда документ вот-вот будет закрыт. Принимает <see cref="SwDestroyNotifyType"/> в качестве параметра.
        /// </summary>
        public event Action<SwDestroyNotifyType> DocumentClosing = destroyType => { };

        /// <summary>
        /// Вызывается каждый раз, когда любая информация о документе изменяется.
        /// </summary>
        public event Action DocumentInfoChanged = () => { };

        /// <summary>
        /// Вызывается каждый раз, когда меняется список выбранных элементов.
        /// </summary>
        public event Action SelectionChanged = () => { };

        #endregion

        #region Constructors

        /// <summary>
        /// Создает новый документ.
        /// </summary>
        /// <param name="model">Объект документа.</param>
        public SwModelDoc(ModelDoc2 model) : base(model)
        {
            Logger.LogInformation("Создаем новый документ");

            // Обновляем информацию о текущем документе
            ReloadModelDocData();

            // Подписываемся на изменения
            SubscribeToEvents();
        }

        #endregion

        #region Document Event Methods

        /// <summary>
        /// Перезагружает все данные о документе.
        /// ВАЖНО: При добавлении новых данных их так же надо очищать в методе <see cref="DisposeAllReferences"/> и <see cref="Dispose"/>.
        /// </summary>
        protected void ReloadModelDocData()
        {
            // Очищаем данные о прошлом документе
            DisposeAllReferences();

            // Если докумета нет, то ничего не делаем
            if (BaseObject == null)
                return;

            // Получаем путь до файла
            FilePath = BaseObject.GetPathName();

            // Получаем тип документа
            DocumentType = (SwDocumentType)BaseObject.GetType();

            // Получаем Extension документа
            Extension = new SwExtension(BaseObject.Extension, this);

            // Получаем SelectionManager документа
            SelectionManager = new SwSelectionManager(BaseObject.SelectionManager);

            // Получаем SketchManager документа
            SketchManager = new SwSketchManager(BaseObject.SketchManager);

            // Получаем FeatureManager документа
            FeatureManager = new SwFeatureManager(BaseObject.FeatureManager);

            // Получаем текущий документ как Part документ
            PartDoc = IsPart ? new SwPartDoc((PartDoc)BaseObject) : null;

            // Получаем текущий документ как Assembly документ
            AssemblyDoc = IsAssembly ? new SwAssemblyDoc((AssemblyDoc)BaseObject) : null;

            // Информируем всех подписчиков об изменении документа.
            DocumentInfoChanged();
        }

        /// <summary>
        /// Метод для подписки на события приложения SolidWorks.
        /// </summary>
        protected void SubscribeToEvents()
        {
            switch (DocumentType)
            {
                case SwDocumentType.Part:
                    this.AsPart().DestroyNotify2 += DocumentPreDestroy;
                    break;
                case SwDocumentType.Assembly:
                    this.AsAssembly().DestroyNotify2 += DocumentPreDestroy;
                    break;
            }
        }

        /// <summary>
        /// Метод для отписки от событий приложения SolidWorks.
        /// </summary>
        protected void UnsubscribeFromEvents()
        {
            switch (DocumentType)
            {
                case SwDocumentType.Part when AsPart() == null:
                case SwDocumentType.Assembly when AsAssembly() == null:
                    {
                        // Происходит в нескольких случаях:
                        // 1: При закрытии SolidWorks
                        // 1: При закрытии не последней модели
                        // 2: При открытии первой модели после закрытия всех моделей.
                        return;
                    }
            }

            switch (DocumentType)
            {
                case SwDocumentType.Part:
                    this.AsPart().DestroyNotify2 -= DocumentPreDestroy;
                    break;
                case SwDocumentType.Assembly:
                    this.AsAssembly().DestroyNotify2 -= DocumentPreDestroy;
                    break;
            }
        }

        #endregion

        #region Document Event Handlers

        /// <summary>
        /// Метод, который вызывается вот-вот перед удалением документа.
        /// </summary>
        /// <param name="destroyType">Тип удаления файла. Подробности в <see cref="SwDestroyNotifyType"/>.</param>
        /// <returns>Результат работы метода. 0 - все хорошо; остальное - ошибка.</returns>
        protected int DocumentPreDestroy(int destroyType)
        {
            // Получаем тип удаления файла
            SwDestroyNotifyType destroyNotifyType = (SwDestroyNotifyType)destroyType;

            // Выводим логи
            Logger.LogInformation($"Файл \"{Name}\" вот-вот будет закрыт с типом {destroyNotifyType}");

            // Сообщаем об удалении файла
            DocumentClosing(destroyNotifyType);

            // Уничтожаем текущий документ ДО того, как будет удален COM объект
            // В противном случае будет утечка памяти
            Dispose();

            // 0 значит все хорошо, все остальное ошибка
            return 0;
        }

        #endregion

        #region Document Cast

        /// <summary>
        /// Текущий документ как <see cref="PartDoc"/>.
        /// Перед использованием необходимо проверить через <see cref="IsPart"/>.
        /// </summary>
        public SwPartDoc PartDoc { get; private set; }

        /// <summary>
        /// Текущий документ как <see cref="AssemblyDoc"/>.
        /// Перед использованием необходимо проверить через <see cref="IsAssembly"/>.
        /// </summary>
        public SwAssemblyDoc AssemblyDoc { get; private set; }

        /// <summary>
        /// Преобразует текущий документ в документ типа <see cref="SwDocumentType.Part"/>.
        /// </summary>
        /// <returns>Текущий документ типа <see cref="SwDocumentType.Part"/>.</returns>
        public PartDoc AsPart() => (PartDoc)BaseObject;

        /// <summary>
        /// Преобразует текущий документ в документ типа <see cref="SwDocumentType.Assembly"/>.
        /// </summary>
        /// <returns>Текущий документ типа <see cref="SwDocumentType.Assembly"/>.</returns>
        public AssemblyDoc AsAssembly() => (AssemblyDoc)BaseObject;

        #endregion

        #region Dispose

        /// <summary>
        /// Очищает все данные ссылки, то есть менеджеры документа.
        /// </summary>
        protected void DisposeAllReferences()
        {
            Extension?.Dispose();
            Extension = null;

            SelectionManager?.Dispose();
            SelectionManager = null;

            SketchManager?.Dispose();
            SketchManager = null;

            FeatureManager?.Dispose();
            FeatureManager = null;

            // Удаляем все обработчики
            UnsubscribeFromEvents();
        }

        /// <summary>
        /// Очищает данные документа и сам документ.
        /// </summary>
        public override void Dispose()
        {
            // Очищаем все данные
            DisposeAllReferences();

            // Удаляем сам объект
            base.Dispose();
        }

        #endregion
    }
}
