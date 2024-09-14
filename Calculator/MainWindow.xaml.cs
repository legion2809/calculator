namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Variables and constructor
        static double num1, num2;
        static int calcFuncCalls = 0;
        static string calcOp = string.Empty;
        bool sign = true;

        CalcOperations? calcOps;

        public MainWindow()
        {
            InitializeComponent();
            DegreesRButton.IsChecked = true;
            if (Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator == ".")
            {
                DecimalSeparatorButton.Content = ".";
            } else
            {
                DecimalSeparatorButton.Content = ",";
            }
            EntryTextBox.Text = "0";
            TempLabel.Content = string.Empty;
        }
        #endregion

        #region Only decimal or float (double) numbers

        private bool FloatOrDoubleCharChecker(char str)
        {
            if (char.IsDigit(str) || str == '-' || str == ',' || str == '.')
            {
                return true;
            }

            return false;
        }

        protected override void OnPreviewKeyDown(KeyEventArgs e)
        {
            e.Handled = (e.Key == Key.Space);
            base.OnPreviewKeyDown(e);
        }
        
        private void FloatOnly(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !FloatOrDoubleCharChecker(Convert.ToChar(e.Text));
            base.OnTextInput(e);
        }

        #endregion

        #region Util methods

        private void BtnContentToEntry(string btnText)
        {
            if (EntryTextBox.Text == "0")
            {
                EntryTextBox.Text = btnText;
            } else
            {
                EntryTextBox.Text += btnText;
            }
        }

        private void ForCalcOpsWithTwoArgs()
        {
            string? text = TempLabel.Content.ToString();
            if (text == string.Empty)
            {
                num1 = Convert.ToDouble(EntryTextBox.Text);
            }
        }

        #endregion

        #region Calculating trigonomethrics
        
        private void CalcTrigonomethric(string func)
        {
            string angleMeasure = RadiansRButton.IsChecked == true ? "radians" : "degrees";
            num1 = Convert.ToDouble(EntryTextBox.Text);

            switch (func)
            {
                case "sin":
                    EntryTextBox.Text = angleMeasure == "radians" ? $"sinr({num1})={Math.Sin(num1)}" : $"sin({num1})={Math.Round(Math.Sin(num1 * (Math.PI / 180)), 5)}";
                    break;
                case "cos":
                    EntryTextBox.Text = angleMeasure == "radians" ? $"cosr({num1})={Math.Cos(num1)}" : $"cos({num1})={Math.Round(Math.Cos(num1 * (Math.PI / 180)), 5)}";
                    break;
                case "tg":
                    EntryTextBox.Text = angleMeasure == "radians" ? $"tgr({num1})={Math.Tan(num1)}" : $"tg({num1})={Math.Round(Math.Tan(num1 * (Math.PI / 180)), 5)}";
                    break;
                case "ctg":
                    EntryTextBox.Text = angleMeasure == "radians" ? $"ctgr({num1})={1.0 / Math.Tan(num1)}" : $"ctg({num1})={Math.Round((1.0 / Math.Tan(num1 * (Math.PI / 180))), 5)}";
                    break;
                default:
                    break;
            }
        }

        #endregion

        #region Inserting digits by clicking the corresponding buttons

        private void bNum0_Click(object sender, RoutedEventArgs e)
        {
            BtnContentToEntry("0");
        }

        private void bNum1_Click(object sender, RoutedEventArgs e)
        {
            BtnContentToEntry("1");
        }

        private void bNum2_Click(object sender, RoutedEventArgs e)
        {
            BtnContentToEntry("2");
        }

        private void bNum3_Click(object sender, RoutedEventArgs e)
        {
            BtnContentToEntry("3");
        }

        private void bNum4_Click(object sender, RoutedEventArgs e)
        {
            BtnContentToEntry("4");
        }

        private void bNum5_Click(object sender, RoutedEventArgs e)
        {
            BtnContentToEntry("5");
        }

        private void bNum6_Click(object sender, RoutedEventArgs e)
        {
            BtnContentToEntry("6");
        }

        private void bNum7_Click(object sender, RoutedEventArgs e)
        {
            BtnContentToEntry("7");
        }

        private void bNum8_Click(object sender, RoutedEventArgs e)
        {
            BtnContentToEntry("8");
        }

        private void bNum9_Click(object sender, RoutedEventArgs e)
        {
            BtnContentToEntry("9");
        }

        #endregion

        #region Decimal separator, deleting digits of the entered number one by one + toggling the sign of number (positive/negative)

        private void bDecimalSeparator_Click(object sender, RoutedEventArgs e) 
        {
            switch (Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator)
            {
                case ",":
                    if (!EntryTextBox.Text.Contains(',', StringComparison.CurrentCulture))
                    {
                        EntryTextBox.Text += ",";
                    }
                    break;
                case ".":
                    if (!EntryTextBox.Text.Contains('.', StringComparison.CurrentCulture))
                    {
                        EntryTextBox.Text += ".";
                    }
                    break;
            }
        }

        private void bDelDigits1By1_Click(object sender, RoutedEventArgs e)
        {
            int length = EntryTextBox.Text.Length - 1;
            string input = EntryTextBox.Text;
            EntryTextBox.Clear();

            for (int i = 0; i < length; i++)
            {
                EntryTextBox.Text += input[i];
            }
        }

        private void bPosNegToggle_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(EntryTextBox.Text))
            {
                return;
            }

            switch (sign)
            {
                case true:
                    EntryTextBox.Text = "-" + EntryTextBox.Text;
                    sign = false;
                    break;
                case false:
                    EntryTextBox.Text = EntryTextBox.Text.Replace("-", "");
                    sign = true; 
                    break;
            }
        }

        #endregion

        #region Mathematic operations

        // Addition
        private void bAdd_Click(object sender, RoutedEventArgs e) 
        {
            calcOp = "+";
            num1 = Convert.ToDouble(EntryTextBox.Text);
            TempLabel.Content = $"{num1} {calcOp}";
            EntryTextBox.Text = "0";
            calcFuncCalls = 0;
        }

        // Subtraction
        private void bSub_Click(object sender, RoutedEventArgs e) 
        {
            calcOp = "-";
            num1 = Convert.ToDouble(EntryTextBox.Text);
            TempLabel.Content = $"{num1} {calcOp}";
            EntryTextBox.Text = "0";
            calcFuncCalls = 0;
        }

        // Multiplication
        private void bMult_Click(object sender, RoutedEventArgs e)
        {
            calcOp = "*";
            num1 = Convert.ToDouble(EntryTextBox.Text);
            TempLabel.Content = $"{num1} {calcOp}";
            EntryTextBox.Text = "0";
            calcFuncCalls = 0;
        }

        // Division
        private void bDiv_Click(object sender, RoutedEventArgs e) 
        {
            calcOp = "/";
            num1 = Convert.ToDouble(EntryTextBox.Text);
            TempLabel.Content = $"{num1} {calcOp}";
            EntryTextBox.Text = "0";
            calcFuncCalls = 0;
        }
        
        // Square root of number
        private void bSqrt_Click(object sender, RoutedEventArgs e) 
        {
            num1 = Convert.ToDouble(EntryTextBox.Text);
            EntryTextBox.Clear();
            TempLabel.Content = $"sqrt({num1}) = ";
            EntryTextBox.Text = Math.Sqrt(num1).ToString();
        }

        // Square number
        private void bSquareNumber_Click(object sender, RoutedEventArgs e)
        {
            double num1 = Convert.ToDouble(EntryTextBox.Text);
            EntryTextBox.Clear();
            EntryTextBox.Text = Math.Pow(num1, 2).ToString();
        }  

        // Raising a number to specified power
        private void bRaiseToPower_Click(object sender, RoutedEventArgs e)
        {
            calcOp = "^";
            num1 = Convert.ToDouble(EntryTextBox.Text);
            TempLabel.Content = $"{num1} {calcOp}";
            EntryTextBox.Text = "0";
            calcFuncCalls = 0;
        }

        // Reciprocal
        private void bReciprocal_Click(object sender, RoutedEventArgs e)
        {
            num1 = Convert.ToDouble(EntryTextBox.Text);
            EntryTextBox.Clear();
            TempLabel.Content = $"1 / {num1}";

            if (num1 == 0)
            {
                EntryTextBox.Text = "Cannot divide by zero";
            }
        }

        // Sin
        private void bSin_Click(object sender, RoutedEventArgs e)
        {
            CalcTrigonomethric("sin");
        }

        // Cos
        private void bCos_Click(object sender, RoutedEventArgs e)
        {
            CalcTrigonomethric("cos");
        }

        // Tg
        private void bTg_Click(object sender, RoutedEventArgs e)
        {
            CalcTrigonomethric("tg");
        }

        // Ctg
        private void bCtg_Click(object sender, RoutedEventArgs e)
        {
            CalcTrigonomethric("ctg");
        }
        #endregion

        #region "Equals" button - performs almost all of the calc operations

        private void bEquals_Click(object sender, RoutedEventArgs e)
        {
            if (calcFuncCalls == 0)
            {
                num2 = Convert.ToDouble(EntryTextBox.Text);
            }

            calcFuncCalls++;

            if (calcFuncCalls > 1) 
            { 
                num1 = Convert.ToDouble(EntryTextBox.Text);
            }

            calcOps = new CalcOperations(num1, num2);
            TempLabel.Content = $"{num1} {calcOp} {num2} = ";
            EntryTextBox.Text = calcOps.Calc(calcOp);
        }

        #endregion

        #region Clear the all entered data

        private void bClearAll_Click(object sender, RoutedEventArgs e)
        {
            EntryTextBox.Text = "0";
            TempLabel.Content = string.Empty;
            calcFuncCalls = 0;
        }

        private void bClearEntry_Click(object sender, RoutedEventArgs e)
        {
            EntryTextBox.Text = "0";
        }

        #endregion
    }
}
