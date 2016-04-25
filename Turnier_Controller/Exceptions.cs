using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turnier_Controller
{
    class InvalidInputException : Exception
    {
        public InvalidInputException() { }

        public InvalidInputException(string message) : base(message) { }
    }

    class NoSelectedItemException : Exception
    {
        public NoSelectedItemException() { }

        public NoSelectedItemException(string message) : base(message) { }
    }
}
