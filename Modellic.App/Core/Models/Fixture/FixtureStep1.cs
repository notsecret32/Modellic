using Microsoft.Extensions.Logging;
using Modellic.App.Enums;
using Modellic.App.Extensions;
using static Modellic.App.Logging.LoggerService;

namespace Modellic.App.Core.Models.Fixture
{
    public class FixtureStep1 : FixtureStep
    {
        public override string Title => "Внешний диск";

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
            _document.Extension.SelectPlane(SwPlane.Front);

            // Создаем эскиз
            _document.SketchManager.CreateSketch(() =>
            {
                // TODO: Перенести в свойства
                const double diameter = 280;
                const double width = 10;

                // Высчитываем радиус внешней окружности
                double radius = (diameter / 2).ToMeters();
                Logger.LogInformation($"[FixtureStep1] Радиус внешней окружности = {radius}");

                // Создаем внешнюю окружность
                _document.SketchManager.CreateCircle(
                    0,       0, 0,
                    radius , 0, 0
                );

                // Высчитываем радиус внутренней окружности
                radius = (diameter / 2 - width).ToMeters();
                Logger.LogInformation($"[FixtureStep1] Радиус внутренней окружности = {radius}");

                // Создаем внутреннюю окружность
                _document.SketchManager.CreateCircle(
                    0, 0, 0, // Начало
                    radius, 0, 0  // Конец
                );
            },
            "ВнешнийДискЭскиз");
        }

        #endregion
    }
}
