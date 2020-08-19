using System;
using System.Linq;

namespace Home.Shapes
{
    public class Triangle : BaseShape
    {
        public double A { get; private set; }
        public double B { get; private set; }
        public double C { get; private set; }

        public Triangle(double a, double b, double c)
        {
            if (a <= 0 || b <= 0 || c <= 0)
                throw new ArgumentException();

            A = a;
            B = b;
            C = c;
        }

        //переполнения int и decimal можно отлавливать в конкретном месте через checked(?) 
        //или сразу на уровне проекта <CheckForOverflowUnderflow>true</CheckForOverflowUnderflow>
        //для float и double (by design) надо проверять вручную ВЕЗДЕ примерно так
        //(или лучше использовать контракты - https://docs.microsoft.com/en-us/dotnet/framework/debug-trace-profile/code-contracts
        //в духе Contract.Ensures(!Double.IsInfinity(A + B + C))) 
        public double Perimeter => (Double.IsInfinity(A + B + C) ? throw new OverflowException() : A + B + C);

        public override double GetArea()
        {
            var p = Perimeter / 2;

            var area = Math.Sqrt(p * (p - A) * (p - B) * (p - C));

            if (double.IsInfinity(area))
                throw new OverflowException();

            return area;
        }


        public bool IsRect
        {
            get
            {
                var abc = new[] { A, B, C };
                Array.Sort(abc);

                double a = abc[0], b = abc[1], c = abc[2];

                var pifagorTheoremLeft = a * a + b * b;
                var pifagorTheoremRight = c * c;

                if (double.IsInfinity(pifagorTheoremLeft) || double.IsInfinity(pifagorTheoremRight))
                    throw new OverflowException();

                return pifagorTheoremLeft == pifagorTheoremRight;
            }
        }
    }
}
