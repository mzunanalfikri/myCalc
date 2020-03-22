using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionClass
{
    public class Modulus : BinaryExpression
    {
        public Modulus(Expression x, Expression y) : base(x, y) { }

        override
        public double solve()
        {
            //return x.solve() % y.solve();
            double result = x.solve() % y.solve();
            if(result < 0){
                result += y.solve();
            }
            return result;
        }
    }
}
