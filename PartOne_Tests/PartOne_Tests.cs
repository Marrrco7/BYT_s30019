using NUnit.Framework;
using Tut2_s20123;

namespace Tut2_s20123_Tests
{
    public class Tests
    {
        // Sphere tests
        private readonly IShape sphere = new Sphere(5);

        [Test]
        public void TestSphereCalculateArea()
        {
            Assert.That(sphere.CalculateArea(), Is.EqualTo(314.159).Within(0.001));
        }

        [Test]
        public void TestSphereCalculateVolume()
        {
            Assert.That(sphere.CalculateVolume(), Is.EqualTo(523.598).Within(0.001));
        }

        // Cylinder tests
        private readonly IShape cylinder = new Cylinder(3, 7);

        [Test]
        public void TestCylinderCalculateArea()
        {
            Assert.That(cylinder.CalculateArea(), Is.EqualTo(188.496).Within(0.001));
        }

        [Test]
        public void TestCylinderCalculateVolume()
        {
            Assert.That(cylinder.CalculateVolume(), Is.EqualTo(197.920).Within(0.001));
        }

        [Test]
        public void TestCylinderZeroHeight()
        {
            IShape cylinderZeroHeight = new Cylinder(5, 0);
            Assert.That(cylinderZeroHeight.CalculateArea(), Is.EqualTo(2 * System.Math.PI * 25).Within(0.001));
            Assert.That(cylinderZeroHeight.CalculateVolume(), Is.EqualTo(0).Within(0.001));
        }

        [Test]
        public void TestCylinderZeroRadius()
        {
            IShape cylinderZeroRadius = new Cylinder(0, 10);
            Assert.That(cylinderZeroRadius.CalculateArea(), Is.EqualTo(0).Within(0.001));
            Assert.That(cylinderZeroRadius.CalculateVolume(), Is.EqualTo(0).Within(0.001));
        }

        private readonly IShape rectangle = new Rectangle(4, 8);
        
        // Rectangle tests
        [Test]
        public void TestRectangleCalculateArea()
        {
            Assert.That(rectangle.CalculateArea(), Is.EqualTo(32).Within(0.001));
        }

        [Test]
        public void TestRectangleCalculateVolumeAlwaysZero()
        {
            Assert.That(rectangle.CalculateVolume(), Is.EqualTo(0).Within(0.001));
        }

        [Test]
        public void TestRectangleZeroDimensionArea()
        {
            Assert.That(new Rectangle(0, 8).CalculateArea(), Is.EqualTo(0).Within(0.001));
            Assert.That(new Rectangle(4, 0).CalculateArea(), Is.EqualTo(0).Within(0.001));
            Assert.That(new Rectangle(0, 0).CalculateArea(), Is.EqualTo(0).Within(0.001));
        }

        // Cube tests
        private readonly IShape cube = new Cube(4);

        [Test]
        public void TestCubeCalculateArea()
        {
            Assert.That(cube.CalculateArea(), Is.EqualTo(96).Within(0.001));
        }

        [Test]
        public void TestCubeCalculateVolume()
        {
            Assert.That(cube.CalculateVolume(), Is.EqualTo(64).Within(0.001));
        }

        [Test]
        public void TestCubeZeroSide()
        {
            IShape cubeZeroSide = new Cube(0);
            Assert.That(cubeZeroSide.CalculateArea(), Is.EqualTo(0).Within(0.001));
            Assert.That(cubeZeroSide.CalculateVolume(), Is.EqualTo(0).Within(0.001));
        }

        // Extra: Parameterized tests for Sphere with different radii
        [TestCase(1.0)]
        [TestCase(2.5)]
        [TestCase(10.0)]
        public void TestSphereParameterized(double radius)
        {
            var s = new Sphere(radius);
            var expectedArea = 4 * System.Math.PI * radius * radius;
            var expectedVolume = (4.0 / 3.0) * System.Math.PI * radius * radius * radius;

            Assert.That(s.CalculateArea(), Is.EqualTo(expectedArea).Within(0.001));
            Assert.That(s.CalculateVolume(), Is.EqualTo(expectedVolume).Within(0.001));
        }
    }
}
