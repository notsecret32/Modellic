using Modellic.App.SolidWorks.Core;
using SolidWorks.Interop.sldworks;

namespace Modellic.App.SolidWorks.Managers
{
    /// <summary>
    /// Предоставляет доступ к менеджеру создания эскизов.
    /// </summary>
    public class SwSketchManager : SwObject<SketchManager>
    {
        #region Constructors

        public SwSketchManager(SketchManager sketchManager) : base(sketchManager)
        {

        }

        #endregion
    }
}
