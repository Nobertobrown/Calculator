using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        public double Result { get; set; }
        public string ButtonText { get; set; }
        public string Operator { get; set; }
        public string NextOp { get; set; }
        public double ButtonNum1;
        public double ButtonNum2;

        public Form1()
        {
            InitializeComponent();
        }

        private void btn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            ButtonText = btn.Text;

            txtResult.Text += ButtonText;
        }

        private void operator_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (Operator == null)
            {
                Operator = btn.Text;
            }
            else
            {
                NextOp = btn.Text;
            }

            if (ButtonNum1 == 0)
            {
                double.TryParse(txtResult.Text, out ButtonNum1);
                lblDisplay.Text = txtResult.Text + Operator;
                txtResult.Clear();
            }
            else if (ButtonNum2 == 0)
            {
                double.TryParse(txtResult.Text, out ButtonNum2);
            }

            if (ButtonNum1 != 0 && ButtonNum2 != 0)
            {
                switch (Operator)
                {
                    case "+":
                        Result = ButtonNum1 + ButtonNum2;
                        break;
                    case "-":
                        Result = ButtonNum1 - ButtonNum2;
                        break;
                    case "×":
                        Result = ButtonNum1 * ButtonNum2;
                        break;
                    case "÷":
                        Result = ButtonNum1 / ButtonNum2;
                        break;
                    default:
                        txtResult.Clear();
                        break;
                }

                ButtonNum1 = Result;
                ButtonNum2 = 0;
                txtResult.Clear();
                Operator = NextOp;
                lblDisplay.Text = Convert.ToString(Result + Operator);
            }
        }

        private void equal_Click(object sender, EventArgs e)
        {
            if (Operator == null)
            {
                if (txtResult.Text != null)
                {
                    lblDisplay.Text = txtResult.Text;
                    txtResult.Clear();
                }
            }
            else
            {
                double.TryParse(txtResult.Text, out ButtonNum2);

                switch (Operator)
                {
                    case "+":
                        Result = ButtonNum1 + ButtonNum2;
                        break;
                    case "-":
                        Result = ButtonNum1 - ButtonNum2;
                        break;
                    case "×":
                        Result = ButtonNum1 * ButtonNum2;
                        break;
                    case "÷":
                        Result = ButtonNum1 / ButtonNum2;
                        break;
                    default:
                        txtResult.Clear();
                        break;
                }

                ButtonNum1 = Result;
                ButtonNum2 = 0;
                txtResult.Clear();
                Operator = null;
                lblDisplay.Text = Convert.ToString(Result);

            }
        }

        private void clear_Click(object sender, EventArgs e) { }
    }
}
