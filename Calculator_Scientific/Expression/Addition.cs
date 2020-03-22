using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionClass
{
    public class Addition : BinaryExpression
    {
        public Addition(Expression x, Expression y) : base(x, y) { }

        override
        public double solve()
        {
            return x.solve() + y.solve();
        }
    }
}
