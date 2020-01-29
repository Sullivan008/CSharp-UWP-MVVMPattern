namespace MVVMPatternInUWP.Core.Interfaces.Calculating
{
    public interface ICalculator
    {
        int Add(int firstValue, int secondValue);

        int Sum(int firstValue, int secondValue);

        int Mul(int firstValue, int secondValue);

        double Div(int firstValue, int secondValue);
    }
}