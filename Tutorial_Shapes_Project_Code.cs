using Tut2_s20123;

// Create a Sphere with radius 5
IShape sphere = new Sphere(5);
Console.WriteLine("Sphere:");
Console.WriteLine($"Area: {sphere.CalculateArea():F3}");
Console.WriteLine($"Volume: {sphere.CalculateVolume():F3}");
Console.WriteLine();

// Create a Cylinder with radius 3 and height 7
IShape cylinder = new Cylinder(3, 7);
Console.WriteLine("Cylinder:");
Console.WriteLine($"Area: {cylinder.CalculateArea():F3}");
Console.WriteLine($"Volume: {cylinder.CalculateVolume():F3}");
Console.WriteLine();

// Create a Rectangle with length 4 and width 8
IShape rectangle = new Rectangle(4, 8);
Console.WriteLine("Rectangle:");
Console.WriteLine($"Area: {rectangle.CalculateArea():F3}");
// Rectangle is a 2D shape, so volume is 0
Console.WriteLine($"Volume: {rectangle.CalculateVolume():F3}");
Console.WriteLine();

// Create a Cube with side 4
IShape cube = new Cube(4);
Console.WriteLine("Cube:");
Console.WriteLine($"Area: {cube.CalculateArea():F3}");
Console.WriteLine($"Volume: {cube.CalculateVolume():F3}");



namespace Tut2_s20123
{
    public interface IShape
    {
        double CalculateArea();
        double CalculateVolume();
    }

}



namespace Tut2_s20123
{
    public class Cube(double side) : IShape
    {
        private readonly double side = side;

        public double CalculateArea()
        {
            return 6 * Math.Pow(side, 2);
        }

        public double CalculateVolume()
        {
            return Math.Pow(side, 3);
        }

    }
}



namespace Tut2_s20123
{
    public class Rectangle(double length, double width) : IShape
    {
        private readonly double length = length;
        private readonly double width = width;

        public double CalculateArea()
        {
            return length * width;
        }

        public double CalculateVolume()
        {
            // For 2D shapes, volume is not applicable.
            // Height of 2D shape is 0, therefore volume is 0
            return 0;
        }
    }
}



namespace Tut2_s20123
{
    public class Cylinder(double radius, double height) : IShape
    {
        private readonly double radius = radius;
        private readonly double height = height;

        public double CalculateArea()
        {
            return 2 * Math.PI * radius * (radius + height);
        }

        public double CalculateVolume()
        {
            return Math.PI * Math.Pow(radius, 2) * height;
        }

    }
}


namespace Tut2_s20123
{
    public class Sphere(double radius) : IShape
    {
        private readonly double radius = radius;

        public double CalculateArea()
        {
            return 4 * Math.PI * Math.Pow(radius, 2);
        }

        public double CalculateVolume()
        {
            return (4.0 / 3.0) * Math.PI * Math.Pow(radius, 3);
        }
    }
}