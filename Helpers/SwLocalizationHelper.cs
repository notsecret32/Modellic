using Modellic.Enums;
using System.Collections.Generic;

namespace Modellic.Helpers
{
    public class SwLocalizationHelper
    {
        /// <summary>
        /// Список плоскостей возвращаемых в зависимости от языка.
        /// </summary>
        private static readonly Dictionary<
            SwSupportedLanguages,
            Dictionary<SwPlanes, string>
        > _planes = new Dictionary<SwSupportedLanguages, Dictionary<SwPlanes, string>>
        {
            [SwSupportedLanguages.English] = new Dictionary<SwPlanes, string>
            {
                [SwPlanes.Front] = "Front Plane",
                [SwPlanes.Top] = "Top Plane",
                [SwPlanes.Right] = "Right Plane"
            },
            [SwSupportedLanguages.Russian] = new Dictionary<SwPlanes, string>
            {
                [SwPlanes.Front] = "Спереди",
                [SwPlanes.Top] = "Сверху",
                [SwPlanes.Right] = "Справа"
            }
        };

        public static string GetLocalizedPlaneName(SwSupportedLanguages language,SwPlanes plane)
        {
            return _planes[language][plane];
        }
    }
}
