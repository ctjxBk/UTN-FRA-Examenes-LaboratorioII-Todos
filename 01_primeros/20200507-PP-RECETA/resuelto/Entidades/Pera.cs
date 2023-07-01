using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Pera : Ingrediente
    {
        private string tipo;

        public override string Proceso
        {
            get
            {
                return "cubitar";
            }
        }
        public override string UnidadDeMedida
        {
            get
            {
                return "unidades";
            }
        }

        public Pera(string descripcion, int cantidad, string tipo) :base(descripcion, cantidad)
        {
            this.tipo = tipo;
        }

        public override string Informacion()
        {
            return $"{base.Informacion()}Tipo: {this.tipo} {Environment.NewLine}";
        }

    }
}
