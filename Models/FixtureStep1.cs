using System;
using System.ComponentModel;
using Modellic.Abstracts;
using Modellic.Enums;
using Modellic.Helpers;
using SolidWorks.Interop.sldworks;

namespace Modellic.Models
{
    /// <summary>
    /// Шаг создания приспособления. Создает самую большую окружность.
    /// </summary>
    [DefaultProperty("Name")]
    public class FixtureStep1 : FixtureStepBase
    {
        #region Constants

        /// <summary>
        /// Стандартное значение внешнего диаметра.
        /// </summary>
        const double DEFAULT_OUTER_DIAMENETER = 280;

        /// <summary>
        /// Стандартное значение внутреннего диаметра.
        /// </summary>
        const double DEFAULT_INNER_DIAMENETER = 260;

        #endregion

        #region Private Members

        private readonly string _name = "Внешняя окружность";

        private double _outerDiameter = DEFAULT_OUTER_DIAMENETER;

        private double _innerDiameter = DEFAULT_INNER_DIAMENETER;

        #endregion

        #region Parameters

        [Browsable(false)]
        public override string Title => _name;

        /// <summary>
        /// Внешний диаметр.
        /// </summary>
        [Category("Размер")]
        [DisplayName("Внешний диаметр (мм)")]
        [DefaultValue(DEFAULT_OUTER_DIAMENETER)]
        public double OuterDiameter
        {
            get
            {
                return _outerDiameter;
            }
            set
            {
                _outerDiameter = value;
            }
        }

        /// <summary>
        /// Внутренний диаметр.
        /// </summary>
        [Category("Размер")]
        [DisplayName("Внешний диаметр (мм)")]
        [DefaultValue(DEFAULT_INNER_DIAMENETER)]
        public double InnerDiameter
        {
            get
            {
                return _innerDiameter;
            }
            set
            {
                if (value < 1 || value > _outerDiameter - 1)
                {
                    throw new ArgumentOutOfRangeException($"Внутренний диаметр должен быть от 1 до {_outerDiameter - 1}");
                }

                _innerDiameter = value;
            }
        }

        #endregion

        #region Public Overrided Methods

        public override void Build()
        {
            // Выбираем фронтальную поверхность
            SwHelpers.SelectByID2(this.Extension, SwPlanes.Front, "PLANE");

            // Создаем эскиз
            this.SketchManager.InsertSketch(true);

            // Переименовываем эскиз
            Feature aciveSketch = (Feature)this.ActiveDoc.GetActiveSketch2();
            aciveSketch.Name = "Эскиз1";

            // Убираем выделение
            this.ActiveDoc.ClearSelection2(true);

            // Создаем внешнюю окружность
            this.ActiveDoc.CreateCircle(
                0, 0, 0, 
                LengthConverter.ConvertMillimetersToMeters(_outerDiameter / 2), 0, 0
            );
            this.ActiveDoc.ClearSelection2(true);

            // Создаем внутреннюю окружность
            var innerRadius = this.SketchManager.CreateCircle(
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
                LengthConverter.ConvertMillimetersToMeters(12),
                0,
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
                0,
                0,
                false
            );
            SwHelpers.RenameFeature(feature, "Окружность1");
        }

        #endregion
    }
}
