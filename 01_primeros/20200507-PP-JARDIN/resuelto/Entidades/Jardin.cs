using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public enum Tipo { Terrozo, Arenozo }
    public class Jardin
    {
        private int espacioTotal;
        private List<Planta> plantas;
        private static Tipo suelo;

        static Jardin()
        {
            Jardin.suelo = Tipo.Terrozo;
        }

        private Jardin()
        {
            this.plantas = new List<Planta>();
        }

        public Jardin(int espacioTotal) : this()
        {
            this.espacioTotal = espacioTotal;
        }

        public static bool operator +(Jardin jardin, Planta planta)
        {
            if(jardin is not null && planta is not null  && jardin.espacioTotal >= jardin.EspacioOcupado(planta))
            {
                jardin.plantas.Add(planta);
                return true;
            }
            return false;
        }
        private int EspacioOcupado()
        {
            int espacio = 0;
            foreach(Planta planta in this.plantas)
            {
                espacio += planta.Tamanio;
            }
            return espacio;
        }

        private int EspacioOcupado(Planta planta)
        {
            return this.EspacioOcupado() + planta.Tamanio;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Composición del Jardín: {Jardin.suelo}");
            sb.AppendLine($"Espacio ocupado {this.EspacioOcupado()} de {this.espacioTotal}");
            sb.AppendLine($"############################");
            foreach(Planta planta in this.plantas)
            {
                sb.AppendLine($"{planta.ResumenDeDatos()}");
            }
            return sb.ToString();
        }

    }
}
