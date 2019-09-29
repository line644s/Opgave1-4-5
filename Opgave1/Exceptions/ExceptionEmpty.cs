using System;
using System.Collections.Generic;
using System.Text;

namespace ModelLib.Exceptions
{
    public class ExceptionEmpty : Exception
    {
        public ExceptionEmpty(string message) : base(message)
        {
            
        }
    }
}
