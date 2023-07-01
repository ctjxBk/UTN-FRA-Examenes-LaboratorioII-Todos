using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class ListaExtended
    {
        public static string InfoDeLaLista(this List<Producto> lista)
        {
            StringBuilder sb = new StringBuilder();

            foreach (Producto p in lista)
            {
                sb.AppendLine(p.ToString());
            }

            return sb.ToString();
        }
    }
}
