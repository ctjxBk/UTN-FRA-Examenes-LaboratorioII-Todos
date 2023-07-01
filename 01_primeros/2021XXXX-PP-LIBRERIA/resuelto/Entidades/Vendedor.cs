using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Entidades
{
    public class Vendedor
    {
        private string nombre;
        private List<Publicacion> ventas;

        public static string ObtenerInformeDeVentas(Vendedor vendedor)
        {
            float ganancia = 0;
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(vendedor.nombre);
            foreach(Publicacion publicacion in vendedor.ventas)
            {
                sb.AppendLine("--------------------------------------");
                sb.AppendLine(publicacion.ObtenerInformacion());
                ganancia += publicacion.Importe;
            }

            sb.AppendLine($"{Environment.NewLine}Ganancia Total: ${ganancia}");
            
            return sb.ToString();
        }

        public static bool operator +(Vendedor vendedor, Publicacion publicacion)
        {
            if(vendedor is not null && publicacion is not null)
            {
                if (publicacion.HayStock)
                {
                    publicacion.Stock--;
                    vendedor.ventas.Add(publicacion);
                    return true;
                }
            }
            return false;
        }

        private Vendedor()
        {
            this.ventas = new List<Publicacion>();
        }

        public Vendedor(string nombre)
            :this()
        {
            this.nombre = nombre;
        }
    }
}
