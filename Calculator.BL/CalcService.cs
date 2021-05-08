using Calculator.Core;

namespace Calculator.BL
{
    public class CalcService : ICalcService
    {
        public CalcService()
        {
        }

        public decimal EvaluateExpression(string expr)
        {
            return Parser.Parse(expr).Eval();
        }
    }
}