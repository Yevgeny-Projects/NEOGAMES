﻿namespace Calculator.Core.Operations
{
    public class DiffOperation : IOperation
    {
        public string Name => "-";

        public decimal Calculate(decimal num1, decimal num2)
        {
            return num1 - num2;
        }
    }
}