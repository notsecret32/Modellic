using Modellic.App.SolidWorks.Core;
using Modellic.App.SolidWorks.Documents;
using SolidWorks.Interop.sldworks;

namespace Modellic.App.SolidWorks.Managers
{
    public class SwExtension : SwSharedObject<ModelDocExtension>
    {
        #region Public Properties

        public SwModelDoc Parent { get; set; }

        #endregion

        #region Constructor

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
