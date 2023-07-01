using System;
using System.Runtime.Serialization;

namespace CoreLibraries
{
    [Serializable]
    public class NoNecesitaDesempateException : Exception
    {
        public NoNecesitaDesempateException() : base("Votación no empatada.")
        {
        }
    }
}