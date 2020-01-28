using MVVMPatternInUWP.Core.Interfaces.Calculating;
using System;

namespace MVVMPatternInUWP.Core.Operations.Calculating
{
    public class Calculator : ICalculator
    {
        private readonly int _firstValue;

        private readonly int _secondValue;

        public Calculator(int firstValue, int secondValue)
        {
            _firstValue = firstValue;
            _secondValue = secondValue;
        }

        public int Add()
        {
            return _firstValue + _secondValue;
        }

        public int Sum()
        {
            return _firstValue - _secondValue;
        }

        public int Mul()
        {
            return _firstValue * _secondValue;
        }

        public int Div()
        {
            if (_secondValue == 0)
            {
                throw new DivideByZeroException("Division by zero is not allowed!");
            }

            return _firstValue / _secondValue;
        }
    }
}