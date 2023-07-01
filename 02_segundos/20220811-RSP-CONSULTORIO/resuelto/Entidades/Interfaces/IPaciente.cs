using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Interfaces
{
    public interface IPaciente
    {
        bool EstaAtendido { get; }
        string Identificador { get; set; }

        void Anunciarse();
        void Atender();

    }
}
