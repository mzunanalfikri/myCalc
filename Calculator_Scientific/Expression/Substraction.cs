using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionClass
{
    public class Substraction : BinaryExpression
    {
        public Substraction(Expression x, Expression y) : base(x, y) { }

        override
        public double solve()
        {
            return x.solve() - y.solve();
        }
    }
}
