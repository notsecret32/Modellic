namespace Modellic.App.Core.Models.Conductor.Parameters
{
    public class ConductorStep1Params : ConductorBaseParams
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

        #region Public Properties

        public double Diameter { get; set; } = DEFAULT_DIAMETER;

        public double Width { get; set; } = DEFAULT_WIDTH;

        public double Thickness { get; set; } = DEFAULT_THICKNESS;

        public double MountWidth { get; set; } = DEFAULT_MOUNT_WIDTH;

        public double MountHeight { get; set; } = DEFAULT_MOUNT_HEIGHT;

        public double Quantity { get; set; } = DEFAULT_MOUNT_QUANTITY;

        public double HoleDiameter { get; set; } = DEFAULT_HOLE_DIAMETER;

        public double FilletRadius { get; set; } = DEFAULT_FILLET_RADIUS;

        #endregion

        #region Public Const Properties

        public static double DefaultDiameter => DEFAULT_DIAMETER;

        public static double DefaultWidth => DEFAULT_WIDTH;

        public static double DefaultThickness => DEFAULT_THICKNESS;

        public static double DefaultMountWidth => DEFAULT_MOUNT_WIDTH;

        public static double DefaultMountHeight => DEFAULT_MOUNT_HEIGHT;

        public static double DefaultQuantity => DEFAULT_MOUNT_QUANTITY;

        public static double DefaultHoleDiameter => DEFAULT_HOLE_DIAMETER;

        public static double DefaultFilletRadius => DEFAULT_FILLET_RADIUS;

        #endregion

        #region Overrided Methods

        public override string ToString()
        {
            return $"Diameter: {Diameter}; Width: {Width}; Thickness: {Thickness} " +
                $"MountWidth: {MountWidth}; MountHeight: {MountHeight}; " +
                $"Quantity: {Quantity}; HoleDiameter: {HoleDiameter}; FilletRadius: {FilletRadius}";
        }

        #endregion
    }
}