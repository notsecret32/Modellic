using Modellic.Enums;
using Modellic.Services;
using SolidWorks.Interop.sldworks;

namespace Modellic.Helpers
{
    public static class SwHelpers
    {
        private static readonly SwService _swService = SwService.GetInstance();

        public static bool SelectByID2(
            ModelDocExtension extension,
            SwPlanes plane, 
            string type, 
            double x = 0, 
            double y = 0, 
            double z = 0, 
            bool append = false, 
            int mark = 0, 
            Callout callout = null, 
            int selectOption = 0
        ) {
            var localizedPlane = SwLocalizationHelper.GetLocalizedPlaneName(_swService.Language, plane);
            return extension.SelectByID2(localizedPlane, type, x, y, z, append, mark, callout, selectOption);
        }
    }
}
