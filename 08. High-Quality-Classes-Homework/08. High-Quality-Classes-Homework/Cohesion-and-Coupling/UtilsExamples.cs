namespace CohesionAndCoupling
{
    using System;

    using CohesionAndCoupling.Geometry.Figure2D;
    using CohesionAndCoupling.Geometry.Figure3D;

    using Files;

    public class UtilsExamples
    {
        public static void Main()
        {
            //Console.WriteLine(FileUtilities.GetFileExtension("example"));

            Console.WriteLine(FileUtilities.GetFileExtension("example.pdf"));
            Console.WriteLine(FileUtilities.GetFileExtension("example.new.pdf"));
                              
            Console.WriteLine(FileUtilities.GetFileNameWithoutExtension("example"));
            Console.WriteLine(FileUtilities.GetFileNameWithoutExtension("example.pdf"));
            Console.WriteLine(FileUtilities.GetFileNameWithoutExtension("example.new.pdf"));

            Console.WriteLine(
                "Distance in the 2D space = {0:f2}",
                Figure2DUtilities.CalcDistance2D(1, -2, 3, 4));
            Console.WriteLine(
                "Distance in the 3D space = {0:f2}",
                Figure3DUtilities.CalcDistance3D(5, 2, -1, 3, -6, 4));

            Figure3D figure = new Figure3D(3, 4, 5);

            Console.WriteLine("Volume = {0:f2}", Figure3DUtilities.CalcVolume(figure));
            Console.WriteLine("Diagonal XYZ = {0:f2}", Figure3DUtilities.CalcDiagonalXYZ(figure));
            Console.WriteLine("Diagonal XY = {0:f2}", Figure3DUtilities.CalcDiagonalXY(figure));
            Console.WriteLine("Diagonal XZ = {0:f2}", Figure3DUtilities.CalcDiagonalXZ(figure));
            Console.WriteLine("Diagonal YZ = {0:f2}", Figure3DUtilities.CalcDiagonalYZ(figure));
        }
    }
}
