using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionClass
{
    public class TerminalExpression : Expression
    {
        protected double x;
        
        public TerminalExpression(double x)
        {
            this.x = x;
        }

        override
        public double solve()
        {
            return x;
        }
    }
}
