using Microsoft.Extensions.Logging;
using Modellic.App.Core.Models.Fixture.Parameters;
using static Modellic.App.Logging.LoggerService;

namespace Modellic.App.Core.Models.Fixture
{
    public class FixtureStep2 : FixtureStep
    {
        #region Publuc Overrided Members

        public override string Title => "Крепления внешнего диска";

        #endregion

        #region Public Properties

        public FixtureStep2Parameters Parameters { get; protected set; }

        #endregion

        #region Constructor

        public FixtureStep2(FixtureStep2Parameters parameters = null) : base()
        {
            Parameters = parameters;
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
