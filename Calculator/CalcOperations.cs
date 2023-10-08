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

        public string Calc(int id, string angleMeasure = "")
        {
            Dictionary<int, string> calcOperations = new Dictionary<int, string>()
            {
                { 1, Add() },
                { 2, Sub() },
                { 3, Mul() },
                { 4, Div() },
                { 5, Pow() }
            };

            return calcOperations[id];
        }
    }
}
