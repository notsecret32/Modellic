using Microsoft.Extensions.Logging;
using static Modellic.App.Logging.LoggerService;

namespace Modellic.App.Core.Models.Fixture
{
    public class FixtureStep2 : FixtureStep
    {
        public override string Title => "Внутренний диск";

        public override void Build()
        {
            Logger.LogInformation($"Собираем FixtureStep под именем {Title}");
        }
    }
}
