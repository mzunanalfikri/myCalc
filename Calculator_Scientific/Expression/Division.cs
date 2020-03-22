using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exceptions;

namespace ExpressionClass
{
    public class Division : BinaryExpression
    {
        public Division (Expression x, Expression y) : base(x, y) { }

        override
        public double solve()
        {
            if (y.solve() == 0)
            {
                throw new ZeroException("Tidak bisa membagi dengan 0.");
            }
            else
            {
                return x.solve() / y.solve();
            }
        }
    }
}
