using Modellic.App.SolidWorks.Core;
using SolidWorks.Interop.sldworks;

namespace Modellic.App.SolidWorks.Managers
{
    /// <summary>
    /// Предоставляет доступ к менеджеру выбранных элементов.
    /// </summary>
    public class SwFeatureManager : SwObject<FeatureManager>
    {
        #region Constructors

        public SwFeatureManager(FeatureManager featureManager) : base(featureManager)
        {

        }

        #endregion
    }
}
