using Microsoft.Extensions.Logging;
using Modellic.App.SolidWorks.Core;
using SolidWorks.Interop.sldworks;
using static Modellic.App.Logging.LoggerService;

namespace Modellic.App.SolidWorks.Models
{
    public class SwSketch : SwObject<Sketch>
    {
        #region Public Members

        public string Name { get; private set; }

        #endregion

        #region Constructors

        public SwSketch(Sketch comObject) : base(comObject)
        {
            Name = ((Feature)comObject).Name;
        }

        #endregion
    }
}
