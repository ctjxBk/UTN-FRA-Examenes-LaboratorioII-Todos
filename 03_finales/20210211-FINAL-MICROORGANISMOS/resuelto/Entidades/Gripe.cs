using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Gripe : Microorganismo
    {
        public Gripe(string nombre, ETipo tipo, EContagiosidad contagiosidad) : base(nombre, tipo, contagiosidad)
        {
        }

        public override long IndiceDeContagios
        {
            get
            {
                this.contador *= 2;
                return this.contador;
            }
        }
    }
}
