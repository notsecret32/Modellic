using System.ComponentModel;
using Modellic.Abstracts;
using Modellic.Enums;
using Modellic.Helpers;
using SolidWorks.Interop.sldworks;

namespace Modellic.Models
{
    [DefaultProperty("Name")]
    public class FixtureStep2 : FixtureStepBase
    {
        #region Constants

        const double DEFAULT_INNER_DIAMETER = 195.2;

        #endregion

        #region Private Members

        private readonly string _name = "Внутренняя окружность";

        private double _innerDiameter = DEFAULT_INNER_DIAMETER;

        #endregion

        #region Parameters

        [Browsable(false)]
        public override string Title => _name;

        [Category("Размер")]
        [DisplayName("Внутренний диаметр (мм)")]
        [DefaultValue(DEFAULT_INNER_DIAMETER)]
        public double InnerDiameter
        {
            get
            {
                return _innerDiameter;
            }
            set
            {
               _innerDiameter = value;
            }
        }

        #endregion

        #region Public Overrided Methods

        public override void Build()
        {
            var previousStep = this.FixtureService.GetStep<FixtureStep1>();

            // Выбираем фронтальную поверхность
            SwHelpers.SelectByID2(this.Extension, SwPlanes.Front, "PLANE");

            // Создаем эскиз
            this.SketchManager.InsertSketch(true);

            // Переименуем эскиз
            Feature aciveSketch = (Feature)this.ActiveDoc.GetActiveSketch2();
            aciveSketch.Name = "Эскиз2";

            // Убираем выделение
            this.ActiveDoc.ClearSelection2(true);

            // Создаем внешнюю окружность
            this.SketchManager.CreateCircle(
                0, 0, 0, 
                LengthConverter.ConvertMillimetersToMeters(previousStep.InnerDiameter / 2), 0, 0
            );
            this.ActiveDoc.ClearSelection2(true);

            // Создаем внутреннюю окружность
            this.SketchManager.CreateCircle(
                0, 0, 0, 
                LengthConverter.ConvertMillimetersToMeters(_innerDiameter / 2), 0, 0
            );
            this.ActiveDoc.ClearSelection2(true);

            // Завершаем эскиз
            this.SketchManager.InsertSketch(true);

            // Вытягиваем по эскизу
            var feature = SwHelpers.CreateExtrusion(
                this.FeatureManager,
                true,
                false,
                true,
                0,
                0,
                0.0255,
                0.012,
                false,
                false,
                false,
                false,
                0,
                0,
                false,
                false,
                false,
                false,
                true,
                true,
                true,
                3,
                0.0015,
                true
            );
            SwHelpers.RenameFeature(feature, "Окружность2");
        }

        #endregion
    }
}