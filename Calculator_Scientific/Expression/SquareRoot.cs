using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exceptions;

namespace ExpressionClass
{
    public class SquareRoot : UnaryExpression
    {
        public SquareRoot (Expression x) : base(x) { }

        override
        public double solve()
        {
            if (x.solve() < 0)
            {
                throw new NegativeRootException("Bilangan negatif tidak bisa diakar.");
            }
            else
            {
                return Math.Pow(x.solve(), 0.5);
            }
        }
    }
}
