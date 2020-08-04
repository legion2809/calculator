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

        string oper;
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
                    if (radioButton1.Checked == true)
                    {
                        result = Math.Sin(Convert.ToDouble(a) * (Math.PI / 180));
                        textBox1.Text = result.ToString();
                        label1.Text = "";
                    } else if (radioButton2.Checked == true)
                    {
                        result = Math.Sin(Convert.ToDouble(a));
                        textBox1.Text = result.ToString();
                        label1.Text = "";
                    }
                    break;
                case "cos":
                    if (radioButton1.Checked == true)
                    {
                        result = Math.Cos(Convert.ToDouble(a) * (Math.PI / 180));
                        textBox1.Text = result.ToString();
                        label1.Text = "";
                    } else if (radioButton2.Checked == true)
                    {
                        result = Math.Cos(Convert.ToDouble(a));
                        textBox1.Text = result.ToString();
                        label1.Text = "";
                    }
                    break;
                case "tg":
                    if (radioButton1.Checked == true)
                    {
                        if (Convert.ToDouble(a) == 90.0 || Convert.ToDouble(a) == 270.0)
                        {
                            textBox1.Text = "undefined";
                            label1.Text = "";
                        } else
                        {
                            result = Math.Tan(Convert.ToDouble(a) * (Math.PI / 180));
                            textBox1.Text = result.ToString();
                            label1.Text = "";
                        }
                    } else if (radioButton2.Checked == true) {
                        result = Math.Tan(Convert.ToDouble(a));
                        textBox1.Text = result.ToString();
                        label1.Text = "";
                    }
                    break;
                case "ctg":
                    if (radioButton1.Checked == true)
                    {
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
                    }
                    else if (radioButton2.Checked == true)
                    {
                        result = 1.0 / Math.Tan(Convert.ToDouble(a));
                        textBox1.Text = result.ToString();
                        label1.Text = "";
                    }
                    break;
                case "sqrt":
                    result = Math.Sqrt(a);
                    textBox1.Text = result.ToString();
                    label1.Text = "";
                    break;
                default:
                    break;
            }
        }

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

        private void Button11_Click(object sender, EventArgs e)
        {
            label1.Text = "";
            textBox1.Clear();
        }

        private void Button16_Click(object sender, EventArgs e)
        {
            a = Convert.ToDouble(textBox1.Text);
            textBox1.Clear();
            label1.Text = a + "/";
            oper = "/";
        }

        private void Button13_Click(object sender, EventArgs e)
        {
            a = Convert.ToDouble(textBox1.Text);
            textBox1.Clear();
            label1.Text = a + "+";
            oper = "+";
        }

        private void Button14_Click(object sender, EventArgs e)
        {
            a = Convert.ToDouble(textBox1.Text);
            textBox1.Clear();
            label1.Text = a + "-";
            oper = "-";
        }

        private void Button15_Click(object sender, EventArgs e)
        {
            a = Convert.ToDouble(textBox1.Text);
            label1.Text = a + "*";
            oper = "*";
            textBox1.Clear();
        }

        private void Button17_Click(object sender, EventArgs e)
        {
            if (sign == true)
            {
                sign = false;
                textBox1.Text = "-" + textBox1.Text;
            } else if (sign == false)
            {
                sign = true;
                textBox1.Text = textBox1.Text.Replace("-", "");
            }
        }

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

        private void button19_Click(object sender, EventArgs e)
        {
            a = Convert.ToDouble(textBox1.Text);
            label1.Text = "sin(" + a + ")";
            oper = "sin";
            textBox1.Clear();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            a = Convert.ToDouble(textBox1.Text);
            label1.Text = "cos(" + a + ")";
            oper = "cos";
            textBox1.Clear();
        }

        private void button21_Click(object sender, EventArgs e)
        {
            a = Convert.ToDouble(textBox1.Text);
            label1.Text = "tg(" + a + ")";
            oper = "tg";
            textBox1.Clear();
        }

        private void button22_Click(object sender, EventArgs e)
        {
            a = Convert.ToDouble(textBox1.Text);
            label1.Text = "ctg(" + a + ")";
            oper = "ctg";
            textBox1.Clear();
        }

        private void button23_Click(object sender, EventArgs e)
        {
            a = Convert.ToDouble(textBox1.Text);
            label1.Text = "sqrt(" + a + ")";
            oper = "sqrt";
            textBox1.Clear();
        }

        private void button24_Click(object sender, EventArgs e)
        {
            if (sign)
            {
                sign = false;
            }

            if (textBox1.Text.IndexOf(",") == -1) textBox1.Text += ',';
        }

        private void Button12_Click(object sender, EventArgs e)
        {
            Calc();
        }
    }
}
