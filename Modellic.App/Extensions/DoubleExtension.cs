using System;

namespace Modellic.App.Extensions
{
    public static class DoubleExtension
    {
        /// <summary>
        /// Преобразует миллиметры в метры.
        /// </summary>
        /// <param name="millimeters">Значение в миллиметрах.</param>
        /// <returns>Значение в метрах.</returns>
        public static double ToMeters(this double millimeters)
        {
            return millimeters / 1000;
        }

        /// <summary>
        /// Преобразует угол в радианы.
        /// </summary>
        /// <param name="degrees">Градусы.</param>
        /// <returns>Угол в радианах.</returns>
        public static double ToRad(this double degrees)
        {
            return degrees * Math.PI / 180.0;
        }
    }
}
