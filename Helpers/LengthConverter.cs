namespace Modellic.Helpers
{
    public static class LengthConverter
    {
        // Константа для преобразования метров в миллиметры
        private const double MetersToMillimetersFactor = 1000;

        /// <summary>
        /// Преобразует метры в миллиметры.
        /// </summary>
        /// <param name="meters">Значение в метрах.</param>
        /// <returns>Значение в миллиметрах.</returns>
        public static double ConvertMetersToMillimeters(double meters)
        {
            return meters * MetersToMillimetersFactor;
        }

        /// <summary>
        /// Преобразует миллиметры в метры.
        /// </summary>
        /// <param name="millimeters">Значение в миллиметрах.</param>
        /// <returns>Значение в метрах.</returns>
        public static double ConvertMillimetersToMeters(double millimeters)
        {
            return millimeters / MetersToMillimetersFactor;
        }
    }
}
