using System;
using System.Windows.Forms;

namespace basicCalculator
{
    public partial class Form1 : Form
    {
        double result = 0;
        string checkCalculationOperator = "";
        bool clickedButton = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            if (textBox_Result.Text == "0" || clickedButton)
                textBox_Result.Clear();
            

            clickedButton = false;
            if (button.Text == ".")
            {
                if (!textBox_Result.Text.Contains("."))
                    textBox_Result.Text = textBox_Result.Text + button.Text;
            }
            else
            {
                textBox_Result.Text =textBox_Result.Text + button.Text;
            }

        }

        private void operator_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            if(result != 0)
            {
                button16.PerformClick();
                checkCalculationOperator = button.Text;
                labelCurrentOperation.Text = result + " " + checkCalculationOperator;
                clickedButton = true;

            }
            else
            {
                checkCalculationOperator = button.Text;
                result = Double.Parse(textBox_Result.Text);
                labelCurrentOperation.Text = result + " " + checkCalculationOperator;
                clickedButton = true;
            }

            
        }


        private void button_Equal_Click(object sender, EventArgs e)
        {
            switch (checkCalculationOperator)
            {
                case "+":
                    textBox_Result.Text = (result + Double.Parse(textBox_Result.Text)).ToString();
                    break;
                case "-":
                    textBox_Result.Text = (result - Double.Parse(textBox_Result.Text)).ToString();
                    break;
                case "*":
                    textBox_Result.Text = (result * Double.Parse(textBox_Result.Text)).ToString();
                    break;
                case "/":
                    textBox_Result.Text = (result / Double.Parse(textBox_Result.Text)).ToString();
                    break;
                default:
                    textBox_Result.Text = "Something went wrong!";
                    break;
            }

            result = Double.Parse(textBox_Result.Text);
            labelCurrentOperation.Text = "";
        }


        private void buttonDelete_Click(object sender, EventArgs e)
        {
            textBox_Result.Text = "";
            result = 0;
        }
    }
}
