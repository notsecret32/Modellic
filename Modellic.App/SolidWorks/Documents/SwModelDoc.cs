using Modellic.App.Enums;
using Modellic.App.SolidWorks.Core;
using Modellic.App.SolidWorks.Managers;
using SolidWorks.Interop.sldworks;

namespace Modellic.App.SolidWorks.Documents
{
    /// <summary>
    /// Представляет собой любой тип файла в SolidWorks (Модель, Сборка, Чертеж).
    /// </summary>
    public class SwModelDoc : SwSharedObject<ModelDoc2>
    {
        #region Public Manager Properties

        public SwModelDocExtension Extension { get; protected set; }

        public SwSelectionManager SelectionManager { get; protected set; }

        public SwSketchManager SketchManager { get; protected set; }

        public SwFeatureManager FeatureManager { get; protected set; }

        #endregion

        #region Public Properties

        public string FilePath { get; protected set; }

        public bool HasBeenSaved => !string.IsNullOrEmpty(FilePath);

        public bool NeedsSaving => BaseObject.GetSaveFlag();

        public SwDocumentType DocumentType { get; protected set; }

        public bool IsPart => DocumentType == SwDocumentType.Part;

        public bool IsAssembly => DocumentType == SwDocumentType.Assembly;

        #endregion

        #region Constructors

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
            Extension = new SwModelDocExtension(BaseObject.Extension, this);

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
