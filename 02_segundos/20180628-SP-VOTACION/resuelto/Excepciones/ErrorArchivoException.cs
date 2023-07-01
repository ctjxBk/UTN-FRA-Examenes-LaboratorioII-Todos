using System;

namespace Excepciones
{
    public class ErrorArchivoException : Exception
    {
        public ErrorArchivoException(string mensaje) : base(mensaje)
        {

        }

        public ErrorArchivoException(string mensaje, Exception innerException) : base(mensaje, innerException)
        {

        }
    }
}
