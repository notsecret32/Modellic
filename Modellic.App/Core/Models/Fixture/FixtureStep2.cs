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
    public class FixtureStep2 : FixtureStep
    {
        #region Public Overrided Members

        public override string Title => "Крепление внешнего диска";

        public new FixtureStep2Parameters Parameters
        {
            get => (FixtureStep2Parameters)base.Parameters;
            set => base.Parameters = value;
        }

        #endregion

        #region Constructors

        public FixtureStep2(FixtureBuilder builder, SwPartDoc partDoc = null) : base(builder, partDoc)
        {

        }

        #endregion

        #region Protected Overrided Methods

        protected override void BuildStep()
        {
            Logger.LogInformation($"[FixtureStep2] Строим шаг \"{Title}\"");

            Document.Extension.SelectPlane(SwPlane.Front);

            Document.SketchManager.CreateSketch((sketchName) =>
            {
                var step1 = _builder.GetStep<FixtureStep1>().Parameters;

                // Вычисляем точку начала окружности
                double mountCircleCenter = ((step1.Diameter / 2) + Parameters.MountWidth - (Parameters.MountHeight / 2)).ToMeters();

                // Вычисляем радиус этой окружности
                double mountCircleRadius = (Parameters.MountHeight / 2).ToMeters();

                var mainCircle = Document.SketchManager.UnsafeObject.CreateArc(
                    mountCircleCenter, 0, 0,
                    mountCircleCenter, -(Parameters.MountHeight / 2).ToMeters(), 0,
                    mountCircleCenter, (Parameters.MountHeight / 2).ToMeters(), 0,
                    1
                );

                // Вычисляем радиус окружности под отверстие
                double holeRadius = (Parameters.HoleDiameter / 2).ToMeters();

                // Строим окружность под отверстие
                var holeCircle = Document.SketchManager.CreateCircleByRadius(
                    mountCircleCenter, 0, 0, // Координаты
                    holeRadius               // Радиус
                );

                // Вычисляем точки для линий
                double startX = mountCircleCenter;
                double startY = (Parameters.MountHeight / 2).ToMeters();
                double endX = (step1.Diameter / 2).ToMeters();
                double endY = (Parameters.MountHeight / 2).ToMeters();

                // Строим линии
                Document.SketchManager.CreateLine(
                    startX, startY, 0, // Точка1
                    endX, endY, 0  // Точка2
                );

                Document.SketchManager.CreateLine(
                    endX, endY, 0, // Точка1
                    endX, -endY, 0  // Точка2
                );

                Document.SketchManager.CreateLine(
                    endX, -endY, 0, // Точка1
                    startX, -startY, 0  // Точка2
                );
                //Document.UnsafeObject.ClearSelection2(true);

                Document.UnsafeObject.CreateCircularSketchStepAndRepeat(0, 360.0.ToRad(), 4, 0, false, "");

                // Объединяем первую точку
                Document.Extension.SelectByPosition("VERTEX", endX, endY, 0);
                Document.Extension.SelectByPosition("EDGE", (step1.Diameter / 2).ToMeters(), 0, 0);
                Document.UnsafeObject.SketchAddConstraints("sgCOINCIDENT");
                Document.UnsafeObject.ClearSelection2(true);
            },
            "ВнешнДискКреплЭскиз");

            var createdFeature = Document.FeatureManager.FeatureExtrusion(
                new StartExtrusionParameters(
                    swStartConditions_e.swStartSketchPlane,
                    0,
                    false
                ),
                new EndExtrusionParameters(
                    swEndConditions_e.swEndCondThroughAll,
                    0,
                    false,
                    0,
                    false,
                    false,
                    false
                )
            );
            createdFeature.Name = "ВнешнДискКрепл";
        }

        protected override bool Validate()
        {
            return true;
        }
        
        #endregion
    }
}
