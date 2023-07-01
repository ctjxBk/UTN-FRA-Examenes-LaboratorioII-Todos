using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public interface IMetodosArchivos<T>
    {
        string GenerarRutacompleta { get; }

        bool ExisteArchivo(string nombreArchivo);
        void Guardar(string archivo, T objeto);
        void Leer(string archivo,out T objeto);
    }
}
