using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    //hora 18:45
    public abstract class Planta
    {
        private string nombre;
        private int tamanio;

        public Planta(string nombre, int tamanio)
        {
            this.nombre = nombre;
            this.tamanio = tamanio;
        }

        public virtual string ResumenDeDatos()
        {
            StringBuilder sb = new StringBuilder(String.Format($"{this.nombre} tiene un tamaño de {this.Tamanio}\n"));
            sb.AppendFormat("Tiene flores {0}\n", (this.TieneFlores) ? "SI" : "NO");
            sb.AppendFormat("Tiene fruto {0}\n", (this.TieneFruto) ? "SI" : "NO");
            return sb.ToString();
        }

        public int Tamanio
        {
            get { return this.tamanio; }
        }
        public abstract bool TieneFlores { get; }
        public abstract bool TieneFruto { get; }

        




    }
}
