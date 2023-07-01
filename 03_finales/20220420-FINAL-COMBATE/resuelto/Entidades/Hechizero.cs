using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Hechizero : Personaje
    {
        public Hechizero()
            : base()
        {

        }

        public Hechizero(decimal id, string nombre)
            : this(id, nombre,1)
        {

        }

        public Hechizero(decimal id, string nombre, short nivel)
            : base(id, nombre, nivel)
        {

        }

        public override void AplicarBeneficiosDeClase()
        {
            this.puntosDePoder = (int)(((double)this.puntosDePoder) * 1.1);
        }
    }
}
