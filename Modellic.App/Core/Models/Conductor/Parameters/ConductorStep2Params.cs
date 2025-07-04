﻿namespace Modellic.App.Core.Models.Conductor.Parameters
{
    public class ConductorStep2Params : ConductorBaseParams
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

        public double ChamferAngle { get; set; } = DEFAULT_CHAMFER_ANGLE_DEG;

        public double Offset { get; set; } = DEFAULT_OFFSET;

        public double Thickness { get; set; } = DEFAULT_THICKNESS;

        public double HoleQuantity { get; set; } = DEFAULT_HOLE_QUANTITY;

        public double HoleDiameter { get; set; } = DEFAULT_HOLE_DIAMETER;

        public double CutoutOffset { get; set; } = DEFAULT_CUTOUT_OFFSET;

        public double CutoutDepth { get; set; } = DEFAULT_CUTOUT_DEPTH;

        public double CutoutThickness { get; set; } = DEFAULT_CUTOUT_THICKNESS;

        #endregion

        #region Public Const Properties

        public static double DefaultDiameter => DEFAULT_DIAMETER;

        public static double DefaultChamferWidth => DEFAULT_CHAMFER_WIDTH;

        public static double DefaultChamferAngle => DEFAULT_CHAMFER_ANGLE_DEG;

        public static double DefaultOffset => DEFAULT_OFFSET;

        public static double DefaultThickness => DEFAULT_THICKNESS;

        public static double DefaultHoleQuantity => DEFAULT_HOLE_QUANTITY;

        public static double DefaultHoleDiameter => DEFAULT_HOLE_DIAMETER;

        public static double DefaultCutoutOffset => DEFAULT_CUTOUT_OFFSET;

        public static double DefaultCutoutDepth => DEFAULT_CUTOUT_DEPTH;

        public static double DefaultCutoutThickness => DEFAULT_CUTOUT_THICKNESS;

        #endregion

        #region Overrided Methods

        public override string ToString()
        {
            return $"Diameter: {Diameter}; ChamferWidth: {ChamferWidth}; " +
                $"ChamferAngle: {ChamferAngle} Offset: {Offset}; " +
                $"Thickness: {Thickness} HoleQuantity: {HoleQuantity}; " +
                $"HoleDiameter: {HoleDiameter} CutoutOffset: {CutoutOffset};" +
                $"CutoutDepth: {CutoutDepth} CutoutThickness: {CutoutThickness};";
        }

        #endregion
    }
}
