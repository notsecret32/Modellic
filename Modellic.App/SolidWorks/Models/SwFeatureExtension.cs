using Modellic.App.Enums;

namespace Modellic.App.SolidWorks.Models
{
    public static class SwFeatureExtension
    {
        public static SwFeatureType GetFeatureType(this SwFeature feature)
        {
            // Получаем название типа
            var type = feature?.FeatureTypeName;

            // Проверяем, что feature не пустой
            if (feature == null || string.IsNullOrEmpty(type))
            {
                return SwFeatureType.None;
            }

            return type switch
            {
                _ => SwFeatureType.None,
            };
        }
    }
}
