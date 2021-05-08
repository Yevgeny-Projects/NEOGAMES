using System;

namespace Calculator.Core
{
    // NodeNumber represents a literal number in the expression
    internal class NodeDice : Node
    {
        public NodeDice(string dice)
        {
            Random rnd = new Random();
            int maxValue = Convert.ToInt32(dice.Remove(0, 1));
            _number = Convert.ToDecimal(rnd.Next(1, maxValue));
        }

        private decimal _number;

        public override decimal Eval()
        {
            return _number;
        }
    }
}