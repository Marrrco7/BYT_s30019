namespace Tut2_s20123
{
    public class Rectangle(double length, double width) : IShape
    {
        public double CalculateArea() => length * width;

        public double CalculateVolume() => 0; // by definition for 2D shapes
    }
}