using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    //21:15 - 22:00
    public abstract class Publicacion
    {
        protected float importe;
        protected string nombre;
        protected int stock;

        protected abstract bool EsColor { get; }

        public virtual bool HayStock
        {
            get { return this.stock > 0 && this.importe > 0; }
        }

        public float Importe
        {
            get { return this.importe; }
        }

        public int Stock
        {
            get
            {
                return this.stock;
            }
            set
            {
                //porque lo puedo dejar en CERO
                if(value > -1)
                {
                    this.stock = value;
                }
            }
        }

        public string ObtenerInformacion()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Nombre: {this.nombre}");
            sb.AppendLine($"Stock: {this.stock}");
            sb.AppendFormat("Es color: {0}{1}", this.EsColor ? "SI" : "NO", Environment.NewLine);
            sb.AppendLine($"Valor: {this.importe}");

            return sb.ToString();
        }

        public Publicacion(string nombre)
        {
            this.nombre = nombre;
        }

        public Publicacion(string nombre, int stock)
            : this (nombre)
        {
            this.stock = stock;
        }

        public Publicacion(string nombre, int stock, float importe)
            : this(nombre, stock)
        {
            this.importe = importe;
        }

        public override string ToString()
        {
            return $"{this.nombre}";
        }

    }
}
