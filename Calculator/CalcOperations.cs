namespace Calculator;

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
    private string Add() => $"{num1 + num2}";

    // Subtraction
    private string Sub() => $"{num1 - num2}";

    // Multiplication
    private string Mul() => $"{num1 * num2}";

    // Division
    private string Div() => num2 == 0 ? "Cannot divide by zero" : $"{num1 / num2}";

    // Raising to power
    private string Pow() => $"{Math.Pow(num1, num2)}";

    #endregion

    /// <summary>
    /// Performs calculation
    /// </summary>
    /// <param name="calcOp">Sign of mathematical operation</param>
    /// <returns>Result of calculation (as a string value)</returns>
    public string Calc(string calcOp) => calcOp switch
    {
        "+" => Add(),
        "-" => Sub(),
        "*" => Mul(),
        "/" => Div(),
        "^" => Pow(),
        _ => "0",
    };
}
