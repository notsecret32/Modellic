﻿using Modellic.App.SolidWorks.Application;

namespace Modellic.App
{
    public static class ModellicEnv
    {
        public static SwApplication Application => SwApplicationManager.Instance.SwApp;

        public static SwApplicationManager ApplicationManager => SwApplicationManager.Instance;
    }
}
