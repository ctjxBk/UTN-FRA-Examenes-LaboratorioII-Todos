using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public interface PersistirDatos
    {
        void Guardar(string mensaje);
        List<string> Leer();
    }
}
