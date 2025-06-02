using Microsoft.Extensions.Logging;
using Modellic.App.Core.Models.Fixture.Parameters;
using Modellic.App.Core.Services;
using Modellic.App.Enums;
using Modellic.App.Extensions;
using Modellic.App.SolidWorks.Documents;
using Modellic.App.SolidWorks.Managers.Helpers;
using SolidWorks.Interop.swconst;
using static Modellic.App.Logging.LoggerService;

namespace Modellic.App.Core.Models.Fixture
{
    public class FixtureStep3 : FixtureStep
    {
        #region Public Overrided Members

        public override string Title => "Внутренний диск";

        public new FixtureStep3Parameters Parameters
        {
            get => (FixtureStep3Parameters)base.Parameters;
            set => base.Parameters = value;
        }

        #endregion

        #region Constructors

        public FixtureStep3(FixtureBuilder builder, SwPartDoc partDoc = null) : base(builder, partDoc)
        {

        }

        #endregion

        #region Protected Overrided Methods

        protected override void BuildStep()
        {
            Logger.LogInformation($"[FixtureStep3] Строим шаг \"{Title}\"");

            CreateInnerDisk();

            CreateCutout();
        }

        protected override bool Validate()
        {
            return true;
        }

        #endregion

        #region Private Methods

        private void CreateInnerDisk()
        {
            Document.Extension.SelectPlane(SwPlane.Front);

            Document.SketchManager.CreateSketch((sketchName) =>
            {
                var step1 = _builder.GetStep<FixtureStep1>().Parameters;

                double radius = ((step1.Diameter / 2) - step1.Width).ToMeters();
                Document.SketchManager.CreateCircle(
                    0, 0, 0,
                    radius, 0, 0
                );

                Document.SketchManager.CreateCircle(
                    0, 0, 0,
                    (Parameters.Diameter / 2).ToMeters(), 0, 0
                );
            },
            "ВнутренДискЭскиз");

            var createdFeature = Document.FeatureManager.FeatureExtrusion(
                new StartExtrusionParameters(
                    swStartConditions_e.swStartOffset,
                    Parameters.Offset.ToMeters(),
                    true
                ),
                new EndExtrusionParameters(
                    swEndConditions_e.swEndCondBlind,
                    Parameters.Thickness.ToMeters(),
                    false,
                    0,
                    false,
                    false,
                    false
                )
            );
            createdFeature.Name = "ВнутренДиск";
        }

        private void CreateCutout()
        {
            Document.SketchManager.CreateSketch((sketchName) =>
            {
                Document.Extension.SelectByName("ВнутренДиск", "FACE");

                Document.SketchManager.CreateCircleByRadius(
                    0, 0, 0,
                    Parameters.CutoutDepth.ToMeters()
                );
            },
            "ВнешнДискВырез");

            var createdCut = Document.FeatureManager.FeatureCut(
                new StartExtrusionParameters(
                    swStartConditions_e.swStartOffset,
                    Parameters.CutoutOffset.ToMeters(),
                    true
                ),
                new EndExtrusionParameters(
                    swEndConditions_e.swEndCondBlind,
                    Parameters.CutoutThickness.ToMeters(),
                    false,
                    0,
                    false,
                    false,
                    false
                )
            );
            createdCut.Name = "ВнешнДискВырез";
        }

        #endregion
    }
}
