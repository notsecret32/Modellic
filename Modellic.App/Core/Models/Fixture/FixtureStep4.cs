using Microsoft.Extensions.Logging;
using static Modellic.App.Logging.LoggerService;

namespace Modellic.App.Core.Models.Fixture
{
    public class FixtureStep4 : FixtureStep
    {
        public override string Title => "Нижнее крепление";

        protected override void BuildStep()
        {
            Logger.LogInformation($"Строим шаг \"{Title}\"");
        }

        protected override bool Validate()
        {
            return true;
        }
    }
}
