using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Guerrero : Personaje
    {
        public Guerrero()
            :base()
        {

        }

        public Guerrero(decimal id, string nombre)
            : this(id, nombre, 1)
        {

        }

        public Guerrero(decimal id, string nombre, short nivel)
            : base(id,nombre,nivel)
        {

        }


        public override void AplicarBeneficiosDeClase()
        {
            this.puntosDeDefensa = (int)(((double)this.puntosDeDefensa) * 1.1);
        }
    }
}
