namespace Modellic.App.Core.Models.Fixture.Parameters
{
    public class FixtureStep2Parameters : FixtureStepParameters
    {
        #region Constants

        private const double DEFAULT_MOUNT_WIDTH = 27.5;

        private const double DEFAULT_MOUNT_HEIGHT = 24;

        private const int DEFAULT_MOUNT_QUANTITY = 8;

        private const double DEFAULT_HOLE_DIAMETER = 8.5;

        private const double DEFAULT_FILLET_RADIUS = 30;

        #endregion

        #region Public Properties

        public double MountWidth { get; set; } = DEFAULT_MOUNT_WIDTH;
        
        public double MountHeight { get; set; } = DEFAULT_MOUNT_HEIGHT;

        public double Quantity { get; set; } = DEFAULT_MOUNT_QUANTITY;
        
        public double HoleDiameter { get; set; } = DEFAULT_HOLE_DIAMETER;
        
        public double FilletRadius { get; set; } = DEFAULT_FILLET_RADIUS;

        #endregion

        #region Public Const Properties

        public static double DefaultMountWidth => DEFAULT_MOUNT_WIDTH;

        public static double DefaultMountHeight => DEFAULT_MOUNT_HEIGHT;

        public static double DefaultQuantity => DEFAULT_MOUNT_QUANTITY;

        public static double DefaultHoleDiameter => DEFAULT_HOLE_DIAMETER;

        public static double DefaultFilletRadius => DEFAULT_FILLET_RADIUS;

        #endregion

        #region Overrided Methods

        public override string ToString()
        {
            return $"MountWidth: {MountWidth}; MountHeight: {MountHeight}; Quantity: {Quantity}; HoleDiameter: {HoleDiameter}; FilletRadius: {FilletRadius}";
        }

        #endregion
    }
}
