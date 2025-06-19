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
    public class ConductorStep3 : ConductorBaseStep
    {
        #region Public Members

        public SwFeature UpperFixture { get; private set; } = null;

        #endregion

        #region Public Overrided Members

        public override string Title => "Верхнее приспособление";

        public new ConductorStep3Params Parameters
        {
            get => (ConductorStep3Params)base.Parameters;
            set => base.Parameters = value;
        }

        #endregion

        #region Constructors

        public ConductorStep3(ConductorBuilder builder, SwPartDoc partDoc = null) : base(builder, partDoc)
        {

        }

        #endregion

        #region Protected Overrided Methods

        protected override void BuildStep()
        {
            Logger.LogInformation($"[FixtureStep3] Строим шаг \"{Title}\"");

            BuildUpperFixture();
        }

        protected override bool Validate()
        {
            return true;
        }

        #endregion

        #region Private Methods

        private void BuildUpperFixture()
        {
            var step1 = _builder.GetStep<ConductorStep1>();

            step1.OuterDisk.SelectFaceByIndex(1);

            Document.SketchManager.CreateSketch(() =>
            {
                var pointX = (Parameters.Width / 2).ToMeters();
                var bottomY = (step1.Parameters.Diameter / 2).ToMeters();
                var topY = bottomY + Parameters.Height.ToMeters();

                var centerLine = Document.SketchManager.CreateCenterLine(
                    0, 0, 0,
                    0, topY + 15.0.ToMeters(), 0
                );

                Document.SketchManager.CreateLine(
                    pointX, bottomY, 0,
                    pointX, topY, 0
                );

                var topLine = Document.SketchManager.CreateLine(
                    pointX, topY, 0,
                    -pointX, topY, 0
                );

                Document.SketchManager.CreateLine(
                    -pointX, topY, 0,
                    -pointX, bottomY, 0
                );

                Document.ClearSelection();

                topLine.Select4(true, null);
                Document.UnsafeObject.SelectMidpoint();
                centerLine.Select4(true, null);
                Document.UnsafeObject.SketchAddConstraints("sgCOINCIDENT");

                Document.ClearSelection();

                Document.SketchManager.SelectPointByIndex(4);
                step1.OuterDisk.SelectEdgeByIndex(3, 1);
                Document.UnsafeObject.AddVerticalDimension(
                    -pointX - 15.0.ToMeters(),
                    topY - (Parameters.Height / 2).ToMeters(),
                    0
                );

                Document.ClearSelection();

                Document.SketchManager.SelectPointByIndex(3);
                Document.SketchManager.SelectPointByIndex(4);
                Document.UnsafeObject.AddHorizontalDimension(
                    0,
                    topY + 15.0.ToMeters(),
                    0
                );

                Document.ClearSelection();

                Document.SketchManager.SelectPointByIndex(2);
                step1.OuterDisk.SelectEdgeByIndex(1, 0);
                Document.UnsafeObject.SketchAddConstraints("sgCOINCIDENT");

                Document.ClearSelection();

                Document.SketchManager.SelectPointByIndex(5);
                step1.OuterDisk.SelectEdgeByIndex(1, 0);
                Document.UnsafeObject.SketchAddConstraints("sgCOINCIDENT");

                Document.ClearSelection();

                var radius = (step1.Parameters.Diameter / 2) - step1.Parameters.Width;
                Document.SketchManager.CreateCircle(
                    0, 0, 0,
                    radius.ToMeters(), 0, 0
                );
                Document.SketchManager.UnsafeObject.SketchTrim((int)swSketchTrimChoice_e.swSketchTrimClosest, 0, -radius, 0);
            },
            "ВерхнПриспособЭскиз");

            step1.OuterDisk.SelectFaceByIndex(2);

            var createdFeature = Document.FeatureManager.UnsafeObject.FeatureExtrusion2(true, false, false, 1, 0, 0, 0, false, false, false, false, 0, 0, false, false, false, false, true, true, true, 1, 0, false);

            UpperFixture = new SwFeature(createdFeature)
            {
                Name = "ВерхнееПриспособление"
            };
        }

        #endregion
    }
}
