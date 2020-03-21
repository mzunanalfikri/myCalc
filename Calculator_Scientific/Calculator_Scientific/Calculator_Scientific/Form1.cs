using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Calculator;

namespace Calculator_Scientific
{
    public partial class Form1 : Form
    {

        Calc calc = new Calc();
        //bool isOperation = false;

        public Form1()
        {
            InitializeComponent();
        }

        //Number untuk menangani number dan .
        private void Number_Clicked(object sender, EventArgs e)
        {
            Button clicked = (Button)sender;

            bool isOperation = calc.GetStateOperation();
            if (textBox_Result.Text == "0" || isOperation)
            {
                if(clicked.Text != ".")
                    textBox_Result.Clear();
            }

            calc.SetStateOperation(false);
            textBox_Result.Text = textBox_Result.Text + clicked.Text;
            
        }

        //Menangani operator +. -. *, /, 
        private void Operator_Clicked(object sender, EventArgs e)
        {
            Button clicked = (Button)sender;
            calc.SetStateOperation(true);
            //Yang paham materi Exception, bisa tambahin exc kalo 
            //pengguna menginput button_operator secara tidak wajar :v

            calc.SignOperator(clicked.Text);
            calc.SetNumber(textBox_Result.Text);
        }

        private void asignButton(object sender, EventArgs e)
            //menangani button samadengan
        {
            double temp = 0.0;

            switch (calc.GetSignOperator())
            {
                case "+":
                    temp = calc.GetResult() + double.Parse(textBox_Result.Text);
                    break;

                case "-":
                    temp = calc.GetResult() - double.Parse(textBox_Result.Text);
                    break;

                case "*":
                    temp = calc.GetResult() * double.Parse(textBox_Result.Text);
                    break;

                case "/":
                    temp = calc.GetResult() / double.Parse(textBox_Result.Text);
                    break;
            }

            calc.SetNumber(temp.ToString());
            textBox_Result.Text = calc.GetResult().ToString();
        }

        
        private void AC_button(object sender, EventArgs e)
            //menangani Button AC
        {
            calc.Reset();
            textBox_Result.Text = "0";
        }

        private void MC_Button(object sender, EventArgs e)
            //menangani MC Button
        {
            calc.SetMemory(textBox_Result.Text);
            textBox_Result.Text = "0";
        }

        private void MR_Button(object sender, EventArgs e)
            //menangani MR Button
        {
            calc.GetMemory();
        }

        private void ButtonSqrt_Click(object sender, EventArgs e)
            //mengangani button SQRT
        {

        }

        private void ButtonPower_Click(object sender, EventArgs e)
            //menangani button pangkat
        {

        }

        private void ButtonMod_Click(object sender, EventArgs e)
            //menangani button Modulo
        {

        }
    }
}
