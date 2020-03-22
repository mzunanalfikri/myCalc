using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionClass
{
    public class Division : BinaryExpression
    {
        public Division (Expression x, Expression y) : base(x, y) { }

        override
        public double solve()
        {
            // TODO: Throw and error if y.solve() == 0;
            return x.solve() / y.solve();
        }
    }
}
