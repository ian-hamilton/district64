using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace District64.District64Wcf.Domain.Exceptions
{
    /// <summary>
    /// Exception thrown during any Enumerator 
    /// Code/Type conversions
    /// </summary>
    public class EnumConvertException : Exception
    {
        public EnumConvertException() : base() { }

        public EnumConvertException(string message) : base(message) { }

        public EnumConvertException(string message, Exception inner) : base(message, inner) { }
    }
}
