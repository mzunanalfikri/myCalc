using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class Calc
    {
        protected double operand1;
        protected double operand2;
        protected string operatorSign;
        protected bool isOperation;

        protected Queue<double> memory;
        protected List<double> numbers;

        // default constructor
        public Calc()
        {
            operand1 = 0.0;
            operand2 = 0.0;
            isOperation = false;

            memory = new Queue<double>();
            numbers = new List<double>();
        }

        // Menghapus semua yang ada di layar dan di memory kalkulator
        // Dipanggil ketika tombol AC ditekan
        public void Reset()
        {
            operand1 = 0.0;
            operand2 = 0.0;
            isOperation = false;

            memory.Clear();
            numbers.Clear();
        }

        // GETTER & SETTER

        // Mengubah string yang diterima dari input kalkulator menjadi double
        // kemudian menyimpannya ke operand
        public void SetOperand1(string number)
        {
            operand1 = double.Parse(number);
        }

        public void SetOperand2(string number)
        {
            operand2 = double.Parse(number);
        }

        // Menyimpan operator dari input ke dalam operatorSign
        public void SignOperator(string sign)
        {
            operatorSign = sign;
        }

        // Mengembalikan operator dari operatorSign
        public string GetSignOperator()
        {
            return operatorSign;
        }

        // Mengubah nilai isOperation
        // isOperation bernilai true jika yang barusan ditekan adalah tombol operator
        public void SetStateOperation(bool state)
        {
            isOperation = state;
        }

        // Mengembalikan nilai isOperation
        // isOperation bernilai true jika yang barusan ditekan adalah tombol operator
        public bool GetStateOperation()
        {
            return isOperation;
        }

        // Memasukkan angka ke dalam memory
        public void SetMemory(string nums)
        {
            memory.Enqueue(double.Parse(nums));
        }

        // Mengeluarkan angka dari memory
        public double GetMemory()
        {
            return memory.Dequeue();
        }

        // Menghitung hasil operasi <operand1> <operator> <operand2>
        public double calculate()
        {
            double temp = 0.0;
            switch (operatorSign)
            {
                case "+":
                    temp = operand1 + operand2;
                    break;

                case "-":
                    temp = operand1 - operand2;
                    break;

                case "*":
                    temp = operand1 * operand2;
                    break;

                case "/":
                    temp = operand1 / operand2;
                    break;
            }
            return temp;
        }
    }
}
