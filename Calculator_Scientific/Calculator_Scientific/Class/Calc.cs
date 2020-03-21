using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class Calc
    {
        protected double resultValue;
        protected string operatorSign;
        protected bool isOperation;

        protected Queue<double> memory;
        protected List<double> numbers;

        public Calc()
        {
            resultValue = 0.0;
            isOperation = false;

            memory = new Queue<double>();
            numbers = new List<double>();
        }

        public void Reset()
        {
            resultValue = 0.0;
            isOperation = false;

            memory.Clear();
            numbers.Clear();
        }

        public void SetNumber(string number)
        {
            resultValue = double.Parse(number);
            //return resultValue;
        }

        public double GetResult()
        {
            return resultValue;
        }

        public void SignOperator(string sign)
        {
            operatorSign = sign;
        }

        public string GetSignOperator()
        {
            return operatorSign;
        }

        public void SetStateOperation(bool state)
        {
            isOperation = state;
        }

        public bool GetStateOperation()
        {
            return isOperation;
        }

        public void SetMemory(string nums)
        {
            memory.Enqueue(double.Parse(nums));
        }

        public double GetMemory()
        {
            return memory.Dequeue();
        }
    }
}
