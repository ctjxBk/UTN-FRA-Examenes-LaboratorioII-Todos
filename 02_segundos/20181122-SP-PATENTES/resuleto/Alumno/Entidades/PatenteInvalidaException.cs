using System;
using System.Runtime.Serialization;

namespace Entidades
{
    [Serializable]
    public class PatenteInvalidaException : Exception
    {

        public PatenteInvalidaException(string message) : base(message)
        {
        }

        public PatenteInvalidaException(string message, Exception innerException) : base(message, innerException)
        {
        }

    }
}