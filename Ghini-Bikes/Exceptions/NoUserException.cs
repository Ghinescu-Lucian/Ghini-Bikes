using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ghini_Bikes.Exceptions
{
    public class NoUserException : Exception
    {
        public NoUserException()
        {

        }
        public NoUserException(string message) : base(message)
        {

        }

        public NoUserException(string message, Exception inner) : base(message, inner)
        {

        }
    }
}
