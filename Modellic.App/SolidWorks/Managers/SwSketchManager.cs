using Modellic.App.SolidWorks.Core;
using SolidWorks.Interop.sldworks;

namespace Modellic.App.SolidWorks.Managers
{
    public class SwSketchManager : SwObject<SketchManager>
    {
        #region Constructors

        public SwSketchManager(SketchManager sketchManager) : base(sketchManager)
        {

        }

        #endregion
    }
}
