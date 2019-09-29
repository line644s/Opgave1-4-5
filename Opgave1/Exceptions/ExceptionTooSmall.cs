using System;
using System.Collections.Generic;
using System.Text;

namespace ModelLib.Exceptions
{
    public class ExceptionTooSmall : Exception
    {
        public ExceptionTooSmall(string message): base(message)
        {
            
        }
    }
}
