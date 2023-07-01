using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Banano : Planta
    {
        private string codigo;

        public override bool TieneFlores
        {
            get
            {
                return true;
            }
        }

        public override bool TieneFruto
        {
            get
            {
                return true;
            }
        }

        public Banano(string nombre, int tamanio, string codigo) : base(nombre, tamanio)
        {
            this.codigo = codigo;
        }


        public override string ResumenDeDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{base.ResumenDeDatos()} Codigo Internacional: {this.codigo}");
            return sb.ToString();
        }
    }
}
