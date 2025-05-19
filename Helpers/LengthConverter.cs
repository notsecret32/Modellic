namespace Modellic.Helpers
{
    public static class LengthConverter
    {
        // Константа для преобразования метров в миллиметры
        private const double MetersToMillimetersFactor = 1000;

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
