using System;
using System.Text;

namespace Entidades
{
    //20:50 - 21:30 corto para cenar
    //23:10 -
    public abstract class Ingrediente
    {
        private int cantidad;
        private string descripcion;

        public int Cantidad
        {
            get
            {
                return this.cantidad;
            }
        }

        public abstract string Proceso { get; }
        public abstract string UnidadDeMedida { get; }

        public Ingrediente(string descripcion, int cantidad)
        {
            this.descripcion = descripcion;
            this.cantidad = cantidad;
        }

        public virtual string Informacion()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(String.Format("{0} en una cantidad de {1}", this.descripcion, this.UnidadDeMedida));
            sb.AppendLine($"Procesar: {this.Proceso}");
            return sb.ToString();
        }
        
    }
}
