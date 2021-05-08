namespace Calculator.Core
{
    // NodeNumber represents a literal number in the expression
    internal class NodeNumber : Node
    {
        public NodeNumber(decimal number)
        {
            _number = number;
        }

        private decimal _number;

        public override decimal Eval()
        {
            return _number;
        }
    }
}