using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class NoExisteFileException : Exception
    {
        public NoExisteFileException(string message):base(message)
        {

        }
    }
}
