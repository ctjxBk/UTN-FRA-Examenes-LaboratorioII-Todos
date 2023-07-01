using System;

namespace BibliotecaDeClases
{
    public class DatoErroneoException : Exception
    {
        public DatoErroneoException(string mensaje) : base(mensaje)
        {

        }
    }
}
