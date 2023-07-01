using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class ExcepcionPersonalizada : Exception
    {
        public ExcepcionPersonalizada(string mensaje)
            : base(mensaje)
        {

        }
    }
}
