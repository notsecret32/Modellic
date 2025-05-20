using System.ComponentModel;
using Modellic.Abstracts;
using Modellic.Enums;
using Modellic.Extensions;
using Modellic.Helpers;
using SolidWorks.Interop.swconst;

namespace Modellic.Models
{
    /// <summary>
    /// Первый шаг создания приспособления. На этом шаге строиться внутренний диск.
    /// </summary>
    [DefaultProperty("Name")]
    public class FixtureStep1 : FixtureStepBase
    {
        #region Constants

        private const double DEFAULT_DIAMETER = 280;

        private const double DEFAULT_WIDTH = 10;

        private const double DEFAULT_THICKNESS = 12;

        private const double DEFAULT_MOUNT_WIDTH = 27.5;

        private const double DEFAULT_MOUNT_HEIGHT = 24;

        private const int DEFAULT_MOUNT_QUANTITY = 8;

        private const double DEFAULT_HOLE_DIAMETER = 8.5;

        private const double DEFAULT_FILLET_RADIUS = 30;

        #endregion

        #region Private Members

        private readonly string _name = "Внешний диск";

        #endregion

        #region Non Browsable

        [Browsable(false)]
        public override string Title => _name;

        #endregion

        #region General Properties

        /// <summary>
        /// Диаметр диска.
        /// </summary>
        [Category("Общее"), Description("Диаметр окружности.")]
        [DisplayName("Диаметр")]
        [DefaultValue(DEFAULT_DIAMETER)]
        public double Diameter { get; set; } = DEFAULT_DIAMETER;

        /// <summary>
        /// Ширина диска. Вычисляется как диаметр диска - ширина.
        /// </summary>
        [Category("Общее"), Description("Ширина диска. Вычисляется как диаметр диска - ширина.")]
        [DisplayName("Ширина")]
        [DefaultValue(DEFAULT_WIDTH)]
        public double Width { get; set; } = DEFAULT_WIDTH;

        /// <summary>
        /// Толщиина диска.
        /// </summary>
        [Category("Общее"), Description("Толщина диска.")]
        [DisplayName("Толщина")]
        [DefaultValue(DEFAULT_THICKNESS)]
        public double Thickness { get; set; } = DEFAULT_THICKNESS;

        #endregion

        #region Mount Properties

        /// <summary>
        /// Ширина крепления.
        /// </summary>
        [Category("Крепление"), Description("Ширина крепления.")]
        [DisplayName("Ширина креплениия")]
        [DefaultValue(DEFAULT_MOUNT_WIDTH)]
        public double MountWidth { get; set; } = DEFAULT_MOUNT_WIDTH;

        /// <summary>
        /// Высота крепления
        /// </summary>
        [Category("Крепление"), Description("Высота крепления.")]
        [DisplayName("Высота крепления")]
        [DefaultValue(DEFAULT_MOUNT_HEIGHT)]
        public double MountHeight { get; set; } = DEFAULT_MOUNT_HEIGHT;

        /// <summary>
        /// Кол-во крепления. Те крепления, которые находятся сверху и будут мешать верхнему креплению уберутся, но они считаются.
        /// </summary>
        [Category("Крепление"), Description("Количество креплений. Это число и число фактический креплений может не совпадать, так как верхние крепления убираются для правильного построения верхней части приспособления.")]
        [DisplayName("Количество")]
        [DefaultValue(DEFAULT_MOUNT_QUANTITY)]
        public int Quantity { get; set; } = DEFAULT_MOUNT_QUANTITY;

        /// <summary>
        /// Диаметр отверстия.
        /// </summary>
        [Category("Крепление"), Description("Диаметр отверстия.")]
        [DisplayName("Диаметр отверстия")]
        [DefaultValue(DEFAULT_HOLE_DIAMETER)]
        public double HoleDiameter { get; set; } = DEFAULT_HOLE_DIAMETER;

        /// <summary>
        /// Радиус скругления.
        /// </summary>
        [Category("Крепление"), Description("Радиус скругления.")]
        [DisplayName("Радиус скругления")]
        [DefaultValue(DEFAULT_FILLET_RADIUS)]
        public double FilletRadius { get; set; } = DEFAULT_FILLET_RADIUS;

        #endregion

        #region Public Overrided Methods

        public override void Build()
        {
            // Создаем внешний диск
            this.CreateDisk();
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Метод для создания внешнего диска.
        /// </summary>
        private void CreateDisk()
        {
            // Выбираем плоскость
            SwHelpers.SelectByID2(this.Extension, SwPlanes.Front, "PLANE");

            // Создаем эскиз
            this.SketchManager.InsertSketch(true);

            // Переименовываем активный эскиз
            SwHelpers.RenameActiveSketch(this.ActiveDoc, "ВнешнДискЭскиз");

            // Объявляем радиус, который будет высчитываться для каждой окружности
            double radius = 0;

            // Создаем внешнюю окружность
            radius = (Diameter / 2).ToMeters();
            this.ActiveDoc.CreateCircle(
                0,      0, 0, // Начало
                radius, 0, 0  // Конец
            );

            // Создаем внутреннюю окружность
            radius = (Diameter / 2 - Width).ToMeters();
            this.ActiveDoc.CreateCircle(
                0,      0, 0, // Начало
                radius, 0, 0  // Конец
            );

            // Выходим из эскиза
            this.SketchManager.InsertSketch(true);

            // Создаем бобышку
            double thickness = Thickness.ToMeters();
            var feature = SwHelpers.CreateExtrusion(
                this.FeatureManager,
                true,
                false,
                true,
                swEndConditions_e.swEndCondBlind,
                0,
                thickness,
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
                swStartConditions_e.swStartSketchPlane,
                0,
                false
            );
            SwHelpers.RenameFeature(feature, "ВнешнийДиск");
        }

        #endregion
    }
}
