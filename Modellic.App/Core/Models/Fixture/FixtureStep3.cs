using Microsoft.Extensions.Logging;
using static Modellic.App.Logging.LoggerService;

namespace Modellic.App.Core.Models.Fixture
{
    public class FixtureStep3 : FixtureStep
    {
        public override string Title => "Верхнее крепление";

        public override void Build()
        {
            Logger.LogInformation($"Собираем FixtureStep под именем {Title}");
        }
    }
}
