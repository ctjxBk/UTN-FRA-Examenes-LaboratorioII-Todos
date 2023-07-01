using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Televisor : Producto
    {
        private int pulgadas;

        public Televisor(string marca, string mod, int pulgadas, float precio)
            :base(mod,precio,marca)
        {
            this.pulgadas = pulgadas;
        }
        public override string Garantia
        {
            get
            {
                if(this.pulgadas > 40)
                {
                    return "Garantía de 48 meses";
                }
                return "Garantía de 24 meses";
            }
        }

        public override string ToString()
        {
            return $"Televisor Smart TV de {this.pulgadas}{Environment.NewLine}{base.ToString()}{Environment.NewLine}";
        }
    }
}
