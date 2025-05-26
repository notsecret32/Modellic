using Modellic.App.Enums;
using Modellic.App.SolidWorks.Documents;
using Modellic.App.SolidWorks.Managers;
using SolidWorks.Interop.sldworks;

namespace Modellic.App.SolidWorks.Core
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

        #region Constructors

        /// <summary>
        /// Создает новый документ.
        /// </summary>
        /// <param name="model">Объект документа.</param>
        public SwModelDoc(ModelDoc2 model) : base(model)
        {
            // Обновляем информацию о текущем документе
            ReloadModelDocData();
        }

        #endregion

        #region Model Document Methods

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
