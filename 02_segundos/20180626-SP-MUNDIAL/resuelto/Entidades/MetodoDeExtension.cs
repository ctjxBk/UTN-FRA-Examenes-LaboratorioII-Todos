using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class MetodoDeExtension
    {
        public static string FormatoTabla(this string cadena, int cantidad)
        {
            string str = "{0,"+cantidad+"}";
            return String.Format(str, cadena);
        }
    }
}
