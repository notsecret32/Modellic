using Microsoft.Extensions.Logging;
using Modellic.App.Core.Models.Fixture.Parameters;
using Modellic.App.Enums;
using Modellic.App.Extensions;
using SolidWorks.Interop.swconst;
using static Modellic.App.Logging.LoggerService;

namespace Modellic.App.Core.Models.Fixture
{
    public class FixtureStep1 : FixtureStep
    {
        #region Publuc Overrided Members

        public override string Title => "Внешний диск";

        #endregion

        #region Public Properties

        public FixtureStep1Parameters Parameters { get; protected set; }

        #endregion

        #region Constructor

        public FixtureStep1(FixtureStep1Parameters parameters = null) : base()
        {
            Parameters = parameters;
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

            double thickness = Parameters.Thickness.ToMeters();

            var feature = Document.FeatureManager.UnsafeObject.FeatureExtrusion3(
                true,
                false,
                true,
                (int)swEndConditions_e.swEndCondBlind,
                0,
                thickness,
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
                (int)swStartConditions_e.swStartSketchPlane,
                0,
                false
            );
        }

        #endregion
    }
}
