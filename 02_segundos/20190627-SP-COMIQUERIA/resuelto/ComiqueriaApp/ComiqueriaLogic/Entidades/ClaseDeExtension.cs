using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComiqueriaLogic
{
    //17:30 - para 18:49 Termine hasta el putno 7 inclusive
    //19:00 volvi , termine 19:17 pero no funciona ...
    // 19:37 con testing, pero no actualiza (buscar sobre los eventos)...
    // volvi 20:00 
    public static class ClaseDeExtension
    {
        public static string FormatearPrecio(this double numero)
        {
            return string.Format("${0:#,###.00}",numero);
        }
    }
}
