namespace Modellic.App.Core.Models.Conductor.Parameters
{
    public class ConductorStep4Params : ConductorBaseParams
    {
        #region Constants

        const double DEFAULT_WIDTH = 135;

        const double DEFAULT_HEIGHT = 40;

        const double DEFAULT_LENGTH = 65;

        const double DEFAULT_HOLE_DIAMETER = 33;

        const double DEFAULT_VERTICAL_HOLE_OFFSET = 28;

        const double DEFAULT_HORIZONTAL_HOLE_OFFSET = 28;

        #endregion

        #region Public Properties

        public double Width { get; set; } = DEFAULT_WIDTH;

        public double Height { get; set; } = DEFAULT_HEIGHT;

        public double Length { get; set; } = DEFAULT_LENGTH;

        public double HoleDiameter { get; set; } = DEFAULT_HOLE_DIAMETER;

        public double VerticalHoleOffset { get; set; } = DEFAULT_VERTICAL_HOLE_OFFSET;

        public double HorizontalHoleOffset { get; set; } = DEFAULT_HORIZONTAL_HOLE_OFFSET;

        #endregion

        #region Public Const Properties

        public static double DefaultWidth => DEFAULT_WIDTH;

        public static double DefaultHeight => DEFAULT_HEIGHT;

        public static double DefaultLength => DEFAULT_LENGTH;

        public static double DefaultHoleDiameter => DEFAULT_HOLE_DIAMETER;

        public static double DefaultVerticalHoleOffset => DEFAULT_VERTICAL_HOLE_OFFSET;

        public static double DefaultHorizontalHoleOffset => DEFAULT_HORIZONTAL_HOLE_OFFSET;

        #endregion

        #region Overrided Methods

        public override string ToString()
        {
            return $"Width: {Width}; Height: {Height}; " +
                $"Length: {Length} HoleDiameter: {HoleDiameter}; " +
                $"VerticalHoleOffset: {VerticalHoleOffset}; HorizontalHoleOffset: {HorizontalHoleOffset};";
        }

        #endregion
    }
}
