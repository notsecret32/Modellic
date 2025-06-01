using Microsoft.Extensions.Logging;
using static Modellic.App.Logging.LoggerService;

namespace Modellic.App.Core.Models.Fixture
{
    public class FixtureStep2 : FixtureStep
    {
        #region Constants

        private const double DEFAULT_MOUNT_WIDTH = 27.5;

        private const double DEFAULT_MOUNT_HEIGHT = 24;

        private const int DEFAULT_MOUNT_QUANTITY = 8;

        private const double DEFAULT_HOLE_DIAMETER = 8.5;

        private const double DEFAULT_FILLET_RADIUS = 30;

        #endregion

        public override string Title => "Крепления внешнего диска";

        protected override void BuildStep()
        {
            Logger.LogInformation($"[FixtureStep2] Строим шаг \"{Title}\"");
        }

        protected override bool Validate()
        {
            return true;
        }
    }
}
