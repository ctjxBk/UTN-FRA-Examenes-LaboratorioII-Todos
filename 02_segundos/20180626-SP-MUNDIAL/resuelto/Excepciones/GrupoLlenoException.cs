using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class GrupoLlenoException : Exception
    {
        public GrupoLlenoException(string mensaje)
            :base(mensaje)
        {

        }
    }
}
