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
    }
}
