using Microsoft.Extensions.Logging;
using Modellic.App.Core.Models.Conductor.Parameters;
using Modellic.App.Core.Services;
using Modellic.App.Enums;
using Modellic.App.Extensions;
using Modellic.App.SolidWorks.Documents;
using Modellic.App.SolidWorks.Managers.Helpers;
using Modellic.App.SolidWorks.Models;
using SolidWorks.Interop.swconst;
using static Modellic.App.Logging.LoggerService;

namespace Modellic.App.Core.Models.Conductor
{
    public class ConductorStep1 : ConductorBaseStep
    {
        #region Public Overrided Members

        public override string Title => "Внешний диск";

        public new ConductorStep1Params Parameters
        {
            get => (ConductorStep1Params)base.Parameters;
            set => base.Parameters = value;
        }

        #endregion
        
        #region Public Properties

        public SwFeature OuterDisk { get; private set; } = default;

        #endregion

        #region Constructors

        public ConductorStep1(ConductorBuilder builder, SwPartDoc partDoc = null) : base(builder, partDoc)
        {

        }

        #endregion

        #region Protected Methods

        protected override void BuildStep()
        {
            Logger.LogInformation($"[FixtureStep1] Строим шаг \"{Title}\"");

            // Создаем диск
            CreateDisk();
        }

        protected override bool Validate()
        {
            return true;
        }

        #endregion

        #region Private Methods

        private void CreateDisk()
        {
            Logger.LogInformation($"[FixtureStep1] Создаем диск");

            // Выбираем плоскость
            Document.Extension.SelectPlane(SwPlane.Front);

            // Создаем эскиз
            Document.SketchManager.CreateSketch(() =>
            {
                // Высчитываем радиус внешней окружности
                double radius = (Parameters.Diameter / 2).ToMeters();
                Logger.LogInformation($"[FixtureStep1] Радиус внешней окружности = {radius}");

                // Создаем внешнюю окружность
                Document.SketchManager.CreateCircle(
                    0,       0, 0,
                    radius , 0, 0
                );

                // Высчитываем радиус внутренней окружности
                radius = (Parameters.Diameter / 2 - Parameters.Width).ToMeters();
                Logger.LogInformation($"[FixtureStep1] Радиус внутренней окружности = {radius}");

                // Создаем внутреннюю окружность
                Document.SketchManager.CreateCircle(
                    0, 0, 0, // Начало
                    radius, 0, 0  // Конец
                );
            },
            "ВнешнийДискЭскиз");

            OuterDisk = Document.FeatureManager.FeatureExtrusion(
                "ВнешнийДиск",
                new StartExtrusionParameters(swStartConditions_e.swStartSketchPlane, 0, false),
                new EndExtrusionParameters(swEndConditions_e.swEndCondBlind, Parameters.Thickness.ToMeters(), false, 0, false, false, false),
                reverseExtrudeSide: true
            );

            Document.ClearSelection();
        }

        #endregion
    }
}
