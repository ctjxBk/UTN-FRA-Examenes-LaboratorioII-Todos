using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Automovil : Vehiculo
    {
        private ConsoleColor color;
        private static int valorHora;

        static Automovil()
        {
            Automovil.valorHora = 50;
        }

        public Automovil(string patente, ConsoleColor color) 
            : base(patente)
        {
            this.color = color;
        }

        public Automovil(string patente, ConsoleColor color, int valorHora)
            : this(patente, color)
        {
            Automovil.valorHora = valorHora;
        }

        public override string ConsultarDatos()
        {
            return $"{base.ToString()}. Color: {this.color}";
        }

        public override bool Equals(object obj)
        {
            return obj is Automovil;
        }

        public override string ImprimirTicket()
        {
            StringBuilder sb = new StringBuilder();
            double tiempo = (DateTime.Now - ingreso).Hours;
            double estadia = Automovil.valorHora * tiempo;
            sb.AppendLine($"{base.ImprimirTicket()}. Costo de estadia: {estadia}");
            return sb.ToString();
        }
    }
}
