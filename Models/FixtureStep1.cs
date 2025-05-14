using System.ComponentModel;
using Modellic.Abstracts;
using Modellic.Enums;
using Modellic.Helpers;

namespace Modellic.Models
{
    [DefaultProperty("Name")]
    public class FixtureStep1 : FixtureStepBase
    {
        #region Private Members

        private readonly string _name = "Шаг 1";

        #endregion

        #region Parameters

        [Category("Общий"), Description("Имя шага")]
        [DisplayName("Название")]
        public override string Title => _name;

        #endregion

        #region Public Overrided Methods

        public override void Build()
        {
            // Первый эскиз
            SwHelpers.SelectByID2(this.Extension, SwPlanes.Front, "PLANE");
            this.SketchManager.InsertSketch(true);
            this.ActiveDoc.ClearSelection2(true);

            // Окружность #1
            this.ActiveDoc.CreateCircle(0, 0, 0, -0.140, 0, 0);
            this.ActiveDoc.ClearSelection2(true);

            // Окружность #2
            this.SketchManager.CreateCircle(0, 0, 0, -0.130, 0, 0);
            this.ActiveDoc.ClearSelection2(true);

            // Завершаем эскиз
            this.SketchManager.InsertSketch(true);

            // Строим модель
            var featureManager = this.FeatureManager;

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
