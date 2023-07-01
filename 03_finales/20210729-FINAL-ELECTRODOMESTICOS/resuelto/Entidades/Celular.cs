using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Celular : Producto
    {
        private bool enOferta;
        private int megaPixelesCamara;


        public override string Garantia
        {
            get
            {
                if(this.Marca == "Noblex")
                {
                    return "Garantia de 12 meses";
                }
                else if(this.MegaPixelesCamara > 12)
                {
                    return "Garantia de 24 meses";
                }
                //else
                return "Garantia de 48 meses";
            }
        }

        public bool EnOferta { get => enOferta; set => enOferta = value; }
        public int MegaPixelesCamara { get => megaPixelesCamara; set => megaPixelesCamara = value; }

        public Celular()
        {

        }

        public Celular(string mod, float precio, string marca, int mpx, bool enOferta)
            :base(mod,precio,marca)
        {
            this.megaPixelesCamara = mpx;
            this.enOferta = enOferta;
        }

        public override string ToString()
        {
            return $"Telefono Celular{Environment.NewLine}{base.ToString()} - Megapíxeles: {this.MegaPixelesCamara}{Environment.NewLine}";
        }

    }
}
