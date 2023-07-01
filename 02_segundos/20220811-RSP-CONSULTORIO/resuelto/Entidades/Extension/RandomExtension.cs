using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Extension
{
    //9.	Extenderá la clase Random la cual retornará un valor 
    //    de Id aleatorio desde 1 hasta el valor recibido por parámetro.
    public static class RandomExtension
    {
        public static int NumeroRandom(this Random random, int maximo)
        {
            return random.Next(1,maximo);
        }
    }
}
