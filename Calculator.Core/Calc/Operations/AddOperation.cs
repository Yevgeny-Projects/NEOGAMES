namespace Calculator.Core.Operations
{
    public class AddOperation : IOperation
    {
        public string Name => "+";

        public decimal Calculate(decimal num1, decimal num2)
        {
            return num1 + num2;
        }
    }
}