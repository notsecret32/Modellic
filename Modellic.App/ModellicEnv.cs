using Modellic.App.Core.Services;
using Modellic.App.SolidWorks.Application;

namespace Modellic.App
{
    public static class ModellicEnv
    {
        public static AssemblyManager AssemblyManager => AssemblyManager.Instance;

        public static SwApplication Application => SwApplicationManager.Instance.Application;

        public static SwApplicationManager ApplicationManager => SwApplicationManager.Instance;
    }
}
