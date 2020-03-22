using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exceptions;

namespace ExpressionClass
{
    public abstract class Expression
    {
        public Expression()
        {

        }

        public abstract double solve();
    }
}
