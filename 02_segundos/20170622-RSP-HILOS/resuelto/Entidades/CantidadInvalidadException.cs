using System;
using System.Runtime.Serialization;

namespace Entidades
{
    [Serializable]
    internal class CantidadInvalidadException : Exception
    {
        public CantidadInvalidadException()
        {
        }

        public CantidadInvalidadException(string message) : base(message)
        {
        }

        //public CantidadInvalidadException(string message, Exception innerException) : base(message, innerException)
        //{
        //}

        //protected CantidadInvalidadException(SerializationInfo info, StreamingContext context) : base(info, context)
        //{
        //}
    }
}