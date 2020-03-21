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
        string current_number; // menyimpan angka dari input pengguna
        bool AssignClicked = false; // menandai apakah tombol = sudah ditekan atau belum

        public Form1()
        {
            InitializeComponent();
        }

        // Jika tombol angka diklik
        private void Number_Clicked(object sender, EventArgs e)
        {
            Button clicked = (Button)sender;

            // Menghapus angka di layar jika di layar 0 atau setelah tanda = ditekan
            if (textBox_Result.Text == "0" || AssignClicked)
            {
                if (AssignClicked)
                {
                    textBox_Result.Clear();
                    AssignClicked = false;
                }
                else if (clicked.Text != ".")
                {
                    textBox_Result.Clear();
                }
            }

            // Mengubah tulisan di layar dan menyimpan angka ke current_number
            textBox_Result.Text = textBox_Result.Text + clicked.Text;
            current_number = current_number + clicked.Text;

            // Tombol yang terakhir di tekan bukan tombol operator, 
            // maka isOperation = false
            calc.SetStateOperation(false);
        }

        // Jika tombol operator diklik
        // TODO: Yang paham materi Exception, bisa tambahin exc kalo 
        // pengguna menginput button_operator secara tidak wajar :v
        private void Operator_Clicked(object sender, EventArgs e)
        {
            Button clicked = (Button)sender;
            // mengubah isOperation menjadi true karena tombol operator diklik
            calc.SetStateOperation(true);
            
            // Menyimpan operator yang diklik ke operatorSign
            calc.SignOperator(clicked.Text);

            // Menyimpan angka ke operand1
            calc.SetOperand1(current_number);
            current_number = "";

            // Menampilkan operator ke layar
            textBox_Result.Text = textBox_Result.Text + clicked.Text;
        }

        private void asignButton(object sender, EventArgs e)
        {
            AssignClicked = true;

            // Menyimpan angka ke operand 2
            calc.SetOperand2(current_number);
            current_number = "";

            // Menghitung operasi
            double temp = calc.calculate();

            // Menampilkan hasil operasi
            textBox_Result.Clear();
            textBox_Result.Text = temp.ToString();
        }

        private void AC_button(object sender, EventArgs e)
        {
            calc.Reset();
            textBox_Result.Text = "0";
        }

        private void MC_Button(object sender, EventArgs e)
        {
            calc.SetMemory(textBox_Result.Text);
            textBox_Result.Text = "0";
        }

        private void MR_Button(object sender, EventArgs e)
        {
            calc.GetMemory();
        }
    }
}
