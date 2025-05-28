using Microsoft.Extensions.Logging;
using Modellic.App.Enums;
using Modellic.App.SolidWorks.Core;
using Modellic.App.SolidWorks.Documents;
using Modellic.App.SolidWorks.Localization;
using SolidWorks.Interop.sldworks;
using static Modellic.App.Logging.LoggerService;

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

        #region Public Methods

        public bool SelectPlane(SwPlane plane)
        {
            string planeName = LocalizationManager.GetPlaneName(plane);

            Logger.LogInformation($"Выбираем плоскость \"{planeName}\"");

            return BaseObject.SelectByID2(planeName, "PLANE", 0, 0, 0, false, 0, null, 0);
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
