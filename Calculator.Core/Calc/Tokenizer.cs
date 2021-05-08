using System.Globalization;
using System.IO;
using System.Text;

namespace Calculator.Core
{
    public class Tokenizer
    {
        public Tokenizer(TextReader reader)
        {
            _reader = reader;
            NextChar();
            NextToken();
        }

        private TextReader _reader;
        private char _currentChar;
        private Token _currentToken;
        private decimal _number;
        private string _dice;


        public Token Token
        {
            get { return _currentToken; }
        }

        public decimal Number
        {
            get { return _number; }
        }

        public string Dice
        {
            get { return _dice; }
        }

        // Read the next character from the input strem
        // and store it in _currentChar, or load '\0' if EOF
        private void NextChar()
        {
            int ch = _reader.Read();
            _currentChar = ch < 0 ? '\0' : (char)ch;
        }

        // Read the next token from the input stream
        public void NextToken()
        {
            // Skip whitespace
            while (char.IsWhiteSpace(_currentChar))
            {
                NextChar();
            }

            // Special characters
            switch (_currentChar)
            {
                case '\0':
                    _currentToken = Token.EOF;
                    return;

                case '+':
                    NextChar();
                    _currentToken = Token.Add;
                    return;

                case '-':
                    NextChar();
                    _currentToken = Token.Subtract;
                    return;

                case '*':
                    NextChar();
                    _currentToken = Token.Multiply;
                    return;

                case '/':
                    NextChar();
                    _currentToken = Token.Divide;
                    return;

                case '(':
                    NextChar();
                    _currentToken = Token.OpenParens;
                    return;

                case ')':
                    NextChar();
                    _currentToken = Token.CloseParens;
                    return;

                case ',':
                    NextChar();
                    _currentToken = Token.Comma;
                    return;
            }

            // Number?
            if (char.IsDigit(_currentChar) || _currentChar == '.')
            {
                // Capture digits/decimal point
                var sb = new StringBuilder();
                bool haveDecimalPoint = false;
                while (char.IsDigit(_currentChar) || (!haveDecimalPoint && _currentChar == '.'))
                {
                    sb.Append(_currentChar);
                    haveDecimalPoint = _currentChar == '.';
                    NextChar();
                }

                // Parse it
                _number = decimal.Parse(sb.ToString(), CultureInfo.InvariantCulture);
                _currentToken = Token.Number;
                return;
            }

            // Dice - starts with letter 'd' 
            if (char.IsLetter(_currentChar) && _currentChar == 'd')
            {
                var sb = new StringBuilder();

                // Accept letter, digit or underscore
                while (char.IsLetterOrDigit(_currentChar))
                {
                    sb.Append(_currentChar);
                    NextChar();
                }

                // Setup token
                _dice = sb.ToString();
                _currentToken = Token.Dice;
                return;
            }
            throw new InvalidDataException($"Unexpected character: {_currentChar}");
        }
    }
}