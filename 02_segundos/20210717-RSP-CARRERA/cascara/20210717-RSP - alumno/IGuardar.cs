using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20210717_RSP___alumno
{
    public interface IGuardar<T> where T : class, new()
    {
        void Guardar(T tipo);
    }
}
