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
        private string Add()
        {
            return $"{num1 + num2}";
        }

        private string Sub()
        {
            return $"{num1 - num2}";
        }

        private string Mul()
        {
            return $"{num1 * num2}";
        }

        private string Div()
        {
            return $"{num1 / num2}";
        }

        private string Pow()
        {
            return $"{Math.Pow(num1, num2)}";
        }
        #endregion

        /// <summary>
        /// Performs calculation
        /// </summary>
        /// <param name="id">ID of mathematical operation</param>
        /// <param name="angleMeasure">Angle measure (degrees or radians) - for trigonometric operations</param>
        /// <returns>Result of calculation (as a string value)</returns>
        public string Calc(string calcOp, string angleMeasure = "")
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
