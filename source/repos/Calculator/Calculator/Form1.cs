using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Calculator.Calc;

namespace Calculator
{
    public partial class Form1 : Form
    {
        ICalc Calc;
        double num1, num2;
        bool isMinus;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            FormInit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddToTextbox(1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddToTextbox(2);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AddToTextbox(3);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AddToTextbox(4);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            AddToTextbox(5);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            AddToTextbox(6);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            AddToTextbox(7);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            AddToTextbox(8);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            AddToTextbox(9);
        }

        private void button0_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Contains("0"))
            {
                if (textBox1.Text.Length > 1)
                {
                    AddToTextbox(0);
                }
            }
            else
                AddToTextbox(0);
        }

        private void FormInit()
        {
            num1 = 0;
            num2 = 0;
            Calc = null;
            isMinus = false;
            textBox1.Text = 0 + "";
        }

        private void AddToTextbox(int a)
        {
            if (textBox1.Text.Length == 1 && textBox1.Text.Contains("0"))
                textBox1.Text = "";
            if (textBox1.Text.Length == 2 && textBox1.Text.Contains("-0"))
                textBox1.Text = "-";
            //Чтобы нельзя было менять ответ
            if(num2 == 0)
                textBox1.Text += a;
        }

        private void doubleButton_Click(object sender, EventArgs e)
        {
            AddToTextbox(',');
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            FormInit();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            DoCalculation();
            Calc = new Adder();
        }

        private void subButton_Click(object sender, EventArgs e)
        {
            DoCalculation();
            Calc = new Substractor();
        }

        private void multiplyButton_Click(object sender, EventArgs e)
        {
            DoCalculation();
            Calc = new Multiplier();
        }

        private void divButton_Click(object sender, EventArgs e)
        {
            DoCalculation();
            Calc = new Divider();
        }

        private void minusButton_Click(object sender, EventArgs e)
        {
            if (num2 == 0)
            {
                if (isMinus == false)
                {
                    if (textBox1.Text.StartsWith("0") && textBox1.Text.Length > 1)
                    {
                        textBox1.Text = textBox1.Text.Insert(0, "-");
                        isMinus = true;
                    }
                    else
                    {
                        textBox1.Text = textBox1.Text.Insert(0, "-");
                        isMinus = true;
                    }
                }
                else
                {
                    textBox1.Text = textBox1.Text.Remove(0, 1);
                    isMinus = false;
                }
            }
        }

        private void solveButton_Click(object sender, EventArgs e)
        {
            if (Calc != null)
            {
                num2 = Convert.ToDouble(textBox1.Text);
                textBox1.Text = Calc.DoMath(num1, num2) + "";
                Calc = null;
                isMinus = false;
            }
        }

        private void AddToTextbox(char a)
        {
            // num2 в условии, чтобы нельзя было ответ менять 
            if(textBox1.Text.Contains(',') == false && num2 == 0)
            {
                textBox1.Text += a;
            }
        }

        private void DoCalculation()
        {
            if (Calc == null)
            {
                num1 = Convert.ToDouble(textBox1.Text);
            }
            else
            {
                double tmp = Convert.ToDouble(textBox1.Text);
                num1 = Calc.DoMath(num1, tmp);
            }
            isMinus = false;
            num2 = 0;
            textBox1.Text = "0";
        }
    }
}
