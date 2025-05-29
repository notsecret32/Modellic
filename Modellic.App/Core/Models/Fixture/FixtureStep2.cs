using Microsoft.Extensions.Logging;
using Modellic.App.Enums;
using Modellic.App.Extensions;
using SolidWorks.Interop.swconst;
using static Modellic.App.Logging.LoggerService;

namespace Modellic.App.Core.Models.Fixture
{
    public class FixtureStep2 : FixtureStep
    {
        #region Constants

        const double DEFAULT_DIAMETER = 195.2;

        const double DEFAULT_CHAMFER_WIDTH = 1.5;

        const double DEFAULT_CHAMFER_ANGLE_DEG = 45;

        const double DEFAULT_OFFSET = 1.5;

        const double DEFAULT_THICKNESS = 27.4;

        const int DEFAULT_HOLE_QUANTITY = 8;

        const double DEFAULT_HOLE_DIAMETER = 15;

        const double DEFAULT_CUTOUT_OFFSET = 10.5;

        const double DEFAULT_CUTOUT_THICKNESS = 10;

        const double DEFAULT_CUTOUT_DEPTH = 6;

        #endregion

        public override string Title => "Внутренний диск";

        protected override void BuildStep()
        {
            Logger.LogInformation($"[FixtureStep2] Строим шаг \"{Title}\"");

            Document.Extension.SelectPlane(SwPlane.Front);

            Document.SketchManager.CreateSketch(() =>
            {
                double radius = ((280.0 - 10) / 2).ToMeters();
                Document.SketchManager.CreateCircle(
                    0, 0, 0,
                    radius, 0, 0
                );

                Document.SketchManager.CreateCircle(
                    0, 0, 0,
                    (DEFAULT_DIAMETER / 2).ToMeters(), 0, 0
                );
            },
            "ВнешннийДискЭскиз");

            var feature = Document.FeatureManager.UnsafeObject.FeatureExtrusion3(
                true,
                false,
                true,
                0,
                0,
                DEFAULT_THICKNESS.ToMeters(),
                0,
                false,
                false,
                false,
                false,
                0,
                0,
                false,
                false,
                false,
                false,
                true,
                true,
                true,
                (int)swStartConditions_e.swStartOffset,
                DEFAULT_OFFSET.ToMeters(),
                true
            );
        }

        protected override bool Validate()
        {
            return true;
        }
    }
}
