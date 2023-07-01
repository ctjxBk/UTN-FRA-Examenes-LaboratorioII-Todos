using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class SinClientesException : Exception
    {
        public SinClientesException()
        {

        }

        public SinClientesException(string mensaje)
            : base (mensaje)
        {

        }

        public SinClientesException(string mensaje, Exception inner)
            : base(mensaje, inner)  
        {

        }
    }
}
