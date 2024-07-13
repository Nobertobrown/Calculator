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

        private void calculate()
        {
            try
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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            ButtonText = btn.Text;

            if (ButtonText == "." && txtResult.Text.Contains(".")) return;
            if (ButtonText == "0" && !txtResult.Text.Contains(".") && txtResult.Text.Length == 0) return;

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
                calculate();
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
                if (txtResult.Text != "")
                {
                    lblDisplay.Text = txtResult.Text;
                    txtResult.Clear();
                }
            }
            else
            {
                double.TryParse(txtResult.Text, out ButtonNum2);

                calculate();
                lblDisplay.Text = $"{ButtonNum1} {Operator} {ButtonNum2} = {Result}";
                ButtonNum1 = 0;
                ButtonNum2 = 0;
                txtResult.Clear();
                Operator = null;
                Result = 0;
            }
        }

        private void clear_Click(object sender, EventArgs e)
        {
            txtResult.Clear();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtResult.Clear();
            Operator = null;
            ButtonNum1 = 0;
            ButtonNum2 = 0;
            Result = 0;
            lblDisplay.Text = 0.ToString();
        }
    }
}
