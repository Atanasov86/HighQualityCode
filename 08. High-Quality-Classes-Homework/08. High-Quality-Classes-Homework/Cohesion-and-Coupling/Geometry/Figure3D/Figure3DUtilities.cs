namespace CohesionAndCoupling.Geometry.Figure3D
{
    using System;
    using Figure2D;

    public static class Figure3DUtilities
    {
        public static double CalcDistance3D(double x1, double y1, double z1, double x2, double y2, double z2)
        {
            double distance = Math.Sqrt(
                    ((x2 - x1) * (x2 - x1)) +
                    ((y2 - y1) * (y2 - y1)) +
                    ((z2 - z1) * (z2 - z1)));

            return distance;
        }

        public static double CalcVolume(Figure3D figure)
        {
            double volume = figure.Width * figure.Height * figure.Depth;
            return volume;
        }

        public static double CalcDiagonalXYZ(Figure3D figure)
        {
            double distance = CalcDistance3D(0, figure.Width, 0, figure.Height, 0, figure.Depth);
            return distance;
        }

        public static double CalcDiagonalXY(Figure3D figure)
        {
            double distance = Figure2DUtilities.CalcDistance2D(0, figure.Width, 0, figure.Height);
            return distance;
        }

        public static double CalcDiagonalXZ(Figure3D figure)
        {
            double distance = Figure2DUtilities.CalcDistance2D(0, figure.Width, 0, figure.Depth);
            return distance;
        }

        public static double CalcDiagonalYZ(Figure3D figure)
        {
            double distance = Figure2DUtilities.CalcDistance2D(0, figure.Height, 0, figure.Depth);
            return distance;
        }
    }
}
