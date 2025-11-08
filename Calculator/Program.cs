using System;

namespace CalcApp
{
    internal static class Program
    {
        private static void Main()
        {
            Console.WriteLine("Calculator demo\n");

            Demo(10, 2, '+');
            Demo(10, 2, '-');
            Demo(10, 2, '*');
            Demo(10, 2, '/');

            // Demo(10, 0, '/'); // division by zero
            // Demo(10, 2, '^'); // invalid operator
        }

        private static void Demo(double a, double b, char op)
        {
            try
            {
                var calc = new Calculator.Calculator(a, b, op); 
                var result = calc.Calculate();
                Console.WriteLine($"{a} {op} {b} = {result}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{a} {op} {b} -> ERROR: {ex.Message}");
            }
        }
    }
}