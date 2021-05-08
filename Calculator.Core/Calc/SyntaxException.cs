using System;

namespace Calculator.Core
{
    // Exception for syntax errors
    public class SyntaxException : Exception
    {
        public SyntaxException(string message)
            : base(message)
        {
        }
    }
}