using Microsoft.Extensions.Logging;
using static Modellic.App.Logging.LoggerService;

namespace Modellic.App.Core.Models.Fixture
{
    public class FixtureStep2 : FixtureStep
    {
        public override string Title => "Внутренний диск";

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
