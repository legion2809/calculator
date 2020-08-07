using System;
using System.Windows.Forms;

namespace Simple_Calculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string oper; // Defines a mathematic operation
        double a, result;
        bool sign = true;

        public void Calc()
        {
            switch (oper)
            {
                case "+":
                    result = a + Convert.ToDouble(textBox1.Text);
                    textBox1.Text = result.ToString();
                    label1.Text = "";
                    break;
                case "-":
                    result = a - Convert.ToDouble(textBox1.Text);
                    textBox1.Text = result.ToString();
                    label1.Text = "";
                    break;
                case "*":
                    result = a * Convert.ToDouble(textBox1.Text);
                    textBox1.Text = result.ToString();
                    label1.Text = "";
                    break;
                case "/":
                    if (Convert.ToDouble(textBox1.Text) == 0)
                    {
                        textBox1.Text = "Division by zero attempt";
                        label1.Text = "";
                    } else
                    {
                        result = a / Convert.ToDouble(textBox1.Text);
                        textBox1.Text = result.ToString();
                        label1.Text = "";
                    }
                    break;
                case "sin":
                    switch (radioButton1.Checked)
                    {
                        case true:
                            result = Math.Sin(Convert.ToDouble(a) * (Math.PI / 180));
                            textBox1.Text = result.ToString();
                            label1.Text = "";
                            break;
                        case false:
                            result = Math.Sin(Convert.ToDouble(a));
                            textBox1.Text = result.ToString();
                            label1.Text = "";
                            break;
                    }
                    break;
                case "cos":
                    switch (radioButton1.Checked)
                    {
                        case true:
                            result = Math.Cos(Convert.ToDouble(a) * (Math.PI / 180));
                            textBox1.Text = result.ToString();
                            label1.Text = "";
                            break;
                        case false:
                            result = Math.Cos(Convert.ToDouble(a));
                            textBox1.Text = result.ToString();
                            label1.Text = "";
                            break;
                    }
                    break;
                case "tg":
                    switch (radioButton1.Checked)
                    {
                        case true:
                            if (Convert.ToDouble(a) == 90.0 || Convert.ToDouble(a) == 270.0)
                            {
                                textBox1.Text = "undefined";
                                label1.Text = "";
                            }
                            else
                            {
                                result = Math.Tan(Convert.ToDouble(a) * (Math.PI / 180));
                                textBox1.Text = result.ToString();
                                label1.Text = "";
                            }
                            break;
                        case false:
                            result = Math.Tan(Convert.ToDouble(a));
                            textBox1.Text = result.ToString();
                            label1.Text = "";
                            break;
                    }
                    break;
                case "ctg":
                    switch (radioButton1.Checked)
                    {
                        case true:
                            if (Convert.ToDouble(a) == 0.0 || Convert.ToDouble(a) == 180.0 || Convert.ToDouble(a) == 360.0)
                            {
                                textBox1.Text = "undefined";
                                label1.Text = "";
                            }
                            else
                            {
                                result = 1.0 / Math.Tan(Convert.ToDouble(a) * (Math.PI / 180));
                                textBox1.Text = result.ToString();
                                label1.Text = "";
                            }
                            break;
                        case false:
                            result = 1.0 / Math.Tan(Convert.ToDouble(a));
                            textBox1.Text = result.ToString();
                            label1.Text = "";
                            break;
                    }
                    break;
                case "sqrt":
                    if (a < 0)
                    {
                        textBox1.Text = "Invaild operation";
                        label1.Text = "";
                    } else
                    {
                        result = Math.Sqrt(a);
                        textBox1.Text = result.ToString();
                        label1.Text = "";
                    }
                    break;
                case "pow":
                    result = Math.Pow(a, Convert.ToDouble(textBox1.Text));
                    textBox1.Text = result.ToString();
                    label1.Text = "";
                    break;
                default:
                    break;
            }
        }

        // These buttons types digits into textbox
        private void Button10_Click(object sender, EventArgs e)
        {
            textBox1.Text += "0";
        }

        private void Button9_Click(object sender, EventArgs e)
        {
            textBox1.Text += "1";
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            textBox1.Text += "2";
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            textBox1.Text += "3";
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            textBox1.Text += "4";
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            textBox1.Text += "5";
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            textBox1.Text += "6";
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            textBox1.Text += "7";
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            textBox1.Text += "8";
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            textBox1.Text += "9";
        }

        // Clears the textbox
        private void Button11_Click(object sender, EventArgs e)
        {
            label1.Text = "";
            textBox1.Clear();
        }

        // Division
        private void Button16_Click(object sender, EventArgs e)
        {
            try
            {
                a = Convert.ToDouble(textBox1.Text);
                textBox1.Clear();
                label1.Text = a + "/";
                oper = "/";
            } catch (FormatException)
            {
                MessageBox.Show("Invalid type of data!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Addition
        private void Button13_Click(object sender, EventArgs e)
        {
            try
            {
                a = Convert.ToDouble(textBox1.Text);
                textBox1.Clear();
                label1.Text = a + "+";
                oper = "+";
            } catch (FormatException)
            {
                MessageBox.Show("Invalid type of data!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Subtraction 
        private void Button14_Click(object sender, EventArgs e)
        {
            try
            {
                a = Convert.ToDouble(textBox1.Text);
                textBox1.Clear();
                label1.Text = a + "-";
                oper = "-";
            } catch (FormatException)
            {
                MessageBox.Show("Invalid type of data!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Multiplication 
        private void Button15_Click(object sender, EventArgs e)
        {
            try
            {
                a = Convert.ToDouble(textBox1.Text);
                label1.Text = a + "*";
                oper = "*";
                textBox1.Clear();
            } catch (FormatException)
            {
                MessageBox.Show("Invalid type of data!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Changes the sign of number
        private void Button17_Click(object sender, EventArgs e)
        {
            switch (sign)
            {
                case true:
                    sign = false;
                    textBox1.Text = "-" + textBox1.Text;
                    sign = true;
                    break;
                case false:
                    sign = true;
                    textBox1.Text = textBox1.Text.Replace("-", "");
                    sign = false;
                    break;
            }
        }

        // Deletes the digits of the entered number one by one
        private void Button18_Click(object sender, EventArgs e)
        {
            int length = textBox1.Text.Length - 1;
            string inputed = textBox1.Text;
            textBox1.Clear();

            for (int i = 0; i < length; i++) 
            {
                textBox1.Text += inputed[i];
            }
        }

        // Sin
        private void button19_Click(object sender, EventArgs e)
        {
            try
            {
                a = Convert.ToDouble(textBox1.Text);
                label1.Text = "sin(" + a + ")";
                oper = "sin";
                textBox1.Clear();
            } catch (FormatException)
            {
                MessageBox.Show("Invalid type of data!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Cos
        private void button20_Click(object sender, EventArgs e)
        {
            try
            {
                a = Convert.ToDouble(textBox1.Text);
                label1.Text = "cos(" + a + ")";
                oper = "cos";
                textBox1.Clear();
            } catch (FormatException)
            {
                MessageBox.Show("Invalid type of data!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Tg
        private void button21_Click(object sender, EventArgs e)
        {
            try
            {
                a = Convert.ToDouble(textBox1.Text);
                label1.Text = "tg(" + a + ")";
                oper = "tg";
                textBox1.Clear();
            } catch (FormatException)
            {
                MessageBox.Show("Invalid type of data!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Ctg
        private void button22_Click(object sender, EventArgs e)
        {
            try
            {
                a = Convert.ToDouble(textBox1.Text);
                label1.Text = "ctg(" + a + ")";
                oper = "ctg";
                textBox1.Clear();
            } catch (FormatException)
            {
                MessageBox.Show("Invalid type of data!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Square root of number
        private void button23_Click(object sender, EventArgs e)
        {
            try
            {
                a = Convert.ToDouble(textBox1.Text);
                label1.Text = "sqrt(" + a + ")";
                oper = "sqrt";
                textBox1.Clear();
            } catch (FormatException)
            {
                MessageBox.Show("Invalid type of data!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Decimal separator
        private void button24_Click(object sender, EventArgs e)
        {
            if (sign)
            {
                sign = false;
            }

            if (textBox1.Text.IndexOf(",") == -1) textBox1.Text += ',';
        }

        // Raising a number to a power
        private void button25_Click(object sender, EventArgs e)
        {
            try
            {
                a = Convert.ToDouble(textBox1.Text);
                label1.Text = a + "^";
                oper = "pow";
                textBox1.Clear();
            } catch (FormatException)
            {
                MessageBox.Show("Invalid type of data!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // This button calls the "Calc" function which checks and performs the specified operation
        private void Button12_Click(object sender, EventArgs e)
        {
            Calc();
        }
    }
}
