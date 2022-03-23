using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class EmptyCartException : Exception
    {
        public EmptyCartException()
        {

        }

        public EmptyCartException(string message) : base(message)
        {

        }

        public EmptyCartException(string message, Exception inner) : base(message, inner)
        {

        }
    }
   
}
