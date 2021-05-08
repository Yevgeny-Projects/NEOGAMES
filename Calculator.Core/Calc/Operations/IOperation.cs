namespace Calculator.Core.Operations
{
    public interface IOperation
    {
        string Name { get; }

        decimal Calculate(decimal num1, decimal num2);
    }
}