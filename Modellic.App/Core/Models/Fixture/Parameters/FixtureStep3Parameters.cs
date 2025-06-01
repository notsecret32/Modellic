namespace Modellic.App.Core.Models.Fixture.Parameters
{
    public class FixtureStep3Parameters : FixtureStepParameters
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

        #region Public Properties

        public double Diameter { get; set; } = DEFAULT_DIAMETER;
        
        public double ChamferWidth { get; set; } = DEFAULT_CHAMFER_WIDTH;
        
        public double ChamferAngleDeg { get; set; } = DEFAULT_CHAMFER_ANGLE_DEG;
        
        public double Offset { get; set; } = DEFAULT_OFFSET;
        
        public double Thickness { get; set; } = DEFAULT_THICKNESS;
        
        public int HoleQuanity { get; set; } = DEFAULT_HOLE_QUANTITY;
        
        public double HoleDiameter { get; set; } = DEFAULT_HOLE_DIAMETER;
        
        public double CutoutOffset { get; set; } = DEFAULT_CUTOUT_OFFSET;
        
        public double CutoutThickness { get; set; } = DEFAULT_CUTOUT_THICKNESS;
        
        public double CutoutDepth { get; set; } = DEFAULT_CUTOUT_DEPTH;

        #endregion
    }
}
