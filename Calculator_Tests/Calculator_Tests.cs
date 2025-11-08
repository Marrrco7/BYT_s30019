using NUnit.Framework;
using System;
using Calc = Calculator.Calculator;   // ← alias

namespace CalcApp.Tests
{
    [TestFixture]
    public class CalculatorTests
    {
        private const double Tol = 1e-9;

        [TestCase(5, 3, '+', 8)]
        [TestCase(-5, 3, '+', -2)]
        [TestCase(1.5, 2.2, '+', 3.7)]
        public void Addition_Works(double a, double b, char op, double expected)
        {
            var calc = new Calc(a, b, op);
            Assert.That(calc.Calculate(), Is.EqualTo(expected).Within(Tol));
        }

        [TestCase(5, 3, '-', 2)]
        [TestCase(3, 5, '-', -2)]
        [TestCase(1.5, 2.2, '-', -0.7)]
        public void Subtraction_Works(double a, double b, char op, double expected)
        {
            var calc = new Calc(a, b, op);
            Assert.That(calc.Calculate(), Is.EqualTo(expected).Within(Tol));
        }

        [TestCase(5, 3, '*', 15)]
        [TestCase(-5, 3, '*', -15)]
        [TestCase(1.5, 2.2, '*', 3.3)]
        [TestCase(0, 123456, '*', 0)]
        public void Multiplication_Works(double a, double b, char op, double expected)
        {
            var calc = new Calc(a, b, op);
            Assert.That(calc.Calculate(), Is.EqualTo(expected).Within(Tol));
        }

        [TestCase(6, 3, '/', 2)]
        [TestCase(-6, 3, '/', -2)]
        [TestCase(7.5, 2.5, '/', 3)]
        public void Division_Works(double a, double b, char op, double expected)
        {
            var calc = new Calc(a, b, op);
            Assert.That(calc.Calculate(), Is.EqualTo(expected).Within(Tol));
        }

        [Test]
        public void Division_By_Zero_Throws()
        {
            var calc = new Calc(10, 0, '/');
            Assert.Throws<DivideByZeroException>(() => calc.Calculate());
        }

        [TestCase('%')]
        [TestCase('^')]
        [TestCase('x')]
        [TestCase(' ')]
        public void Invalid_Operator_Throws(char invalid)
        {
            var calc = new Calc(2, 3, invalid);
            Assert.Throws<InvalidOperationException>(() => calc.Calculate());
        }

        [Test]
        public void Multiple_Calls_Return_Same_Result()
        {
            var calc = new Calc(10, 4, '-');
            var r1 = calc.Calculate();
            var r2 = calc.Calculate();
            Assert.That(r1, Is.EqualTo(r2).Within(Tol));
        }

        [Test]
        public void Large_Values_Do_Not_Crash()
        {
            var calc = new Calc(double.MaxValue, double.MaxValue, '+');
            var result = calc.Calculate();
            Assert.That(double.IsInfinity(result) || !double.IsNaN(result));
        }

        [Test]
        public void NegativeZero_Behavior_Is_Fine()
        {
            var calc = new Calc(-0.0, 5.0, '+');
            Assert.That(calc.Calculate(), Is.EqualTo(5.0).Within(Tol));
        }

        [Test]
        public void Commutativity_Applies_To_Add_And_Mul()
        {
            var add1 = new Calc(2, 7, '+').Calculate();
            var add2 = new Calc(7, 2, '+').Calculate();
            Assert.That(add1, Is.EqualTo(add2).Within(Tol));

            var mul1 = new Calc(2, 7, '*').Calculate();
            var mul2 = new Calc(7, 2, '*').Calculate();
            Assert.That(mul1, Is.EqualTo(mul2).Within(Tol));
        }

        [Test]
        public void NonCommutativity_For_Sub_And_Div()
        {
            var sub1 = new Calc(9, 4, '-').Calculate();
            var sub2 = new Calc(4, 9, '-').Calculate();
            Assert.That(sub1, Is.Not.EqualTo(sub2).Within(Tol));

            var div1 = new Calc(9, 4, '/').Calculate();
            var div2 = new Calc(4, 9, '/').Calculate();
            Assert.That(div1, Is.Not.EqualTo(div2).Within(Tol));
        }
    }
}
