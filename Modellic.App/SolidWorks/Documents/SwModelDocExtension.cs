using Modellic.App.SolidWorks.Core;
using SolidWorks.Interop.sldworks;

namespace Modellic.App.SolidWorks.Documents
{
    public class SwModelDocExtension : SharedSwObject<ModelDocExtension>
    {
        #region Public Properties

        public SwModelDoc Parent { get; set; }

        #endregion

        #region Constructor

        public SwModelDocExtension(ModelDocExtension model, SwModelDoc parent) : base(model)
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
