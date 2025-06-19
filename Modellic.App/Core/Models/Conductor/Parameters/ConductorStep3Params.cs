namespace Modellic.App.Core.Models.Conductor.Parameters
{
    public class ConductorStep3Params : ConductorBaseParams
    {
        #region Constants

        const double DEFAULT_WIDTH = 135;

        const double DEFAULT_HEIGHT = 55;

        const double DEFAULT_CHAMFER_WIDTH = 1.5;

        const double DEFAULT_CHAMFER_ANGLE_DEG = 45;

        const double DEFAULT_FILLET_RADIUS = 20;

        const double DEFAULT_HOLE_DIAMETER = 16;

        const double DEFAULT_HOLE_OFFSET = 6.4;

        const double DEFAULT_MOUNTING_HOLE_PADDING_X = 20;

        const double DEFAULT_MOUNTING_HOLE_PADDING_Y = 20;

        const double DEFAULT_MOUNTING_HOLE_GAP = 41.05;

        const double DEFAULT_BACK_HOLE_DIAMETER = 24;

        const double DEFAULT_BACK_HOLE_THICKNESS = 3;

        #endregion

        #region Public Properties

        public double Width { get; set; } = DEFAULT_WIDTH;

        public double Height { get; set; } = DEFAULT_HEIGHT;

        public double ChamferWidth { get; set; } = DEFAULT_CHAMFER_WIDTH;

        public double ChamferAngle { get; set; } = DEFAULT_CHAMFER_ANGLE_DEG;

        public double FilletRadius { get; set; } = DEFAULT_FILLET_RADIUS;

        public double HoleDiameter { get; set; } = DEFAULT_HOLE_DIAMETER;

        public double HoleOffset { get; set; } = DEFAULT_HOLE_OFFSET;

        public double MountingHolePaddingX { get; set; } = DEFAULT_MOUNTING_HOLE_PADDING_X;

        public double MountingHolePaddingY { get; set; } = DEFAULT_MOUNTING_HOLE_PADDING_Y;

        public double MountingHoleGap { get; set; } = DEFAULT_MOUNTING_HOLE_GAP;

        public double BackHoleDiameter { get; set; } = DEFAULT_BACK_HOLE_DIAMETER;

        public double BackHoleThickness { get; set; } = DEFAULT_BACK_HOLE_THICKNESS;

        #endregion

        #region Public Const Properties

        public static double DefaultWidth => DEFAULT_WIDTH;

        public static double DefaultHeight => DEFAULT_HEIGHT;

        public static double DefaultChamferWidth => DEFAULT_CHAMFER_WIDTH;

        public static double DefaultChamferAngle => DEFAULT_CHAMFER_ANGLE_DEG;

        public static double DefaultFilletRadius => DEFAULT_FILLET_RADIUS;

        public static double DefaultHoleDiameter => DEFAULT_HOLE_DIAMETER;

        public static double DefaultHoleOffset => DEFAULT_HOLE_OFFSET;

        public static double DefaultMountingHolePaddingX => DEFAULT_MOUNTING_HOLE_PADDING_X;

        public static double DefaultMountingHolePaddingY => DEFAULT_MOUNTING_HOLE_PADDING_Y;

        public static double DefaultMountingHoleGap => DEFAULT_MOUNTING_HOLE_GAP;

        public static double DefaultBackHoleDiameter => DEFAULT_BACK_HOLE_DIAMETER;

        public static double DefaultBackHoleThickness => DEFAULT_BACK_HOLE_THICKNESS;

        #endregion

        #region Overrided Methods

        public override string ToString()
        {
            return $"Width: {Width}; Height: {Height}; " +
                $"ChamferWidth: {ChamferWidth} ChamferAngle: {ChamferAngle}; " +
                $"FilletRadius: {FilletRadius}; HoleDiameter: {HoleDiameter}; " +
                $"BackHoleDiameter: {BackHoleDiameter}; BackHoleThickness: {BackHoleThickness}";
        }

        #endregion
    }
}
