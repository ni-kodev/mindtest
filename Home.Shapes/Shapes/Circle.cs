using System;

namespace Home.Shapes
{
    public class Circle : BaseShape
    {
        public double Radius { get; private set; }

        public Circle(double radius)
        {
            if (radius <= 0)
                throw new ArgumentException();

            Radius = radius;
        }

        public override double GetArea()
        {
            var result = Math.PI * Radius * Radius;

            if (double.IsInfinity(result))
                throw new OverflowException();

            return result;
        }
    }
}
