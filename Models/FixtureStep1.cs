using System.ComponentModel;
using Modellic.Interfaces;
using Modellic.Services;
using SolidWorks.Interop.sldworks;

namespace Modellic.Models
{
    [DefaultProperty("Name")]
    public class FixtureStep1 : IFixtureStep
    {
        #region Private Members

        private readonly string _name = "Шаг 1";

        #endregion

        #region Parameters

        [Category("Общий"), Description("Имя шага")]
        [DisplayName("Название")]
        public string Title => _name;

        #endregion

        #region Public Methods

        public void Build()
        {
            var swService = SwService.GetInstance();
            var activeDoc = (ModelDoc2)swService.SwApp.ActiveDoc;
            var sketchManager = activeDoc.SketchManager;
            var swModelDocExt = activeDoc.Extension;

            // Первый эскиз
            swModelDocExt.SelectByID2("Front Plane", "PLANE", 0, 0, 0, false, 0, null, 0);
            sketchManager.InsertSketch(true);
            activeDoc.ClearSelection2(true);

            // Окружность #1
            sketchManager.CreateCircle(0, 0, 0, -0.140, 0, 0);
            activeDoc.ClearSelection2(true);

            // Окружность #2
            sketchManager.CreateCircle(0, 0, 0, -0.130, 0, 0);
            activeDoc.ClearSelection2(true);

            // Завершаем эскиз
            sketchManager.InsertSketch(true);

            // Строим модель
            var featureManager = activeDoc.FeatureManager;

            var feature = featureManager.FeatureExtrusion2(
                true,
                false,
                true,
                0,
                0,
                0.012,
                0.027,
                false,
                false,
                false,
                false,
                1.74532925199433E-02, 
                1.74532925199433E-02,
                false,
                false,
                false,
                false,
                true,
                true,
                true,
                0,
                0,
                false
            );
            feature.Name = "Окружность1";
        }

        #endregion
    }
}
