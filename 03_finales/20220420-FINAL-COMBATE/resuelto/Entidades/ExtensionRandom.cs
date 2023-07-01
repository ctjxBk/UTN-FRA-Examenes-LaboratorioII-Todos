using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class ExtensionRandom
    {
        private static Random random;
        static ExtensionRandom()
        {
            random = new Random();
        }
        public static LadosMoneda TirarUnaModeda(this Random random)
        {
            return (LadosMoneda)random.Next(1, 3);
        }
    }
}
