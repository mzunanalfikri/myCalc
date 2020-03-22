using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionClass
{
    public class NegativeExpression : UnaryExpression
    {
        public NegativeExpression(Expression x) : base(x) { }

        override
        public double solve()
        {
            return x.solve() * -1;
        }
    }
}
