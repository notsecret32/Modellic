using Modellic.Enums;
using SolidWorks.Interop.sldworks;

namespace Modellic.Interfaces
{
    /// <summary>
    /// Интерфейс представляющий собой шаг создания приспособления.
    /// </summary>
    public interface IFixtureStep
    {
        ISldWorks SwApp { get; }

        ModelDoc2 ActiveDoc { get; }

        SketchManager SketchManager { get; }

        ModelDocExtension Extension { get; }

        FeatureManager FeatureManager { get; }

        string Title { get; }

        FixtureStepBuildStatus BuildStatus { get; set; }

        void Build();
    }
}
