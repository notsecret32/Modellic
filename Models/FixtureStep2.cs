using System;
using System.ComponentModel;
using Modellic.Abstracts;
using Modellic.Enums;
using Modellic.Extensions;
using Modellic.Helpers;
using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swconst;

namespace Modellic.Models
{
    /// <summary>
    /// Второй шаг создания приспособления. На этом шаге строиться внутренний диск.
    /// </summary>
    [DefaultProperty("Name")]
    public class FixtureStep2 : FixtureStepBase
    {
        #region Constants

        const double DEFAULT_DIAMETER = 195.2;

        const double DEFAULT_CHAMFER_WIDTH = 1.5;

        const double DEFAULT_CHAMFER_ANGLE_DEG = 45;

        const double DEFAULT_OFFSET = 1.5;

        const double DEFAULT_THICKNESS = 27.4;

        const int DEFAULT_HOLE_QUANTITY = 8;

        const double DEFAULT_HOLE_DIAMETER = 15;

        const double DEFAULT_CUTOUT_OFFSET = 10.5;

        const double DEFAULT_CUTOUT_THICKNESS = 10;

        const double DEFAULT_CUTOUT_DEPTH = 6;

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
        /// Диаметр окружности.
        /// </summary>
        [Category("Общее"), Description("Диаметр окружности.")]
        [DisplayName("Диаметр")]
        [DefaultValue(DEFAULT_DIAMETER)]
        public double Diameter { get; set; } = DEFAULT_DIAMETER;

        /// <summary>
        /// Ширина фаски в миллиметрах.
        /// </summary>
        [Category("Общее"), Description("Ширина фаски (мм).")]
        [DisplayName("Ширина фаски")]
        [DefaultValue(DEFAULT_CHAMFER_WIDTH)]
        public double ChamferWidth { get; set; } = DEFAULT_CHAMFER_WIDTH;

        /// <summary>
        /// Угол фаски в градусах.
        /// </summary>
        [Category("Общее"), Description("Угол фаски (в градусах).")]
        [DisplayName("Угол фаски")]
        [DefaultValue(DEFAULT_CHAMFER_ANGLE_DEG)]
        public double ChamferAngle { get; set; } = DEFAULT_CHAMFER_ANGLE_DEG;

        [Category("Общее"), Description("Расстояние, на которое уйдет деталь вглубь относительно внешнего диска.")]
        [DisplayName("Смещение")]
        [DefaultValue(DEFAULT_OFFSET)]
        public double Offset { get; set; } = DEFAULT_OFFSET;

        [Category("Общее"), Description("Толщина диска.")]
        [DisplayName("Толщина")]
        [DefaultValue(DEFAULT_THICKNESS)]
        public double Thickness { get; set; } = DEFAULT_THICKNESS;

        #endregion

        #region Hole Properties

        /// <summary>
        /// Количество отверстий.
        /// </summary>
        [Category("Отверстия"), Description("Количество отверстий.")]
        [DisplayName("Количество")]
        [DefaultValue(DEFAULT_HOLE_QUANTITY)]
        public double HoleQuantity { get; set; } = DEFAULT_HOLE_QUANTITY;

        /// <summary>
        /// Диаметр отверстия.
        /// </summary>
        [Category("Отверстия"), Description("Диаметр отверстия.")]
        [DisplayName("Диаметр отверстия")]
        [DefaultValue(DEFAULT_HOLE_DIAMETER)]
        public double HoleDiameter { get; set; } = DEFAULT_HOLE_DIAMETER;

        #endregion

        #region Cutout Properties

        /// <summary>
        /// Смещение выреза. Расстояние от внутреннего диска и до начала выреза.
        /// </summary>
        [Category("Вырез"), Description("Смещение выреза. Расстояние от внутреннего диска и до начала выреза.")]
        [DisplayName("Смещение выреза")]
        [DefaultValue(DEFAULT_CUTOUT_OFFSET)]
        public double CutoutOffset { get; set; } = DEFAULT_CUTOUT_OFFSET;

        /// <summary>
        /// Глубина выреза. Высчитывается как радиус внутреннего диска + глубина выреза.
        /// </summary>
        [Category("Вырез"), Description("Глубина выреза. Высчитывается как радиус внутреннего диска + глубина выреза.")]
        [DisplayName("Глубина выреза")]
        [DefaultValue(DEFAULT_CUTOUT_DEPTH)]
        public double CutoutDepth { get; set; } = DEFAULT_CUTOUT_DEPTH;

        /// <summary>
        /// Толщина выреза.
        /// </summary>
        [Category("Вырез"), Description("Толщина выреза.")]
        [DisplayName("Толщина выреза")]
        [DefaultValue(DEFAULT_CUTOUT_THICKNESS)]
        public double CutoutThickness { get; set; } = DEFAULT_CUTOUT_THICKNESS;

        #endregion

        #region Public Overrided Methods

        public override void Build()
        {
            // Создаем диск
            this.CreateDisk();

            // Создаем вырез
            this.CreateCutout();
        }

        #endregion

        #region Private Methods

        private void CreateDisk()
        {
            var step1 = this.FixtureService.GetStep<FixtureStep1>();

            // Выбираем фронтальную поверхность
            SwHelpers.SelectByID2(this.Extension, SwPlanes.Front, "PLANE");

            // Создаем эскиз
            this.SketchManager.InsertSketch(true);

            // Переименуем эскиз
            SwHelpers.RenameActiveSketch(this.ActiveDoc, "ВнутрДискЭскиз");

            // Создаем внешнюю окружность
            this.SketchManager.CreateCircle(
                0, 0, 0,
                ((step1.Diameter / 2) - step1.Width).ToMeters(), 0, 0
            );
            this.ActiveDoc.ClearSelection2(true);

            // Создаем внутреннюю окружность
            this.SketchManager.CreateCircle(
                0, 0, 0,
                (Diameter / 2).ToMeters(), 0, 0
            );

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
                Thickness.ToMeters(),
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
                SolidWorks.Interop.swconst.swStartConditions_e.swStartOffset,
                Offset.ToMeters(),
                true
            );
            SwHelpers.RenameFeature(feature, "ВнутреннийДиск");
        }

        private void CreateCutout()
        {
            // Получаем доступ к данным первого шага
            var step1 = this.FixtureService.GetStep<FixtureStep1>();

            // Вычисляем вспомогательные значения
            double innerDiskRadiusStart = (Diameter / 2).ToMeters();                   // Начало внутренней окружности диска (в метрах)
            double innerDiskRadiusEnd = (step1.Diameter / 2 - step1.Width).ToMeters(); // Конец внутренней окружности диска (в метрах)

            // Вычисляем точку для выбора плоскости
            double facePointX = (innerDiskRadiusStart + innerDiskRadiusEnd) / 2;

            // Выбираем переднюю плоскость внутреннего диска
            // ВАЖНО! Выбирать эту плоскость нужно строго перед созданием отверстий, иначе их тоже надо будет учитывать
            bool status = SwHelpers.SelectByID2(this.Extension, "", "FACE", facePointX);

            // Если не удалось выделить нужную плоскость
            if (!status)
            {
                throw new Exception("Не удалось выбрать плоскость для создания эскиза");
            }

            // Создаем эскиз
            this.SketchManager.InsertSketch(true);

            // Переименовываем автивный эскиз
            SwHelpers.RenameActiveSketch(this.ActiveDoc, "ВнутрВырезЭскиз");

            // Создаем окружность под вырез
            double cutoutCircleRadius = innerDiskRadiusStart + CutoutDepth.ToMeters();
            this.SketchManager.CreateCircleByRadius(
                0, 0, 0,           // Начальная точка
                cutoutCircleRadius // Радиус
            );

            // Завершаем эскиз
            this.SketchManager.InsertSketch(true);

            // Создаем вырез
            Feature cutFeatue = this.FeatureManager.FeatureCut4(
                true,
                false,
                false,
                (int)swEndConditions_e.swEndCondBlind,
                (int)swEndConditions_e.swEndCondBlind,
                CutoutOffset.ToMeters(),
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
                false,
                true,
                true,
                true,
                true,
                false,
                (int)swStartConditions_e.swStartOffset,
                CutoutThickness.ToMeters(),
                true,
                false
            );
            SwHelpers.RenameFeature(cutFeatue, "ВнутрДискВырез");
        }

        #endregion
    }
}