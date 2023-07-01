using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Arbusto : Planta
    {

        public override bool TieneFlores
        {
            get
            {
                return false;
            }
        }

        public override bool TieneFruto
        {
            get
            {
                return false;
            }
        }

        public Arbusto(string nombre, int tamanio) : base(nombre, tamanio)
        {

        }

    }
}
