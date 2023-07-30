namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static double num1, num2;
        bool sign = true;
        static int calcOpId;
        string calcOp = string.Empty, angleMeasure = string.Empty;

        CalcOperations? calcOps;

        public MainWindow()
        {
            InitializeComponent();
            DegreesRButton.IsChecked = true;
            if (Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator == ".")
            {
                DecimalSeparatorButton.Content = ".";
            }
            else
            {
                DecimalSeparatorButton.Content = ",";
            }
        }

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

        #region Inserting digits by clicking the corresponding buttons

        private void bNum0_Click(object sender, RoutedEventArgs e)
        {
            MainTextBox.Text += "0";
        }

        private void bNum1_Click(object sender, RoutedEventArgs e)
        {
            MainTextBox.Text += "1";
        }

        private void bNum2_Click(object sender, RoutedEventArgs e)
        {
            MainTextBox.Text += "2";
        }

        private void bNum3_Click(object sender, RoutedEventArgs e)
        {
            MainTextBox.Text += "3";
        }

        private void bNum4_Click(object sender, RoutedEventArgs e)
        {
            MainTextBox.Text += "4";
        }

        private void bNum5_Click(object sender, RoutedEventArgs e)
        {
            MainTextBox.Text += "5";
        }

        private void bNum6_Click(object sender, RoutedEventArgs e)
        {
            MainTextBox.Text += "6";
        }

        private void bNum7_Click(object sender, RoutedEventArgs e)
        {
            MainTextBox.Text += "7";
        }

        private void bNum8_Click(object sender, RoutedEventArgs e)
        {
            MainTextBox.Text += "8";
        }

        private void bNum9_Click(object sender, RoutedEventArgs e)
        {
            MainTextBox.Text += "9";
        }

        #endregion

        #region Decimal separator, deleting digits of the entered number one by one + toggling the sign of number (positive/negative)

        private void bDecimalSeparator_Click(object sender, RoutedEventArgs e) 
        {
            switch (Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator)
            {
                case ",":
                    if (!MainTextBox.Text.Contains(',', StringComparison.CurrentCulture))
                    {
                        MainTextBox.Text += ",";
                    }
                    break;
                case ".":
                    if (!MainTextBox.Text.Contains('.', StringComparison.CurrentCulture))
                    {
                        MainTextBox.Text += ".";
                    }
                    break;
            }
        }

        private void bDelDigits1By1_Click(object sender, RoutedEventArgs e)
        {
            int length = MainTextBox.Text.Length - 1;
            string input = MainTextBox.Text;
            MainTextBox.Clear();

            for (int i = 0; i < length; i++)
            {
                MainTextBox.Text += input[i];
            }
        }

        private void bPosNegToggle_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(MainTextBox.Text))
            {
                return;
            }

            switch (sign)
            {
                case true:
                    MainTextBox.Text = "-" + MainTextBox.Text;
                    sign = false;
                    break;
                case false:
                    MainTextBox.Text = MainTextBox.Text.Replace("-", "");
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
            calcOpId = 1;
            num1 = Convert.ToDouble(MainTextBox.Text);
            MainTextBox.Text += calcOp;
        }

        // Subtraction
        private void bSub_Click(object sender, RoutedEventArgs e) 
        {
            calcOp = "-";
            calcOpId = 2;
            num1 = Convert.ToDouble(MainTextBox.Text);
            MainTextBox.Text += calcOp;
        }

        // Multiplication
        private void bMult_Click(object sender, RoutedEventArgs e)
        {
            calcOp = "*";
            calcOpId = 3;
            num1 = Convert.ToDouble(MainTextBox.Text);
            MainTextBox.Text += calcOp;
        }

        // Division
        private void bDiv_Click(object sender, RoutedEventArgs e) 
        {
            calcOp = "/";
            calcOpId = 4;
            num1 = Convert.ToDouble(MainTextBox.Text);
            MainTextBox.Text += calcOp;
        }
        
        // Square root of number
        private void bSqrt_Click(object sender, RoutedEventArgs e) 
        {
            double temp = Convert.ToDouble(MainTextBox.Text);
            MainTextBox.Clear();
            MainTextBox.Text = Math.Sqrt(temp).ToString();
        }

        // Square number
        private void bSquareNumber_Click(object sender, RoutedEventArgs e)
        {
            double temp = Convert.ToDouble(MainTextBox.Text);
            MainTextBox.Clear();
            MainTextBox.Text = Math.Pow(temp, 2).ToString();
        }  

        // Raising a number to specified power
        private void bRaiseToPower_Click(object sender, RoutedEventArgs e)
        {
            calcOp = "^";
            calcOpId = 5;
            num1 = Convert.ToDouble(MainTextBox.Text);
            MainTextBox.Text += calcOp;
        }

        // Reciprocal
        private void bReciprocal_Click(object sender, RoutedEventArgs e)
        {
            double temp = Convert.ToDouble(MainTextBox.Text);
            MainTextBox.Clear();
            MainTextBox.Text = (1 / temp).ToString();
        }

        // Sin
        private void bSin_Click(object sender, RoutedEventArgs e)
        {
            angleMeasure = RadiansRButton.IsChecked == true ? "radians" : "degrees";
            calcOpId = 6;
            num1 = Convert.ToDouble(MainTextBox.Text);

            calcOps = new CalcOperations(num1, 0);
            MainTextBox.Text = calcOps.Calc(calcOpId, angleMeasure);
        }

        // Cos
        private void bCos_Click(object sender, RoutedEventArgs e)
        {
            angleMeasure = RadiansRButton.IsChecked == true ? "radians" : "degrees";
            calcOpId = 7;
            num1 = Convert.ToDouble(MainTextBox.Text);

            calcOps = new CalcOperations(num1, 0);
            MainTextBox.Text = calcOps.Calc(calcOpId, angleMeasure);
        }

        // Tg
        private void bTg_Click(object sender, RoutedEventArgs e)
        {
            angleMeasure = RadiansRButton.IsChecked == true ? "radians" : "degrees";
            calcOpId = 8;
            num1 = Convert.ToDouble(MainTextBox.Text);

            calcOps = new CalcOperations(num1, 0);
            MainTextBox.Text = calcOps.Calc(calcOpId, angleMeasure);
        }

        // Ctg
        private void bCtg_Click(object sender, RoutedEventArgs e)
        {
            angleMeasure = RadiansRButton.IsChecked == true ? "radians" : "degrees";
            calcOpId = 9;
            num1 = Convert.ToDouble(MainTextBox.Text);

            calcOps = new CalcOperations(num1, 0);
            MainTextBox.Text = calcOps.Calc(calcOpId, angleMeasure);
        }
        #endregion

        #region "Equals" button - performs almost all of calc operations

        private void bEquals_Click(object sender, RoutedEventArgs e)
        {
            num2 = Convert.ToDouble(MainTextBox.Text.Substring(MainTextBox.Text.IndexOf(calcOp) + 1));
            calcOps = new CalcOperations(num1, num2);
            MainTextBox.Text = calcOps.Calc(calcOpId);
        }

        #endregion

        #region Clear the all entered data

        private void bClearAll_Click(object sender, RoutedEventArgs e)
        {
            MainTextBox.Clear();
        }

        #endregion
    }
}
