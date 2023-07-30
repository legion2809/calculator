namespace Calculator
{
    internal class CalcOperations
    {
        private static double num1;
        private static double num2;

        public CalcOperations(double n1, double n2)
        {
            num1 = n1;
            num2 = n2;
        }

        public string Calc(int id, string angleMeasure = "")
        {
            Dictionary<int, string> calcOperations = new Dictionary<int, string>()
            {
                { 1, $"{num1 + num2}" },
                { 2, $"{num1 - num2}" },
                { 3, $"{num1 * num2}" },
                { 4, $"{num1 / num2}" },
                { 5, $"{Math.Pow(num1, num2)}" },
                { 6, angleMeasure == "radians" ? $"sinr({num1})={Math.Sin(num1)}" : $"sin({num1})={Math.Round(Math.Sin(num1 * (Math.PI / 180)), 2)}" },
                { 7, angleMeasure == "radians" ? $"cosr({num1})={Math.Cos(num1)}" : $"cos({num1})={Math.Round(Math.Cos(num1 * (Math.PI / 180)), 2)}" },
                { 8, angleMeasure == "radians" ? $"tgr({num1})={Math.Tan(num1)}" : $"tg({num1})={Math.Round(Math.Tan(num1 *(Math.PI / 180)), 2)}" },
                { 9, angleMeasure == "radians" ? $"ctgr({num1})={ 1.0 / Math.Tan(num1)}" : $"ctg({num1})={Math.Round((1.0 / Math.Tan(num1 * (Math.PI / 180))), 2)}" }
            };

            return calcOperations[id];
        }
    }
}
