namespace CohesionAndCoupling.Geometry.Figure2D
{
    using System;

    public static class Figure2DUtilities
    {
        public static double CalcDistance2D(double x1, double y1, double x2, double y2)
        {
            double distance = Math.Sqrt(
                ((x2 - x1) * (x2 - x1)) +
                ((y2 - y1) * (y2 - y1)));

            return distance;
        }
    }
}
