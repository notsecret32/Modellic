using Microsoft.Extensions.Logging;
using static Modellic.App.Logging.LoggerService;

namespace Modellic.App.Core.Models.Fixture
{
    public class FixtureStep4 : FixtureStep
    {
        public override string Title => "Нижнее крепление";

        public override void Build()
        {
            Logger.LogInformation($"Собираем FixtureStep под именем {Title}");
        }
    }
}
