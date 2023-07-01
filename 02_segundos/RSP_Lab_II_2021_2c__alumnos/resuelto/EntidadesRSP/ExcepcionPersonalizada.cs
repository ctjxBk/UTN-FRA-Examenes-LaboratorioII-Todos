using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesRSP
{
    public class ExcepcionPersonalizada : Exception
    {
        public ExcepcionPersonalizada()
        {
        }

        public ExcepcionPersonalizada(string message) : base(message)
        {
        }

        public ExcepcionPersonalizada(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
