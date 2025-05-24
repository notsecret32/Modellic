using Modellic.App.SolidWorks.Core;
using SolidWorks.Interop.sldworks;

namespace Modellic.App.SolidWorks.Managers
{
    public class SwFeatureManager : SwObject<FeatureManager>
    {
        #region Constructors

        public SwFeatureManager(FeatureManager featureManager) : base(featureManager)
        {

        }

        #endregion
    }
}
