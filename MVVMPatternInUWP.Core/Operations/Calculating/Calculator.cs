using MVVMPatternInUWP.Core.Interfaces.Calculating;
using System;

namespace MVVMPatternInUWP.Core.Operations.Calculating
{
    public class Calculator : ICalculator
    {
        public int Add(int firstValue, int secondValue)
        {
            return firstValue + secondValue;
        }

        public int Sum(int firstValue, int secondValue)
        {
            return firstValue - secondValue;
        }

        public int Mul(int firstValue, int secondValue)
        {
            return firstValue * secondValue;
        }

        public double Div(int firstValue, int secondValue)
        {
            if (secondValue == 0)
            {
                throw new DivideByZeroException("Division by zero is not allowed!");
            }

            return (double)firstValue / secondValue;
        }
    }
}