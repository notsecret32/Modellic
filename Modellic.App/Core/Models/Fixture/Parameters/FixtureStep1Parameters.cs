namespace Modellic.App.Core.Models.Fixture.Parameters
{
    public class FixtureStep1Parameters : FixtureStepParameters
    {
        #region Constants

        private const double DEFAULT_DIAMETER = 280;

        private const double DEFAULT_WIDTH = 10;

        private const double DEFAULT_THICKNESS = 12;

        #endregion

        #region Public Properties

        public double Diameter { get; set; } = DEFAULT_DIAMETER;

        public double Width { get; set; } = DEFAULT_WIDTH;

        public double Thickness { get; set; } = DEFAULT_THICKNESS;

        #endregion

        #region Public Const Properties

        public static double DefaultDiameter => DEFAULT_DIAMETER;

        public static double DefaultWidth => DEFAULT_WIDTH;

        public static double DefaultThickness => DEFAULT_THICKNESS;

        #endregion

        #region Overrided Methods

        public override string ToString()
        {
            return $"Diameter: {Diameter}; Width: {Width}; Thickness: {Thickness}";
        }

        #endregion
    }
}
