using Modellic.App.Core.Services;
using Modellic.App.SolidWorks.Application;

namespace Modellic.App
{
    public static class ModellicEnv
    {
        public static FixtureManager FixtureManager => FixtureManager.Instance;

        public static FixtureBuilder FixtureBuilder => FixtureBuilder.Instance;

        public static SwApplication Application => SwApplicationManager.Instance.Application;

        public static SwApplicationManager ApplicationManager => SwApplicationManager.Instance;
    }
}
