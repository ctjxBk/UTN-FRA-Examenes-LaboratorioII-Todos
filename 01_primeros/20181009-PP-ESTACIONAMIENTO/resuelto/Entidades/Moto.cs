using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Moto : Vehiculo
    {
        private int cilindrada;
        private short ruedas;
        private static int valorHora;

        public override string ConsultarDatos()
        {
            return $"{base.ToString()}. Cilindrada: {this.cilindrada} - Ruedas: {this.ruedas}{Environment.NewLine}";
        }

        public override bool Equals(object obj)
        {
            return obj is Moto;
        }

        public override string ImprimirTicket()
        {
            StringBuilder sb = new StringBuilder();
            double tiempo = (DateTime.Now - ingreso).Hours;
            double estadia = Moto.valorHora * tiempo;
            sb.AppendLine($"{base.ImprimirTicket()}. Costo de estadia: {estadia}");
            return sb.ToString();
        }

        static Moto()
        {
            Moto.valorHora = 30;
        }

        public Moto(string patente, int cilindrada) 
            : this(patente, cilindrada, 2)
        {
        }

        public Moto(string patente, int cilindrada, short ruedas)
            : base(patente)
        {
            this.cilindrada = cilindrada;
            this.ruedas = ruedas;
        }

        public Moto(string patente, int cilindrada, short ruedas, int valorHora)
            : this(patente, cilindrada, ruedas)
        {
            Moto.valorHora = valorHora; 
        }

    }
}
