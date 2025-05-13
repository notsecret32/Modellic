using Modellic.Interfaces;
using Modellic.Services;
using SolidWorks.Interop.sldworks;
using System.ComponentModel;

namespace Modellic.Abstracts
{
    public abstract class FixtureStepBase : IFixtureStep
    {
        private readonly ISwService _swService;

        [Browsable(false)]
        public ISldWorks SwApp => SwService.Instance.SwApp;

        [Browsable(false)]
        public ModelDoc2 ActiveDoc => SwApp?.ActiveDoc;

        [Browsable(false)]
        public SketchManager SketchManager => ActiveDoc?.SketchManager;

        [Browsable(false)]
        public ModelDocExtension Extension => ActiveDoc?.Extension;

        [Browsable(false)]
        public FeatureManager FeatureManager => ActiveDoc?.FeatureManager;

        public abstract string Title { get; }

        public abstract void Build();
    }
}
