using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Rucula : Ingrediente
    {
           public override string Proceso
        {
            get
            {
                return "cortar";
            }
        }
        public override string UnidadDeMedida
        {
            get
            {
                return "hojas";
            }
        }

        public Rucula(string descripcion, int cantidad) : base(descripcion, cantidad)
        { }

    }
}
