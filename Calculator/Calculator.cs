namespace Calculator
{
    public sealed class Calculator(double a, double b, char op)
    {
        public double Calculate()
        {
            return op switch
            {
                '+' => a + b,
                '-' => a - b,
                '*' => a * b,
                '/' => b == 0
                    ? throw new DivideByZeroException("Division by zero is not allowed.")
                    : a / b,
                _ => throw new InvalidOperationException($"Unsupported operator '{op}'. Use + - * /.")
            };
        }
    }
}