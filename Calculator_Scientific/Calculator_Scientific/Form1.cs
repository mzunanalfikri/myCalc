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
    /*
    public abstract class Exception
    {
        protected string error;
           
        public Exception(string m)
        {
            error = m;
        }
        public abstract void ShowError();
    }
    */
    
    public partial class Form1 : Form
    {

        Calc calc = new Calc();
        string current_number = ""; // menyimpan angka dari input pengguna
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
            if (!calc.GetStateOperation() && current_number.Equals("") && clicked.Text.Equals("-"))
            //percabangan saat awal diinput negatif
            {
                textBox_Result.Clear();
                AssignClicked = false;
                textBox_Result.Text = textBox_Result.Text + clicked.Text;
                current_number = current_number + clicked.Text;
            }
            else if (calc.GetStateOperation() && current_number.Equals("") && clicked.Text.Equals("-"))
            //percaabangan setelah tanda operasi lalu ada simbol negatif
            {
                textBox_Result.Text = textBox_Result.Text + clicked.Text;
                current_number = current_number + clicked.Text;
            }
            else
            {
                // mengubah isOperation menjadi true karena tombol operator diklik
                calc.SetStateOperation(true);

                // Menyimpan operator yang diklik ke operatorSign
                calc.SignOperator(clicked.Text);

                // Menyimpan angka ke operand1
                calc.SetOperand1(current_number);
                current_number = "";

                // Menampilkan operator ke layar
                if (clicked.Text.Equals("mod"))
                {
                    textBox_Result.Text = textBox_Result.Text + "%";
                }
                else
                {
                    textBox_Result.Text = textBox_Result.Text + clicked.Text;
                }
            }
        }

        private void asignButton(object sender, EventArgs e)
        {
            
            if (calc.GetSignOperator().Equals("/") && current_number.Equals("0"))
            {
                //throw new ZeroException("Pembagian dengan nol");
                MessageBox.Show("pembagian dengan 0");
            }
            else
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

                //set state operation false
                calc.SetStateOperation(false);
                //set ans
                calc.SetAns(temp.ToString());
            }
                
        }

        private void AC_button(object sender, EventArgs e)
        {
            calc.Reset();
            current_number = "";
            textBox_Result.Text = "0";
        }

        private void MC_Button(object sender, EventArgs e)
            //button mc untuk save ke queue
        {
            if (current_number.Equals(""))
            {
                MessageBox.Show("tidak ada yang di simpan");
            } else
            {
                calc.SetMemory(current_number);
                MessageBox.Show(current_number + " berhasil dimasukkan ke queue");
            }
        }

        private void MR_Button(object sender, EventArgs e)
        {
            if (calc.IsMemEmpty())
            {
                MessageBox.Show("Queue kosong");
            }
            else
            {
                string temp = calc.GetMemory().ToString();
                textBox_Result.Text = textBox_Result.Text + temp;
                current_number = temp;
            }
            
        }

        

        private void ButtonPower_Click(object sender, EventArgs e)
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

        private void ButtonSqrt_Click(object sender, EventArgs e)
        {
            Button clicked = (Button)sender;
            if (calc.GetStateOperation() || current_number.Equals(""))
            {
                MessageBox.Show("Masukkan bilangan yang valid");
            }
            else
            {
                AssignClicked = true;

                // mengubah isOperation menjadi true karena tombol operator diklik
                calc.SetStateOperation(true);

                // Menyimpan operator yang diklik ke operatorSign
                calc.SignOperator(clicked.Text);

                //set operand 1
                calc.SetOperand1(current_number);
                current_number = "";

                // Menghitung operasi
                double temp = calc.calculate();

                // Menampilkan hasil operasi
                textBox_Result.Clear();
                textBox_Result.Text = temp.ToString();

                //set state operation false
                calc.SetStateOperation(false);
                //set ans
                calc.SetAns(temp.ToString());
            }
        }

        private void ButtonAns_Click(object sender, EventArgs e)
        {
            string temp = calc.GetAns().ToString();
            textBox_Result.Text = textBox_Result.Text + temp;
            current_number = temp;
        }
    }
}
