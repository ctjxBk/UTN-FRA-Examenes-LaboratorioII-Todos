using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Receta
    {
        public enum Tipo { Clasica, Especial}
        private int capacidadDelContenedor;
        private List<Ingrediente> ingredientes;
        private static Tipo preparacion;

        private Receta()
        {
            this.ingredientes = new List<Ingrediente>();
        }

        static Receta()
        {
            Receta.TipoDePreparacion = Tipo.Clasica;
        }

        public Receta(int capacidad) : this()
        {
            this.capacidadDelContenedor = capacidad;
        }

        public static Tipo TipoDePreparacion
        {
            set
            {
                Receta.preparacion = value;
            }
        }

        private int CapacidadLibre()
        {
            int cantidadLibre = 0;
            foreach(Ingrediente ingrediente in this.ingredientes)
            {
                cantidadLibre += ingrediente.Cantidad;
            }
            return cantidadLibre;
        }

        private int CapacidadLibre(Ingrediente planta)
        {
            return this.CapacidadLibre() + planta.Cantidad;
        }

        public static bool operator +(Receta receta, Ingrediente ingrediente)
        {
            if(receta is not null && ingrediente is not null)
            {
                if (receta.capacidadDelContenedor >= receta.CapacidadLibre(ingrediente))
                {
                    receta.ingredientes.Add(ingrediente);
                    return true;
                }
            }

            return false;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Receta {Receta.preparacion}");
            sb.AppendLine($"Capacidad libre: {this.CapacidadLibre()}");
            sb.AppendLine($"Capacidad total: {this.capacidadDelContenedor}");
            foreach(Ingrediente ingrediente in this.ingredientes)
            {
                sb.AppendLine(ingrediente.Informacion());
            }
            return sb.ToString();
        }


    }
}
