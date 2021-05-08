using Calculator.Core.Operations;
using System.IO;

namespace Calculator.Core
{
    public class Parser
    {
        private Tokenizer _tokenizer;

        // Constructor
        public Parser(Tokenizer tokenizer)
        {
            _tokenizer = tokenizer;
        }

        // Parse an entire expression and check EOF was reached
        public Node ParseExpression()
        {
            // For the moment, all we understand is add and subtract
            var expr = ParseAddSubtract();

            // Check everything was consumed
            if (_tokenizer.Token != Token.EOF)
                throw new SyntaxException("Unexpected characters at end of expression");

            return expr;
        }

        // Parse an sequence of add/subtract operators
        private Node ParseAddSubtract()
        {
            // Parse the left hand side
            var lhs = ParseMultiplyDivide();

            while (true)
            {
                // Work out the operator
                IOperation op = null;
                if (_tokenizer.Token == Token.Add)
                {
                    op = new AddOperation();
                }
                else if (_tokenizer.Token == Token.Subtract)
                {
                    op = new DiffOperation();
                }

                // Binary operator found?
                if (op == null)
                    return lhs;

                // Skip the operator
                _tokenizer.NextToken();

                // Parse the right hand side of the expression
                var rhs = ParseMultiplyDivide();

                // Create a binary node and use it as the left-hand side from now on
                lhs = new NodeBinary(lhs, rhs, op);
            }
        }

        // Parse an sequence of add/subtract operators
        private Node ParseMultiplyDivide()
        {
            // Parse the left hand side
            var lhs = ParseLeaf();

            while (true)
            {
                // Work out the operator
                IOperation op = null;
                if (_tokenizer.Token == Token.Multiply)
                {
                    op = new MultOperation();
                }
                else if (_tokenizer.Token == Token.Divide)
                {
                    op = new DivOperation();
                }

                // Binary operator found?
                if (op == null)
                    return lhs;

                // Skip the operator
                _tokenizer.NextToken();

                // Parse the right hand side of the expression
                var rhs = ParseLeaf();

                // Create a binary node and use it as the left-hand side from now on
                lhs = new NodeBinary(lhs, rhs, op);
            }
        }

        // Parse a leaf node
        // (For the moment this is just a number)
        private Node ParseLeaf()
        {
            // Is it a number?
            if (_tokenizer.Token == Token.Number)
            {
                var node = new NodeNumber(_tokenizer.Number);
                _tokenizer.NextToken();
                return node;
            }

            // Is it a Dice?
            if ( _tokenizer.Token == Token.Dice)
            {
                var node = new NodeDice(_tokenizer.Dice);
                _tokenizer.NextToken();
                return node;
            }

            // Parenthesis?
            if (_tokenizer.Token == Token.OpenParens)
            {
                // Skip '('
                _tokenizer.NextToken();

                // Parse a top-level expression
                var node = ParseAddSubtract();

                // Check and skip ')'
                if (_tokenizer.Token != Token.CloseParens)
                    throw new SyntaxException("Missing close parenthesis");
                _tokenizer.NextToken();

                // Return
                return node;
            }

            // Unexpected
            throw new SyntaxException($"Unexpect token: {_tokenizer.Token}");
        }

        #region Helpers

        // Static helper to parse a string
        public static Node Parse(string str)
        {
            return Parse(new Tokenizer(new StringReader(str)));
        }

        // Static helper to parse from a tokenizer
        public static Node Parse(Tokenizer tokenizer)
        {
            var parser = new Parser(tokenizer);
            return parser.ParseExpression();
        }

        #endregion Helpers
    }
}