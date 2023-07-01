using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Extensora
    {
        public static int CalcularDiferenciaEnDias(this DateTime fecha)
        {
            return ((int)(DateTime.Now - fecha).TotalDays);
        }
    }
}
