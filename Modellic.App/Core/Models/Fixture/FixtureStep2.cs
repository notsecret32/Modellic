using Microsoft.Extensions.Logging;
using Modellic.App.Core.Models.Fixture.Parameters;
using static Modellic.App.Logging.LoggerService;

namespace Modellic.App.Core.Models.Fixture
{
    public class FixtureStep2 : FixtureStep
    {
        #region Public Overrided Members

        public override string Title => "Внешний диск";

        public new FixtureStep2Parameters Parameters
        {
            get => (FixtureStep2Parameters)base.Parameters;
            set => base.Parameters = value;
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
