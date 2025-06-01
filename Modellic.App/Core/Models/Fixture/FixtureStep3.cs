using Microsoft.Extensions.Logging;
using Modellic.App.Core.Models.Fixture.Parameters;
using Modellic.App.Enums;
using Modellic.App.Extensions;
using SolidWorks.Interop.swconst;
using static Modellic.App.Logging.LoggerService;

namespace Modellic.App.Core.Models.Fixture
{
    public class FixtureStep3 : FixtureStep
    {
        #region Publuc Overrided Members

        public override string Title => "Внутренний диск";

        #endregion

        #region Public Properties

        public FixtureStep3Parameters Parameters { get; protected set; }

        #endregion

        #region Constructor

        public FixtureStep3(FixtureStep3Parameters parameters = null) : base()
        {
            Parameters = parameters;
        }

        #endregion

        #region Protected Overrided Methods

        protected override void BuildStep()
        {
            Logger.LogInformation($"[FixtureStep3] Строим шаг \"{Title}\"");

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
                    (Parameters.Diameter / 2).ToMeters(), 0, 0
                );
            },
            "ВнешннийДискЭскиз");

            var feature = Document.FeatureManager.UnsafeObject.FeatureExtrusion3(
                true,
                false,
                true,
                0,
                0,
                Parameters.Thickness.ToMeters(),
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
                Parameters.Offset.ToMeters(),
                true
            );
        }

        protected override bool Validate()
        {
            return true;
        }

        #endregion
    }
}
