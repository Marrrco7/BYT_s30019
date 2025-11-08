using System;

namespace Tut2_s20123
{
    public class Cylinder(double radius, double height) : IShape
    {
        public double CalculateArea() => 2 * Math.PI * radius * (radius + height);

        public double CalculateVolume() => Math.PI * Math.Pow(radius, 2) * height;
    }
}