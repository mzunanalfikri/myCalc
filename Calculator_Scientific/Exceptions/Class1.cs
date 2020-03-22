using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions
{
    public class ZeroException : Exception
    {
        public ZeroException(string m) : base(m) { }
    }

    public class NegativeRootException : Exception
    {
        public NegativeRootException(string m) : base(m) { }
    }
        
    public class InvalidOperation : Exception
    {
        public InvalidOperation(string m) : base(m) { }
    }
}
