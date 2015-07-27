namespace CohesionAndCoupling.Geometry.Figure3D
{
    using System;

    public class Figure3D
    {
        private double width;

        private double heigth;

        private double depth;

        public Figure3D(double width, double height, double depth)
        {
            this.Width = width;
            this.Height = height;
            this.Depth = depth;
        }

        public double Width
        {
            get
            {
                return this.width;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException(
                        "Width",
                        "The width cannot be zero or negative.");
                }

                this.width = value;
            }
        }

        public double Height
        {
            get
            {
                return this.heigth;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("height", "The heigth cannot be zero or negative.");
                }

                this.heigth = value;
            }
        }

        public double Depth
        {
            get
            {
                return this.depth;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("depth", "The depth cannot be zero or negative.");
                }

                this.depth = value;
            }
        }
    }
}
