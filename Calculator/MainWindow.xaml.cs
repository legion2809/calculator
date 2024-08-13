namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Variables and constructor
        static double num1, num2;
        bool sign = true;
        string calcOp = string.Empty, angleMeasure = string.Empty;

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
            TempLabel.Content = "0";
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

        private void AddDigit(string btnText)
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

        #region Inserting digits by clicking the corresponding buttons

        private void bNum0_Click(object sender, RoutedEventArgs e)
        {
            AddDigit("0");
        }

        private void bNum1_Click(object sender, RoutedEventArgs e)
        {
            AddDigit("1");
        }

        private void bNum2_Click(object sender, RoutedEventArgs e)
        {
            AddDigit("2");
        }

        private void bNum3_Click(object sender, RoutedEventArgs e)
        {
            AddDigit("3");
        }

        private void bNum4_Click(object sender, RoutedEventArgs e)
        {
            AddDigit("4");
        }

        private void bNum5_Click(object sender, RoutedEventArgs e)
        {
            AddDigit("5");
        }

        private void bNum6_Click(object sender, RoutedEventArgs e)
        {
            AddDigit("6");
        }

        private void bNum7_Click(object sender, RoutedEventArgs e)
        {
            AddDigit("7");
        }

        private void bNum8_Click(object sender, RoutedEventArgs e)
        {
            AddDigit("8");
        }

        private void bNum9_Click(object sender, RoutedEventArgs e)
        {
            AddDigit("9");
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
        }

        // Subtraction
        private void bSub_Click(object sender, RoutedEventArgs e) 
        {
            calcOp = "-";
            num1 = Convert.ToDouble(EntryTextBox.Text);
            TempLabel.Content = $"{num1} {calcOp}";
            EntryTextBox.Text = "0";
        }

        // Multiplication
        private void bMult_Click(object sender, RoutedEventArgs e)
        {
            calcOp = "*";
            num1 = Convert.ToDouble(EntryTextBox.Text);
            TempLabel.Content = $"{num1} {calcOp}";
            EntryTextBox.Text = "0";
        }

        // Division
        private void bDiv_Click(object sender, RoutedEventArgs e) 
        {
            calcOp = "/";
            num1 = Convert.ToDouble(EntryTextBox.Text);
            TempLabel.Content = $"{num1} {calcOp}";
            EntryTextBox.Text = "0";
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
        }

        // Reciprocal
        private void bReciprocal_Click(object sender, RoutedEventArgs e)
        {
            num1 = Convert.ToDouble(EntryTextBox.Text);
            EntryTextBox.Clear();
            TempLabel.Content = $"1 / {num1}";
            EntryTextBox.Text = (1 / num1).ToString();
        }

        // Sin
        private void bSin_Click(object sender, RoutedEventArgs e)
        {
            angleMeasure = RadiansRButton.IsChecked == true ? "radians" : "degrees";
            num1 = Convert.ToDouble(EntryTextBox.Text);
            
            if (RadiansRButton.IsChecked == true)
            {
                EntryTextBox.Text = $"sinr({num1})={Math.Sin(num1)}";
            } else
            {
                EntryTextBox.Text = $"sin({num1})={Math.Round(Math.Sin(num1 * (Math.PI / 180)), 2)}";
            }
        }

        // Cos
        private void bCos_Click(object sender, RoutedEventArgs e)
        {
            angleMeasure = RadiansRButton.IsChecked == true ? "radians" : "degrees";
            num1 = Convert.ToDouble(EntryTextBox.Text);

            if (RadiansRButton.IsChecked == true)
            {
                EntryTextBox.Text = $"cosr({num1})={Math.Cos(num1)}";
            } else
            {
                EntryTextBox.Text = $"cos({num1})={Math.Round(Math.Cos(num1 * (Math.PI / 180)), 2)}";
            }
        }

        // Tg
        private void bTg_Click(object sender, RoutedEventArgs e)
        {
            angleMeasure = RadiansRButton.IsChecked == true ? "radians" : "degrees";
            num1 = Convert.ToDouble(EntryTextBox.Text);

            if (angleMeasure == "radians")
            {
                EntryTextBox.Text = $"tgr({num1})={Math.Tan(num1)}";
            } else
            {
                EntryTextBox.Text = $"tg({num1})={Math.Round(Math.Tan(num1 * (Math.PI / 180)), 2)}";
            }
        }

        // Ctg
        private void bCtg_Click(object sender, RoutedEventArgs e)
        {
            angleMeasure = RadiansRButton.IsChecked == true ? "radians" : "degrees";
            num1 = Convert.ToDouble(EntryTextBox.Text);

            if (angleMeasure == "radians")
            {
                EntryTextBox.Text = $"ctgr({num1})={1.0 / Math.Tan(num1)}";
            } else
            {
                EntryTextBox.Text = $"ctg({num1})={Math.Round((1.0 / Math.Tan(num1 * (Math.PI / 180))), 2)}";
            }
        }
        #endregion

        #region "Equals" button - performs almost all of the calc operations

        private void bEquals_Click(object sender, RoutedEventArgs e)
        {
            num2 = Convert.ToDouble(EntryTextBox.Text);
            calcOps = new CalcOperations(num1, num2);
            TempLabel.Content = $"{num1} {calcOp} {num2} = ";
            EntryTextBox.Text = calcOps.Calc(calcOp);
        }

        #endregion

        #region Clear the all entered data

        private void bClearAll_Click(object sender, RoutedEventArgs e)
        {
            EntryTextBox.Text = "0";
            TempLabel.Content = "0";
        }

        private void bClearEntry_Click(object sender, RoutedEventArgs e)
        {
            EntryTextBox.Text = "0";
        }

        #endregion
    }
}
