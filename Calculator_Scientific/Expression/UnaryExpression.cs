using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionClass
{
    public abstract class UnaryExpression : Expression
    {
        protected Expression x;

        public UnaryExpression(Expression x)
        {
            this.x = x;
        }

        override
        abstract public double solve();
    }
}
