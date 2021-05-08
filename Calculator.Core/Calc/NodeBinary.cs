using Calculator.Core.Operations;

namespace Calculator.Core
{
    // NodeBinary for binary operations such as Add, Subtract etc...
    internal class NodeBinary : Node
    {
        private Node _lhs;
        private Node _rhs;
        private IOperation _op;

        // Constructor accepts the two nodes to be operated on and function
        // that performs the actual operation
        public NodeBinary(Node lhs, Node rhs, IOperation op)
        {
            _lhs = lhs;
            _rhs = rhs;
            _op = op;
        }

        public override decimal Eval()
        {
            // Evaluate both sides
            var lhsVal = _lhs.Eval();
            var rhsVal = _rhs.Eval();

            // Evaluate and return
            var result = _op.Calculate(lhsVal, rhsVal);
            return result;
        }
    }
}