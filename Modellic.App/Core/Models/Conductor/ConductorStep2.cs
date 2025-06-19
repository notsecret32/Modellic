using Microsoft.Extensions.Logging;
using Modellic.App.Core.Models.Conductor.Parameters;
using Modellic.App.Core.Services;
using Modellic.App.Extensions;
using Modellic.App.SolidWorks.Documents;
using Modellic.App.SolidWorks.Managers.Helpers;
using Modellic.App.SolidWorks.Models;
using SolidWorks.Interop.swconst;
using static Modellic.App.Logging.LoggerService;

namespace Modellic.App.Core.Models.Conductor
{
    public class ConductorStep2 : ConductorBaseStep
    {
        #region Public Overrided Members

        public override string Title => "Внутренний диск";

        public new ConductorStep2Params Parameters
        {
            get => (ConductorStep2Params)base.Parameters;
            set => base.Parameters = value;
        }

        #endregion

        #region Public Properties

        public SwFeature InnerDisk { get; private set; } = default;

        public SwFeature Cutout { get; private set; } = default;

        #endregion

        #region Constructors

        public ConductorStep2(ConductorBuilder builder, SwPartDoc partDoc = null) : base(builder, partDoc)
        {

        }

        #endregion

        #region Protected Overrided Methods

        protected override void BuildStep()
        {
            Logger.LogInformation($"[FixtureStep2] Строим шаг \"{Title}\"");

            BuildInnerDisk();

            BuildCutout();
        }

        protected override bool Validate()
        {
            return true;
        }

        #endregion

        #region Private Methods

        private void BuildInnerDisk()
        {
            var step1 = _builder.GetStep<ConductorStep1>();

            step1.OuterDisk.SelectFaceByIndex(1);

            Document.SketchManager.CreateSketch(() =>
            {
                var radius = (step1.Parameters.Diameter / 2) - step1.Parameters.Width;
                Document.SketchManager.CreateCircleByRadius(
                    0, 0, 0,
                    radius.ToMeters()
                );

                radius = Parameters.Diameter / 2;
                Document.SketchManager.CreateCircleByRadius(
                    0, 0, 0,
                    radius.ToMeters()
                );
            },
            "ВнутренДискЭскиз");

            InnerDisk = Document.FeatureManager.FeatureExtrusion(
                "ВнутреннийДиск",
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
                    true,
                    false
                ),
                reverseExtrudeSide: true
            );

            Document.ClearSelection();
        }

        private void BuildCutout()
        {
            InnerDisk.SelectFaceByIndex(1);

            Document.SketchManager.CreateSketch(() =>
            {
                var radius = (Parameters.Diameter / 2) + Parameters.CutoutDepth;
                Document.SketchManager.CreateCircleByRadius(
                    0, 0, 0,
                    radius.ToMeters()
                );
            },
            "ВнутренДискВырезЭскиз");

            Cutout = Document.FeatureManager.FeatureCut(
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
            Cutout.Name = "ВнутренДискВырез";
        }

        #endregion
    }
}
