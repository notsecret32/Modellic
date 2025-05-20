using Modellic.Abstracts;
using System.ComponentModel;

namespace Modellic.Models
{
    /// <summary>
    /// Третий шаг создания приспособления. На этом шаге строиться верхнее приспособление.
    /// </summary>
    [DefaultProperty("Name")]
    public class FixtureStep3 : FixtureStepBase
    {
        #region Constants

        const double DEFAULT_WIDTH = 135;

        const double DEFAULT_HEIGHT = 40;

        const double DEFAULT_CHAMFER_WIDTH = 1.5;

        const double DEFAULT_CHAMFER_ANGLE_DEG = 45;

        const double DEFAULT_FILLET_RADIUS = 20;

        const double DEFAULT_HOLE_DIAMETER = 16;

        const double DEFAULT_BACK_HOLE_DIAMETER = 24;

        const double DEFAULT_BACK_HOLE_THICKNESS = 3;

        #endregion

        #region Private Members

        private readonly string _name = "Верхнее приспособление";

        #endregion

        #region Non Browsable

        [Browsable(false)]
        public override string Title => _name;

        #endregion

        #region General Properties

        /// <summary>
        /// Ширина верхнего приспособления. Считается от края внешнего диска.
        /// </summary>
        [Category("Общее"), Description("Ширина верхнего приспособления. Считается от края внешнего диска.")]
        [DisplayName("Ширина")]
        [DefaultValue(DEFAULT_WIDTH)]
        public double Width { get; set; } = DEFAULT_WIDTH;

        /// <summary>
        /// Высота верхнего приспособления. Считается от края внешнего диска.
        /// </summary>
        [Category("Общее"), Description("Высота верхнего приспособления. Считается от края внешнего диска.")]
        [DisplayName("Высота")]
        [DefaultValue(DEFAULT_HEIGHT)]
        public double Height { get; set; } = DEFAULT_HEIGHT;

        /// <summary>
        /// Ширина фаски. Применяется на отверстие под деталь.
        /// </summary>
        [Category("Общее"), Description("Ширина фаски. Применяется на отверстие под деталь.")]
        [DisplayName("Ширина фаски")]
        [DefaultValue(DEFAULT_CHAMFER_WIDTH)]
        public double ChamferWidth { get; set; } = DEFAULT_CHAMFER_WIDTH;

        /// <summary>
        /// Угол фаски. Применяется на отверстие под деталь.
        /// </summary>
        [Category("Общее"), Description("Угол фаски. Применяется на отверстие под деталь.")]
        [DisplayName("Угол фаски")]
        [DefaultValue(DEFAULT_CHAMFER_ANGLE_DEG)]
        public double ChamferAngle { get; set; } = DEFAULT_CHAMFER_ANGLE_DEG;

        /// <summary>
        /// Радиус скругления.
        /// </summary>
        [Category("Общее"), Description("Радиус скругления.")]
        [DisplayName("Радиус скругления")]
        [DefaultValue(DEFAULT_FILLET_RADIUS)]
        public double FilletRadius { get; set; } = DEFAULT_FILLET_RADIUS;

        #endregion

        #region Front Hole Properties

        /// <summary>
        /// Диаметр маленьких отверстий.
        /// </summary>
        [Category("Отверстия (Спереди)"), Description("Диаметр маленьких отверстий.")]
        [DisplayName("Диаметр отверстий")]
        [DefaultValue(DEFAULT_HOLE_DIAMETER)]
        public double HoleDiameter { get; set; } = DEFAULT_HOLE_DIAMETER;

        #endregion

        #region Back Hole Parameters

        /// <summary>
        /// Диаметр задних углублений.
        /// </summary>
        [Category("Отверстия (Сзади)"), Description("Диаметр задних углублений.")]
        [DisplayName("Диаметр задних углублений")]
        [DefaultValue(DEFAULT_BACK_HOLE_DIAMETER)]
        public double BackHoleDiameter { get; set; } = DEFAULT_BACK_HOLE_DIAMETER;

        /// <summary>
        /// Расстояние, на которое уйдет углубление внутрь отверстия с задней стороны.
        /// </summary>
        [Category("Отверстия (Сзади)"), Description("Расстояние, на которое уйдет углубление внутрь отверстия с задней стороны.")]
        [DisplayName("Глубина задний углублений.")]
        [DefaultValue(DEFAULT_BACK_HOLE_THICKNESS)]
        public double BackHoleThickness { get; set; } = DEFAULT_BACK_HOLE_THICKNESS;

        #endregion

        #region Public Overrided Methods

        public override void Build() { }

        #endregion
    }
}
