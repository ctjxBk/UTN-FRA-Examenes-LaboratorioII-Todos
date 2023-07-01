using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public interface IMantenerDatos<T,V>
        where T : class, new()
        where V : class, new()
    {
        void Guardar(T item, string path);
        V Leer(string path);
    }
}
