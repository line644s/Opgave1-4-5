using System;
using System.Collections.Generic;
using System.Text;

namespace ModelLib.Exceptions
{
    public class ExceptionTooBig : Exception
    {
        public ExceptionTooBig(string message): base(message)
        {
            
        }
    }
}
