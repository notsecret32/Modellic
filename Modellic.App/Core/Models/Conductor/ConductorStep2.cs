using Microsoft.Extensions.Logging;
using Modellic.App.Core.Models.Conductor.Parameters;
using Modellic.App.Core.Services;
using Modellic.App.SolidWorks.Documents;
using static Modellic.App.Logging.LoggerService;

namespace Modellic.App.Core.Models.Conductor
{
    public class ConductorStep2 : ConductorBaseStep
    {
        #region Public Overrided Members

        public override string Title => "Внутренний диск";

        public new ConductorStep2Params Parameters
        {
            get => (ConductorStep2Params)base.Parameters;
            set => base.Parameters = value;
        }

        #endregion

        #region Constructors

        public ConductorStep2(ConductorBuilder builder, SwPartDoc partDoc = null) : base(builder, partDoc)
        {

        }

        #endregion

        #region Protected Overrided Methods

        protected override void BuildStep()
        {
            Logger.LogInformation($"[FixtureStep2] Строим шаг \"{Title}\"");
        }

        protected override bool Validate()
        {
            return true;
        }
        
        #endregion
    }
}
