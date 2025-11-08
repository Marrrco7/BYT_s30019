using System;

namespace Tut2_s20123
{
    public class Cube(double side) : IShape
    {
        public double CalculateArea() => 6 * Math.Pow(side, 2);

        public double CalculateVolume() => Math.Pow(side, 3);
    }
}