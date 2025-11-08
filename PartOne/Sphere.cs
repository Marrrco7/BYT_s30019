using System;

namespace Tut2_s20123
{
    public class Sphere(double radius) : IShape
    {
        public double CalculateArea() => 4 * Math.PI * Math.Pow(radius, 2);

        public double CalculateVolume() => (4.0 / 3.0) * Math.PI * Math.Pow(radius, 3);
    }
}