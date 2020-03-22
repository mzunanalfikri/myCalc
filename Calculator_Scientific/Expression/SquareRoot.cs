using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionClass
{
    public class SquareRoot : UnaryExpression
    {
        public SquareRoot (Expression x) : base(x) { }

        override
        public double solve()
        {
            // TODO: Throw an error if x.solve() < 0
            return Math.Pow(x.solve(), 0.5);
        }
    }
}
