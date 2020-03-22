using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions
{
    public class ZeroException : System.Exception
    {
        public ZeroException(string m) : base(m) { }
    }

    public class NegativeRootException : System.Exception
    {
        public NegativeRootException(string m) : base(m) { }
    }
        
}
