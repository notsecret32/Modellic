using Microsoft.Extensions.Logging;
using Modellic.App.Core.Models.Conductor.Parameters;
using Modellic.App.Core.Services;
using Modellic.App.SolidWorks.Documents;
using static Modellic.App.Logging.LoggerService;

namespace Modellic.App.Core.Models.Conductor
{
    public class ConductorStep4 : ConductorBaseStep
    {
        #region Public Overrided Members

        public override string Title => "Нижнее приспособление";

        public new ConductorStep4Params Parameters
        {
            get => (ConductorStep4Params)base.Parameters;
            set => base.Parameters = value;
        }

        #endregion

        #region Constructors

        public ConductorStep4(ConductorBuilder builder, SwPartDoc partDoc = null) : base(builder, partDoc)
        {

        }

        #endregion

        #region Protected Overrided Methods

        protected override void BuildStep()
        {
            Logger.LogInformation($"[FixtureStep3] Строим шаг \"{Title}\"");
        }

        protected override bool Validate()
        {
            return true;
        }

        #endregion

        #region Private Methods

        #endregion
    }
}
