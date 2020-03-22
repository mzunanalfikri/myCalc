using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionClass
{
    public class Power : BinaryExpression
    {
        public Power(Expression x, Expression y) : base(x, y) { }

        override
        public double solve()
        {
            return Math.Pow(x.solve(), y.solve());
        }
    }
}
