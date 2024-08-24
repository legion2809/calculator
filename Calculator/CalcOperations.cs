namespace Calculator
{
    internal class CalcOperations
    {
        private static double num1;
        private static double num2;

        public CalcOperations(double n1, double n2 = 0)
        {
            num1 = n1;
            num2 = n2;
        }

        #region Arithmetic operations

        // Addition
        private string Add()
        {
            return $"{num1 + num2}";
        }

        // Subtraction
        private string Sub()
        {
            return $"{num1 - num2}";
        }

        // Multiplication
        private string Mul()
        {
            return $"{num1 * num2}";
        }

        // Division
        private string Div()
        {
            if (num2 == 0)
            {
                return "Cannot divide by zero";
            }
            return $"{num1 / num2}";
        }

        // Raising to power
        private string Pow()
        {
            return $"{Math.Pow(num1, num2)}";
        }
        #endregion

        /// <summary>
        /// Performs calculation
        /// </summary>
        /// <param name="calcOp">Sign of mathematical operation</param>
        /// <returns>Result of calculation (as a string value)</returns>
        public string Calc(string calcOp)
        {
            string result = string.Empty;
            switch (calcOp)
            {
                case "+":
                    result = Add();
                    break;
                case "-":
                    result = Sub();
                    break;
                case "*":
                    result = Mul();
                    break;
                case "/":
                    result = Div();
                    break;
                case "^":
                    result = Pow();
                    break;
            }

            return result;
        }
    }
}
