using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpressionClass;
using Exceptions;

namespace Calculator
{
    public class Calc
    {
        protected Expression operand1;
        protected Expression operand2;
        protected string operatorSign;
        protected bool isOperation;
        protected double ans;

        protected Queue<double> memory;

        // default constructor
        public Calc()
        {
            operand1 = new TerminalExpression(0);
            operand2 = new TerminalExpression(0);
            ans = 0.0;
            isOperation = false;

            memory = new Queue<double>();
        }

        // Menghapus semua yang ada di layar dan di memory kalkulator
        // Dipanggil ketika tombol AC ditekan
        public void Reset()
        {
            operand1 = new TerminalExpression(0);
            operand2 = new TerminalExpression(0);
            isOperation = false;

            memory.Clear();
        }

        // GETTER & SETTER

        // Mengubah string yang diterima dari input kalkulator menjadi double
        // kemudian menyimpannya ke operand
        public void SetOperand1(string number)
        {
            try
            {
                double temp = double.Parse(number);
                operand1 = new TerminalExpression(temp);
            }
            catch (Exception)
            {
                throw new InvalidOperation("Operasi tidak valid.");
            }
        }

        public void SetOperand2(string number)
        {
            double temp = double.Parse(number);
            operand2 = new TerminalExpression(temp);
        }

        public void SetAns(string number)
        {
            ans = double.Parse(number);
        }
        // Menyimpan operator dari input ke dalam operatorSign
        public void SignOperator(string sign)
        {
            operatorSign = sign;
        }

        public double GetAns()
        {
            return ans;
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

        public bool IsMemEmpty()
        {
            return memory.Count == 0;
        }
        // Mengeluarkan angka dari memory
        public double GetMemory()
        {
            return memory.Dequeue();
        }

        // Menghitung hasil operasi <operand1> <operator> <operand2>
        public double calculate()
        {
            Expression temp = new TerminalExpression(0);
            switch (operatorSign)
            {
                case "+":
                    temp = new Addition(operand1, operand2);
                    break;
                case "-":
                    temp = new Substraction(operand1, operand2);
                    break;
                case "*":
                    temp = new Multiplication(operand1, operand2);
                    break;
                case "/":
                    temp = new Division(operand1, operand2);
                    break;
                case "^":
                    temp = new Power(operand1, operand2);
                    break;
                case "sqrt":
                    temp = new SquareRoot(operand1);
                    break;
                case "mod":
                    temp = new Modulus(operand1, operand2);
                    break;
            }
            return temp.solve();
        }
    }
}
