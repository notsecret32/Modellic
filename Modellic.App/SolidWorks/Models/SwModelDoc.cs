using Modellic.App.SolidWorks.Core;
using SolidWorks.Interop.sldworks;

namespace Modellic.App.SolidWorks.Models
{
    /// <summary>
    /// Представляет собой любой тип файла в SolidWorks (Модель, Сборка, Чертеж).
    /// </summary>
    public class SwModelDoc : SharedSwObject<IModelDoc2>
    {
        #region Constructors

        public SwModelDoc(IModelDoc2 model) : base(model) { }

        #endregion

        #region Dispose

        public override void Dispose()
        {
            base.Dispose();
        }

        #endregion
    }
}
