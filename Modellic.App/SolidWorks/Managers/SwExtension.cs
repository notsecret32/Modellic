using Modellic.App.SolidWorks.Core;
using SolidWorks.Interop.sldworks;

namespace Modellic.App.SolidWorks.Managers
{
    /// <summary>
    /// Предоставляет доступ к модели документа.
    /// </summary>
    public class SwExtension : SwSharedObject<ModelDocExtension>
    {
        #region Public Properties

        /// <summary>
        /// Родительский документ к которому принадлежит.
        /// </summary>
        public SwModelDoc Parent { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Создаем объект предоставляющий доступ к модели документа.
        /// </summary>
        /// <param name="model">Модель активного документа.</param>
        /// <param name="parent">Документ, у которого берется доступ к модели документа.</param>
        public SwExtension(ModelDocExtension model, SwModelDoc parent) : base(model)
        {
            Parent = parent;
        }

        #endregion

        #region Dispose

        public override void Dispose()
        {
            Parent = null;

            base.Dispose();
        }

        #endregion
    }
}
