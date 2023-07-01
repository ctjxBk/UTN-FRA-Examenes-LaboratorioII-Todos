using System;
using System.Runtime.Serialization;

namespace Entidades
{
    [Serializable]
    public class ExcepcionPersonalizada : Exception
    {
        public ExcepcionPersonalizada(string message) : base(message)
        {
        }
    }
}