namespace Abstraction.Models
{
    using Abstraction.Interfaces;

    public abstract class Figure : IPerimeterCalculatable, ISurfaceCalculatable
    {
        public abstract double CalcPerimeter();

        public abstract double CalcSurface();
    }
}
