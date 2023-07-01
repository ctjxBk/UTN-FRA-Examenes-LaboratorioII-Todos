using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class ExcepcionPersonalizada :Exception
    {
        public ExcepcionPersonalizada() : base()
        {

        }
        public ExcepcionPersonalizada(string mensaje) : base(mensaje)
        {

        }
        public ExcepcionPersonalizada(string mensaje, Exception innerException) : base(mensaje, innerException)
        {

        }
    }
}
