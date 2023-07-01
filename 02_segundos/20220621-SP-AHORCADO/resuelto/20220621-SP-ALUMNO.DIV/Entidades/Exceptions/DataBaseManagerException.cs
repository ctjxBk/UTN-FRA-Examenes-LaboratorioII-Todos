using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Exceptions
{
    public class DataBaseManagerException : Exception
    {
        public DataBaseManagerException(string mensage)
            : base(mensage)
        {

        }

        public DataBaseManagerException(string message, Exception innerException)
            : base(message, innerException)
        {

        }
    }
}
