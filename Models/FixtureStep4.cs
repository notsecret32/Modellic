using Modellic.Abstracts;
using System.ComponentModel;

namespace Modellic.Models
{
    /// <summary>
    /// Четвертый шаг создания приспособления. На этом шаге строиться нижнее крепление.
    /// </summary>
    [DefaultProperty("Name")]
    public class FixtureStep4 : FixtureStepBase
    {
        #region Constants

        const double DEFAULT_WIDTH = 135;

        const double DEFAULT_HEIGHT = 40;

        const double DEFAULT_LENGTH = 65;

        const double DEFAULT_HOLE_DIAMETER = 33;

        #endregion

        #region Private Members

        private readonly string _name = "Нижнее крепление";

        #endregion

        #region Non Browsable

        [Browsable(false)]
        public override string Title => _name;

        #endregion

        #region General Properties

        /// <summary>
        /// Ширина нижнего крепления.
        /// </summary>
        [Category("Общее"), Description("Ширина нижнего крепления.")]
        [DisplayName("Ширина")]
        [DefaultValue(DEFAULT_WIDTH)]
        public double Width { get; set; } = DEFAULT_WIDTH;

        /// <summary>
        /// Высота нижнего крепления.
        /// </summary>
        [Category("Общее"), Description("Высота нижнего крепления.")]
        [DisplayName("Высота")]
        [DefaultValue(DEFAULT_HEIGHT)]
        public double Height { get; set; } = DEFAULT_HEIGHT;

        /// <summary>
        /// Высота нижнего крепления.
        /// </summary>
        [Category("Общее"), Description("Длина нижнего крепления.")]
        [DisplayName("Длина")]
        [DefaultValue(DEFAULT_LENGTH)]
        public double Length { get; set; } = DEFAULT_LENGTH;

        #endregion

        #region Hole Properties

        /// <summary>
        /// Диаметр отверстий.
        /// </summary>
        [Category("Отверстия"), Description("Диаметр отверстий.")]
        [DisplayName("Диаметр отверстий")]
        [DefaultValue(DEFAULT_HOLE_DIAMETER)]
        public double HoleDiameter { get; set; } = DEFAULT_HOLE_DIAMETER;

        #endregion

        #region Public Overrided Methods

        public override void Build() { }

        #endregion
    }
}
