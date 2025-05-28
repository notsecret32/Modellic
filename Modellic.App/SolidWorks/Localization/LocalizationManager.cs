using Modellic.App.Enums;
using System.Collections.Generic;

namespace Modellic.App.SolidWorks.Localization
{
    public static class LocalizationManager
    {
        #region Private Static Members

        private static readonly Dictionary<
            SwSupportedLanguage,
            Dictionary<SwPlane, string>
        > _localizedPlaneNames = new Dictionary<SwSupportedLanguage, Dictionary<SwPlane, string>>
        {
            [SwSupportedLanguage.English] = new Dictionary<SwPlane, string>
            {
                [SwPlane.Front] = "Front Plane",
                [SwPlane.Top] = "Top Plane",
                [SwPlane.Right] = "Right Plane"
            },
            [SwSupportedLanguage.Russian] = new Dictionary<SwPlane, string>
            {
                [SwPlane.Front] = "Спереди",
                [SwPlane.Top] = "Сверху",
                [SwPlane.Right] = "Справа"
            }
        };

        #endregion

        #region Public Static Properties

        public static SwSupportedLanguage Language { get; set; }

        #endregion

        #region Public Static Methods

        public static string GetPlaneName(SwPlane plane)
        {
            return _localizedPlaneNames[Language][plane];
        }

        #endregion
    }
}
